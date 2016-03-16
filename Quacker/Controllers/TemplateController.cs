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

		public ActionResult QuackForm()
		{
			return PartialView("~/Views/Quacker/QuackForm.cshtml");
		}

		public ActionResult QuackDetails()
		{
			return PartialView("~/Views/Quacker/QuackDetails.cshtml");
		}

		public ActionResult Error404()
		{
			return PartialView("~/Views/Shared/Error404.cshtml");
		}
	}
}