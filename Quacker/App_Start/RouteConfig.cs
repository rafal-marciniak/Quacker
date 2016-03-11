﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Quacker
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
			    defaults: new { controller = "Identity", action = "Login", id = UrlParameter.Optional }
			);

			//routes.MapRoute(
			//	name: "Catch all route for SPA",
			//	url: "App/{*catchall}",
			//	defaults: new { controller = "Quacker", action = "Dashboard" }
			//);
		}
	}
}
