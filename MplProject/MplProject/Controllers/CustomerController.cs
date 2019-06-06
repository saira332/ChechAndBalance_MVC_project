using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        CheckAndBalanceEntities _db;
        public CustomerController()
        {
            _db = new CheckAndBalanceEntities();
        }
        public ActionResult Index()
        {
            var results = (from row in _db.customers select row).ToList();
            return View(results);
        }
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(customer c)
        {
            _db.customers.Add(c);
            _db.SaveChanges();
            return View();
        }
        public ActionResult EditCustomer(int id)
        {
            var result = _db.customers.Single(customer => customer.id == id);
            return View(result);
        }

        [HttpPut]
        public ActionResult EditCustomer(customer s)
        {
            customer result = _db.customers.Single(customer => customer.id == s.id);
            result.name = s.name;
            result.gender = s.gender;
            result.email = s.email;
            result.address = s.address;
            result.contact_no = s.contact_no;
            _db.SaveChanges();
            return View();
        }
        //public ActionResult DeleteCustomer(int id)
        //{
        //    var result = _db.customers.Single(customer => customer.id == id);
        //    return View(result);
        //}
        [HttpDelete]
        public ActionResult DeleteCustomer(int id)
        {
            var result = _db.company_details.Single(company_details => company_details.company_id == id);
            _db.company_details.Remove(result);
            _db.SaveChanges();
            return Redirect("/");
        }
    }
}