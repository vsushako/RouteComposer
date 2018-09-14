using System;
using System.Collections.Generic;
using System.Text;

namespace RouteComposer
{
    /// <summary>
    /// Класс содержащий в себе маршрут
    /// </summary>
    public class Route
    {
        /// <summary>
        /// Пункт отправления
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Пункт назначения
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Преобразуем к формату строки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{From} → {To}";
        }
    }
}
