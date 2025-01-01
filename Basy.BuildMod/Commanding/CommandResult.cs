using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basy.BuildMod.Commanding
{
    public record CommandResult(int ExitCode, string StandardOutput, string StandardError)
    {
    }
}
