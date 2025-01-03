using Basy.BuildMod.Commanding;
using NetcodePatcher;
using System.Diagnostics;

namespace Basy.BuildMod
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var modName = "Basy.FirstMod";
            var modSourceDir = @"C:\Users\Honza\source\repos\BasyFirstModSolution\src\Mods\FirstMod\Basy.FirstMod";
            var modBinDir = modSourceDir + @"\bin\Debug\netstandard2.1";
            var modPublishDir = modBinDir + @"\publish";
            var lethalDir = @"C:\Program Files (x86)\Steam\steamapps\common\Lethal Company";
            var lethalManagerDir = lethalDir + @"\Lethal Company_Data\Managed";
            var modPatchedDir = modBinDir + "/pathed";
            var modResources = modPublishDir + "/Resources";
            var testDir = @"C:\Program Files (x86)\Steam\steamapps\common\Lethal Company\BepInEx\plugins\BasyFirstMod";
            //var steamArgs = "--doorstop-enable true --doorstop-target \"C:\\Users\\Honza\\AppData\\Roaming\\r2modmanPlus-local\\LethalCompany\\profiles\\BasyFistMod\\BepInEx\\core\\BepInEx.Preloader.dll\"";
            //var steamExePath = "C:\\Program Files (x86)\\Steam\\Steam.exe";

            if (Directory.Exists(modBinDir))
            {
                Directory.Delete(modBinDir, true);
            }

            CommandInvoker.Invoke($"dotnet publish {modSourceDir}");
            CommandInvoker.Invoke($"netcode-patch \"{modPublishDir}\" \"{lethalManagerDir}\" --log-level Verbose --output \"{modPatchedDir}\"", 5000);
            CopyDirectory(new(modResources), new(modPatchedDir + "\\Resources"));
            ThunderStore.Pack(modName, modBinDir, modPublishDir, modPatchedDir);

            Directory.Delete(testDir, true);
            CopyDirectory(new(modPatchedDir), new(testDir));
            var startProcess = Process.Start($"{lethalDir}\\Lethal Company.exe");
            await Task.Delay(3000);
            var startProcess2 = Process.Start($"{lethalDir}\\Lethal Company.exe");
        }

        private static void CopyDirectory(DirectoryInfo sourceDir, DirectoryInfo targetDir)
        {
            targetDir.Create();

            foreach (DirectoryInfo childDir in sourceDir.GetDirectories())
            {
                CopyDirectory(childDir, new DirectoryInfo(Path.Combine(targetDir.FullName, childDir.Name)));
            }

            foreach (FileInfo childFIle in sourceDir.GetFiles())
            {
                childFIle.CopyTo(Path.Combine(targetDir.FullName, childFIle.Name), true);
            }
        }
    }
}
