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
using BasyFirstMod.Services.Logging;
using Basy.LethalCompany.Utilities;

namespace BasyFirstMod.Services.Pranking
{
    public class PrankNetworker : NetworkBehaviour
    {
        public static PrankNetworker Instance { get; private set; }
        private void Awake()
        {
            Instance = this;
            BasyLogger.Instance.LogInfo($"{nameof(PrankNetworker)} Awake called");
        }

        private void Start()
        {
            BasyLogger.Instance.LogInfo($"{nameof(PrankNetworker)} Start called");
        }

        public override void OnNetworkSpawn()
        {
            BasyLogger.Instance.LogInfo($"{nameof(PrankNetworker)} OnNetworkSpawn called");
            base.OnNetworkSpawn();
        }

        [ServerRpc(RequireOwnership = false)]
        public void RequestPrankServerRpc(int playerId, string prankId)
        {
            BasyLogger.Instance.LogInfo($"{nameof(RequestPrankServerRpc)} Start");
            BasyLogger.Instance.LogInfo($"{nameof(RequestPrankServerRpc)} IsSpawned: {IsSpawned}");
            BasyLogger.Instance.LogInfo($"{nameof(RequestPrankServerRpc)} IsServer: {IsServer}");
            BasyLogger.Instance.LogInfo($"{nameof(RequestPrankServerRpc)} IsHost: {IsHost}");
            var networker = PrankNetworker.Instance.GetComponent<PrankNetworker>();

            networker.RecievePrankClientRpc(playerId, prankId);

            BasyLogger.Instance.LogInfo($"{nameof(RequestPrankServerRpc)} End");
        }

        [ClientRpc]
        public void RecievePrankClientRpc(int playerId, string prankId)
        {
            BasyLogger.Instance.LogInfo($"{nameof(RecievePrankClientRpc)} Start");
            if (playerId == -1 || PlayerHelper.GetLocalPlayer().playerClientId == (ulong)playerId)
            {
                BasyLogger.Instance.LogInfo($"{PlayerHelper.GetLocalPlayer().playerClientId} targeted by prank");
                PrankClient.Instance.RecievePrank(prankId);
            }
            BasyLogger.Instance.LogInfo($"{nameof(RecievePrankClientRpc)} End");
        }
    }
}