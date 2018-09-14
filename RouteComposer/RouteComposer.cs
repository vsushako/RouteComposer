using System;
using System.Collections.Generic;
using System.Linq;

namespace RouteComposer
{
    /// <summary>
    /// Состовитель пути
    /// </summary>
    public class RouteComposer
    {
        /// <summary>
        /// Парсер строки 
        /// </summary>
        /// <param name="routes">массив путей</param>
        /// <returns></returns>
        public IEnumerable<Route> ParseRoute(string[] routes)
        {
            if (routes == null || !routes.Any()) return Enumerable.Empty<Route>();
            return routes.Select(ParseString);
        }

        /// <summary>
        /// Преобразуем каждую строку в путь
        /// </summary>
        /// <param name="route">Объект пути</param>
        /// <returns></returns>
        private static Route ParseString(string route)
        {
            if (!route.Contains("→")) throw new ArgumentException("Для каждого маршрута разделителем должен быть →");

            var strRoute = route.Split('→');
            if (string.IsNullOrEmpty(strRoute[0])) throw new ArgumentException("У пути должны быть указаны пункты отправления");
            if (string.IsNullOrEmpty(strRoute[1])) throw new ArgumentException("У пути должны быть указаны пункты назначения");

            return new Route { From = strRoute[0].Trim(), To = strRoute[1].Trim() };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="routes"></param>
        /// <returns></returns>
        public IEnumerable<Route> SortRoute(string[] routes) => SortRoute(ParseRoute(routes).ToArray());

        /// <summary>
        /// Метод упорядочивает массив путей
        /// </summary>
        /// <param name="routes">массив путей</param>
        /// <returns></returns>
        public IEnumerable<Route> SortRoute(Route[] routes)
        {
            // Проверяем количество элементов в массиве и если их 0 или 1 или 2 сразу выдаем результат
            // TODO если таких кейсов будет мало убрать switch что бы не тратить процессорное время и оставить только ветку default
            switch (routes?.Length)
            {
                case null:
                case 0:
                    return Enumerable.Empty<Route>();
                case 1:
                    return routes;
                case 2:
                    return routes[0].To == routes[1].From ? routes : routes.Reverse();
                default:
                    return SortRouteWithoutChecks(routes);
            }
        }

        /// <summary>
        /// Метод упорядочивает массив путей без проверки на количество элементов 
        /// </summary>
        /// <param name="routes"></param>
        /// <returns></returns>
        private IEnumerable<Route> SortRouteWithoutChecks(Route[] routes)
        {
            // Используется для получения результата
            var fromDictinary = new Dictionary<string, Route>();
            // Используется для получения начала пути
            var toDictinary = new Dictionary<string, Route>();
            var routesLength = routes.Length;

            // Создаем dictionary с элементами пути, где ключ отправная точка
            foreach (var route in routes)
            {
                fromDictinary.Add(route.From, route);
                toDictinary.Add(route.To, route);
            }

            // Получаем начало пути
            var current = routes.First(r => !toDictinary.ContainsKey(r.From));
            var result = new List<Route> { current };

            // Сортируем пути по готовому dictionary
            for (var i = 0; i < routesLength - 1; i++)
            {
                current = fromDictinary[current.To];
                result.Add(current);
            }

            return result;
        }
    }
}
