using Basy.LethalCompany.Utilities.Helpers.Networks;
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

namespace Basy.LethalCompany.Utilities.Helpers.Audios
{
    public class AudioHelper
    {
        public async Task PlayAtPlayerLocallyAsync(ulong playerId, AudioClip audioClip, float pitch = 1)
        {
            BLUtils.Logger.LogInfo($"PlayAtPlayerLocallyAsync '{audioClip.name}' at player '{playerId}' with pitch '{pitch}'");
            var player = BLUtils.Players.GetPlayer(playerId);
            var audioSource = player.gameObject.AddComponent<AudioSource>();
            audioSource.maxDistance = 15;
            audioSource.pitch = pitch;
            audioSource.rolloffMode = AudioRolloffMode.Linear;
            audioSource.spatialBlend = 1;
            audioSource.PlayOneShot(audioClip, 1f);
            while (audioSource.isPlaying)
            {
                await Task.Delay(50);
            }
            GameObject.Destroy(audioSource);
        }

        public void PlayAtPlayerAsync(ulong playerId, string audioClip, float pitch = 1)
        {
            BLUtils.Logger.LogInfo($"PlayAtPlayerAsync '{audioClip}' at player '{playerId}' with pitch '{pitch}'");

            BasyUtiltsNetworker.Instance.RequestPlayAudioAtPlayerServerRpc(playerId, audioClip, pitch);
        }
    }
}
