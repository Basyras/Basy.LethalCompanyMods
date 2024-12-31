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
    public class CameraShakePrank : PrankBase
    {
        public override void Start()
        {
            HUDManager.Instance.ShakeCamera(ScreenShakeType.VeryStrong);
        }
    }
}
