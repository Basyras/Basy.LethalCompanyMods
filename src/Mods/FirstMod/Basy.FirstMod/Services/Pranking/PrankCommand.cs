﻿using Basy.LethalCompany.Utilities;
using Basy.LethalCompany.Utilities.Commands;
using BasyFirstMod.Services.Logging;
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
        private static bool stopRequested = false;

        public async Task ExecuteAsync(string[] args)
        {
            if (args[0] == "start")
            {
                Task.Run(async () =>
                {
                    while (true)
                    {
                        if (stopRequested)
                        {
                            stopRequested = false;
                            break;
                        }

                        var prankIds = PrankClient.Instance.GetPrankIds();
                        var pranKId = prankIds[new Random().Next(prankIds.Length)];
                        var playerIds = BLUtils.Players.GetPlayers();
                        var player = playerIds[new Random().Next(playerIds.Length)];
                        try
                        {
                            BasyLogger.Instance.LogInfo($"Random prank '{pranKId}' for player '{player.playerClientId}'");
                            PrankClient.Instance.RequestPrank(player.playerClientId, pranKId);
                        }
                        catch (Exception ex)
                        {
                            BasyLogger.Instance.LogError($"{ex.Message}\n\n{ex.StackTrace}");
                        }
                        await Task.Delay(5000);
                    }
                });
                return;
            }

            if (args[0] == "stop")
            {
                stopRequested = true;
            }

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
