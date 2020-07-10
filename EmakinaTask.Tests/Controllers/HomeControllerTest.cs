using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmakinaTask;
using EmakinaTask.Controllers;
using EmakinaTask.Models;
using System.Web.UI.WebControls;
using System.Web.WebPages;

namespace EmakinaTask.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private BoardGameController controller = new BoardGameController();
        [TestMethod]
        public void Index()
        {
           
            // Act
            ActionResult result = controller.Index(null);

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CorrectIndexing()
        {
            ViewResult result = (ViewResult)controller.Index(null);
            int firstID = ((IEnumerable<BoardGame>)result.Model).First().ID;
            Assert.IsTrue(firstID>=0);
        }
        [TestMethod]
        public void CorrectNumbers()
        {
            ViewResult result = (ViewResult)controller.Index(null);
            foreach(BoardGame game in ((IEnumerable<BoardGame>)result.Model))
            {
                Assert.IsTrue(game.MinAge > 0 && game.MinPlayers > 0 && game.MaxPlayers > 0);
            }
        }
        [TestMethod]
        public void NonEmptyGame()
        {

            ViewResult result = (ViewResult)controller.Index(null);
            foreach (BoardGame game in ((IEnumerable<BoardGame>)result.Model))
            {
                Assert.IsFalse(game.GameName.IsEmpty());
            }
        }


    }
}
