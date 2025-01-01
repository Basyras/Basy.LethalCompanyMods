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
    public class AsteroidsPrank : PrankBase
    {
        public override async Task ExecuteAsync()
        {
            HUDManager.Instance.DisplayStatusEffect("Asteriods incoming!");
            for (int i = 0; i < 10; i++)
            {
                HUDManager.Instance.ShakeCamera(ScreenShakeType.VeryStrong);
                await Task.Delay(1000);
            }
        }
    }
}
