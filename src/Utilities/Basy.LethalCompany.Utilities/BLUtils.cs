using Basy.LethalCompany.Utilities.Commands;
using Basy.LethalCompany.Utilities.Helpers.Assets;
using Basy.LethalCompany.Utilities.Helpers.Audios;
using Basy.LethalCompany.Utilities.Helpers.Coroutines;
using Basy.LethalCompany.Utilities.Helpers.Networks;
using Basy.LethalCompany.Utilities.Helpers.Networks.Messages;
using Basy.LethalCompany.Utilities.Helpers.Players;
using Basy.LethalCompany.Utilities.Helpers.Randoms;
using Basy.LethalCompany.Utilities.Helpers.Times;
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

            On.OnLocalChatMessageSending += (s, a) =>
            {
                if (CommandsHelper.TryExecute(a.Message))
                {
                    a.PreventSending = true;
                }
            };

            On.OnNetworkMessageRecieved += (s, a) =>
            {
                if (a is DisplayTipMessage tip)
                {
                    HUDManager.Instance.DisplayTip(tip.Header, tip.Body);
                }

                if(a is TeleportPlayerMessage teleport)
                {
                    var position = new Vector3(teleport.PositionX, teleport.PositionY, teleport.PositionZ);
                    var rotation = new Quaternion(teleport.RotationX, teleport.RotationY, teleport.RotationZ, teleport.RotationW);
                    BLUtils.Players.GetLocalPlayer().transform.position = position;
                    BLUtils.Players.GetLocalPlayer().transform.rotation = rotation;
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
        public static RandomHelper Random { get; } = new RandomHelper();
        public static TimeHelper Time { get; } = new TimeHelper();

    }
}
