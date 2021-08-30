using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    /// <summary>
    /// Интерфейс всех карт.
    /// </summary>
    interface ICard
    {
        /// <summary>
        /// Тип карты - овощ.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Текст рецепта карты.
        /// </summary>
        public string QuestText { get; set; }
        /// <summary>
        /// Метод начисления очков за рецепт.
        /// </summary>
        /// <param name="player"></param>*/
        public void Quest();

    }
}
