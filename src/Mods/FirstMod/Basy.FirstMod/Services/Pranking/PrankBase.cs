using BasyFirstMod.Services.Logging;
using GameNetcodeStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasyFirstMod.Services.Pranking
{
    public abstract class PrankBase : IPrank
    {
        protected PlayerControllerB Player { get; private set; }
        protected ulong PlayerId { get; private set; }

        public abstract string Description { get; }

        public void Initialize(PlayerControllerB player)
        {
            Player = player;
            PlayerId = player.playerClientId;
        }

        public virtual Task ExecuteAsync()
        {
            return Task.CompletedTask;
        }
    }
}
