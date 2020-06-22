using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloASPDotNET.Controllers
{
    [Route("/helloworld")]
    public class HelloController : Controller
    {
        // GET: /<controler>/
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post' action='/helloworld/'>" +
                                "<input type='text' name='name' />" +

                                "<select name='language' id='language'>" +
                                    "<option value='english'>English</option>" +
                                    "<option value='french'>French</option>" +
                                    "<option value='thai'>Thai</option>" +
                                    "<option value='polish'>Polish</option>" +
                                    "<option value='german'>German</option>" +
                                "</select>" +
                                "<input type='submit' value='Greet Me!' />" +
                              "</form>";

            return Content(html, "text/html");
        }

        [HttpGet("welcome/{name?}")]
        [HttpPost]
        public IActionResult Welcome(string name = "World", string language = "english")
        {
            return Content(CreateMessage(name, language), "text/html");
        }

        public static string CreateMessage(string name, string language)
        {
            if (language == "polish")
            {
                return "<h1>witam w mojej aplikacji " + name + "!</h1>";
            }
            else if (language == "german")
            {
                return "<h1>Willkommen in meiner App " + name + "!</h1>";
            }
            else if (language == "thai")
            {
                return "<h1>ยินดีต้อนรับสู่แอพของฉัน " + name + "!</h1>";
            }
            else if (language == "french")
            {
                return "<h1>bienvenue dans mon application " + name + "!</h1>";
            }
            else
            {
                return "<h1>Welcome to my app, " + name + "!</h1>";
            }
        }
    }
}
