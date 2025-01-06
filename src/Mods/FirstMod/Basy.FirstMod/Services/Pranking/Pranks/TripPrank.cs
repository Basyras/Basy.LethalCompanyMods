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
    public class TripPrank : PrankBase
    {
        public override string Description => "You just tripped!";

        public override async Task ExecuteAsync()
        {
            //TODO drop item in hand
            //Player.DiscardHeldObject();
            Player.DropAllHeldItems();
            Player.SpawnPlayerAnimation();
        }
    }
}
