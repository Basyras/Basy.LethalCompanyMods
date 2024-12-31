using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BuildTasks
{
    public class CleanModTask : Task
    {
        [Required]
        public string OutputPath { get; set; }

        public override bool Execute()
        {
            if (Directory.Exists(OutputPath) is false)
            {
                return true;
            }

            var publishPath = Path.Combine(OutputPath, "Publish");
            if (Directory.Exists(publishPath) is false)
            {
                return true;
            }

            Directory.Delete(publishPath, true);

            return true;
        }
    }
}
