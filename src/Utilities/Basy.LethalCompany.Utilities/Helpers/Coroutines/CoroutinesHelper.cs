using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Basy.LethalCompany.Utilities.Helpers.Coroutines
{
    public class CoroutinesHelper
    {
        public IEnumerator FromTask(Task task)
        {
            var wait = new WaitForSeconds(0.1f);
            while (task.IsCompleted is false && task.IsFaulted is false && task.IsCanceled is false)
            {
                yield return wait;
            }

            if(task.IsFaulted)
            {
                throw task.Exception;
            }
        }

        public void RunTask(Task task)
        {
            var coroutine = FromTask(task);
            BLUtils.Players.GetLocalPlayer().StartCoroutine(coroutine);
        }

        public void RunCoroutine(IEnumerator coroutine)
        {
            BLUtils.Players.GetLocalPlayer().StartCoroutine(coroutine);
        }
    }
}
