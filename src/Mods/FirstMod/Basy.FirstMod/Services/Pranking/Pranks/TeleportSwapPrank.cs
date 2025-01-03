using Basy.LethalCompany.Utilities;
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
            PlayerControllerB otherPlayer = PlayerHelper.GetLocalPlayer();
            while (otherPlayer == PlayerHelper.GetLocalPlayer() || otherPlayer.isPlayerControlled is false)
            {
                var randomPlayerId = new System.Random().Next(0, PlayerHelper.GetPlayers().Length);
                otherPlayer = PlayerHelper.GetPlayer(randomPlayerId);
            }

            LoggerHelper.LogInfo($"Teleporting swap player '{otherPlayer.playerClientId}' to player '{Player.playerClientId}'");

            var otherPlayerPosition = otherPlayer.transform.position;
            var otherPlayerRotation = otherPlayer.transform.rotation;

            otherPlayer.TeleportPlayer(Player.transform.position);
            otherPlayer.transform.rotation = Player.transform.rotation;

            Player.TeleportPlayer(otherPlayerPosition);
            Player.transform.rotation = otherPlayerRotation;

        }
    }
}
