﻿using GameNetcodeStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basy.LethalCompany.Utilities
{
    public static class PlayerHelper
    {
        public static PlayerControllerB GetLocalPlayer()
        {
            return StartOfRound.Instance.localPlayerController;
        }      
        
        public static ulong GetLocalPlayerId()
        {
            return StartOfRound.Instance.localPlayerController.playerClientId;
        }

        public static PlayerControllerB[] GetPlayers()
        {
            return StartOfRound.Instance.allPlayerScripts;
        }

        public static PlayerControllerB GetPlayer(int playerId)
        {
            return StartOfRound.Instance.allPlayerScripts[playerId];
        }
    }
}
