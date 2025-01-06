using Basy.LethalCompany.Utilities;
using Basy.LethalCompany.Utilities.Helpers.Audios;
using BasyFirstMod.Services.Logging;
using BasyFirstMod.Services.Pranking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Basy.FirstMod.Services.Pranking.Pranks
{
    public class ScarySoundPrank : PrankBase
    {

        public override string Description => ":O";


        public override async Task ExecuteAsync()
        {
            var scaryAudioFolder = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, $"Resources\\Audio\\Scary");
            var files = Directory.GetFiles(scaryAudioFolder);
            var playCustomSound = new System.Random().Next(0, 2);
            AudioClip audioClip;
            if (playCustomSound == 0)
            {
                var path = files[new System.Random().Next(0, files.Length - 1)];
                audioClip = await BLUtils.Assets.GetAudioFromFileAsync(path);
            }
            else
            {
                var audioClips = BLUtils.Assets.GetAssets<AudioClip>();
                audioClip = audioClips[new System.Random().Next(audioClips.Length)];
            }
            await BLUtils.Audio.PlayAtPlayerLocallyAsync(PlayerId, audioClip);
        }
    }
}
