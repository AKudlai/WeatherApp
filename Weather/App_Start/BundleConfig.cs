namespace Weather
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/bootstrap")
                .Include("~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/site")
                .Include("~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.intellisense.js", 
                    "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.bundle.min.js"));
        }
    }
}