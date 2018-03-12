using System.Web.Mvc;
using System.Web.Routing;

namespace BookStore.Controllers
{

    public class MyController:IController
    {
        public void Execute(RequestContext requestContext)
        {
            string ip = requestContext.HttpContext.Request.UserHostAddress;
            var responce = requestContext.HttpContext.Response;
            responce.Write($"<h2>Your IP address is: {ip} </h2>");
        }
    }
}