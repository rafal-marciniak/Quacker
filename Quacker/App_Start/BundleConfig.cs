using System.Web.Optimization;

namespace Quacker
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			//styles:
			bundles.Add(new StyleBundle("~/Content/css").Include(
				"~/Content/bootstrap.css",
				"~/Content/site.css"));

			//scripts:
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
				"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
				"~/Scripts/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
				"~/Scripts/bootstrap.js",
				"~/Scripts/respond.js"));

			bundles.Add(new ScriptBundle("~/bundles/angular").Include(
				"~/Scripts/angular.js",
				"~/Scripts/angular-route.js",
				"~/Scripts/angular-cookies.js"));

			bundles.Add(new ScriptBundle("~/bundles/quacker").Include(
				"~/Scripts/quacker.js",
				"~/Scripts/quackerLoginController.js",
				"~/Scripts/quackerDashboardController.js",
				"~/Scripts/quackerDirectives.js"));

			bundles.Add(new ScriptBundle("~/bundles/moment").Include("~/Scripts/moment.js"));
		}
	}
}
