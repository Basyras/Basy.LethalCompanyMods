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
        void Initialize(PlayerControllerB player);
        Task ExecuteAsync();
        string Description { get; }
    }
}
