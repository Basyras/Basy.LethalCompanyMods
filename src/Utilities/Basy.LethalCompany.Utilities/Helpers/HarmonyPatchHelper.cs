using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Basy.LethalCompany.Utilities
{
    public static class HarmonyPatchHelper
    {
        static HarmonyPatchHelper()
        {
            Patch(typeof(HarmonyPatchHelper).Assembly, "HookPatchHelper");
        }

        public static void Patch<TAssemblyMarker>(string modGuid)
        {
            Patch(typeof(TAssemblyMarker).Assembly, modGuid);
        }

        public static void Patch(Assembly assembly, string modGuid)
        {
            Harmony harmony = new Harmony(modGuid);
            foreach (var type in assembly.GetTypes())
            {
                harmony.PatchAll(type);
            }
        }
    }
}
