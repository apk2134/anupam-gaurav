using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BookRent.Controllers
{
    public class AdminController : Controller
    {
        static List<string> list = new List<string>();
        // GET: Admin
        public ActionResult Index(string code="")
        {
            if(code.Length>2)
            {
                if (list.Count == 0)
                {
                    string aceesToken = GetAccessToken(code);
                    Dictionary<string, string> getData = GetDataFromGmail(aceesToken);
                    list.Add(ViewBag.Username);
                    ViewBag.Username = getData["name"];
                    list.Add(ViewBag.Username);

                }

                else
                {
                    ViewBag.Username = list.FirstOrDefault(a=>a!=null&&a.Length>1);
                }
            }
            else
            {
                AuthorizetoGoogle();
            }
            return View();
        }

        private Dictionary<string, string> GetDataFromGmail(string aceesToken)
        {

            var Client = new HttpClient();
            Client.BaseAddress = new Uri("https://www.googleapis.com/oauth2/v1/userinfo");
            var re = Client.GetAsync("?alt=json&access_token=" + aceesToken).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(re);

        }

        private string GetAccessToken(string code)
        {

            try
            {
                string accesstoke;
                string ClientId = ConfigurationManager.AppSettings["ClientId"];
                string ClientSecreat = ConfigurationManager.AppSettings["ClientSecreat"];
                string RedirectUrl = "http://localhost:3847/Admin/Index";
                var Content = "code=" + code + "&client_id=" + ClientId + "&client_secret=" + ClientSecreat + "&redirect_uri=" + RedirectUrl + "&grant_type=authorization_code";
                WebRequest request = WebRequest.Create("https://accounts.google.com/o/oauth2/token");
                request.Method = "Post";
                request.ContentType = "application/x-www-form-urlencoded";
                byte[] byteArray = Encoding.UTF8.GetBytes(Content);

                request.ContentLength = byteArray.Length;

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                }

                using (var response = request.GetResponse())
                {
                    Stream responseDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(responseDataStream);
                    string ResponseData = reader.ReadToEnd();
                    reader.Close();
                    responseDataStream.Close();

                    var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(ResponseData);

                    accesstoke = data["access_token"];
                    // WebRequest req = WebRequest.Create("https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token=youraccess_token" + accesstoke);
                    // var resp = req.GetResponse();
                    var Client = new HttpClient();
                    Client.BaseAddress = new Uri("https://www.googleapis.com/oauth2/v1/userinfo");

                    var re = Client.GetAsync("?alt=json&access_token=" + accesstoke).Result.Content.ReadAsStringAsync().Result;

                };
                return accesstoke;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        private void AuthorizetoGoogle()
        {
            string url = GetAuthrozieAndThenComeback();
            Response.Redirect(url, false);
        }

        private string GetAuthrozieAndThenComeback()
        {
            string ClientID= ConfigurationManager.AppSettings["ClientId"];
            string Scopes = "https://www.googleapis.com/auth/userinfo.email";
            string RedirectUrl = "http://localhost:3847/Admin/Index";
            string Url = "https://accounts.google.com/o/oauth2/auth?";
            StringBuilder UrlBuilder = new StringBuilder(Url);
            UrlBuilder.Append("client_id=" + ClientID);
            UrlBuilder.Append("&redirect_uri=" + RedirectUrl);
            UrlBuilder.Append("&response_type=" + "code");
            UrlBuilder.Append("&scope=" + Scopes);
            UrlBuilder.Append("&access_type=" + "offline");
            UrlBuilder.Append("&state="); 
            return UrlBuilder.ToString();
        }

        //[HttpPost]
        //    public ActionResult  Index(string option)
        //    {
        // //        //TODO


        //    }
    }
}