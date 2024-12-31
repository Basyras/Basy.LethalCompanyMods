using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using NetcodePatcher;
using System.Threading.Tasks;

namespace BasyFirstMod
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var modpackSourceDir = @"C:\Users\Honza\source\repos\BasyFirstModSolution\BasyFirstMod\bin\Debug\net48\Publish\BasyFirstMod\BepInEx\plugins\BasyFirstMod";
            var modpackTargetDir = @"C:\Users\Honza\AppData\Roaming\r2modmanPlus-local\LethalCompany\profiles\BasyFistMod\BepInEx\plugins\BasyTeam-BasyFirstMod\BasyFirstMod";
            var steamArgs = "--doorstop-enable true --doorstop-target \"C:\\Users\\Honza\\AppData\\Roaming\\r2modmanPlus-local\\LethalCompany\\profiles\\BasyFistMod\\BepInEx\\core\\BepInEx.Preloader.dll\"";
            var steamExePath = "C:\\Program Files (x86)\\Steam\\Steam.exe";


            Patcher.Patch(modpackSourceDir, modpackTargetDir, new string[] {});
            //CopyDirectory(new DirectoryInfo(modpackSourceDir), new DirectoryInfo(modpackTargetDir));
            Process.Start($"{steamExePath}", $"-applaunch 1966720 {steamArgs}");
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
