using Microsoft.Build.Execution;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
namespace BuildTasks
{
    //public static class BuildTaskExtensions
    //{
    //    private const BindingFlags BindingFlags = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.FlattenHierarchy | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public;

    //    public static ProjectInstance GetProjectInstance(this Task buildTask)
    //    {
    //        var buildEngineType = buildTask.BuildEngine.GetType();
    //        var callbackName = "_targetBuilderCallback";
    //        var targetBuilderCallbackField = buildEngineType.GetField(callbackName, BindingFlags);
    //        if (targetBuilderCallbackField is null)
    //            throw new InvalidOperationException($"Could not extract {callbackName} from {buildEngineType.FullName}");

    //        var targetBuilderCallback = targetBuilderCallbackField.GetValue(buildTask);
    //        var targetCallbackType = targetBuilderCallback.GetType();
    //        var projectInstanceField = targetCallbackType.GetField("_projectInstance", BindingFlags);

    //        if (projectInstanceField is null)
    //            throw new InvalidOperationException($"Could not extract _projectInstance from {targetCallbackType.FullName}");

    //        if (projectInstanceField.GetValue(targetBuilderCallback) is ProjectInstance project)
    //        {
    //            return project;
    //        }

    //        throw new InvalidOperationException();
    //    }
    //}
}
