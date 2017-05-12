using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {

        public ViewResult Index()
        {
            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;
            return View();
        }

        public ViewResult Result() => View((object)"Hello World");

        public RedirectToActionResult Redirect() => RedirectToAction("Index", "Home");
        public JsonResult GetJson() => Json(new[] { "Alice", "Bob", "Joe" });

        public ContentResult GetContent() => Content("[\"Alice\",\"Bob\",\"Joe\"]", "application/json");

        public ObjectResult GetObject() => Ok(new string[] { "Alice", "Bob", "Joe" });

        public VirtualFileResult GetFile() => File("/lib/bootstrap/dist/css/bootstrap.css", "text/css");

        public StatusCodeResult RaiseNotFound() => StatusCode(StatusCodes.Status404NotFound);

        public StatusCodeResult RaiseAnotherNotFound() => NotFound();
    }
}
