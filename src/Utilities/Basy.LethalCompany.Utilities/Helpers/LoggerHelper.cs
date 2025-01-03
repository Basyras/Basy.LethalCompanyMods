using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basy.LethalCompany.Utilities
{
    public static class LoggerHelper
    {
        private static readonly ManualLogSource logger;

        static LoggerHelper()
        {
            logger = BepInEx.Logging.Logger.CreateLogSource("Basy.LethalCompany.Utilities");
        }

        public static void LogInfo(string message)
        {
            logger.LogInfo(message);
        }

        public static void LogError(string message)
        {
            logger.LogError(message);
        }

        public static void LogError(Exception ex)
        {
            logger.LogError($"{ex.Message}\n\n{ex.StackTrace}");
        }

    }
}
