using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This will return the Converter view and pass converted miles to it.
        /// </summary>
        /// <returns> Return the Converter view.</returns>
        [HttpGet]
        public ActionResult Converter()
        {
            string miles = (Request.QueryString["miles"]);
            
            //If miles is not empty then convert to selected units.
            if(miles != null)
            {
                string units = (Request.QueryString["unit"]);
                double distance = 0;
                switch (units)
                {
                    case "millimeters":
                        distance = Convert.ToDouble(miles) * 1609344;
                        break;
                    case "centimeters":
                        distance = Convert.ToDouble(miles) * 160934.4;
                        break;
                    case "meters":
                        distance = Convert.ToDouble(miles) * 1609.344;
                        break;
                    case "kilometers":
                        distance = Convert.ToDouble(miles) * 1.609344;
                        break;
                }

                string message = miles + " miles is equal to " + distance + " " + units;
                ViewBag.message = message;
            }
            return View();
        }

    }
}