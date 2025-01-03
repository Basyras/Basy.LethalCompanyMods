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
using Newtonsoft.Json.Linq;

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
                var audio = AssetsHelper.GetAsset<AudioClip>(audioId);
                SoundHelper.PlayAtPlayerLocally(audio);
            }
        }

        [ServerRpc(RequireOwnership = false)]
        public void RequestGiveItemServerRpc(int playerId, int itemId)
        {
            LoggerHelper.LogError($"Giving item '{itemId}' to player '{playerId}'");

            var networker = BasyUtiltsNetworker.Instance.GetComponent<BasyUtiltsNetworker>();
            var player = PlayerHelper.GetPlayer(playerId);
            GameObject newItem = UnityEngine.Object.Instantiate(StartOfRound.Instance.allItemsList.itemsList[itemId].spawnPrefab, player.transform.position, Quaternion.identity, StartOfRound.Instance.propsContainer);
            newItem.GetComponent<GrabbableObject>().fallTime = 0f;
            newItem.GetComponent<NetworkObject>().Spawn();
        }
    }
}