using Basy.FirstMod.Services.Pranking.Pranks;
using BasyFirstMod.Services.Logging;
using BasyFirstMod.Services.Pranking;
using BasyFirstMod.Services.Pranking.Hooks;
using BepInEx;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Basy.FirstMod.Services.Pranking
{
    public static class PrankHooks
    {
        public static void Register()
        {
            On.OnKeyPressed += (s, a) =>
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

                BasyLogger.Instance.LogInfo($" P + {prankId} PRESSED");
                int currentPlayerId = (int)StartOfRound.Instance.localPlayerController.playerClientId;
                BasyLogger.Instance.LogInfo($"By playerId: " + currentPlayerId);
                PrankClient.Instance.RequestPrank(-1, prankId);
                static bool GetPressedPrank(out string prankId)
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
                        prankId = nameof(AsteroidsPrank);
                    }

                    if (UnityInput.Current.GetKeyDown(KeyCode.Keypad3))
                    {
                        prankId = nameof(CameraLockPrank);
                    }

                    if (UnityInput.Current.GetKeyDown(KeyCode.Keypad4))
                    {
                        prankId = nameof(ScarySoundPrank);
                    }

                    if (UnityInput.Current.GetKeyDown(KeyCode.Keypad5))
                    {
                        prankId = nameof(DrunkPrank);
                    }

                    return prankId != null;
                }
            };

            On.OnChatSend += (s, a) =>
            {
                var tokens = a.Split(' ');
                if (tokens[0] == "prank")
                {
                    var prankId = tokens[1];
                    var playerId = tokens.Length < 3 ? -1 : int.Parse(tokens[2]);
                    if (prankId.EndsWith("Prank") is false)
                    {
                        prankId = prankId + "Prank";
                    }
                    PrankClient.Instance.RequestPrank(-1, prankId);
                }
            };
        }
    }
}
