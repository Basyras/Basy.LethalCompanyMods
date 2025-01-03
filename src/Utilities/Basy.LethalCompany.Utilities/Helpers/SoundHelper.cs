using GameNetcodeStuff;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Basy.LethalCompany.Utilities
{
    public class SoundHelper
    {


        public static AudioSource PlayAtPlayerLocally(AudioClip audioClip)
        {
            var currentPlayer = StartOfRound.Instance.localPlayerController;
            currentPlayer.movementAudio.PlayOneShot(audioClip, 1f);
            return currentPlayer.movementAudio;
        }
    }
}
