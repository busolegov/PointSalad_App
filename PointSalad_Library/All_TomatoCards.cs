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
        private string text = "+3/(лук) -2/(перец)";
        public override string QuestText { get => text; set => text = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.OnionStack;
            player.Score -= 2* player.PepperStack;
        }
    }
    public class TomatoCardEx2 : TomatoCards
    {
        public string text = "+7/(морковь + лук + перец)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            if (player.CarrotStack < player.OnionStack)
            {
                if (player.CarrotStack < player.PepperStack)
                    player.Score += 7 * player.CarrotStack;
                else
                if (player.PepperStack < player.OnionStack)
                    player.Score += 7 * player.PepperStack;
            }
            else
                player.Score += 7 * player.OnionStack;
        }
    }
    public class TomatoCardEx3 : TomatoCards
    {
        public string text = "+1/(лук) +1/(морковь)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += player.OnionStack;
            player.Score += player.CarrotStack;
        }
    }
    public class TomatoCardEx4 : TomatoCards
    {
        public string text = "+5/(2 лука)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 5* (player.OnionStack % 2);
        }
    }
    
    public class TomatoCardEx5 : TomatoCards

    {
        public string text = "+4/(капуста + перец)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            if (player.PepperStack < player.CabbageStack)
                player.Score += 4 * player.PepperStack;
            else
                player.Score += 4 * player.CabbageStack;
        }
    }

    public class TomatoCardEx6 : TomatoCards
    {
        public string text = "+4/(морковь + салат)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            if (player.CarrotStack < player.LetucceStack)
                player.Score += 4 * player.CarrotStack;
            else
                player.Score += 4 * player.LetucceStack;
        }
    }

    public class TomatoCardEx7 : TomatoCards
    {
        public string text = "+10/(больше всех лука)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game <Player>game, Player player)
        {
            List<int> l = new List<int>();
            foreach (var item in game.players)      //TODO
            {
                l.Add(item.OnionStack);
            }
            l.Max();
        }

    }

    public class TomatoCardEx8 : TomatoCards
    {
        public string text = "+7/(меньше всех лука)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            List<int> l = new List<int>();
            foreach (var item in game.players)      //TODO
            {
                l.Add(item.OnionStack);
            }
            l.Max();
        }

    }

    public class TomatoCardEx9 : TomatoCards
    {
        private string text = "+2/(лук)";
        public override string QuestText { get => text; set => text = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.OnionStack;
        }

    }
}


