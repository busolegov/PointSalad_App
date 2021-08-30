using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    public abstract class PepperCards : Card
    {
        private string text = "pepper";
        public override string Type { get => text; set => text = value; }
        /// <summary>
        /// Метод начисления очков за рецепт.
        /// </summary>
        /// <param name="player"></param>*/
        public abstract void Quest(Game<Player> game, Player player);
    }
}
