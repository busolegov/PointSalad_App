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
        public abstract void Quest();
        public abstract string Type { get; set; }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)QuestText).GetEnumerator();
        }

        public virtual string QuestText { get; set; }
    }
}
