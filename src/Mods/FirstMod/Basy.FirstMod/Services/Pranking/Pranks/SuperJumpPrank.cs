using Basy.LethalCompany.Utilities;
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
    public class SuperJumpPrank : PrankBase
    {
        public override async Task ExecuteAsync()
        {
            //var originalForce = Player.jumpForce;
            //Player.jumpForce = 50f;
            //await Task.Delay(5000);
            //Player.jumpForce = originalForce;
            Player.StartCoroutine(Play());
        }

        private IEnumerator Play()
        {
            var originalForce = Player.jumpForce;
            BasyLogger.Instance.LogError($"ori: {originalForce}");
            Player.jumpForce = 50f;
            yield return new WaitForSeconds(10f);
            Player.jumpForce = originalForce;
            BasyLogger.Instance.LogError($"returned to: {Player.jumpForce}");
        }
    }
}
