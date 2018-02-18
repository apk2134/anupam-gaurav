using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookEntity;
using BookRent.Models;
using BookRentBL;
using System.IO;

namespace BookRent.Controllers
{
    [AuthorizationFilter.AuthorizationFilter]

    public class BooksController : Controller
    {
        public ActionResult GetBookScreen()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetBookScreen(BookViewModel bookViewModel)
        {

            BookManager bmanager = new BookManager();
            bmanager.CreateBook(bookViewModel.BookId, bookViewModel.BookName, bookViewModel.Publisher, bookViewModel.Availability, bookViewModel.AuthorId, bookViewModel.CategoryId);
            //return RedirectToAction("Index", "Admin");
            return PartialView("UploadBookImage");

        }

        public ActionResult UploadBookImage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadBookImage(FormCollection fc, HttpPostedFileBase file)
        {

            var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", ".jpeg",".JPG"
        };

            var fileName = Path.GetFileName(file.FileName);
            var ext = Path.GetExtension(file.FileName);
            if (allowedExtensions.Contains(ext))
            {
                string name = Path.GetFileNameWithoutExtension(fileName);
                string myfile = "x" + ext;

                var path = Path.Combine("D:/myProjects/mytest-master/update/BookRent/BookRent/BookImages/ ", myfile);
                //    Server.MapPath(~/ BookRent / BookImages)  
                file.SaveAs(path);
            }
            else
            {
                ViewBag.message = "Please choose only Image file";
            }
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Authors author)
        {
            AuthorManager amanager = new AuthorManager();
            amanager.CreateAuthor(author);
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryManager cmanager = new CategoryManager();
            cmanager.CreateCategory(category);
            return RedirectToAction("Index", "Admin");
        }


        public ActionResult GetBookMenu()
        {
            return View();
        }
        public ActionResult UpdateBook()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult UpdateBook(string isBn)
        {
            try
            {
                BookManager bmanager = new BookManager();
                var book = bmanager.GetSingleBook(isBn);
                var bookCategory = book.BookCategory.FirstOrDefault(m => m.BookId == isBn);
                var bookAuthor = book.BooksAuthors.FirstOrDefault(m => m.BookId == isBn);
                List<BookViewModel> viewModel = new List<BookViewModel>();

                viewModel.Add(new BookViewModel
                {
                    AuthorId = bookAuthor.AuthorId,
                    CategoryId = bookCategory.CategoryId,
                    BookName = book.BookName,
                    Availability = book.Avalability,
                    Publisher = book.Publisher_,
                    BookId = book.BookId,
                    Author = bookAuthor.Authors.AuthorName,
                    Category = bookCategory.Category.CategoryName


                });
                return PartialView("../Books/SearchResult", viewModel);
            }

            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }

        }
    }
}