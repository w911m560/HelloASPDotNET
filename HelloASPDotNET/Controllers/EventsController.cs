using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloASPDotNET.Controllers
{
    public class EventsController : Controller
    {
        static private Dictionary<string, string> Events = new Dictionary<string, string>();
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            //List<string> Events = new List<string>();
            //Events.Add("Code With Pride");
            //Events.Add("Apple WWDC");
            //Events.Add("Strange Loop");

            ViewBag.events = Events; // List is on line 11

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            // Any additional method code here

            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(string name, string description)
        {
            Events.Add(name, description); //line 11

            return Redirect("/Events");
        }
    }
}
