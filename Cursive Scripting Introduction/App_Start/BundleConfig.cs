using System.Web;
using System.Web.Optimization;

namespace Cursive_Scripting_Introduction
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/cursiveScript").Include(
                        "~/bin/Scripts/cursive.js"));

            bundles.Add(new StyleBundle("~/bundles/cursiveStyle").Include(
                        "~/bin/Style/cursiveDemo.css",
                        "~/Style/workspace.css"));
        }
    }
}
