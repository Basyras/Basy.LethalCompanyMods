using Basy.LethalCompany.Utilities.Helpers.Networks;
using Basy.LethalCompany.Utilities.Helpers.Players;
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
            ulong playerId = tokens.Length < 2 ? BLUtils.Players.GetLocalPlayerId() : ulong.Parse(tokens[1]);
            BasyUtiltsNetworker.Instance.RequestGiveItemServerRpc(playerId, itemId);
        }
    }
}
