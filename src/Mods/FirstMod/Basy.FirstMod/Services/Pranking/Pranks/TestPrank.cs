using Basy.LethalCompany.Utilities;
using Basy.LethalCompany.Utilities.Helpers.Audios;
using BasyFirstMod.Services.Logging;
using BasyFirstMod.Services.Pranking;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Basy.FirstMod.Services.Pranking.Pranks
{
    public class TestPrank : PrankBase
    {
        public override string Description => "Test prank";


        public override async Task ExecuteAsync()
        {

            Vector3 motion = new Vector3(BLUtils.Random.Int(0, 4), 0, BLUtils.Random.Int(0, 4));
            float timeMs = BLUtils.Random.Int(1000, 5000);
            BasyLogger.Instance.LogInfo($"Motion: {motion} timeMs: {timeMs}");
            Player.StartCoroutine(Play(timeMs, motion));
        }

        private IEnumerator Play(float timeMs, Vector3 motion)
        {
            while (timeMs >= 0.0f)
            {
                timeMs -= Time.deltaTime * 1000;
                Player.thisController.Move(motion * Time.deltaTime);
                yield return null;
            }
        }
    }
}
