using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Basy.LethalCompany.Utilities
{
    public static class NetCodePatcherHelper
    {
        public static void Patch<TAssemblyMarker>()
        {
            NetcodePatcher(typeof(TAssemblyMarker).Assembly);
        }

        private static void NetcodePatcher(Assembly assembly)
        {
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (var method in methods)
                {
                    var attributes = method.GetCustomAttributes(typeof(RuntimeInitializeOnLoadMethodAttribute), false);
                    if (attributes.Length > 0)
                    {
                        method.Invoke(null, null);
                    }
                }
            }
        }
    }
}
