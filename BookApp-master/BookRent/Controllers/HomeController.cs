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

        public int AddBooktoCart(string str)
        {
            int added = 0;

            var bookList = TempData.Peek("bookData") as List<string>;

            if (bookList == null)
            {
                bookList = new List<string>();
                bookList = (bookList as List<string>);
                bookList.Add(str);
                TempData["bookData"] = bookList;
            }
            else
            {

                if (bookList.Contains(str))
                {
                    added = 1;
                    bookList.Remove(str);
                }
                else
                {
                    bookList.Add(str);
                }
                TempData["bookData"] = bookList;
            }

            return added;
          
        }
    }
}