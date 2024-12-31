using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Windows;

namespace BasyFirstMod.Services.Pranking.Pranks.Cameras
{
    public class StartOfRoundPatch
    {
        [HarmonyPatch(typeof(StartOfRound), "Update")]
        [HarmonyPostfix]
        public static void UpdatePatch()
        {
            var localPlayer = StartOfRound.Instance.localPlayerController;
            if (localPlayer is null)
            {
                return;
            }

            var camera = localPlayer.gameplayCamera;
            //camera.projectionMatrix = FishEyeMatrix(camera);
        }

        private static Matrix4x4 RandomMatrix(Camera camera)
        {
            var originalMatrix = camera.projectionMatrix;
            originalMatrix.m01 += Mathf.Sin(Time.time * 1.2F) * 0.1F;
            originalMatrix.m10 += Mathf.Sin(Time.time * 1.5F) * 0.1F;
            return originalMatrix;
        }

        private static Matrix4x4 FishEyeMatrix(Camera camera)
        {
            float near = camera.nearClipPlane;
            float far = camera.farClipPlane;

            float multiplier = Mathf.Sin(Time.time * 1.2F);
            float left = -0.2F * multiplier;
            float right = 0.2F * multiplier;
            float top = 0.2F * multiplier;
            float bottom = -0.2F * multiplier;

            float x = 2.0F * near / (right - left);
            float y = 2.0F * near / (top - bottom);
            float a = (right + left) / (right - left);
            float b = (top + bottom) / (top - bottom);
            float c = -(far + near) / (far - near);
            float d = -(2.0F * far * near) / (far - near);
            float e = -1.0F;
            Matrix4x4 m = new Matrix4x4();
            m[0, 0] = x;
            m[0, 1] = 0;
            m[0, 2] = a;
            m[0, 3] = 0;
            m[1, 0] = 0;
            m[1, 1] = y;
            m[1, 2] = b;
            m[1, 3] = 0;
            m[2, 0] = 0;
            m[2, 1] = 0;
            m[2, 2] = c;
            m[2, 3] = d;
            m[3, 0] = 0;
            m[3, 1] = 0;
            m[3, 2] = e;
            m[3, 3] = 0;
            return m;
        }
    }
}
