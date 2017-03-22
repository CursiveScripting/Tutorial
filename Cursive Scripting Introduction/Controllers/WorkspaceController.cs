using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cursive_Scripting_Introduction.Workspaces;
using Cursive_Scripting_Introduction.Models;

namespace Cursive_Scripting_Introduction.Controllers
{
    public class WorkspaceController : Controller
    {
        // GET: Workspace/Lesson1
        public ActionResult Lesson1()
        {
            var workspace = new WorkspaceModel(
                Workspaces.Lesson1.Instance.Value.WriteForClient().OuterXml,
                Workspaces.Lesson1.InitialTemplate
            );
            workspace.FixedSingleProcess = true;
            workspace.DisableVariables = true;
            workspace.HideProcessFilter = true;
            workspace.ProcessListCaption = @"Drag any of the processes listed below into the workspace to use them.

Drag onto the bin to remove a step, and drag from the square next to the bin to add a new ""stop"" step.";
            return View("Index", workspace);
        }

        // GET: Workspace/Lesson2
        public ActionResult Lesson2()
        {
            var workspace = new WorkspaceModel(
                Workspaces.Lesson2.Instance.Value.WriteForClient().OuterXml,
                Workspaces.Lesson2.InitialTemplate
            );
            return View("Index", workspace);
        }
    }
}