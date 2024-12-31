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
        public static void UpdatePatch()
        {
            var pPressed = UnityInput.Current.GetKey(KeyCode.P);
            if (pPressed is false)
            {
                return;
            }

            var prankId = GetPressedPrank();

            if (prankId is null)
            {
                return;
            }

            BasyLogger.Instance.LogInfo($"{nameof(KeysPressedHook)} P + {prankId} PRESSED");
            int currentPlayerId = (int)StartOfRound.Instance.localPlayerController.playerClientId;
            BasyLogger.Instance.LogInfo($"{nameof(KeysPressedHook)} By playerId: " + currentPlayerId);


            PrankClient.Instance.RequestPrank(-1, prankId);
        }

        //private static int GetPressedNumber()
        //{
        //    if (UnityInput.Current.GetKeyDown(KeyCode.Keypad0))
        //    {
        //        return 0;
        //    }

        //    if (UnityInput.Current.GetKeyDown(KeyCode.Keypad1))
        //    {
        //        return 1;
        //    }

        //    if (UnityInput.Current.GetKeyDown(KeyCode.Keypad2))
        //    {
        //        return 2;
        //    }

        //    if (UnityInput.Current.GetKeyDown(KeyCode.Keypad3))
        //    {
        //        return 3;
        //    }

        //    return -1;
        //}

        private static string GetPressedPrank()
        {
            if (UnityInput.Current.GetKeyDown(KeyCode.Keypad0))
            {
                return nameof(ScarySoundPrank);
            }

            if (UnityInput.Current.GetKeyDown(KeyCode.Keypad1))
            {
                return nameof(CameraShakePrank);
            }

            if (UnityInput.Current.GetKeyDown(KeyCode.Keypad2))
            {
                return nameof(ScarySoundPrank);
            }

            if (UnityInput.Current.GetKeyDown(KeyCode.Keypad3))
            {
                return nameof(ScarySoundPrank);
            }

            return null;
        }
    }
}
