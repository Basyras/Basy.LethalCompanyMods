using Basy.LethalCompany.Utilities;
using Basy.LethalCompany.Utilities.Helpers.Players;
using BasyFirstMod.Services.Pranking;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Basy.FirstMod.Services.Pranking.Pranks
{
    public class TeleportSwapPrank : PrankBase
    {
        public override async Task ExecuteAsync()
        {
            PlayerControllerB otherPlayer = Player;
            while (otherPlayer == Player || otherPlayer.isPlayerControlled is false)
            {
                var randomPlayerId = new System.Random().Next(0, BLUtils.Players.GetPlayers().Length);
                otherPlayer = BLUtils.Players.GetPlayer(randomPlayerId);
            }
            BLUtils.Logger.LogInfo($"Teleporting swap player '{Player.playerClientId}':{Player.transform.position} to player '{otherPlayer.playerClientId}':{otherPlayer.transform.position} ");

            BLUtils.Audio.PlayAtPlayerAsync(Player.playerClientId, "ShipTeleporterSpin");
            BLUtils.Audio.PlayAtPlayerAsync(otherPlayer.playerClientId, "ShipTeleporterSpin");
            await Task.Delay(4000);
            var otherPlayerPosition = otherPlayer.transform.position;
            var otherPlayerRotation = otherPlayer.transform.rotation;

            otherPlayer.TeleportPlayer(Player.transform.position);
            otherPlayer.transform.rotation = Player.transform.rotation;
            await Task.Delay(1000);

            Player.TeleportPlayer(otherPlayerPosition);
            Player.transform.rotation = otherPlayerRotation;

        }
    }
}
