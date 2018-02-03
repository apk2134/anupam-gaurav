using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testing.Models;
using testing.RentBook;

namespace testing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Admin(admin u)
        {
            //if (ModelState.IsValid)
            //{
            //    using (DB_Entities db = new DB_Entities())
            //    {
            //        var obj = db.UserProfiles.Where(a => a.UserName.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();
            //        if (obj != null)
            //        {
            //            Session["UserID"] = obj.UserId.ToString();
            //            Session["UserName"] = obj.UserName.ToString();
            //            return RedirectToAction("UserDashBoard");
            //        }
            //    }
            //}
            RentBookDAL a = new RentBook.RentBookDAL();
            u.Username = a.test();
            return View(u);
        }

        public ActionResult AdminLogedin()
        {
            return View();
        }

        public ActionResult AddBook()
        {
            return View();
        }
    }
}