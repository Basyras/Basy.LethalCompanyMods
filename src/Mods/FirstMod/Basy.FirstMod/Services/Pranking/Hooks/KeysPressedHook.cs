using BasyFirstMod.Services.Logging;
using BasyFirstMod.Services.Pranking.Pranks.Cameras;
using BasyFirstMod.Services.Pranking.Pranks.Sounds;
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
    public static class KeysPressedHook
    {
        [HarmonyPatch(typeof(RoundManager), "Update")]
        [HarmonyPostfix]
        public static void UpdatePatch(RoundManager __instance)
        {
            var pPressed = UnityInput.Current.GetKey(KeyCode.P);
            if (pPressed is false)
            {
                return;
            }

            if (GetPressedPrank(out var prankId) is false)
            {
                return;
            }

            BasyLogger.Instance.LogInfo($"{nameof(KeysPressedHook)} P + {prankId} PRESSED");
            int currentPlayerId = (int)StartOfRound.Instance.localPlayerController.playerClientId;
            BasyLogger.Instance.LogInfo($"{nameof(KeysPressedHook)} By playerId: " + currentPlayerId);


            PrankClient.Instance.RequestPrank(-1, prankId);
        }

        private static bool GetPressedPrank(out string prankId)
        {

            prankId = null;
            if (UnityInput.Current.GetKeyDown(KeyCode.Keypad0))
            {
                return true;
            }

            if (UnityInput.Current.GetKeyDown(KeyCode.Keypad1))
            {
                prankId = nameof(ScarySoundPrank);
            }

            if (UnityInput.Current.GetKeyDown(KeyCode.Keypad2))
            {
                prankId = nameof(CameraShakePrank);
            }

            if (UnityInput.Current.GetKeyDown(KeyCode.Keypad3))
            {
                prankId = nameof(CameraLockPrank);
            }

            if (UnityInput.Current.GetKeyDown(KeyCode.Keypad4))
            {
                prankId = nameof(ScarySoundPrank);
            }

            return prankId != null;
        }
    }
}
