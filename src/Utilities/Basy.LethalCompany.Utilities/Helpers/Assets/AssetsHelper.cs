using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Basy.LethalCompany.Utilities.Helpers.Assets
{
    public class AssetsHelper
    {
        public T GetAsset<T>(string name) where T : UnityEngine.Object
        {
            var asset = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault(x => x.name == name);
            if (asset is null)
            {
                throw new Exception($"Asset with name '{name}' not found in game assets");

            }

            return asset;
        }

        public T[] GetAssets<T>() where T : UnityEngine.Object
        {
            var assets = Resources.FindObjectsOfTypeAll<T>();
            return assets;
        }

        public async Task<AudioClip> GetAudioFromFileAsync(string path)
        {
            AudioClip clip = null;

            using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.WAV))
            {
                uwr.SendWebRequest();

                while (!uwr.isDone) await Task.Delay(5);

                if (uwr.result is UnityWebRequest.Result.ConnectionError
                    || uwr.result is UnityWebRequest.Result.DataProcessingError
                    || uwr.result is UnityWebRequest.Result.ProtocolError
                    )
                {
                    throw new Exception(uwr.error);
                }
                else
                {
                    clip = DownloadHandlerAudioClip.GetContent(uwr);
                }
            }

            return clip;
        }
    }
}
