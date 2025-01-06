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

        public override string Description => "Not adviced to jump outdoors";


        public override async Task ExecuteAsync()
        {
            Player.StartCoroutine(Play());
        }

        private IEnumerator Play()
        {
            var originalForce = Player.jumpForce;
            Player.jumpForce = 50f;
            yield return new WaitForSeconds(10f);
            Player.jumpForce = originalForce;
        }
    }
}
