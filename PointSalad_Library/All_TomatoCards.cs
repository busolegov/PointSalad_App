using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    /// <summary>
    /// Классы всех карт томатов.
    /// </summary>
    public class TomatoCardEx1 : TomatoCards
    {
        private string text = "+3/onion & -2/pepper";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3*player.onionStack;
            player.Score -= player.pepperStack;
        }
    }
    public class TomatoCardEx2 : TomatoCards
    {
        private string text = "+7/carrot + onion + pepper";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            if (player.carrotStack < player.onionStack)
            {
                if (player.carrotStack < player.pepperStack)
                {
                    player.Score += 7*player.carrotStack;
                }
                else
                {

                }
            }
        }
    }
    public class TomatoCardEx3 : TomatoCards
    {
        private string text = "+1/onion & +1/carrot";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 5 * (player.onionStack % 2);
        }
    }
    public class TomatoCardEx4 : TomatoCards
    {
        private string text = "+5/2 onions";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += player.onionStack % 2;
        }
    }
    
    public class TomatoCardEx5 : TomatoCards

    {
        private string text = "+4/cabbage + pepper";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.onionStack;
            player.Score -= player.pepperStack;
        }
    }

    public class TomatoCardEx6 : TomatoCards
    {
        private string text = "+4pts / carrot + lettuce";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.onionStack;
            player.Score -= player.pepperStack;
        }
    }

    public class TomatoCardEx7 : TomatoCards
    {
        private string text = "+10pts / if max onions";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game <Player>game, Player player)
        {
            List<int> l = new List<int>();
            foreach (var item in game.players)
            {
                l.Add(item.onionStack);
            }
            l.Max();
        }

    }

    public class TomatoCardEx8 : TomatoCards
    {
        private string text = "+7pts / if min onions";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            List<int> l = new List<int>();
            foreach (var item in game.players)
            {
                l.Add(item.onionStack);
            }
            l.Max();
        }

    }

    public class TomatoCardEx9 : TomatoCards
    {
        private string text = "+2pts / onion";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            List<int> l = new List<int>();
            foreach (var item in game.players)
            {
                l.Add(item.onionStack);
            }
            l.Max();
        }

    }
}


