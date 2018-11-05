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
        public ActionResult Detail(int id)
        {
            var person = db.People.Find(id);

            PersonDashboardVM detailedPerson = new PersonDashboardVM
            {
                //personal info
                FullName = person.FullName,
                PreferredName = person.PreferredName,
                PhoneNumber = person.PhoneNumber,
                FaxNumber = person.FaxNumber,
                EmailAddress = person.EmailAddress,
                ValidFrom = person.ValidFrom,
                //adjust photo here
                Photo = person.Photo
            };

            if (person.Customers2.FirstOrDefault() == null)
                return View(detailedPerson);

            if (person.Customers2.FirstOrDefault().PrimaryContactPersonID == id)
            {
                //company info
                var customer = db.People.Find(id).Customers2.FirstOrDefault();
                detailedPerson.CompanyName = customer.CustomerName;
                detailedPerson.CompanyPhoneNumber = customer.PhoneNumber;
                detailedPerson.CompanyFaxNumber = customer.PhoneNumber;
                detailedPerson.Website = customer.WebsiteURL;
                //adjust below to only year
                detailedPerson.YearStarted = customer.ValidFrom.Year;

                //purchases info
                detailedPerson.TotalOrders = customer.Orders.Count();
                detailedPerson.GrossSales = customer.Orders.Sum(n => n.Invoices.Sum(n2 => n2.InvoiceLines.Sum(n3 => n3.ExtendedPrice)));
                detailedPerson.GrossProfit = customer.Orders.Sum(n => n.Invoices.Sum(n2 => n2.InvoiceLines.Sum(n3 => n3.LineProfit)));

                var test = customer.Orders.SelectMany(n => n.Invoices.SelectMany(n2 => n2.InvoiceLines.Select(n3 => new { StockItemID = n3.StockItemID, LineProfit = n3.LineProfit, Description = n3.Description, SP = n3.Invoice.Person4.FullName }))).OrderByDescending(n4 => n4.LineProfit).Take(10).ToList();

                detailedPerson.MostProfitableItems = new List<ItemPurchased>(); 

                for (int i = 0; i < test.Count(); i++)
                {
                    detailedPerson.MostProfitableItems.Add(new ItemPurchased(test.ElementAt(i).StockItemID, test.ElementAt(i).Description, test.ElementAt(i).LineProfit, test.ElementAt(i).SP));
                }
                return View(detailedPerson);
            }


            //remember to put in filler photo

            return View(detailedPerson);
        }

    }
}