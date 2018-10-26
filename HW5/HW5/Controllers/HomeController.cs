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

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Display()
        {
            return View(db.TennantRequests.ToList());
        }
        /*
        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TennantRequest user = db.TennantRequests.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }*/

        public ActionResult Create()
        {
            return View();
        }
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
        
        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TennantRequest user = db.TennantRequests.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TennantRequest user = db.TennantRequests.Find(id);
            db.TennantRequests.Remove(user);
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