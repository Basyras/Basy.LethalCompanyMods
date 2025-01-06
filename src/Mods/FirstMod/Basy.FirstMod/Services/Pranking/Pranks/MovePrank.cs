using Basy.LethalCompany.Utilities;
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
    public class MovePrank : PrankBase
    {
        public override string Description => "Keyboard disconnected simulator";

        public override async Task ExecuteAsync()
        {
            Player.StartCoroutine(Play());
        }

        private IEnumerator Play()
        {
            var timeSeconds = BLUtils.Random.Int(15, 15);
            var maxDirection = 3;

            var motion = new Vector3(BLUtils.Random.Int(-maxDirection, maxDirection), 0, BLUtils.Random.Int(-maxDirection, maxDirection));
            yield return BLUtils.Time.ExecuteFor(timeSeconds, (context) =>
            {
                Player.thisController.Move(motion * Time.deltaTime);
            });
        }
    }
}
