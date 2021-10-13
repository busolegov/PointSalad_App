using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    public class PepperCardEx1 : PepperCards
    {
        public string text = "+4/(салат) & -2/(томат) & -2/(капуста)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 4 * player.LetucceStack;
            player.Score -= 2 * player.TomatoStack;
            player.Score -= 2 * player.CabbageStack;
        }
    }

    public class PepperCardEx2 : PepperCards
    {
        public string text = "+2/(салат) & +1/(лук) & -2/(перец)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.LetucceStack;
            player.Score += player.OnionStack;
            player.Score -= 2 * player.PepperStack;
        }
    }

    public class PepperCardEx3 : PepperCards
    {
        public string text = "+3/(салат) & -1/(лук) & -1/(перец)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.LetucceStack;
            player.Score -= player.OnionStack;
            player.Score -= player.PepperStack;
        }
    }

    public class PepperCardEx4 : PepperCards
    {
        public string text = "+2/(салат) & +2/(морковь) & -4/(лук)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.LetucceStack;
            player.Score += 2 * player.CarrotStack;
            player.Score -= 4 * player.OnionStack;
        }
    }

    public class PepperCardEx5 : PepperCards
    {
        public string text = "+8/(три салата)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 8 * (player.OnionStack % 3);
        }
    }

    public class PepperCardEx6 : PepperCards
    {
        public string text = "+7/(перец + салат + капуста";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            if (player.PepperStack < player.LetucceStack)
            {
                if (player.PepperStack < player.CabbageStack)
                {
                    player.Score += 7 * player.PepperStack;
                }
                else
                if (player.LetucceStack < player.CabbageStack)
                {
                    player.Score += 7 * player.LetucceStack;
                }
            }
            else
                player.Score += 7 * player.CabbageStack;
        }
    }
    public class PepperCardEx7 : PepperCards
    {
        public string text = "+7/(чётн. салата) +3/(нечетн. салата)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            if (player.LetucceStack % 2 == 0)
            {
                player.Score += 7;
            }
            else
                player.Score += 3;
        }
    }

    public class PepperCardEx8 : PepperCards
    {
        public string text = "+1/(салат) +1/(лук)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += player.LetucceStack;
            player.Score += player.OnionStack;
        }
    }

    public class PepperCardEx9 : PepperCards
    {
        public string text = "+7/(томат + салат + морковь)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            if (player.TomatoStack < player.LetucceStack)
            {
                if (player.TomatoStack < player.CarrotStack)
                {
                    player.Score += 7 * player.TomatoStack;
                }
                else
                if (player.LetucceStack < player.CarrotStack)
                {
                    player.Score += 7 * player.LetucceStack;
                }
            }
            else
                player.Score += 7 * player.CarrotStack;
        }
    }
}
