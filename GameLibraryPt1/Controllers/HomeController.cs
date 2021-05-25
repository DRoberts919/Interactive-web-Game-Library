
using GameLibraryPt1.Data;
using GameLibraryPt1.Interfaces;
using GameLibraryPt1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameLibraryPt1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IDataAccessLayer dataAccessLayer;


        public HomeController(IDataAccessLayer dal)
        {
            dataAccessLayer = dal;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult GamesDisplay()
        {
            return View(dataAccessLayer.GetCollection(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        [Authorize]
        [HttpGet]
        public IActionResult LoadGame(int id)
        {


            Game foundGame = dataAccessLayer.getGame(id, User.FindFirstValue(ClaimTypes.NameIdentifier));

            if(foundGame != null)
            {
                return View("RentGame", foundGame);
            }


            return RedirectToAction("index");
            
            
        }

        [Authorize]
        [HttpPost]
        public IActionResult RentGame(int id, string renter)
        {
            Game rentGame = dataAccessLayer.getGame(id, User.FindFirstValue(ClaimTypes.NameIdentifier));

            if(rentGame != null)
            {
                rentGame.LoanedTo = renter;
                rentGame.LoanDate = DateTime.Now;

                dataAccessLayer.updateGame(rentGame);

                return RedirectToAction("GamesDisplay");
            }


            return RedirectToAction("GamesDisplay");
        }


        [Authorize]
        public IActionResult ReturnGame(int id)
        {
            Game renturnedGame = dataAccessLayer.getGame(id,User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (renturnedGame != null)
            {
                renturnedGame.LoanedTo = null;
                renturnedGame.LoanDate = null;

                dataAccessLayer.updateGame(renturnedGame);

                return RedirectToAction("GamesDisplay");
            }
            return View();
        }

        [Authorize]
        public IActionResult DeleteGame(int id)
        {
            dataAccessLayer.DeleteGame(id,User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View("GamesDisplay", dataAccessLayer.GetCollection(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddGame(Game game)
        {
            dataAccessLayer.AddGame(game);

            return View("GamesDisplay", dataAccessLayer.GetCollection(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        [Authorize]
        public IActionResult AddGameRoute()
        {
            ViewBag.userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View("AddGame");
        }

        [Authorize]
        public IActionResult SearchGames(string title,string genre,string platform,string esrbRating)
        {
            var searchedTitle = dataAccessLayer.SearchForGames(title, genre, platform, esrbRating, User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View("GamesDisplay", searchedTitle);
        }

        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
