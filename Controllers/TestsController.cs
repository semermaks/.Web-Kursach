using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Timers;
using System.Web.Mvc;
using TestKursach2.Helpers;
using TestKursach2.Models;

namespace TestKursach2.Controllers
{
	public class TestsController : Controller
	{
		public Test test2 { get; set; }
		public int result { get; set; }
		private TestsContext db = new TestsContext();
		// GET: Tests
		public ActionResult Index()
		{
			return View(db.Test);
		}

		// GET: Tests/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Test test = db.Test.Find(id);
			if (test == null)
			{
				return HttpNotFound();
			}
			return View(test);
		}

		// GET: Tests/Create
		public ActionResult Create()
		{
			ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Text");
			ViewBag.Question = db.Questions.ToList();
			return View();
		}

		// POST: Tests/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Name,Time")] Test test)
		{
			if (ModelState.IsValid)
			{
				test.OvnerId = UserInfo.User.Id;
				string _ = Request.Form["mycheckbox"];
				foreach (var item in _.Split(','))
				{
					foreach (var item2 in db.Questions)
					{
						if (int.Parse(item) == item2.Id) test.Questions.Add(item2);
					}
				}
				db.Test.Add(test);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(test);
		}

		// GET: Tests/Edit/5
		public ActionResult Edit(int? id)
		{
			ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Text");
			ViewBag.Question = db.Questions;
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Test test = db.Test.Find(id);
			if (test == null)
			{
				return HttpNotFound();
			}
			return View(test);
		}

		// POST: Tests/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name")] Test test)
		{
			if (ModelState.IsValid)
			{
				db.Entry(test).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(test);
		}

		public ActionResult Start(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Test test = db.Test.Find(id);
			if (test == null)
			{
				return HttpNotFound();
			}
			ViewBag.time = test.Time * 60 * 1000;
			List<Question> quest = (List<Question>)test.Questions;
			Random rand = new Random();
			var shuffled = quest.OrderBy(_ => rand.Next()).ToList();
			test.Questions = shuffled;
			return View(test);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Start([Bind(Include = "Id,Name")] Test test)
		{
			test2 = db.Test.Find(test.Id);
			string final = "";
			result = 0;
			bool _1 = false, _2 = false, _3 = false, _4 = false;
			foreach (var item in db.Questions)
			{
				final = item.Id + "_1";
				if (Request.Form[final] != null)
				{
					_1 = false;
					_2 = false;
					_3 = false;
					_4 = false;
					if (item.Answer1Right == true && Request.Form[final] != "false" || item.Answer1Right == false && Request.Form[final] == "false")
					{
						_1 = true;
					}
					final = item.Id + "_2";
					if (item.Answer2Right == true && Request.Form[final] != "false" || item.Answer2Right == false && Request.Form[final] == "false")
					{
						_2 = true;
					}
					final = item.Id + "_3";
					if (item.Answer3Right == true && Request.Form[final] != "false" || item.Answer3Right == false && Request.Form[final] == "false")
					{
						_3 = true;
					}
					final = item.Id + "_4";
					if (item.Answer4Right == true && Request.Form[final] != "false" || item.Answer4Right == false && Request.Form[final] == "false")
					{
						_4 = true;
					}
					if (_1 && _2 && _3 && _4) result++;
				}
			}
			result *= 100;
			result /= test2.Questions.Count;
			TestsResults.Load();
			if (!TestsResults.IsExist(test.Id))
			{
				TestsResults.Add(UserInfo.User.Id, test.Id, result);
			}
			return RedirectToAction("Index", "User");
		}
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Test test = db.Test.Find(id);
			if (test == null)
			{
				return HttpNotFound();
			}
			return View(test);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Test test = db.Test.Find(id);
			db.Test.Remove(test);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
