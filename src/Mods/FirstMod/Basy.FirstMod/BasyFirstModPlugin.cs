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
using Basy.FirstMod.Services.Pranking.Pranks;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;
using Basy.FirstMod.Services.Pranking;
using Basy.LethalCompany.Utilities.Commands;

namespace BasyFirstMod
{
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    public class BasyFirstModPlugin : BaseUnityPlugin
    {
        public const string ModGuid = "Basy.FirstMod";
        public const string ModName = "Basy first mod";
        public const string ModVersion = "1.0.2";

        public void Awake()
        {
            BasyLogger.Instance.LogInfo($"{ModGuid}({ModVersion}) {nameof(Awake)} Start");

            BasyLethalUtils.Register();
            NetCodePatcherHelper.Patch<BasyFirstModPlugin>();
            HarmonyPatchHelper.Patch<BasyFirstModPlugin>();
            CommandsHelper.AddCommands<BasyFirstModPlugin>();
            NetworkHelper.RegisterNetworker<PrankNetworker>();

            BasyLogger.Instance.LogInfo($"{ModGuid}({ModVersion}) {nameof(Awake)} End");
        }
    }
}
