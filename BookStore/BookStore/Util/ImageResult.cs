﻿using System.Web.Mvc;

namespace BookStore.Util
{
    public class ImageResult:ActionResult
    {
        private string _path;

        public ImageResult(string path)
        {
            _path = path;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Write("<div style='width:100%;text-align:center;'>" +
                "<img style='max-width:600px;' src='" + _path + "' /></div>");
        }
    }
}