using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using BasyFirstMod.Services.Logging;
using BasyFirstMod.Services.Pranking;
using BasyFirstMod.Services.Pranking.Hooks;
using Basy.LethalCompany.Utilities;
using Basy.FirstMod.Services.Pranking.Pranks;

namespace BasyFirstMod
{
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    public class BasyFirstModPlugin : BaseUnityPlugin
    {
        public const string ModGuid = "Basy.FirstMod";
        public const string ModName = "Basy first mod";
        public const string ModVersion = "1.0.2";

        public void Awake()
        {
            BasyLogger.Instance.LogInfo($"{ModGuid}({ModVersion}) {nameof(Awake)} Start");
            NetCodePatcherHelper.Patch<BasyFirstModPlugin>();
            HarmonyPatchHelper.Patch<BasyFirstModPlugin>(ModGuid);
            NetworkHelper.RegisterNetworker<PrankNetworker>();

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
                        prankId = nameof(CameraDrunkPrank);
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


            BasyLogger.Instance.LogInfo($"{ModGuid}({ModVersion}) {nameof(Awake)} End");
        }
    }
}
