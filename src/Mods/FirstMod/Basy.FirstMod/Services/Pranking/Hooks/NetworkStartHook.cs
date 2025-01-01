using BasyFirstMod;
using BasyFirstMod.Services.Logging;
using BasyFirstMod.Services.Pranking;
using HarmonyLib;
using Unity.Netcode;

namespace BasyFirstMod.Services.Pranking.Hooks
{
    public class NetworkStartHook
    {
        [HarmonyPatch(typeof(GameNetworkManager), "Start")]
        [HarmonyPostfix]
        public static void StartPatch(GameNetworkManager __instance)
        {
            BasyLogger.Instance.LogInfo("GameNetworkManagerPatch Start Start");
            BasyLogger.Instance.LogInfo($"Is PrankNetworkObject.Prefab null: {PrankNetworkObject.Prefab is null}");
            BasyLogger.Instance.LogInfo($"Is NetworkManager.Singleton null: {NetworkManager.Singleton is null}");
            //NetworkManager.Singleton.AddNetworkPrefab(PrankNetworkObject.Prefab);
            BasyLogger.Instance.LogInfo("GameNetworkManagerPatch Start End");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(GameNetworkManager), "StartDisconnect")]
        public static void StartDisconnectPatch()
        {

        }
    }
}
