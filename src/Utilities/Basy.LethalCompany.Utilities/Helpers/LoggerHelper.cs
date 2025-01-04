using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basy.LethalCompany.Utilities
{
    public class LoggerHelper
    {
        private static readonly ManualLogSource logger;

        static LoggerHelper()
        {
            logger = BepInEx.Logging.Logger.CreateLogSource("Basy.LethalCompany.Utilities");
        }

        public void LogInfo(string message)
        {
            logger.LogInfo(message);
        }

        public void LogError(string message)
        {
            logger.LogError(message);
        }

        public void LogError(Exception ex)
        {
            logger.LogError($"{ex.Message}\n\n{ex.StackTrace}");
        }

    }
}
