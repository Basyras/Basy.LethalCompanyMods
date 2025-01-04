using Basy.LethalCompany.Utilities;
using Basy.LethalCompany.Utilities.Helpers.Audios;
using BasyFirstMod.Services.Pranking;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Basy.FirstMod.Services.Pranking.Pranks
{
    public class AsthmaPrank : PrankBase
    {
        private static bool IsActive { get; set; }
        public override async Task ExecuteAsync()
        {
            IsActive = true;
            for (int i = 0; i < 5; i++)
            {
                BLUtils.Audio.PlayAtPlayerAsync(PlayerId, "Wheeze", 0.33f);
                await Task.Delay(3000);
            }
            IsActive = false;
        }

        [HarmonyPatch(typeof(PlayerControllerB), "Update")]
        [HarmonyPostfix]
        public static void UpdatePatch(PlayerControllerB __instance)
        {
            if (IsActive)
            {
                if (__instance.isSprinting)
                {
                    float penalty = Time.deltaTime / 10;
                    BLUtils.Logger.LogInfo($"Asthma: Meter: {__instance.sprintMeter} Penalty: {penalty}");
                    __instance.sprintMeter -= penalty;
                }
            }
        }
    }
}
