using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RouteComposer.Test
{
    [TestClass]
    public class ParseRouteTest
    {
        [TestMethod]
        public void CheckParseRoute_CheckNull_ExpectOk()
        {
            var composer = new RouteComposer();
            var routes = composer.ParseRoute(null);
            Assert.AreEqual(Enumerable.Empty<Route>(), routes);
        }

        [TestMethod]
        public void CheckParseRoute_CheckEmpty_ExpectOk()
        {
            var composer = new RouteComposer();
            var routes = composer.ParseRoute(new string[0]);
            Assert.AreEqual(Enumerable.Empty<Route>(), routes);
        }

        [TestMethod]
        public void CheckParseRoute_CheckParseOne_ExpectOk()
        {
            var composer = new RouteComposer();
            var routes = composer.ParseRoute(new [] { "Мельбурн → Кельн" });
            Assert.AreEqual("Мельбурн → Кельн", routes.First().ToString());
        }

        [TestMethod]
        public void CheckParseRoute_CheckParseMultiple_ExpectOk()
        {
            var composer = new RouteComposer();
            var routes = composer.ParseRoute(new[] {"Мельбурн → Кельн", "Москва → Париж", "Кельн → Москва"});
            Assert.AreEqual("Мельбурн → Кельн, Москва → Париж, Кельн → Москва", string.Join(", ", routes.Select(r => r.ToString())));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckParseRoute_CheckParseWrong_ExpectError()
        {
            var composer = new RouteComposer();
            composer.ParseRoute(new[] { "Мельбурн Кельн" }).First();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckParseRoute_CheckParseToOnly_ExpectError()
        {
            var composer = new RouteComposer();
            composer.ParseRoute(new[] { "→ Кельн" }).First();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckParseRoute_CheckParseFromOnly_ExpectError()
        {
            var composer = new RouteComposer();
            composer.ParseRoute(new[] { "→ Кельн" }).First();
        }
    }
}
