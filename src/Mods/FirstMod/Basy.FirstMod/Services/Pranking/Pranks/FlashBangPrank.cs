using Basy.LethalCompany.Utilities;
using Basy.LethalCompany.Utilities.Helpers.Audios;
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
        public override string Description => "To nebol tvoj flash";

        public override async Task ExecuteAsync()
        {
            var time = 1f;
            var audio = BLUtils.Assets.GetAsset<AudioClip>("FlashbangExplode");
            BLUtils.Audio.PlayAtPlayerLocallyAsync(PlayerId, audio);
            await Task.Delay(150);
            HUDManager.Instance.flashFilter = time;
            SoundManager.Instance.earsRingingTimer = time;
        }
    }
}
