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
        private string text = "+3pts / onion\n-2pts / pepper";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3*player.onionStack;
            player.Score -= player.pepperStack;
        }
    }
    public class TomatoCardEx2 : TomatoCards
    {
        private string text = "+7pts / carrot + onion + pepper";
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
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 5 * (player.onionStack % 2);
        }
    }
    public class TomatoCardEx4 : TomatoCards
    {
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += player.onionStack % 2;
        }
    }
    
    public class TomatoCardEx5 : TomatoCards
    {
        public new string QuestText = "+3pts / onion\n-2pts / pepper";
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.onionStack;
            player.Score -= player.pepperStack;
        }
    }

    public class TomatoCardEx6 : TomatoCards
    {
        public new string QuestText = "+3pts / onion\n-2pts / pepper";
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.onionStack;
            player.Score -= player.pepperStack;
        }
    }

    /*public class TomatoCardEx7 : TomatoCards
    {
        public new string QuestText = "+3pts / onion\n-2pts / pepper";
        public override void Quest(Game <Player>game, Player player)
        {
            List<int> l = new List<int>();
            foreach (var item in game.players)
            {
                l.Add(item.onionStack);
            }
            l.Max( )
        }

    }*/
}


