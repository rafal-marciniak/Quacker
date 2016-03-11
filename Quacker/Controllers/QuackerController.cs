using Domain;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Quacker.Controllers
{
	public class QuackerController : Controller
	{
		private IQuackService _service;

		public QuackerController(IQuackService service)
		{
			_service = service;
		}

		public ActionResult Dashboard()
		{
			return View();
		}

		public JsonResult GetQuacks(int? id = null)
		{
			IEnumerable<Quack> quacks;

			if (id.HasValue)
			{
				quacks = _service.GetReplies(id.Value);
			}
			else
			{
				quacks = _service.GetAll();
			}

			return new JsonResult
			{
				JsonRequestBehavior = JsonRequestBehavior.AllowGet, // temporarily?
				Data = quacks
			};
		}
	}
}