using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using VGLibrary.Models;

namespace VGLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //hardcoded game list
        private static List<Game> Gamelist = new List<Game>
        {
            new Game(1, "Gears Of War 3", "Xbox 360", "3rd Person", "Mature", 2011, "GearsOfWar3.jpg", null, null),
            new Game(2, "Halo Infinite", "Xbox", "1st Person Shooter", "Teen", 2021, "Halo_Infinite.png", null, null),
            new Game(3, "Doki Doki Literature Club", "PC", "Visual Novel", "Mature", 2017, "DokiDoki.jpg", null, null),
            new Game(4, "Minecraft: Java Edition", "PC", "Sandbox", "PC", 2009, "Minecraft.jpg", null, null),
            new Game(5, "Fortnite", "PC", "3rd Person", "Teen", 2017, "Fortnite.jpg", null, null)
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Collection(Game g)
        {
            return View(Gamelist);
        }
        [HttpGet]
        public IActionResult Collection()
        {
            return View(Gamelist);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        //public IActionResult ReturnGame(Game g)
        //{
        //    g.LoanDate = null;
        //    g.LoanedTo = null;
        //    return RedirectToAction("Collection", "Home");
        //}

        [HttpPost]
        public IActionResult LoanGame(int ID, string loanedTo)
        {
            //modify game being loaned (hardcoded)
            int i = Gamelist.FindIndex(x => x.Id == ID);
            if (loanedTo != null)
            {
                DateTime dateTime = DateTime.Now;
                DateTime.TryParse(dateTime.ToString(), out dateTime);

                Gamelist[i].LoanedTo = loanedTo;
                Gamelist[i].LoanDate = dateTime;
                //return RedirectToAction("Collection", "Home");
            }
            else
            {

                Gamelist[i].LoanedTo = null;
                Gamelist[i].LoanDate = null;
            }
            //hardcoded
            //Gamelist[i] = new Game(loangame.Id, loangame.Title, loangame.Platform, loangame.Genre, loangame.Rating, loangame.Year, loangame.Image, g.LoanedTo, g.LoanDate);
            return RedirectToAction("Collection", "Home");
        }


        //needs to be fixed, pass in id and fine it by id
        //[HttpPost]
        //public IActionResult LoanGame(string loanedTo, int ID)
        //{
        //    int i = Gamelist.FindIndex(x => x.Id == ID);
        //    if (loanedTo != null)
        //    {
        //        DateTime dateTime = DateTime.Now;
        //        DateTime.TryParse(dateTime.ToString(), out dateTime);

                
        //        Gamelist[i].LoanedTo = loanedTo;
        //        Gamelist[i].LoanDate = dateTime;

        //        return RedirectToAction("Collection", "Home");
        //    }
        //    else 
        //    {
        //        Gamelist[i].LoanedTo = null;
        //        Gamelist[i].LoanDate = null;

        //        return RedirectToAction("Collection", "Home");
        //    }
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}