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
            player.Score += 4 * player.lettuceStack;
            player.Score -= 2 * player.tomatoStack;
            player.Score -= 2 * player.cabbageStack;
        }
    }

    public class PepperCardEx2 : PepperCards
    {
        public string text = "+2/(салат) & +1/(лук) & -2/(перец)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.lettuceStack;
            player.Score += player.onionStack;
            player.Score -= 2 * player.pepperStack;
        }
    }

    public class PepperCardEx3 : PepperCards
    {
        public string text = "+3/(салат) & -1/(лук) & -1/(перец)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.lettuceStack;
            player.Score -= player.onionStack;
            player.Score -= player.pepperStack;
        }
    }

    public class PepperCardEx4 : PepperCards
    {
        public string text = "+2/(салат) & +2/(морковь) & -4/(лук)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.lettuceStack;
            player.Score += 2 * player.carrotStack;
            player.Score -= 4 * player.onionStack;
        }
    }

    public class PepperCardEx5 : PepperCards
    {
        public string text = "+8/(три салата)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 8 * (player.onionStack % 3);
        }
    }

    //public class PepperCardEx6 : PepperCards
    //{
    //    public string text = "+7/(перец + салат + капуста";
    //    public override string QuestText { get => text; set => text = value; }
    //    public override void Quest(Game<Player> game, Player player)
    //    {
    //        player.Score += 3 * player.onionStack;
    //        player.Score -= player.pepperStack;
    //    }
    //}
    public class PepperCardEx7 : PepperCards
    {
        public string text = "+7/(перец + салат + капуста";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            if (player.lettuceStack % 2 == 0)
            {
                player.Score += 7;
            }
            else
                player.Score += 3;
        }
    }
}
