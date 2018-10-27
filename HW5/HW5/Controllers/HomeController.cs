using HW5.Models;
using HW5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace HW5.Controllers
{
    public class HomeController : Controller
    {
        private TennantRequestContext db = new TennantRequestContext();

        /// <summary>
        /// This is the action to get the index view.
        /// </summary>
        /// <returns>Index view wll be returned.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This is the action to get the index view. This is to display the values of the database.
        /// </summary>
        /// <returns> Display view will be returned.</returns>
        public ActionResult Display()
        {
            return View(db.TennantRequests.ToList());
        }

        /// <summary>
        /// This is the action to get the Create view with GET.
        /// </summary>
        /// <returns> Create view will be returned.</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// This is the action to get the Create view with POST.
        /// </summary>
        /// <param name="tennant"></param>
        /// <returns>Create view will be returned.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,PhoneNumber,ApartmentName,UnitNumber,RequestDescription,AllowEnter")] TennantRequest tennant)
        {
            if (ModelState.IsValid)
            {
                tennant.RequestTimeStamp = DateTime.Now;
                db.TennantRequests.Add(tennant);
                db.SaveChanges();
                return RedirectToAction("Display");
            }

            return View(tennant);
        }
        
    }
}