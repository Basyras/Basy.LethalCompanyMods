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
using Basy.LethalCompany.Utilities.Helpers.Audios;
using Basy.LethalCompany.Utilities.Helpers.Players;
using LethalLib.Modules;

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
        public void RequestPlayAudioAtPlayerServerRpc(ulong playerId, string audioId, float pitch)
        {
            BLUtils.Logger.LogInfo($"RequestPlayAudioAtPlayerServerRpc playerId: {playerId} audioId: {audioId} pitch: {pitch}");


            var networker = BasyUtiltsNetworker.Instance.GetComponent<BasyUtiltsNetworker>();
            networker.RecievePlayAudioAtPlayerClientRpc(playerId, audioId, pitch);
        }

        [ClientRpc]
        public void RecievePlayAudioAtPlayerClientRpc(ulong playerId, string audioId, float pitch)
        {
            BLUtils.Logger.LogInfo($"RecievePlayAudioAtPlayerClientRpc playerId: {playerId} audioId: {audioId} pitch: {pitch}");

            var audio = BLUtils.Assets.GetAsset<AudioClip>(audioId);
            BLUtils.Coroutines.RunTask(BLUtils.Audio.PlayAtPlayerLocallyAsync((ulong)playerId, audio, pitch));
        }

        [ServerRpc(RequireOwnership = false)]
        public void RequestGiveItemServerRpc(ulong playerId, int itemId)
        {
            BLUtils.Logger.LogInfo($"RequestGiveItemServerRpc playerId: {playerId} itemId: {itemId}");

            var networker = BasyUtiltsNetworker.Instance.GetComponent<BasyUtiltsNetworker>();
            var player = BLUtils.Players.GetPlayer(playerId);
            GameObject newItem = UnityEngine.Object.Instantiate(StartOfRound.Instance.allItemsList.itemsList[itemId].spawnPrefab, player.transform.position, Quaternion.identity, StartOfRound.Instance.propsContainer);
            newItem.GetComponent<GrabbableObject>().fallTime = 0f;
            newItem.GetComponent<NetworkObject>().Spawn();
        }
    }
}