using Basy.LethalCompany.Utilities.Commands;
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
    public static class BasyLethalUtils
    {
        public static void Register()
        {
            NetworkHelper.RegisterNetworker<BasyUtiltsNetworker>();
            NetCodePatcherHelper.Patch<BasyUtiltsNetworker>();
            CommandsHelper.AddCommands<BasyUtiltsNetworker>();

            On.OnLocalPlayerSendingMessage += (s, a) =>
            {
                CommandsHelper.TryExecute(a);
            };
        }
    }
}
