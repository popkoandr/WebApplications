using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class AnotherHomeController : Controller
    {
        // GET: AnotherHome
        public ActionResult Index()
        {
            ViewBag.Message = "This is Partial view";
            return View("~/Views/AnotherHome/StartView.cshtml");
        }

        public ActionResult Partial()
        {
            ViewBag.Message = "This is Partial view";
            return PartialView();
        }
    }
}