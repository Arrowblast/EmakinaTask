using EmakinaTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI;
namespace EmakinaTask.Controllers
{
    public class BoardGameController : Controller
    {
        public BoardgameDbContext bgContext = new BoardgameDbContext();
        //GET: /BoardGame/Index?amount
        public ActionResult Index(int? amount)
        {
            var games = from g in bgContext.BoardGames
                        orderby g.ID
                        select g;
            if (amount != null)
            {
                games = (IOrderedQueryable<BoardGame>)games.Take((int)amount);
            }
            return View(games);
        }
        //GET: /BoardGame/Details?id
        public ActionResult Details(int id)
        {
            BoardGame boardGame = bgContext.BoardGames.First(game => game.ID == id);
            DisplayInfo info = new DisplayInfo();
            info.GameID = boardGame.ID;
            info.DateTime = DateTime.Now;
            info.Browser = Request.Browser.Browser;
            bgContext.DisplayInfoes.Add(info);
            bgContext.SaveChanges();
            return View(boardGame);
        }
        //GET: /BoardGame/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: /BoardGame/Create
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
        //GET: /BoardGame/Edit?id
        public ActionResult Edit(int id)
        {
            BoardGame boardGame = bgContext.BoardGames.First(game => game.ID == id);
            return View(boardGame);
        }
        //POST: /BoardGame/Edit?id
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                BoardGame boardGame = bgContext.BoardGames.First(game => game.ID == id);
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
        //GET: /BoardGame/Delete?id
        public ActionResult Delete(int id)
        {
            BoardGame boardGame = bgContext.BoardGames.First(game => game.ID == id);
            bgContext.BoardGames.Remove(boardGame);
            bgContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}