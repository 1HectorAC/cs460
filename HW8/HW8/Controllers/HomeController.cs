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

        /// <summary>
        /// Get index View and pass it a list of recent 10 bids from Bids.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.TodayDate = DateTime.Today.ToString("d");
            return View(db.Bids.OrderByDescending(n => n.TimeStamp).Take(10).ToList());
        }

        /// <summary>
        /// Get the ListItems view and pass it a list of all the Items.
        /// </summary>
        /// <returns></returns>
        public ActionResult ListItems()
        {
            return View(db.Items.ToList());
        }

        /// <summary>
        /// Use GET and return createItem View.
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateItem()
        {
            return View(db.Sellers);
        }

        /// <summary>
        /// Use Post and Return a View. This will also add changes to database.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get the DetailItem View. This will also pass an item of an item based on the id passed to it.
        /// </summary>
        /// <param name="id">The id of an Item.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Use GET and return a EditItem View.
        /// </summary>
        /// <param name="id">The id of an item in Items.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Use POST and return a EditItem View. This will save changes made to an Item in Items.
        /// </summary>
        /// <param name="item">The item that will be edited.</param>
        /// <returns></returns>
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

        /// <summary>
        /// This will use GET and return an item based on the id passed to it.
        /// </summary>
        /// <param name="id">The id of an item in Items.</param>
        /// <returns></returns>
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

        /// <summary>
        /// This will use Post and return a DeleteItemConfimed View. This actually remove an item from Items.
        /// </summary>
        /// <param name="id">The id of an item from Items.</param>
        /// <returns></returns>
        [HttpPost, ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItemConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("ListItems");
        }

        /// <summary>
        /// This is involved in deletion.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This will use GET and return a CreateBid View.
        /// </summary>
        /// <returns>CreateBid View</returns>
        public ActionResult CreateBid()
        {
            BuyerItem BuyersAndItems = new BuyerItem
            {
                Buyers = db.Buyers,
                Items = db.Items
            };

            return View(BuyersAndItems);
        }

        /// <summary>
        /// This will use Post and will either redirect or return a CreateBid View.
        /// </summary>
        /// <param name="bid">This is a binded bid that will be added to Bids</param>
        /// <returns>CreateBid View.</returns>
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

        /// <summary>
        /// This will create a var object and store the bids of a specified item (only the information that is needed) and then return a JsonResult with the infomation.
        /// </summary>
        /// <param name="id">The id of an Item in Items.</param>
        /// <returns>A JsonResult.</returns>
        public JsonResult ItemBids(int? id)
        {

            var test = db.Items.Find(id).Bids.OrderByDescending(n => n.Price).Select(n => new { TablePrice = n.Price, TableBuyer = n.Buyer.Name }).ToList();
            var data = new { TablePrice = test.Select(n => n.TablePrice), TableBuyer = test.Select(n => n.TableBuyer) };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }


}