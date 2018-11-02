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
            string name = (Request.QueryString["name"]);
            if (name != null)
            {
                ViewBag.name = name;
                return View(db.People.Where(n => n.SearchName.Contains(" " + name + " ")).ToList());

            }
            return View();
        }
        [HttpPost]
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
            //have stuff here
   
            var people = db.People.Where(n => n.SearchName.Contains(" " + name + " "));




            //need to enter some variable here, probably colection of names from search
            return View(people.ToList());
        }

        [HttpPost]
        public ActionResult Detail(int id)
        {
            var person = db.People.Find(id);

            //var person = db.People.FirstOrDefault();
            return View(person);
        }

    }
}