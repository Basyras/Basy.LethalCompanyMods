using Basy.LethalCompany.Utilities;
using BasyFirstMod.Services.Logging;
using BasyFirstMod.Services.Pranking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Basy.FirstMod.Services.Pranking.Pranks
{
    public class ScarySoundPrank : PrankBase
    {
        public override async Task ExecuteAsync()
        {
            var scaryAudioFolder = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, $"Resources\\Audio\\Scary");
            var files = Directory.GetFiles(scaryAudioFolder);
            var path = files[new Random().Next(0, files.Length - 1)];
            var audioClip = await AssetsHelper.GetAudioFromFileAsync(path);
            BasyLogger.Instance.LogInfo("Trying to load: " + path);
            SoundHelper.PlayAtPlayerLocally(audioClip);
        }
    }
}
