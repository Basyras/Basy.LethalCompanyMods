using BasyFirstMod.Services.Logging;
using GameNetcodeStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasyFirstMod.Services.Pranking
{
    public class PrankBase : IPrank
    {
        protected PlayerControllerB Player { get; private set; }

        public void Initialize(PlayerControllerB player)
        {
            Player = player;
        }

        public virtual Task ExecuteAsync()
        {
            return Task.CompletedTask;
        }
    }
}
