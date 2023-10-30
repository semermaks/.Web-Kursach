using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestKursach2.Helpers;
using TestKursach2.Models;

namespace TestKursach2.Controllers
{
	public class UserController : Controller
	{
		private TestsContext db = new TestsContext();

		public ActionResult Index()
		{
			TestsResults.Load();
			var Dict = TestsResults.getDictionary();
			Dictionary<Test, int> tests = new Dictionary<Test, int>();
			foreach (var item in Dict)
			{
				foreach (var item2 in db.Test)
				{
					if (item.Key == item2.Id) tests.Add(item2, item.Value);
				}
			}
			ViewBag.Test = tests;
			return View(db.Users.ToList());
		}

		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			User user = db.Users.Find(id);
			if (user == null)
			{
				return HttpNotFound();
			}
			return View(user);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,LastName,FirstName,Email,Password")] User user)
		{
			if (ModelState.IsValid)
			{
				UserInfo.User = user;
				db.Users.Add(user);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(user);

		}
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			User user = db.Users.Find(id);
			if (user == null)
			{
				return HttpNotFound();
			}
			return View(user);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,Email,Password")] User user)
		{
			if (ModelState.IsValid)
			{
				db.Entry(user).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(user);
		}

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost, ActionName("Login")]
		[ValidateAntiForgeryToken]
		public ActionResult Login([Bind(Include = "Email,Password,LastName,FirstName")] User user)
		{
			foreach (var item in db.Users)
			{
				if (item.Email == user.Email && item.Password == user.Password)
				{
					UserInfo.User = item;
					return RedirectToAction("Index", "Home");
				}
			}
			return View(user);
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
