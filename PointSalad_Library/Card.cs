using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    /// <summary>
    /// Абстрактный класс всех карт.
    /// </summary>
    public abstract class Card
    {
        /// <summary>
        /// Тип карты - овощ.
        /// </summary>
        public abstract string Type { get; set; }
        public void Quest() { }
        public virtual string QuestText { get; set; }

    }
}
