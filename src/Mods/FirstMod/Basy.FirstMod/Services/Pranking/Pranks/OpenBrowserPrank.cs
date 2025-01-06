using Basy.LethalCompany.Utilities;
using Basy.LethalCompany.Utilities.Helpers.Audios;
using BasyFirstMod.Services.Pranking;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Basy.FirstMod.Services.Pranking.Pranks
{
    public class OpenBrowserPrank : PrankBase
    {

        public override string Description => "Remember to clear your browser history";

        public override async Task ExecuteAsync()
        {
            Process.Start("https://cz.pornhub.com/view_video.php?viewkey=66aef1f60a8a0&t=1152");
        }
    }
}
