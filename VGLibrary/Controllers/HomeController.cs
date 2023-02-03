using Microsoft.AspNetCore.Mvc;
using VGLibrary.Data;
using System.Diagnostics;
using VGLibrary.Models;
using VGLibrary.Interfaces;

namespace VGLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IDataAccessLayer dal = new GameListDAL();

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
            return View(dal.GetGames());
        }
        [HttpGet]
        public IActionResult Collection()
        {
            return View(dal.GetGames());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoanGame(int ID, string loanedTo)
        {
            Game foundgame = dal.GetGame(ID);
            if (loanedTo != null)
            {
                DateTime dateTime = DateTime.Now;
                DateTime.TryParse(dateTime.ToString(), out dateTime);

                foundgame.LoanedTo = loanedTo;
                foundgame.LoanDate = dateTime;
            }
            else
            {
                foundgame.LoanedTo = null;
                foundgame.LoanDate = null;
            }
            return RedirectToAction("Collection", "Home", fragment: ID.ToString());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            Game foundGame = dal.GetGame(id);

            if (foundGame == null) return NotFound();

            return View(foundGame);
        }

        //edit part 2
        [HttpPost]
        public IActionResult Edit(Game g)
        {
            if (ModelState.IsValid)
            {
                dal.EditGame(g);
                TempData["success"] = $"Game {g.Title} edited";
                return RedirectToAction("Collection", "Home");
            }
            return View();
        }

        //add
        [HttpGet] //loading create page
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //saving create page
        public IActionResult Create(Game g)
        {
            if (ModelState.IsValid)
            {
                dal.AddGame(g);
                TempData["Success"] = g.Title + " was added!"; //last through redirects
                return RedirectToAction("Collection", "Home");
            }
            return View();
        }

        //delete
        public IActionResult Delete(int? id)
        {
            if (dal.GetGame(id) == null)
            {
                //validator
                ModelState.AddModelError("Title", "Cannot find game to delete");
            }
            if (ModelState.IsValid)
            {
                //temp delete
                dal.RemoveGame(id);
                TempData["success"] = "Game deleted";
            }
            else
            {
                return View();
            }
            return RedirectToAction("Collection", "Home");
        }

        //search
        public IActionResult Search(string key)
        {
            if (String.IsNullOrEmpty(key))
            {
                return View("Collection", dal.GetGames());
            }
            //returns searched
            return View("Collection", dal.GetGames().Where(c => c.Title.ToLower().Contains(key.ToLower())));
    }
    }
}