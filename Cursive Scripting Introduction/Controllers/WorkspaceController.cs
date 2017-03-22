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
            return View("Index", workspace);
        }
    }
}