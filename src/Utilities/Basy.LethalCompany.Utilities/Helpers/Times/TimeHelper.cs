using LethalLib.Modules;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Basy.LethalCompany.Utilities.Helpers.Times
{
    public class TimeHelper
    {
        public IEnumerator ExecuteFor(float seconds, Action<ExecuteForContext> action)
        {
            var context = new ExecuteForContext();
            context.TimeExecutedSec = 0;
            context.TimeLeftSec = seconds;
            context.TimeRequstedSec = seconds;
            while (context.TimeLeftSec >= 0.0f)
            {
                context.TimeLeftSec -= Time.deltaTime;
                context.TimeExecutedSec += Time.deltaTime;
                action.Invoke(context);
                yield return null;
            }
        }

        public IEnumerator ExecuteFor(float seconds, Action action)
        {
            return ExecuteFor(seconds, (s) => action.Invoke());
        }
    }
}
