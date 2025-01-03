using BasyFirstMod.Services.Pranking;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basy.LethalCompany.Utilities.Commands
{
    public class GiveItemCommand : ICommand
    {
        public string Command => "give";

        public async Task ExecuteAsync(string[] tokens)
        {
            var itemId = tokens.Length < 1 ? 0 : int.Parse(tokens[0]);
            var playerId = tokens.Length < 2 ? (int)PlayerHelper.GetLocalPlayerId() : int.Parse(tokens[1]);
            BasyUtiltsNetworker.Instance.RequestGiveItemServerRpc(playerId, itemId);
        }
    }
}
