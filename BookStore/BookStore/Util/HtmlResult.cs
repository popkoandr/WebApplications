using System.Web.Mvc;
using Antlr.Runtime.Misc;

namespace BookStore.Util
{
    public class HtmlResult:ActionResult
    {
        private string _htmlCode;
        public HtmlResult(string html)
        {
            _htmlCode = html;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            string fullHtmlCode = "<!DOCTYPE html><html><head>";
            fullHtmlCode += "<title>Главная страница</title>";
            fullHtmlCode += "<meta charset=utf-8 />";
            fullHtmlCode += "</head> <body>";
            fullHtmlCode += _htmlCode;
            fullHtmlCode += "</body></html>";
            context.HttpContext.Response.Write(fullHtmlCode);
        }
    }
}