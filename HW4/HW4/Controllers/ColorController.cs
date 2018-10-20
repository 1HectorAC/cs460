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
        /// <summary>
        /// It will create the Create view. This will be called when GET is requested.
        /// </summary>
        /// <returns>The Create view will be returned.</returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// It will create the Create view. This will be called when Post is requested.
        /// </summary>
        /// <param name="colorA">This is the first hexadecimal color to mix.</param>
        /// <param name="colorB">This is the second hexadecimal color to mix.</param>
        /// <returns>The Create view will be returned.</returns>
        [HttpPost]
        public ActionResult Create(string colorA, string colorB)
        {
            string mixedColor = "#";
            //Check for invalid length of 4 or 5 for color string not including the #.
            //Note that html validation will already restrict length of colorA and colorB from 3 to 6.
            if (!(colorA.Length == 5 || colorA.Length == 6 || colorB.Length == 5 || colorB.Length == 6))
            {
                //Check if colorA and colorB are 3 character and adjust it to 6 if so, not conting the #.
                if (colorA.Length == 4)
                {
                    colorA = "#" + colorA[1] + colorA[1] + colorA[2] + colorA[2] + colorA[3] + colorA[3];
                }
                if (colorB.Length == 4)
                {
                    colorB = "#" + colorB[1] + colorB[1] + colorB[2] + colorB[2] + colorB[3] + colorB[3];
                }

                //Setup up mixedColor with mix of colorA and colorB.
                for (int i = 1; i <= 5; i += 2)
                {
                    //Convert part of colorA to decimal.
                    int colorDecimalA = Convert.ToInt32(colorA.Substring(i, 2), 16);
                    //Convert part of colorB to decimal.
                    int colorDecimalB = Convert.ToInt32(colorB.Substring(i, 2), 16);
                    //Check if addition of colorDecimalA and colorDecimalB is too high.
                    if (colorDecimalA + colorDecimalB >= 255)
                        mixedColor = mixedColor + "FF";
                    else
                    {
                        //Make sure that 0(s) is added properly when converting back to hexadecimal.
                        if (colorDecimalA + colorDecimalB == 0)
                            mixedColor = mixedColor + "00";
                        else if (colorDecimalA + colorDecimalB < 10)
                            mixedColor = mixedColor + "0" + (colorDecimalA + colorDecimalB).ToString("X");
                        else
                            mixedColor = mixedColor + (colorDecimalA + colorDecimalB).ToString("X");
                    }
                }
            }
           
            @ViewBag.first = colorA;
            @ViewBag.second = colorB;
            @ViewBag.result = mixedColor;
            return View();
        }

    }
}