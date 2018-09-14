using System;
using System.Linq;

namespace RouteComposer
{
    class Program
    {
        static void Main(string[] args)
        {
            var routeComposer = new RouteComposer();
            var routes = routeComposer.SortRoute(new[] {"Мельбурн → Кельн", "Москва → Париж", "Кельн → Москва"});
            
            Console.WriteLine(string.Join(", ", routes.Select(r => r.ToString())));
            Console.ReadKey();
        }
    }
}
