using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    public class CabbageCardEx1 : CabbageCards
    {
        private string text = "+4/(морковь) -2/(салат) -2/(томат)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 4 * player.CarrotStack;
            player.Score -= 2 * player.LetucceStack;
            player.Score -= 2 * player.TomatoStack;
        }
    }
    public class CabbageCardEx2 : CabbageCards
    {
        private string text = "+2/(морковь) +1/(перец) -2/(капуста)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.CarrotStack;
            player.Score += player.PepperStack;
            player.Score -= 2 * player.CabbageStack;
        }
    }
    public class CabbageCardEx3 : CabbageCards
    {
        private string text = "+2/(морковь) +2/(лук) -4/(перец)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.CarrotStack;
            player.Score += 2 * player.OnionStack;
            player.Score -= 4 * player.PepperStack;
        }
    }
    public class CabbageCardEx4 : CabbageCards
    {
        private string text = "+3/(морковь) -1/(перец) -1/(капуста)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.CarrotStack;
            player.Score -= player.PepperStack;
            player.Score -= player.CabbageStack;
        }
    }
    public class CabbageCardEx5 : CabbageCards
    {
        private string text = "+7/(капуста + морковь + томат)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            if (player.CabbageStack < player.CarrotStack)
            {
                if (player.CabbageStack < player.TomatoStack)
                {
                    player.Score += 7 * player.CabbageStack;
                }
                else
                if (player.CarrotStack < player.TomatoStack)
                    player.Score += 7 * player.CarrotStack;
            }
            else
                player.Score += 7 * player.TomatoStack;
        }
    }
    public class CabbageCardEx6 : CabbageCards
    {
        private string text = "+7/(салат + морковь + лук)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            if (player.LetucceStack < player.CarrotStack)
            {
                if (player.LetucceStack < player.OnionStack)
                {
                    player.Score += 7 * player.LetucceStack;
                }
                else
                if (player.CarrotStack < player.OnionStack)
                    player.Score += 7 * player.CarrotStack;
            }
            else
                player.Score += 7 * player.OnionStack;
        }
    }
    public class CabbageCardEx7 : CabbageCards
    {
        private string text = "+3/(морковь) & -1/(перец) & -1/(капуста)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.CarrotStack;
            player.Score -= player.PepperStack;
            player.Score -= player.CabbageStack;
        }
    }

    public class CabbageCardEx8 : CabbageCards
    {
        private string text = "+3/(морковь) & -1/(перец) & -1/(капуста)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.CarrotStack;
            player.Score -= player.PepperStack;
            player.Score -= player.CabbageStack;
        }
    }

    public class CabbageCardEx9 : CabbageCards
    {
        private string text = "+3/(морковь) & -1/(перец) & -1/(капуста)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.CarrotStack;
            player.Score -= player.PepperStack;
            player.Score -= player.CabbageStack;
        }
    }
}




