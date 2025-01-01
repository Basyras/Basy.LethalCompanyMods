using BepInEx;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Windows;

namespace BasyFirstMod.Services.Pranking.Hooks
{
    public static partial class On
    {
        public static event EventHandler OnKeyPressed;

        [HarmonyPatch(typeof(RoundManager), "Update")]
        [HarmonyPostfix]
        public static void Patch(RoundManager __instance)
        {
            OnKeyPressed?.Invoke(__instance, EventArgs.Empty);
        }
    }
}
