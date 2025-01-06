using GameNetcodeStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basy.LethalCompany.Utilities.Helpers.Players
{
    public class PlayerHelper
    {
        public PlayerControllerB GetLocalPlayer()
        {
            return StartOfRound.Instance.localPlayerController;
        }

        public ulong GetLocalPlayerId()
        {
            return StartOfRound.Instance.localPlayerController.playerClientId;
        }

        public PlayerControllerB[] GetPlayers()
        {
            return StartOfRound.Instance.allPlayerScripts.Where(x=>x.isPlayerControlled).ToArray();
        }

        public PlayerControllerB GetPlayer(int playerId)
        {
            return StartOfRound.Instance.allPlayerScripts[playerId];
        }

        public PlayerControllerB GetPlayer(ulong playerId)
        {
            return GetPlayer((int)playerId);
        }
    }
}
