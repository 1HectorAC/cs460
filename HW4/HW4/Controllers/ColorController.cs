using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Diagnostics;


namespace HW4.Controllers
{
    public class ColorController : Controller
    {

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string first, string second)
        {

            //int one = Convert.ToInt32(first.Substring(1, 2), 16);
            //int two = Convert.ToInt32(first.Substring(3, 4), 16);
            //int three = Convert.ToInt32(first.Substring(5, 6), 16);
            string result = "#";
            for(int i = 1; i <= 5; i+=2)
            {
                int decFirst = Convert.ToInt32(first.Substring(i, 2), 16);
                int decSec = Convert.ToInt32(second.Substring(i, 2), 16);
                if (decFirst + decSec > 255)
                    result = result + "FF";
                else
                {
                    if(decFirst + decSec < 10)
                        result = result + "0" + (decFirst + decSec).ToString("X");
                    else
                        result = result + (decFirst + decSec).ToString("X");
                }
            }
            Debug.WriteLine(first + " + " + second + " = " + result);


            @ViewBag.first = first;
            @ViewBag.second = second;
            @ViewBag.result = result;
            return View();
        }

    }
}