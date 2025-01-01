using BasyFirstMod.Services.Pranking.Hooks;
using System;
using System.Collections.Generic;
using System.Text;
using Unity.Netcode;

namespace Basy.LethalCompany.Utilities
{
    public static class NetworkHelper
    {
        public static void RegisterNetworker<TNetworkBehaviour>()
            where TNetworkBehaviour : NetworkBehaviour
        {
            var prefab = NetworkPrefabHelper.CreateNetworkPrefab("NetworkHelper_" + Guid.NewGuid().ToString());
            prefab.AddComponent<TNetworkBehaviour>();
            On.OnGameStart += (s, a) =>
            {
                if (RoundManager.Instance.IsHost)
                {
                    var intance = UnityEngine.Object.Instantiate(prefab);
                    intance.GetComponent<NetworkObject>().Spawn();
                }
            };
        }
    }
}
