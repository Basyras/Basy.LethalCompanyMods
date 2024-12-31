using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;

namespace BasyFirstMod.Services.Pranking
{
    public static class PrankNetworkObject
    {
        static PrankNetworkObject()
        {
            //var fakePrefab = new GameObject("PrankNetworkerPrefab",
            //    new Type[]
            //    {
            //        typeof(PrankNetworker),
            //        typeof(NetworkObject),
            //    });

            //fakePrefab.SetActive(true);
            //fakePrefab.isStatic = true;
            //Prefab = fakePrefab;
        }

        public static GameObject Prefab;

        public static GameObject Instance;
    }
}
