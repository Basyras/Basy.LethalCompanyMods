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
    public static partial class On
    {
        public static event EventHandler OnGameStart;

        [HarmonyPatch(typeof(RoundManager), "Start")]
        [HarmonyPostfix]
        public static void PatchOnGameStart(RoundManager __instance)
        {

            OnGameStart?.Invoke(__instance, EventArgs.Empty);
        }
    }
}
