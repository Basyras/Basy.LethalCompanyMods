using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basy.BuildMod
{
    public static class ThunderStore
    {
        public static void Pack(string ModName, string binDir, string publishDir, string patchDir)
        {
            var manifestDir = Path.Combine(publishDir, "Manifest");
            var thunderZip = Path.Combine(binDir, $"{ModName}.zip");
            var thunderUnZipDir = binDir + $"\\{ModName}";
            var bepInExCodeDir = thunderUnZipDir + $"\\BepInEx" + $"\\plugins\\{ModName}";
            CopyTo(manifestDir, thunderUnZipDir);
            CopyTo(patchDir, bepInExCodeDir);

            ZipFile.CreateFromDirectory(thunderUnZipDir, thunderZip);
        }

        private static void CopyTo(string absoluteSourcePath, string absoluteTargetPath)
        {
            var isFile = File.Exists(absoluteSourcePath);
            if (isFile)
            {
                File.Copy(absoluteSourcePath, absoluteTargetPath, true);
            }
            else
            {
                CopyDirectory(absoluteSourcePath, absoluteTargetPath);
            }
        }

        private static void CopyTo(string relativeSourcePath)
        {
            CopyTo(relativeSourcePath, relativeSourcePath);
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

        private static void CopyDirectory(string absoluteSourcePath, string absoluteTargetPath)
        {
            var source = new DirectoryInfo(absoluteSourcePath);
            var target = new DirectoryInfo(absoluteTargetPath);

            CopyDirectory(source, target);
        }

        private static bool TwoDirsSame(string first, string second)
        {
            return string.Compare(NormalizePath(first), NormalizePath(second)) == 0;
        }

        private static bool TwoDirsSame(DirectoryInfo first, DirectoryInfo second)
        {
            return TwoDirsSame(first.FullName, second.FullName);
        }

        private static string NormalizePath(string path)
        {
            return Path.GetFullPath(path)
                       .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                       .ToUpperInvariant();
        }
    }
}
