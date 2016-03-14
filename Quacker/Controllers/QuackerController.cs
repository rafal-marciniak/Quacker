using Domain;
using System.Collections.Generic;
using System.Linq;
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

		public JsonResult Get(int? id = null)
		{
			IEnumerable<Quack> quacks;

			if (id.HasValue)
			{
				quacks = _service.GetReplies(id.Value).OrderBy(q => q.CreationDate);
			}
			else
			{
				quacks = _service.GetAll().OrderByDescending(q => q.CreationDate);
			}

			return new JsonResult
			{
				JsonRequestBehavior = JsonRequestBehavior.AllowGet, // temporarily?
				Data = quacks
			};
		}

		public ActionResult Add(Quack quack)
		{
			var result = _service.Add(quack);
			return new JsonResult { Data = result };
		}
	}
}