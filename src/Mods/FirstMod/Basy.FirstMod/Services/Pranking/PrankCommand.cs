using Basy.LethalCompany.Utilities;
using Basy.LethalCompany.Utilities.Commands;
using BasyFirstMod.Services.Pranking;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basy.FirstMod.Services.Pranking
{
    public class PrankCommand : ICommand
    {
        public string Command => "prank";

        public async Task ExecuteAsync(string[] args)
        {
            var prankId = args[0];
            var playerId = args.Length < 2 ? BLUtils.Players.GetLocalPlayerId() : ulong.Parse(args[1]);
            if (prankId.EndsWith("Prank") is false)
            {
                prankId = prankId + "Prank";
            }
            PrankClient.Instance.RequestPrank(playerId, prankId);
        }
    }
}
