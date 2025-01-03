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
            for (int i = 0; i < 180; i++)
            {
                //Player.gameplayCamera.transform.Rotate(0, 1, 0, Space.Self);
                //Player.gameplayCamera.transform.rotation = Quaternion.LookRotation(new Vector3(1,0,0));
                //Player.transform.rotation = Quaternion.LookRotation(new Vector3(i, 0, 0));
                Player.transform.Rotate(0, i / 5, 0);
                yield return null;
            }
        }
    }
}
