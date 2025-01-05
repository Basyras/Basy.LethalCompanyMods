using System;
using System.Collections.Generic;
using System.Text;

namespace Basy.LethalCompany.Utilities.Helpers.Networks
{
    public class NetworkMessageRequest
    {
        public NetworkMessageRequest()
        {
            
        }

        public string MesssageAssemblyQualifiedName { get; set; }
        public string MessageJson { get; set; }
        public ulong[] TargetClientIds { get; set; }
    }
}
