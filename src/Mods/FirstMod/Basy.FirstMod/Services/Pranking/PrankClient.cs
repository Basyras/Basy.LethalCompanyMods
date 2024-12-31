using BasyFirstMod.Services.Logging;
using BasyFirstMod.Services.Pranking.Pranks.Sounds;
using GameNetcodeStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BasyFirstMod.Services.Pranking
{
    public class PrankClient
    {
        public static PrankClient Instance { get; } = new PrankClient();


        public void RequestPrank(int playerId, string prankId)
        {
            var localPlayer = StartOfRound.Instance.localPlayerController;
            var networker = PrankNetworkObject.Instance.GetComponent<PrankNetworker>();
            networker.RequestPrankServerRpc(playerId, prankId);
        }

        public void RecievePrank(string prankId)
        {
            var prankType = Assembly.GetExecutingAssembly().GetTypes().First(x => x.Name == prankId);
            var prankInstance = (IPrank)Activator.CreateInstance(prankType);
            prankInstance.Start();
        }
    }
}
