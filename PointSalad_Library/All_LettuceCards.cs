using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    public class LettuceCardEx1 : LettuceCards
    {
        private string text = "+2/(перец) +2/(капуста) -4/(томат)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.PepperStack;
            player.Score += 2 * player.CabbageStack;
            player.Score -= 4 * player.TomatoStack;
        }
    }

    public class LettuceCardEx2 : LettuceCards
    {
        private string text = "+4/(перец) -2/(лук) -2/(морковь)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 4 * player.PepperStack;
            player.Score -= 2 * player.OnionStack;
            player.Score -= 2 * player.CarrotStack;
        }
    }

    public class LettuceCardEx3 : LettuceCards
    {
        private string text = "+3/(морковь) -1/(томат) -1/(салат)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.CarrotStack;
            player.Score -= player.TomatoStack;
            player.Score -= player.LetucceStack;
        }
    }

    public class LettuceCardEx4 : LettuceCards
    {
        private string text = "+2/(перец) +1/(томат) -2/(салат)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.PepperStack;
            player.Score += player.TomatoStack;
            player.Score -= 2 * player.LetucceStack;
        }
    }

    public class LettuceCardEx5 : LettuceCards
    {
        private string text = "+7/(морковь + перец + капуста)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            if (player.CarrotStack < player.PepperStack)
            {
                if (player.CarrotStack < player.CabbageStack)
                {
                    player.Score += 7 * player.CarrotStack;
                }
                else
                if (player.PepperStack < player.CabbageStack)
                {
                    player.Score += 7 * player.PepperStack;
                }
            }
            else
                player.Score += 7 * player.CabbageStack;
        }
    }

    public class LettuceCardEx6 : LettuceCards
    {
        private string text = "+8/(3 перца)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 8 * (player.PepperStack % 3);
        }
    }

    public class LettuceCardEx7 : LettuceCards
    {
        private string text = "+7/(чётн. перцев) +3/(нечетн. перцев)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            if (player.PepperStack % 2 == 0)
                player.Score += 7;
            else
                player.Score += 3;
        }
    }

    public class LettuceCardEx8 : LettuceCards
    {
        private string text = "+3/(перец) -2/(капуста)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.PepperStack;
            player.Score -= 2 * player.CabbageStack;
        }
    }

    public class LettuceCardEx9 : LettuceCards
    {
        private string text = "+7/(салат + перец + морковь)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            if (player.LetucceStack < player.PepperStack)
            {
                if (player.LetucceStack < player.CarrotStack)
                {
                    player.Score += 7 * player.LetucceStack;
                }
                else
                if (player.PepperStack < player.CarrotStack)
                {
                    player.Score += 7 * player.PepperStack;
                }
            }
            else
                player.Score += 7 * player.CarrotStack;
        }
    }
}
