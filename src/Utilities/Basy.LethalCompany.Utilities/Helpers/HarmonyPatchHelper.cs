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
            Patch(typeof(HarmonyPatchHelper).Assembly);
        }

        public static void Patch<TAssemblyMarker>()
        {
            Patch(typeof(TAssemblyMarker).Assembly);
        }

        public static void Patch(Assembly assembly)
        {
            Harmony harmony = new Harmony(Guid.NewGuid().ToString());
            foreach (var type in assembly.GetTypes())
            {
                harmony.PatchAll(type);
            }
        }
    }
}
