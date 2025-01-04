using Basy.LethalCompany.Utilities;
using BasyFirstMod.Services.Pranking;
using GameNetcodeStuff;
using HarmonyLib;
using LethalLib.Modules;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Basy.FirstMod.Services.Pranking.Pranks
{
    public class RotatePrank : PrankBase
    {
        public override async Task ExecuteAsync()
        {
            Player.StartCoroutine(Play());
        }

        private IEnumerator Play()
        {
            for (int i = 0; i < 360; i++)
            {
                Player.transform.Rotate(0, 2, 0, Space.Self);
                yield return null;
            }
        }
    }
}
