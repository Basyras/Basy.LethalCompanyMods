using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasyFirstMod.Services.Logging
{
    public class BasyLogger
    {
        private ManualLogSource logger;

        public BasyLogger()
        {
            logger = BepInEx.Logging.Logger.CreateLogSource(BasyFirstModPlugin.ModGuid);
        }

        public static BasyLogger Instance { get; set; } = new BasyLogger();

        public void LogInfo(string message)
        {
            logger.LogInfo(message);
        }

        public void LogError(string message)
        {
            logger.LogError(message);
        }
    }
}
