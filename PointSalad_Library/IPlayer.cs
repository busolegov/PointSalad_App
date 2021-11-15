using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    /// <summary>
    /// Интерфейс игрока.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Метод взятия карты рецепта.
        /// </summary>
        /// <param name="card"></param>
        void TakeQuest(Card card);
        /// <summary>
        /// Метод вязтия карты овоща.
        /// </summary>
        /// <param name="card"></param>
        void TakeVegetable(Card card);
    }
}
