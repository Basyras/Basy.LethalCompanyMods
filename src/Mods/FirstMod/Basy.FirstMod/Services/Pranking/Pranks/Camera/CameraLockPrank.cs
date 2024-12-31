using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BasyFirstMod.Services.Pranking.Pranks.Cameras
{
    public class CameraLockPrank : PrankBase
    {
        public override void Start()
        {
            Player.isFreeCamera = false;
        }

        public override void End()
        {
            Player.isFreeCamera = true;
        }
    }
}
