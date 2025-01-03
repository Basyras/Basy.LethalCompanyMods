using BasyFirstMod.Services.Pranking;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basy.LethalCompany.Utilities.Commands
{
    public class PlayAudioCommand : ICommand
    {
        public string Command => "audio";

        public async Task ExecuteAsync(string[] args)
        {
            var audioName = args[0];
            var playerId = args.Length < 2 ? -1 : int.Parse(args[1]);
            BasyUtiltsNetworker.Instance.RequestPlayAudioServerRpc(playerId, audioName);
        }
    }
}
