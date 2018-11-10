using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HW7.Controllers
{
    public class TranslatorController : Controller
    {
        // GET: Translator
        public JsonResult Translate(string word)
        {
            
            var key = System.Web.Configuration.WebConfigurationManager.AppSettings["APIKey"];
            //string source = "https://api.giphy.com/v1/stickers/translate?api_key="+key+"&s=" + word;
            string source = "https://api.giphy.com/v1/stickers/translate?api_key=" + key + "&s=lobster";

            //WebRequest request = WebRequest.Create(@source);        
            //WebResponse response = request.GetResponse();
            //Stream dataStream = response.GetResponseStream();
            //Console.WriteLine("check 1");
            /*
            StreamReader reader = new StreamReader(dataStream);
            Console.WriteLine("check 2");
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine("check 3");

            reader.Close();*/
            //dataStream.Close();     
            //response.Close();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(source);
           
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine("check 1///");
            response.Close();
            //var data = ProcessData(responseFromServer);
            //Console.WriteLine(responseFromServer);
            var data = new {test = "something"};
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}