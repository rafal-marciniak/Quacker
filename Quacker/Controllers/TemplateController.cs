using System.Web.Mvc;

namespace Quacker.Controllers
{
	/// <summary>
	/// A controller to serve partial views as templates
	/// </summary>
	public class TemplateController : Controller
	{
		public ActionResult Login()
		{
			return PartialView("~/Views/Identity/Login.cshtml");
		}

		public ActionResult Dashboard()
		{
			return PartialView("~/Views/Quacker/Dashboard.cshtml");
		}
	}
}