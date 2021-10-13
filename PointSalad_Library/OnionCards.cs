using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    public abstract class OnionCards : Card
    {
        private string type = "лук";
        public override string Type { get => type; set => type = value; }
        /// <summary>
        /// Метод начисления очков за рецепт.
        /// </summary>
        /// <param name="player"></param>*/
        public abstract override void Quest(Game<Player> game, Player player);
        public abstract override string QuestText { get; set; }
    }
}
