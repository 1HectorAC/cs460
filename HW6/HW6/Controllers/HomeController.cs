using HW6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW6.Controllers
{
    public class HomeController : Controller
    {
        WorldWideImportersContext db = new WorldWideImportersContext();
        public ActionResult Index()
        {
            Debug.Write("\n stuff \n \n");
            Debug.Write("\n\n" + db.Cities.Find(3).CityName + "\n\n");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string name)
        {
            /*
            if (ModelState.IsValid)
            {
                tennant.RequestTimeStamp = DateTime.Now;
                db.TennantRequests.Add(tennant);
                db.SaveChanges();
                return RedirectToAction("Display");
            }*/
            var names = 


            //need to enter some variable here, probably colection of names from search
            return View();
        }

    }
}