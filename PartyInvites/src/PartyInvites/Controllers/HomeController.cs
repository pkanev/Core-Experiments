using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";
            return View("MyView");
        }

        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RsvpForm(GuestResponse guestResponse)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Repository.AddResponse(guestResponse);
            return View("Thanks", guestResponse);
        }

        [HttpGet]
        public IActionResult ListResponses()
        {
            var responses = Repository.Responses.Where(r => r.WillAttend == true);
            return View(responses);
        }
    }
}
