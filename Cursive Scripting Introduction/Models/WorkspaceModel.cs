﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cursive_Scripting_Introduction.Models
{
    public class WorkspaceModel
    {
        public WorkspaceModel(string workspaceDefinition)
            : this(workspaceDefinition, null) { }

        public WorkspaceModel(string workspaceDefinition, string processDefinition)
        {
            WorkspaceDefinition = workspaceDefinition;
            ProcessDefinition = processDefinition;
        }

        public string WorkspaceDefinition { get; }
        public string ProcessDefinition { get; }

        public bool FixedSingleProcess { get; set; } = false;
        public bool DisableVariables { get; set; } = false;
        public bool HideProcessFilter { get; set; } = false;
        public string ProcessListCaption { get; set; } = "Drag to use, click to edit";
    }
}