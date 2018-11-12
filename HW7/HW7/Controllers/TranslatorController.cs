using HW7.DAL;
using HW7.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HW7.Controllers
{
    public class TranslatorController : Controller
    {
        private UserContext db = new UserContext();

        // GET: Translator
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
            string gifUrl;
            bool isImage;
            //need borng definition
            string [] boringWords = {"the", "is", "I", "me", "want", "are", "you", "am"};
            if (boringWords.Contains(word))
            {
                gifUrl = word;
                isImage = false;
            }
            else
            {
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
                    isImage = true;
                }
                catch (Exception e)
                {
                    gifUrl = word;
                    isImage = false;
                }
            }
            var data = new {gif = gifUrl, imageCheck = isImage};
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}