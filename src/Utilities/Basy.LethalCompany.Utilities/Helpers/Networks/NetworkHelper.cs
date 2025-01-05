using BasyFirstMod.Services.Pranking.Hooks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Unity.Netcode;
using static Unity.Networking.Transport.NetworkPipelineStage;

namespace Basy.LethalCompany.Utilities.Helpers.Networks
{
    public class NetworkHelper
    {
        public void RegisterNetworker<TNetworkBehaviour>()
            where TNetworkBehaviour : NetworkBehaviour
        {
            var networkType = typeof(TNetworkBehaviour);
            var prefab = LethalLib.Modules.NetworkPrefabs.CreateNetworkPrefab("NetworkHelper_" + networkType);
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

        public void Send(object message, ulong[] targetClientIds)
        {
            var request = new NetworkMessageRequest();
            request.TargetClientIds = targetClientIds;
            request.MesssageAssemblyQualifiedName = message.GetType().AssemblyQualifiedName;
            request.MessageJson = JsonConvert.SerializeObject(message);
            var messgeRequestJson = JsonConvert.SerializeObject(request);
            BasyUtiltsNetworker.Instance.RequestMessageServerRpc(messgeRequestJson);
        }

        public void Send(object message, ulong targetClientId)
        {
            Send(message, new ulong[] { targetClientId });
        }

        public void Recieve(object message)
        {
            On.InvokeNetworkMessageRecieved(message);
        }
    }
}
