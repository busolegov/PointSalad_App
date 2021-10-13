using System;//e4333333333po0using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    public class TomatoCards : Card
    {
        private string type = "томат";
        public override string Type { get => type; set => type = value; }
        /// <summary>
        /// Метод начисления очков за рецепт.
        /// </summary>
        /// <param name="player"></param>*/
        public override void Quest() { }
        public override string QuestText { get; set; }
    }
}
