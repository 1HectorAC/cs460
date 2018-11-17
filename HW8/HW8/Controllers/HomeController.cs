using HW8.Models;
using HW8.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HW8.Controllers
{
    public class HomeController : Controller
    {
        AuctionContext db = new AuctionContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListItems()
        {
            return View(db.Items);

        }

        public ActionResult CreateItem()
        {
            return View(db.Sellers);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateItem([Bind(Include = " Name, Description, SellerID")] Item item)
        {
            
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("ListItems");
            }


            return View(db.Sellers);
        }

        public ActionResult DetailItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            
            return View(item);
        }



        // GET:
        public ActionResult EditItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }



        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem([Bind(Include = "ItemID,Name,Description,SellerID")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET:
        public ActionResult DeleteItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: 
        [HttpPost, ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItemConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("ListItems");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult CreateBid()
        {
            BuyerItem BuyersAndItems = new BuyerItem
            {
                Buyers = db.Buyers,
                Items = db.Items
            };

            return View(BuyersAndItems);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBid([Bind(Include = "ItemID,BuyerID,Price")] Bid bid)
        {
            bid.TimeStamp = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Bids.Add(bid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            BuyerItem BuyersAndItems = new BuyerItem
            {
                Buyers = db.Buyers,
                Items = db.Items
            };
            return View(BuyersAndItems);
        }

            public JsonResult ItemBids(int? id)
        {

            //var data = db.Items.Find(id).Bids.OrderByDescending(n => n.Price).Select(n => new { TablePrice = n.Price, TableBuyer = n.Buyer.Name }).ToList();
            var test = db.Items.Find(id).Bids.OrderByDescending(n => n.Price).Select(n => new { TablePrice = n.Price, TableBuyer = n.Buyer.Name }).ToList();
            var data = new {TablePrice = test.Select(n=>n.TablePrice), TableBuyer = test.Select(n=>n.TableBuyer) };

            //var data = new {fewf = 4 };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }


}