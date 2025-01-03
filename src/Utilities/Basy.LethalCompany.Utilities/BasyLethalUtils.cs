using BasyFirstMod.Services.Pranking;
using BasyFirstMod.Services.Pranking.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Netcode;
using UnityEngine;

namespace Basy.LethalCompany.Utilities
{
    public static class BasyLethalUtils
    {
        public static void Register()
        {
            NetworkHelper.RegisterNetworker<BasyUtiltsNetworker>();
            NetCodePatcherHelper.Patch<BasyUtiltsNetworker>();

            On.OnChatSend += (s, a) =>
            {
                var tokens = a.Split(' ');
                if (tokens[0] == "audio")
                {
                    var audioName = tokens[1];
                    var playerId = tokens.Length < 3 ? -1 : int.Parse(tokens[2]);
                    BasyUtiltsNetworker.Instance.RequestPlayAudioServerRpc(playerId, audioName);
                }
            };

            On.OnChatSend += (s, a) =>
            {
                var tokens = a.Split(' ');
                if (tokens[0] == "give")
                {
                    var itemId = tokens.Length < 2 ? 0 : int.Parse(tokens[1]);
                    var playerId = tokens.Length < 3 ? (int)PlayerHelper.GetLocalPlayerId() : int.Parse(tokens[2]);
                    GameObject newItem = UnityEngine.Object.Instantiate(StartOfRound.Instance.allItemsList.itemsList[itemId].spawnPrefab, PlayerHelper.GetLocalPlayer().transform.position, Quaternion.identity, StartOfRound.Instance.propsContainer);
                    newItem.GetComponent<GrabbableObject>().fallTime = 0f;
                    newItem.GetComponent<NetworkObject>().Spawn();
                }
            };
        }
    }
}
