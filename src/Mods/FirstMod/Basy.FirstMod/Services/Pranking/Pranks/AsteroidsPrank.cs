using Basy.LethalCompany.Utilities;
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
            for (int i = 0; i < 10; i++)
            {
                HUDManager.Instance.DisplayStatusEffect("Asteriods incoming!");
                HUDManager.Instance.DisplayTip("Asteriods incoming!", "", true);
                var audio = AssetsHelper.GetAsset<AudioClip>("Cruiser_Explode");
                SoundHelper.PlayAtPlayerLocally(audio);
                HUDManager.Instance.ShakeCamera(ScreenShakeType.VeryStrong);
                await Task.Delay(1000);
            }
        }
    }
}
