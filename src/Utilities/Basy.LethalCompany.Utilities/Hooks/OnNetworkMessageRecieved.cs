using Basy.LethalCompany.Utilities;
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
    public static partial class On
    {
        public static event EventHandler<object> OnNetworkMessageRecieved;

        public static void InvokeNetworkMessageRecieved(object message)
        {
            BLUtils.Logger.LogInfo($"Message recieved: {message.GetType()}");
            OnNetworkMessageRecieved?.Invoke(null, message);
        }
    }
}
