using System;//e4333333333po0using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    public abstract class TomatoCards : Card
    {
        private string type = "tomato";
        public override string Type { get => type; set => type = value; }
        /// <summary>
        /// Метод начисления очков за рецепт.
        /// </summary>
        /// <param name="player"></param>*/
        public abstract void Quest(Game<Player> game, Player player);
        public abstract override string QuestText { get; set; }
    }
}
