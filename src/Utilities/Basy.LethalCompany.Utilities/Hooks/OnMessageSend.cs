using Basy.LethalCompany.Utilities;
using Basy.LethalCompany.Utilities.Commands;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BasyFirstMod.Services.Pranking.Hooks
{
    public static partial class On
    {
        public static event EventHandler<string> OnLocalPlayerSendingMessage;

        [HarmonyPatch(typeof(HUDManager), "SubmitChat_performed")]
        [HarmonyPrefix]
        public static void PatchAddChatMessage(HUDManager __instance, InputAction.CallbackContext context)
        {
            var localPlayer = GameNetworkManager.Instance.localPlayerController;
            if (!context.performed || localPlayer == null || !localPlayer.isTypingChat || ((!localPlayer.IsOwner || (__instance.IsServer && !localPlayer.isHostPlayerObject))))
            {
                return;
            }

            var message = __instance.chatTextField.text;
            OnLocalPlayerSendingMessage?.Invoke(null, message);
        }
    }
}
