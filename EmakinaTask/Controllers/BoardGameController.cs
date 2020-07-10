using EmakinaTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EmakinaTask.Controllers
{
    public class BoardGameController : Controller
    {
        private BoardgameDbContext bgContext = new BoardgameDbContext();
        
        public ActionResult Index( int? amount )
        {
            var games = from g in bgContext.BoardGames
                        orderby g.ID
                        select g;
            return View(games);
        }
        public ActionResult Details(int id)
        {
            BoardGame boardGame = bgContext.BoardGames.Single(game => game.ID == id);
            DisplayInfo info = new DisplayInfo();
            info.GameID = boardGame.ID;
            info.DateTime = DateTime.Now;
            info.Browser = Request.Browser.Browser;
            bgContext.DisplayInfoes.Add(info);

            bgContext.SaveChanges();
            return View(boardGame);
        }
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                BoardGame boardGame = new BoardGame();
                boardGame.GameName = collection["GameName"];
                boardGame.MinPlayers = int.Parse(collection["MinPlayers"]);
                boardGame.MaxPlayers = int.Parse(collection["MaxPlayers"]);
                boardGame.MinAge = int.Parse(collection["MinAge"]);

                bgContext.BoardGames.Add(boardGame);
                bgContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }
        public ActionResult Edit(int id)
        {
            BoardGame boardGame = bgContext.BoardGames.Single(game => game.ID == id);
            return View(boardGame);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                BoardGame boardGame = bgContext.BoardGames.Single(game => game.ID == id);
                bgContext.Entry(boardGame).State = EntityState.Modified;
                boardGame.GameName = collection["GameName"];
                boardGame.MinPlayers = int.Parse(collection["MinPlayers"]);
                boardGame.MaxPlayers = int.Parse(collection["MaxPlayers"]);
                boardGame.MinAge = int.Parse(collection["MinAge"]);


                bgContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }

        public ActionResult Delete(int id)
        {
            BoardGame boardGame = bgContext.BoardGames.Single(game => game.ID == id);
            bgContext.BoardGames.Remove(boardGame);
            bgContext.SaveChanges();
            return RedirectToAction("Index");
        }

        /*[HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
           
        }*/
        [NonAction]
        public List<BoardGame> TestGameList()
        {
            return new List<BoardGame>
            {
                new BoardGame
                {
                    ID = 1,
                    GameName = "First",
                    MinPlayers = 1,
                    MaxPlayers = 4,
                    MinAge = 12
                },
                new BoardGame
                {
                    ID = 2,
                    GameName = "Second",
                    MinPlayers = 2,
                    MaxPlayers = 8,
                    MinAge = 18
                }
            };
        }
        


    }
}