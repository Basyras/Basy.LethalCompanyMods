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
            var playerId = args.Length < 2 ? BLUtils.Players.GetLocalPlayerId() : ulong.Parse(args[1]);
            var pitch = args.Length < 3 ? 1 : float.Parse(args[2]);
            BLUtils.Audio.PlayAtPlayerAsync(playerId,audioName, pitch);
        }
    }
}
