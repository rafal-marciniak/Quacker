using Domain;
using System.Web.Mvc;
using System.Web.Routing;

namespace Quacker.Controllers
{
	public class QuackerControllerFactory : DefaultControllerFactory
	{
		public override IController CreateController(RequestContext requestContext, string controllerName)
		{
			if (IsQuackerController(controllerName))
			{
				return new QuackerController(QuackServiceFactory.Create()); // use IoC container in real-life scenario
			}

			return base.CreateController(requestContext, controllerName);
		}

		private bool IsQuackerController(string controllerName)
		{
			return controllerName == "Quacker";
		}
	}
}