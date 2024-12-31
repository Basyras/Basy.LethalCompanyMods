using System;
using System.IO;
using System.IO.Compression;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace BuildTasks
{
    public class PackModTask : TaskBase
    {
        [Required]
        public string OutputPath { get; set; }

        [Required]
        public string ModName { get; set; }

        private string publishDir;
        private string manifestDir;
        private string tempDir;
        private string modPathDir;
        private string finalZipPath;
        private string finalDir;

        public override bool Execute()
        {
            try
            {
                manifestDir = Path.Combine(OutputPath, "Manifest");
                publishDir = Path.Combine(OutputPath, "Publish");
                tempDir = Path.Combine(publishDir, "Temp");
                modPathDir = Path.Combine(tempDir, $"BepInEx\\plugins\\{ModName}");
                finalZipPath = Path.Combine(publishDir, $"{ModName}.zip");
                finalDir = Path.Combine(publishDir, $"{ModName}");

                if (Directory.Exists(publishDir))
                {
                    Directory.Delete(publishDir, true);
                }

                Directory.CreateDirectory(publishDir);
                Directory.CreateDirectory(tempDir);
                Directory.CreateDirectory(modPathDir);

                CopyTo(manifestDir, tempDir);
                CopyTo(OutputPath, modPathDir);
                Directory.Delete(Path.Combine(modPathDir, "Manifest"), true);

                ZipFile.CreateFromDirectory(tempDir, finalZipPath);
                CopyDirectory(tempDir, finalDir);
                Directory.Delete(tempDir, true);
                return true;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message + "\n" + ex.StackTrace);
            }

            return false;
        }

        private void CopyTo(string absoluteSourcePath, string absoluteTargetPath)
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

        private void CopyTo(string relativeSourcePath)
        {
            CopyTo(relativeSourcePath, relativeSourcePath);
        }

        private void CopyDirectory(DirectoryInfo sourceDir, DirectoryInfo targetDir)
        {
            if (TwoDirsSame(sourceDir.FullName, publishDir))
            {
                return;
            }

            //if (TwoDirsSame(sourceDir.FullName, workDir))
            //{
            //    return;
            //}

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

        private void CopyDirectory(string absoluteSourcePath, string absoluteTargetPath)
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
