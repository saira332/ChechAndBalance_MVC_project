using System.Linq;
using System.Web.Mvc;
using myFirstMVCAPP.Models;

namespace myFirstMVCAPP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        demoDatabaseEntities _db;

        public HomeController() {
            // The model keyword can be added as a namespace by doing using Models
            _db = new demoDatabaseEntities(); //add your own database

        }

        public ActionResult Index()
        {
            student s = new student();

            s.age = 21;
            s.courses = "MPL, Web Engeneering";
            s.name = "ABC";
            _db.students.Add(s);
            _db.SaveChanges();


            var results = (from row in _db.students select row).ToList();
             

            return View(results);
        }


    }
}