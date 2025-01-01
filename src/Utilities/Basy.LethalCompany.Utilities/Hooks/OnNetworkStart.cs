using BasyFirstMod;
using BasyFirstMod.Services.Pranking;
using HarmonyLib;
using System;
using Unity.Netcode;

namespace BasyFirstMod.Services.Pranking.Hooks
{

    public static partial class On
    {
        public static event EventHandler OnNetworkStart;

        [HarmonyPatch(typeof(GameNetworkManager), "Start")]
        [HarmonyPostfix]
        public static void StartPatch(GameNetworkManager __instance)
        {
            OnNetworkStart?.Invoke(__instance, EventArgs.Empty);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(GameNetworkManager), "StartDisconnect")]
        public static void StartDisconnectPatch()
        {
        }
    }
}
