using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    /// <summary>
    /// Абстрактный класс всех карт.
    /// </summary>
    public abstract class Card : IEnumerable
    {
        public virtual void Quest(Game<Player> game, Player player) { }
        public virtual void Quest() { }
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)QuestText).GetEnumerator();
        }
        public abstract string Type { get; set; }

        public abstract string QuestText { get; set; }
    }
}
