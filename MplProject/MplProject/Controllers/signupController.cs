using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MplProject.Models;

namespace MplProject.Controllers
{
    public class signupController : Controller
    {
        // GET: signup
        CheckAndBalanceEntities _db;
        public signupController()
        {
            _db = new CheckAndBalanceEntities();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult usersignup(signup s, string question, string status)
        {
            _db.signups.Add(s);
            _db.SaveChanges();
            return RedirectToAction("Index", "login");
        }
    }

}