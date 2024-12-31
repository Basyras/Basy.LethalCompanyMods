using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuildTasks
{
    public abstract class TaskBase : Task
    {
        //private ProjectInstance _project;
        //private ProjectInstance Project 
        //{
        //    get
        //    {
        //        if (_project == null)
        //        {
        //            _project = this.GetProjectInstance();
        //        }

        //        return _project;
        //    }
        //}

        //protected string GetProperty(string name)
        //{
        //    return Project.GetPropertyValue("ProjectName");
        //}
    }
}
