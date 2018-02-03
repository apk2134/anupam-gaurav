using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookEntity;
using BookRentBL;
using BookRent.Models;

namespace BookRent.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult search()
        {
            BookManager bmanager = new BookManager();
            SearchViewModel smodel = new Models.SearchViewModel();
            smodel.SearchBook = bmanager.GetAllBooks();
            return View(smodel);
        }

        public ActionResult order()
        {
            return View();
        }

        public ActionResult subscribe()
        {
            return View();
        }
        public ActionResult Author()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Author(Authors author)
        {
            AuthorManager manager = new AuthorManager();
            manager.CreateAuthor(author);
            return View();

        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Book(Authors author, Books book, Category category)
        {
            Manager bookadd = new Manager();
            bookadd.Createitems(author, book, category);
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}