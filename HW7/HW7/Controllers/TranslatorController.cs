using HW7.DAL;
using HW7.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace HW7.Controllers
{
    public class TranslatorController : Controller
    {
        private UserContext db = new UserContext();

        /// <summary>
        /// This action method takes in a word and tranlate it to a gif representation of it.
        /// </summary>
        /// <param name="word">This is the word that needs to be tranlated.</param>
        /// <returns>It returns a JsonResult object which contains the gif url link.</returns>
        public JsonResult Translate(string word)
        {
            //Log user information in database.
            User currentUser = new User
            {
                LogDate = DateTime.Today,
                RequestedWord = word,
                RequestorsIPAddress = this.Request.UserHostAddress,
                RequestorsBrowser = this.Request.Browser.Type
            };
            db.Users.Add(currentUser);
            db.SaveChanges();

            //This will hold the gif url for the tranlated word.
            string gifUrl;

            //This is part is retriving information from the api.
            try
            {
                var key = System.Web.Configuration.WebConfigurationManager.AppSettings["APIKey"];
                string source = "https://api.giphy.com/v1/stickers/translate?api_key=" + key + "&s=" + word;

                WebRequest request = WebRequest.Create(@source);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                reader.Close();
                dataStream.Close();
                response.Close();

                JObject gifObject = JObject.Parse(responseFromServer);
                gifUrl = gifObject["data"]["images"]["original"]["url"].ToString();
            }
            catch (Exception e)
            {
                gifUrl = word;
            }

            var data = new { gif = gifUrl };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}