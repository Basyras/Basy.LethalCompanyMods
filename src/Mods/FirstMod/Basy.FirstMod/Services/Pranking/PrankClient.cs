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
        private Type[] prankTypes;

        public PrankClient()
        {
            prankTypes = this.GetType().Assembly.GetTypes()
                .Where(x => typeof(IPrank).IsAssignableFrom(x))
                .Where(x => x.IsAbstract is false)
                .Where(x => x.IsInterface is false)
                .ToArray();
        }

        public void RequestPrank(int playerId, string prankId)
        {
            BasyLogger.Instance.LogInfo("PrankClient RequestPrank Start");

            var localPlayer = StartOfRound.Instance.localPlayerController;
            var networker = PrankNetworker.Instance.GetComponent<PrankNetworker>();

            if (networker.IsHost || networker.IsServer)
            {
                networker.RecievePrankClientRpc(prankId);
            }
            else
            {
                networker.RequestPrankServerRpc(playerId, prankId);
            }

            BasyLogger.Instance.LogInfo("PrankClient RequestPrank End");
        }

        public void RecievePrank(string prankId)
        {
            Type prankType = null;
            if (prankId is null)
            {
                prankType = prankTypes[new Random().Next(0, prankTypes.Length - 1)];
            }
            else
            {
                prankType = Assembly.GetExecutingAssembly().GetTypes().First(x => x.Name == prankId);
            }

            var prankInstance = (IPrank)Activator.CreateInstance(prankType);
            prankInstance.Start();
        }
    }
}
