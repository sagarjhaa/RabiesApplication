using System.Web;
using System.Web.Optimization;

namespace RabiesApplication.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        //"~/Scripts/jquery-3.2.1.slim.js",
                        "~/Scripts/popper.min.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/DataTables/dataTables.min.js",
                        "~/Scripts/knockout-3.4.2"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      
                      //"~/Content/site.css",
                      "~/Content/bootstrap.css",
                      "~/Content/PagedList.css",
                      //"~/Content/bootstrap-theme.css",
                      //"~/Content/bootswatch/readable/bootstrap.css",
                      "~/Content/DataTables/css/dataTables.bootstrap4.css"
                      ));
        }
    }
}
