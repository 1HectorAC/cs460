using HW6.Models;
using HW6.Models.ViewModels;
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

        /// <summary>
        /// Create Index view and pass it a person list based on the search name provided by query (if it has one)
        /// </summary>
        /// <returns>Return the Index View.</returns>
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

        /// <summary>
        /// Create Detail view.
        /// </summary>
        /// <param name="id">The id of person we are looking up.</param>
        /// <returns>Return the Detail View.</returns>
        [HttpPost]
        public ActionResult Detail(int id)
        {
            var person = db.People.Find(id);

            //Setup detailedPerson with personal info
            PersonDashboardVM detailedPerson = new PersonDashboardVM
            {
                //personal info
                FullName = person.FullName,
                PreferredName = person.PreferredName,
                PhoneNumber = person.PhoneNumber,
                FaxNumber = person.FaxNumber,
                EmailAddress = person.EmailAddress,
                ValidFrom = person.ValidFrom,
                Photo = person.Photo
            };

            //check if customers2 is null and return if so
            if (person.Customers2.FirstOrDefault() == null)
                return View(detailedPerson);

            //Fill in detailedPerson with more information if matches customer2 id
            if (person.Customers2.FirstOrDefault().PrimaryContactPersonID == id)
            {
                //company info
                var customer = db.People.Find(id).Customers2.FirstOrDefault();
                detailedPerson.CompanyName = customer.CustomerName;
                detailedPerson.CompanyPhoneNumber = customer.PhoneNumber;
                detailedPerson.CompanyFaxNumber = customer.PhoneNumber;
                detailedPerson.Website = customer.WebsiteURL;
                detailedPerson.YearStarted = customer.ValidFrom.Year;

                //purchases info
                detailedPerson.TotalOrders = customer.Orders.Count();
                detailedPerson.GrossSales = customer.Orders.Sum(n => n.Invoices.Sum(n2 => n2.InvoiceLines.Sum(n3 => n3.ExtendedPrice)));
                detailedPerson.GrossProfit = customer.Orders.Sum(n => n.Invoices.Sum(n2 => n2.InvoiceLines.Sum(n3 => n3.LineProfit)));

                //make list of top 10 purchases
                var topPurchases = customer.Orders.SelectMany(n => n.Invoices.SelectMany(n2 => n2.InvoiceLines.Select(n3 => new { StockItemID = n3.StockItemID, LineProfit = n3.LineProfit, Description = n3.Description, SP = n3.Invoice.Person4.FullName }))).OrderByDescending(n4 => n4.LineProfit).Take(10).ToList();

                detailedPerson.MostProfitableItems = new List<ItemPurchased>(); 
                
                //populate detailedPersons mostProfitable Item list with topPurchases
                for (int i = 0; i < topPurchases.Count(); i++)
                {
                    detailedPerson.MostProfitableItems.Add(new ItemPurchased(topPurchases.ElementAt(i).StockItemID, topPurchases.ElementAt(i).Description, topPurchases.ElementAt(i).LineProfit, topPurchases.ElementAt(i).SP));
                }
                return View(detailedPerson);
            }

            return View(detailedPerson);
        }

    }
}