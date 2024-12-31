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
using BasyFirstMod.Services.Pranking.Pranks.Sounds;
using GameNetcodeStuff;
using BasyFirstMod.Services.Logging;
using BasyFirstMod.Helpers;

namespace BasyFirstMod.Services.Pranking
{
    public class PrankNetworker : NetworkBehaviour
    {
        private void Awake()
        {
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
        public void RequestPrankServerRpc(int playerId, string prankId, ServerRpcParams serverRpcParams = default)
        {
            BasyLogger.Instance.LogInfo($"{nameof(RequestPrankServerRpc)} Start");
            BasyLogger.Instance.LogInfo($"{nameof(RequestPrankServerRpc)} IsSpawned: {IsSpawned}");
            BasyLogger.Instance.LogInfo($"{nameof(RequestPrankServerRpc)} IsServer: {IsServer}");
            BasyLogger.Instance.LogInfo($"{nameof(RequestPrankServerRpc)} IsHost: {IsHost}");

            if (IsServer is false)
            {
                BasyLogger.Instance.LogInfo($"{nameof(RequestPrankServerRpc)} Returns early, not server");
                return;
            }

            PlayerControllerB[] playersToPrank;

            if (playerId is -1)
            {
                playersToPrank = StartOfRound.Instance.allPlayerScripts.ToArray();
            }
            else
            {
                playersToPrank = new PlayerControllerB[] { StartOfRound.Instance.allPlayerScripts[playerId] };
            }

            ClientRpcParams clientRpcParams = new ClientRpcParams
            {
                Send = new ClientRpcSendParams
                {
                    TargetClientIds = NetworkManager.ConnectedClientsIds
                }
            };
            //foreach (PlayerControllerB playerToPrank in playersToPrank)
            //{
            //    var networker = playerToPrank.gameObject.GetComponent<PrankNetworker>();
            //    networker.RecievePrankClientRpc(prankId, clientRpcParams);
            //}

            var networker = PrankNetworkObject.Instance.GetComponent<PrankNetworker>();
            networker.RecievePrankClientRpc(prankId, clientRpcParams);

            BasyLogger.Instance.LogInfo($"{nameof(RequestPrankServerRpc)} End");
        }

        [ClientRpc]
        public void RecievePrankClientRpc(string prankId, ClientRpcParams clientRpcParams)
        {
            BasyLogger.Instance.LogInfo($"{nameof(RecievePrankClientRpc)} Start");
            var localPlayer = PlayerHelper.GetLocalPlayer();
            var isLocaLPlayer = localPlayer.gameObject == this.gameObject;
            //BasyLogger.Instance.LogInfo($"{nameof(RecievePrankClientRpc)} isLocaLPlayer: {isLocaLPlayer}");
            if (isLocaLPlayer is false)
            {
                BasyLogger.Instance.LogInfo($"{nameof(RecievePrankClientRpc)} Not local player. returning");
                return;
            }

            //BasyLogger.Instance.LogInfo($"{nameof(RecievePrankClientRpc)} PlayerId '{localPlayer.playerClientId}' is local.");
            BasyLogger.Instance.LogInfo($"{nameof(RecievePrankClientRpc)} local player. executing prank.");

            PrankClient.Instance.RecievePrank(prankId);

            BasyLogger.Instance.LogInfo($"{nameof(RecievePrankClientRpc)} End");
        }
    }
}