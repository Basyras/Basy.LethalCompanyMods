using BasyFirstMod.Services.Logging;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;

namespace BasyFirstMod.Services.Pranking.Hooks
{
    public static class GameStartHook
    {
        //[HarmonyPatch(typeof(RoundManager), "LoadNewLevelWait")]
        //[HarmonyPostfix]
        //public static void Patch(RoundManager __instance)
        //{

        //    try
        //    {

        //        BasyLogger.Instance.LogInfo($"{nameof(GameStartHook)} Start");
        //        //GameObject prankNetworkObject = UnityEngine.Object.Instantiate(PrankNetworkObject.Prefab);
        //        //prankNetworkObject.GetComponent<NetworkObject>().Spawn();
        //        //PrankNetworkObject.Instance = prankNetworkObject.GetComponent<PrankNetworker>();
        //        PrankNetworkObject.Instance.GetComponent<NetworkObject>().Spawn();

        //        BasyLogger.Instance.LogInfo($"{nameof(GameStartHook)} End");
        //    }
        //    catch (Exception e)
        //    {
        //        BasyLogger.Instance.LogError($"{e.Message} \n{e.StackTrace}");
        //    }
        //}

        [HarmonyPatch(typeof(RoundManager), "Start")]
        [HarmonyPostfix]
        public static void Patch(RoundManager __instance)
        {

            if (__instance.IsHost)
            {
                BasyLogger.Instance.LogInfo($"{nameof(GameStartHook)} Creating instantiate network");
                var intance = UnityEngine.Object.Instantiate(PrankNetworkObject.Prefab);
                BasyLogger.Instance.LogInfo($"{nameof(GameStartHook)} Creating spawning network");
                intance.GetComponent<NetworkObject>().Spawn();
                BasyLogger.Instance.LogInfo($"{nameof(GameStartHook)} DONE");
            }
        }
    }
}
