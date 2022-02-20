using System.Web;
using System.Web.Optimization;

namespace SistRE
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Content/plugins/jquery/jquery.min.js",
                       "~/Content/plugins/jquery-ui/jquery-ui.min.js",
                       "~/Content/plugins/bootstrap/js/bootstrap.bundle.min.js",
                       "~/Content/plugins/chart.js/Chart.min.js",
                       "~/Content/plugins/sparklines/sparkline.js",
                       "~/Content/plugins/jqvmap/jquery.vmap.min.js",
                       "~/Content/plugins/jqvmap/maps/jquery.vmap.usa.js",
                       "~/Content/plugins/jquery-knob/jquery.knob.min.js",
                       "~/Content/plugins/moment/moment.min.js",
                       "~/Content/plugins/daterangepicker/daterangepicker.js",
                       "~/Content/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js",
                       "~/Content/plugins/summernote/summernote-bs4.min.js",
                       "~/Content/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js",
                       "~/Content/dist/js/adminlte.js",
                       "~/Content/dist/js/pages/dashboard.js",
                       "~/Content/dist/js/demo.js"));

            bundles.Add(new ScriptBundle("~/bundles/Main").Include(
                      "~/Scripts/Utility.js",
                      "~/Scipts/notify.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                         "~/Content/plugins/fontawesome-free/css/all.min.css",
                         "~/Content/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css",
                         "~/Content/plugins/icheck-bootstrap/icheck-bootstrap.min.css",
                         "~/Content/plugins/jqvmap/jqvmap.min.css",
                         "~/Content/dist/css/adminlte.min.css",
                         "~/Content/plugins/overlayScrollbars/css/OverlayScrollbars.min.css",
                         "~/Content/plugins/daterangepicker/daterangepicker.css",
                         "~/Content/plugins/summernote/summernote-bs4.css"));

          // bundles.Add(new StyleBundle("~/Content/css").Include(
          //                "~/Content/bootstrap.css",
          //                "~/Content/DataTables/css/dataTables.bootstrap.css",
          //                "~/Content/site.css"));

          //bundles.Add(new ScriptBundle("~/bundles/DataTables").Include(
          //                        "~/Scripts/DataTables/jquery.dataTables.min.js",
          //                        "~/Scripts/DataTables/dataTables.bootstrap.js"
          //                        //"~/Scripts/DatatableDefaults.js"
          //                        ));

        }
    }
}
