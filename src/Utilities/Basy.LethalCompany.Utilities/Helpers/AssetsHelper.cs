using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Basy.LethalCompany.Utilities
{
    public static class AssetsHelper
    {
        public static T GetAsset<T>(string name) where T : UnityEngine.Object
        {
            var asset = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault(x => x.name == name);
            if (asset is null)
            {
                throw new Exception($"Asset with name '{name}' not found");
            }
            return asset;
        }

        public static T[] GetAssets<T>() where T : UnityEngine.Object
        {
            var assets = Resources.FindObjectsOfTypeAll<T>();
            return assets;
        }

        public static async Task<AudioClip> GetAudioFromFileAsync(string path)
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
