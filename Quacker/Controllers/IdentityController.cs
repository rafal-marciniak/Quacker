using System.Web.Mvc;

namespace Quacker.Controllers
{
	public class IdentityController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
    }
}