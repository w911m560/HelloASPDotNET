using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloASPDotNET.Data;
using HelloASPDotNET.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloASPDotNET.Controllers
{
    public class EventsController : Controller
    {

        //static private List<Event> Events = new List<Event>(); //made a class for this

        // GET: /<controller>/
        public IActionResult Index()
        {
            //ViewBag.events = Events; //new class makes this no longer available
            ViewBag.events = EventData.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Events/Add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);

            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }

        public IActionResult Edit(int eventId)
        {
            ViewBag.eventToEdit = EventData.GetById(eventId + 1);
            return View();
        }

        [HttpPost]
        [Route("Events/Edit/{eventId?}")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            EventData.GetById(eventId).Name = name;
            EventData.GetById(eventId).Description = description;

            return Redirect("/Events");
        }
    }
}
