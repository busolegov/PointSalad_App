using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    public class CabbageCardEx1 : CabbageCards
    {
        private string text = "+4/(морковь) & -2/(салат) & -2/(томат)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 4 * player.carrotStack;
            player.Score -= 2 * player.lettuceStack;
            player.Score -= 2 * player.tomatoStack;
        }
    }
    public class CabbageCardEx2 : CabbageCards
    {
        private string text = "+2/(морковь) & +1/(перец) & -2/(капуста)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.carrotStack;
            player.Score += player.pepperStack;
            player.Score -= 2 * player.cabbageStack;
        }
    }
    public class CabbageCardEx3 : CabbageCards
    {
        private string text = "+2/(морковь) & +2/(лук) & -4/(перец)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.carrotStack;
            player.Score += 2 * player.onionStack;
            player.Score -= 4 * player.pepperStack;
        }
    }
    public class CabbageCardEx4 : CabbageCards
    {
        private string text = "+3/(морковь) & -1/(перец) & -1/(капуста)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.carrotStack;
            player.Score -= player.pepperStack;
            player.Score -= player.cabbageStack;
        }
    }
    //public class CabbageCardEx5 : CabbageCards
    //{
    //    private string text = "+3/(морковь) & -1/(перец) & -1/(капуста)";
    //    public override string QuestText { get => text; set => text = value; }

    //    public override void Quest(Game<Player> game, Player player)
    //    {
    //        player.Score += 3 * player.carrotStack;
    //        player.Score -= player.pepperStack;
    //        player.Score -= player.cabbageStack;
    //    }
    //}
    //public class CabbageCardEx6 : CabbageCards
    //{
    //    private string text = "+3/(морковь) & -1/(перец) & -1/(капуста)";
    //    public override string QuestText { get => text; set => text = value; }

    //    public override void Quest(Game<Player> game, Player player)
    //    {
    //        player.Score += 3 * player.carrotStack;
    //        player.Score -= player.pepperStack;
    //        player.Score -= player.cabbageStack;
    //    }
    //}
    public class CabbageCardEx7 : CabbageCards
    {
        private string text = "+3/(морковь) & -1/(перец) & -1/(капуста)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.carrotStack;
            player.Score -= player.pepperStack;
            player.Score -= player.cabbageStack;
        }
    }
}




