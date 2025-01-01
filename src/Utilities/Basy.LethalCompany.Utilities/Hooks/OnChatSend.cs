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
        public static event EventHandler<string> OnChatSend;

        [HarmonyPatch(typeof(HUDManager), "AddChatMessage")]
        [HarmonyPrefix]
        public static void PatchOnGameStart(HUDManager __instance, string chatMessage, string nameOfUserWhoTyped = "")
        {
            if (__instance.lastChatMessage == chatMessage)
            {
                return;
            }

            OnChatSend?.Invoke(null, chatMessage);
        }
    }
}
