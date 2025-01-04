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
using Basy.LethalCompany.Utilities.Helpers.Players;
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
        public void RequestPrankServerRpc(ulong playerId, string prankId)
        {
            BasyLogger.Instance.LogInfo($"{nameof(RequestPrankServerRpc)} playerId: {playerId} prankId: {prankId}");
            var networker = PrankNetworker.Instance.GetComponent<PrankNetworker>();
            networker.RecievePrankClientRpc(playerId, prankId);
            BasyLogger.Instance.LogInfo($"{nameof(RequestPrankServerRpc)} End");
        }

        [ClientRpc]
        public void RecievePrankClientRpc(ulong playerId, string prankId)
        {
            BasyLogger.Instance.LogInfo($"{nameof(RecievePrankClientRpc)} playerId: {playerId} prankId: {prankId}");
            if (BLUtils.Players.GetLocalPlayerId() == playerId)
            {
                BasyLogger.Instance.LogInfo($"{BLUtils.Players.GetLocalPlayer().playerClientId} targeted by prank");
                PrankClient.Instance.RecievePrank(prankId);
            }
            BasyLogger.Instance.LogInfo($"{nameof(RecievePrankClientRpc)} End");
        }
    }
}