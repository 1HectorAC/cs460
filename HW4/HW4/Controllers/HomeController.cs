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
            string units = (Request.QueryString["unit"]);
            if(miles != null)
            {
                string message = miles + " miles is equal to " + units;
                ViewBag.message = message;
            }
            return View();
        }

    }
}