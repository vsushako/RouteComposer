using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RouteComposer.Test
{
    [TestClass]
    public class SortRouteTest
    {
        [TestMethod]
        public void CheckSortRoute_CheckNull_ExpectOk()
        {
            var composer = new RouteComposer();
            var routes = composer.SortRoute((Route[]) null);
            Assert.AreEqual(Enumerable.Empty<Route>(), routes);
        }

        [TestMethod]
        public void CheckSortRoute_CheckEmpty_ExpectOk()
        {
            var composer = new RouteComposer();
            var routes = composer.SortRoute(new Route[0]);
            Assert.AreEqual(Enumerable.Empty<Route>(), routes);
        }

        [TestMethod]
        public void CheckSortRoute_CheckOne_ExpectOk()
        {
            var composer = new RouteComposer();
            var routes = composer.SortRoute(new [] { new Route{ From = "Мельбурн", To = "Кельн" } });
            Assert.AreEqual("Мельбурн → Кельн", routes.First().ToString());
        }

        [TestMethod]
        public void CheckSortRoute_CheckTwo_ExpectOk()
        {
            var composer = new RouteComposer();
            var routes = composer.SortRoute(new[] { new Route { From = "Мельбурн", To = "Кельн" }, new Route { From = "Кельн", To = "Москва" } });
            Assert.AreEqual("Мельбурн → Кельн, Кельн → Москва", string.Join(", ", routes.Select(r => r.ToString())));
        }

        [TestMethod]
        public void CheckSortRoute_CheckTwoReverse_ExpectOk()
        {
            var composer = new RouteComposer();
            var routes = composer.SortRoute(new[] { new Route { From = "Кельн", To = "Москва" }, new Route { From = "Мельбурн", To = "Кельн" }});
            Assert.AreEqual("Мельбурн → Кельн, Кельн → Москва", string.Join(", ", routes.Select(r => r.ToString())));
        }

        [TestMethod]
        public void CheckSortRoute_CheckMultiple1_ExpectOk()
        {
            var composer = new RouteComposer();
            var routes = composer.SortRoute(new[] { new Route { From = "Кельн", To = "Москва" }, new Route { From = "Мельбурн", To = "Кельн" }, new Route { From = "Москва", To = "Париж" } });
            Assert.AreEqual("Мельбурн → Кельн, Кельн → Москва, Москва → Париж", string.Join(", ", routes.Select(r => r.ToString())));
        }

        [TestMethod]
        public void CheckSortRoute_CheckMultiple2_ExpectOk()
        {
            var composer = new RouteComposer();
            var routes = composer.SortRoute(new[] { new Route { From = "Мельбурн", To = "Кельн" }, new Route { From = "Кельн", To = "Москва" },  new Route { From = "Москва", To = "Париж" } });
            Assert.AreEqual("Мельбурн → Кельн, Кельн → Москва, Москва → Париж", string.Join(", ", routes.Select(r => r.ToString())));
        }

        [TestMethod]
        public void CheckSortRoute_CheckMultiple3_ExpectOk()
        {
            var composer = new RouteComposer();
            var routes = composer.SortRoute(new[] { new Route { From = "Москва", To = "Париж" }, new Route { From = "Мельбурн", To = "Кельн" }, new Route { From = "Кельн", To = "Москва" } });
            Assert.AreEqual("Мельбурн → Кельн, Кельн → Москва, Москва → Париж", string.Join(", ", routes.Select(r => r.ToString())));
        }

        [TestMethod]
        public void CheckSortRoute_CheckMultiple4_ExpectOk()
        {
            var composer = new RouteComposer();
            var routes = composer.SortRoute(new[] { new Route { From = "Москва", To = "Париж" }, new Route { From = "Кельн", To = "Москва" }, new Route { From = "Мельбурн", To = "Кельн" } });
            Assert.AreEqual("Мельбурн → Кельн, Кельн → Москва, Москва → Париж", string.Join(", ", routes.Select(r => r.ToString())));
        }
    }
}
