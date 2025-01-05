using Basy.LethalCompany.Utilities.Helpers.Networks;
using Basy.LethalCompany.Utilities.Helpers.Networks.Messages;
using BasyFirstMod.Services.Pranking;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basy.LethalCompany.Utilities.Commands
{
    public class SendTipCommand : ICommand
    {
        public string Command => "tip";

        public async Task ExecuteAsync(string[] args)
        {
            var targetClientId = args[0].Split(',').Select(ulong.Parse).ToArray();
            var body = string.Join(" ", args.Skip(1));

            BLUtils.Network.Send(new DisplayTipMessage()
            {
                Header = null,
                Body = body
            }, targetClientId);
        }
    }
}
