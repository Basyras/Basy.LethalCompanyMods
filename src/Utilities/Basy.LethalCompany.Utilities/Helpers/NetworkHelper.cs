using BasyFirstMod.Services.Pranking.Hooks;
using System;
using System.Collections.Generic;
using System.Text;
using Unity.Netcode;

namespace Basy.LethalCompany.Utilities
{
    public class NetworkHelper
    {
        public void RegisterNetworker<TNetworkBehaviour>()
            where TNetworkBehaviour : NetworkBehaviour
        {
            var networkType = typeof(TNetworkBehaviour);
            var prefab = NetworkPrefabHelper.CreateNetworkPrefab("NetworkHelper_" + networkType);
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
