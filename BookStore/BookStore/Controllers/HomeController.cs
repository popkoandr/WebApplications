using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Util;
using Action = Antlr.Runtime.Misc.Action;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        // Create data context
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            
            IEnumerable<Book> books = db.Books;//todo difference between IENumer.. and IQueryable in Entity context
            // send all objects to dynamic property Books in ViewBag
            ViewBag.Books = books;
            return View();// also we can specify the path directly as View("Index");
                          // or as View("~/Views/Some/Index.cshtml")
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();

            return "Thank you," + purchase.Person + "for your purchase";

        }

        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет мир!</h2>");
        }

        public ActionResult GetImage(string pathToPhoto)// todo not completed 
        {
            return new ImageResult(pathToPhoto);
        }

        public ViewResult SomeMethod()
        {
            ViewData["Head"] = "Hello World, hi Andrew";
            // or use       ViewBag.Head = "Hello World, hi Andrew";
            // or use TempData["Head"] = "Hello World, hi Andrew";
            ViewBag.Title = "Title_SomeMethod";
            return View("SomeView");
        }



    }
}