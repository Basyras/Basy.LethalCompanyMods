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

        public void Awake(PlayerControllerB player)
        {
            Player = player;
        }

        public virtual void End()
        {
            BasyLogger.Instance.LogInfo($"{this.GetType().Name} End");

        }

        public virtual void Start()
        {
            BasyLogger.Instance.LogInfo($"{this.GetType().Name} Start");
        }

        public virtual void Update()
        {

        }
    }
}
