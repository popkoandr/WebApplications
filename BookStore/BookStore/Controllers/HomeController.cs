using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Util;
using Action = Antlr.Runtime.Misc.Action;

namespace BookStore.Controllers
{

    
    //todo 2. in what way i can restrict in style declaration that style for _input_  should be applied only for concrete input type.
    //todo 3. 
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

        public ActionResult MethodWithRedirect1()
        {
            return Redirect("/Home/SomeMethod");
        }

        public ActionResult MethodWithRedirectToRoute()
        {
            return RedirectToRoute(new { controller = "Home", action = "SomeMethod" });
            //todo how i can specify the concrete parameter for the action  (method)
            // or return RedirectToAction("SomeMethod");

        }

        public ActionResult CalcRectangleArea()
        {
            var a = int.Parse(Request.Params["a"]);
            var h = int.Parse(Request.Params["h"]);

            double s = a * h;
            return Content($"<h2> Area of the rectangle with side a={a} and h={h} is equal to {s} </h2>");
        }

        public ActionResult RedirectToActionWithParams()
        {
            return RedirectToAction("CalcRectangleArea", "Home", new { a = 5, h = 8 });
        }

        #region File sending

        public FileResult GetFile()
        {
            //*** FilePathResult
            string filePath = Server.MapPath("~/Files/Test.pdf");
            string fileType = "application/pdf";
            string fileName = "PDFTestName.pdf"; //Is not mandatory

            return File(filePath, fileType, fileName);
        }

        private FileResult GetBytes()
        {
            //***FileContentResult
            string filePath = Server.MapPath("~/Files/Test.pdf");
            string fileType = "application/pdf";
            string fileName = "PDFTestName.pdf"; //Is not mandatory
            byte[] massBytes = System.IO.File.ReadAllBytes(filePath);
            return File(massBytes, fileType, fileName);
        }

        public FileResult GetStream()
        {
            //*** FileStreamResult
            string filePath = Server.MapPath("~/Files/Test.pdf");
            string fileType = "application/pdf";
            string fileName = "PDFTestName.pdf"; //Is not mandatory
            FileStream fs = new FileStream(filePath, FileMode.Open);

            return File(fs, fileType, fileName);
        }

        #endregion

        public string GetContext()
        {

            string browser = HttpContext.Request.Browser.Browser;
            string userAgent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null  ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;

            //bool IsAdmin = HttpContext.User.IsInRole("admin"); //bug the trust relationship between the primary domain and the trusted domain failed."
            bool IsAuth = HttpContext.User.Identity.IsAuthenticated; // аутентифицирован ли пользователь
            string login = HttpContext.User.Identity.Name; // логин авторизованного пользователя

            HttpContext.Response.Write($"<p> is admin: {login}</p><p> is IsAuth: {IsAuth}</p><p>login: {login}</p>");
            return "<p>Browser: " + browser + "</p><p>User-Agent: " + userAgent + "</p><p>Url запроса: " + url +
                "</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>";
            //instead return we can use httpContext.Response.Write(...) previously updating return type of method to void;

        }

        
    }
}