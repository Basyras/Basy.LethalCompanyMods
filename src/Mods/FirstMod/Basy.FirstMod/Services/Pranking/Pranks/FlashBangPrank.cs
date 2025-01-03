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
    public class FlashBangPrank : PrankBase
    {
        public override async Task ExecuteAsync()
        {
            var time = 1f;

            var tt = new StunGrenadeItem().explodeSFX;
            SoundHelper.PlayAtPlayerLocally(tt);
            await Task.Delay(500);
            HUDManager.Instance.flashFilter = time;
            SoundManager.Instance.earsRingingTimer = time;
        }
    }
}
