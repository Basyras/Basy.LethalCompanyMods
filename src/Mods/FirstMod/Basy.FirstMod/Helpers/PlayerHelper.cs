using GameNetcodeStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasyFirstMod.Helpers
{
    public static class PlayerHelper
    {
        public static PlayerControllerB GetLocalPlayer()
        {
            return StartOfRound.Instance.localPlayerController;
        }
    }
}
