using GameNetcodeStuff;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Basy.LethalCompany.Utilities
{
    public class SoundHelper
    {
        public static async Task<AudioClip> LoadAudioAsync(string path)
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

        public static async Task PlaySoundAsync(AudioClip audioClip)
        {
            var currentPlayer = StartOfRound.Instance.localPlayerController;
            currentPlayer.movementAudio.PlayOneShot(audioClip, 1f);
        }




    }
}
