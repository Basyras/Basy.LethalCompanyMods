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
    public class TestPrank : PrankBase
    {
        public override async Task ExecuteAsync()
        {
            var audios = AssetsHelper.GetAssets<AudioClip>().OrderBy(x=>x.name);
            foreach (var audio1 in audios)
            {
                LoggerHelper.LogInfo(audio1.name);
            }
            var audio = AssetsHelper.GetAsset<AudioClip>("ShakeSpraycan");
            SoundHelper.PlayAtPlayerLocally(audio);
        }
    }
}
