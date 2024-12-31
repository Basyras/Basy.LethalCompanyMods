using GameNetcodeStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasyFirstMod.Services.Pranking
{
    public interface IPrank
    {
        void Awake(PlayerControllerB player);
        void Start();
        void Update();
        void End();
    }
}
