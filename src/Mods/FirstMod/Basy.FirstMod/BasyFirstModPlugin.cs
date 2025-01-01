using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using BasyFirstMod.Services.Logging;
using BasyFirstMod.Services.Pranking;
using BasyFirstMod.Services.Pranking.Hooks;
using Basy.LethalCompany.Utilities;

namespace BasyFirstMod
{
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    public class BasyFirstModPlugin : BaseUnityPlugin
    {
        public const string ModGuid = "Basy.FirstMod";
        public const string ModName = "Basy first mod";
        public const string ModVersion = "1.0.2";

        private readonly Harmony harmony = new Harmony(ModGuid);
        public void Awake()
        {
            BasyLogger.Instance.LogInfo($"{ModGuid}({ModVersion}) {nameof(Awake)} Start");
            NetCodePatchHelper.Patch<BasyFirstModPlugin>();
            PrankNetworkObject.Prefab = NetworkPrefabHelper.CreateNetworkPrefab("FirstModNetworkPrefab");
            PrankNetworkObject.Prefab.AddComponent<PrankNetworker>();

            foreach (var localTypes in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (localTypes.Name.EndsWith("Patch") || localTypes.Name.EndsWith("Hook"))
                {
                    harmony.PatchAll(localTypes);
                }
            }

            BasyLogger.Instance.LogInfo($"{ModGuid}({ModVersion}) {nameof(Awake)} End");
        }
    }
}
