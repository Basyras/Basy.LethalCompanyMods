using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basy.BuildMod.Commanding
{
    public static class CommandInvoker
    {

        public static CommandResult Invoke(string command, int timeout = 0)
        {
            var tokens = command.Split(" ");
            return Invoke(tokens.First(), timeout, tokens.Skip(1).ToArray());
        }

        public static CommandResult Invoke(string filePath, int timeout = 0, params string[] args)
        {
            return Invoke(filePath, string.Join(" ", args), timeout);
        }

        public static CommandResult Invoke(string filePath, string args, int timeout = 0)
        {
            var processInfo = new ProcessStartInfo();
            processInfo.RedirectStandardOutput = true;
            processInfo.RedirectStandardError = true;
            processInfo.FileName = filePath;
            processInfo.UseShellExecute = false;
            processInfo.Arguments = args;
            Debug.WriteLine($"{filePath} {args}");
            var process = new Process();
            process.StartInfo = processInfo;
            process.Start();
            if (timeout > 0)
            {
                process.WaitForExit(timeout);
            }
            var standardOutput = process.StandardOutput.ReadToEnd();
            var standardError = process.StandardError.ReadToEnd();
            if (process.ExitCode != 0)
            {
                throw new Exception($"Error:\n{standardError}\nOutput:\n{standardOutput}");
            }

            return new CommandResult(process.ExitCode, standardOutput, standardError);
        }
    }
}
