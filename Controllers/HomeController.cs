using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestKursach2.Helpers;

namespace TestKursach2.Controllers
{
	public class HomeController : Controller
	{
		private TestsContext db = new TestsContext();
		public ActionResult Index()
		{
			return View(db.Test);
		}
	}
}