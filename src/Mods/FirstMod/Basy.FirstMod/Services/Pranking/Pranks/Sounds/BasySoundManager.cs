using BasyFirstMod.Services.Logging;
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

namespace BasyFirstMod.Services.Pranking.Pranks.Sounds
{
    public class BasySoundManager
    {
        public static BasySoundManager Instance { get; } = new BasySoundManager();

        async Task<AudioClip> LoadAudioAsync(int soundId)
        {
            var path = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, $"Resources\\scarySound{soundId}.wav");

            AudioClip clip = null;
            using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.WAV))
            {
                uwr.SendWebRequest();

                // wrap tasks in try/catch, otherwise it'll fail silently
                try
                {
                    while (!uwr.isDone) await Task.Delay(5);

                    if (uwr.result is UnityWebRequest.Result.ConnectionError
                        || uwr.result is UnityWebRequest.Result.DataProcessingError
                        || uwr.result is UnityWebRequest.Result.ProtocolError
                        )
                    {
                        BasyLogger.Instance.LogError($"{uwr.error}");
                    }
                    else
                    {
                        clip = DownloadHandlerAudioClip.GetContent(uwr);
                    }
                }
                catch (Exception err)
                {
                    BasyLogger.Instance.LogError($"{err.Message}, {err.StackTrace}");
                }
            }

            return clip;
        }

        public async void PlaySoundAsync(int soundId)
        {
            BasyLogger.Instance.LogInfo($"{nameof(BasySoundManager)} {nameof(PlaySoundAsync)} Start");
            int currentPlayerId = (int)StartOfRound.Instance.localPlayerController.playerClientId;
            var currentPlayer = StartOfRound.Instance.localPlayerController;
            var audio = await LoadAudioAsync(soundId);
            currentPlayer.movementAudio.PlayOneShot(audio, 10f);
            BasyLogger.Instance.LogInfo($"{nameof(BasySoundManager)} {nameof(PlaySoundAsync)} End");
        }


    }
}
