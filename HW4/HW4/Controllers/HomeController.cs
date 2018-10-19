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

        [HttpGet]
        public ActionResult Converter()
        {
            string miles = (Request.QueryString["miles"]);
            
            if(miles != null)
            {
                string units = (Request.QueryString["unit"]);
                double distance = 0;
                switch (units)
                {
                    case "millimeters":
                        distance = Convert.ToInt32(miles) * 1609344;
                        break;
                    case "centimeters":
                        distance = Convert.ToInt32(miles) * 160934.4;
                        break;
                    case "meters":
                        distance = Convert.ToInt32(miles) * 1609.344;
                        break;
                    case "kilometers":
                        distance = Convert.ToInt32(miles) * 1.609344;
                        break;
                }

                string message = miles + " miles is equal to " + distance + units;
                ViewBag.message = message;
            }
            return View();
        }

    }
}