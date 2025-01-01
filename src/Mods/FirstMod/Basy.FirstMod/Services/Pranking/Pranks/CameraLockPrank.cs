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
    public class CameraLockPrank : PrankBase
    {
        public override async Task ExecuteAsync()
        {
            Player.isFreeCamera = true;
            await Task.Delay(5000);
            Player.isFreeCamera = false;
        }
    }
}
