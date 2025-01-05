using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Basy.LethalCompany.Utilities.Helpers.Networks.Messages
{
    public class TeleportPlayerMessage
    {
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        public float RotationX { get; set; }
        public float RotationY { get; set; }
        public float RotationZ { get; set; }
        public float RotationW { get; set; }
    }
}
