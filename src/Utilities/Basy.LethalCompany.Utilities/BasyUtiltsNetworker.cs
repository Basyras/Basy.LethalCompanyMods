using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.Audio;
using UnityEngine;
using Unity.Netcode;
using System.Collections;
using UnityEngine.Windows;
using UnityEngine.Networking;
using GameNetcodeStuff;
using Basy.LethalCompany.Utilities;

namespace BasyFirstMod.Services.Pranking
{
    public class BasyUtiltsNetworker : NetworkBehaviour
    {
        public static BasyUtiltsNetworker Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
        }

        [ServerRpc(RequireOwnership = false)]
        public void RequestPlayAudioServerRpc(int playerId, string audioId)
        {
            var networker = BasyUtiltsNetworker.Instance.GetComponent<BasyUtiltsNetworker>();
            networker.RecievePlayAudioClientRpc(playerId, audioId);
        }

        [ClientRpc]
        public void RecievePlayAudioClientRpc(int playerId, string audioId)
        {
            if (playerId == -1 || PlayerHelper.GetLocalPlayer().playerClientId == (ulong)playerId)
            {
                LoggerHelper.LogInfo($"{PlayerHelper.GetLocalPlayer().playerClientId} targeted by audio");
                var audio = AssetsHelper.GetAsset<AudioClip>(audioId);
                SoundHelper.PlayAtPlayerLocally(audio);
            }
        }
    }
}