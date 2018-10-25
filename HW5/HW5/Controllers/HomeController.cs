using HW5.Models;
using HW5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW5.Controllers
{
    public class HomeController : Controller
    {
        private TennantRequestContext db = new TennantRequestContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,PhoneNumber,ApartmentName,UnitNumber,Description")] TennantRequest tennant)
        {
            if (ModelState.IsValid)
            {
                db.TennantRequests.Add(tennant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tennant);
        }
    }
}