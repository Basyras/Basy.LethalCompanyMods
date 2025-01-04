using Basy.LethalCompany.Utilities.Commands;
using Basy.LethalCompany.Utilities.Helpers.Assets;
using Basy.LethalCompany.Utilities.Helpers.Audios;
using Basy.LethalCompany.Utilities.Helpers.Coroutines;
using Basy.LethalCompany.Utilities.Helpers.Players;
using BasyFirstMod.Services.Pranking;
using BasyFirstMod.Services.Pranking.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Unity.Netcode;
using UnityEngine;

namespace Basy.LethalCompany.Utilities
{
    public static class BLUtils
    {
        public static void Register<TAssemblyMarker>()
        {
            Network.RegisterNetworker<BasyUtiltsNetworker>();
            NetCodePatcherHelper.Patch<BasyUtiltsNetworker>();
            CommandsHelper.AddCommands<BasyUtiltsNetworker>();

            On.OnLocalPlayerSendingMessage += (s, a) =>
            {
                if (CommandsHelper.TryExecute(a.Message))
                {
                    a.PreventSending = true;
                }
            };


            NetCodePatcherHelper.Patch<TAssemblyMarker>();
            HarmonyPatchHelper.Patch<TAssemblyMarker>();
            CommandsHelper.AddCommands<TAssemblyMarker>();
        }

        public static AssetsHelper Assets { get; } = new AssetsHelper();
        public static AudioHelper Audio { get; } = new AudioHelper();
        public static PlayerHelper Players { get; } = new PlayerHelper();
        public static CoroutinesHelper Coroutines { get; } = new CoroutinesHelper();
        public static LoggerHelper Logger { get; } = new LoggerHelper();
        public static NetworkHelper Network { get; } = new NetworkHelper();

    }
}
