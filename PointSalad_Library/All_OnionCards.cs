using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    public class OnionCardEx1 : Card
    {
        public string text = "+2/(томат) -2/(капуста) -2(перец)";
        public string type = "лук";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.TomatoStack;
            player.Score -= 2 * player.CabbageStack;
            player.Score -= 2 * player.PepperStack;
        }
    }
    public class OnionCardEx2 : Card
    {
        public string text = "+2/(томат) +2/(салат) -4(морковь)";
        public string type = "лук";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.TomatoStack;
            player.Score += 2 * player.LetucceStack;
            player.Score -= 4 * player.CarrotStack;
        }
    }
    public class OnionCardEx3 : Card
    {
        public string text = "+2/(томат) +1/(морковь) -2(лук)";
        public string type = "лук";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.TomatoStack;
            player.Score += player.CarrotStack;
            player.Score -= 2 * player.OnionStack;
        }
    }
    public class OnionCardEx4 : Card
    {
        public string text = "+3/(томат) -1/(морковь) -1(лук)";
        public string type = "лук";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.CabbageStack;
            player.Score -= player.CarrotStack;
            player.Score -= player.OnionStack;
        }
    }
    public class OnionCardEx5 : Card
    {
        public string text = "+8/(3 томата)";
        public string type = "лук";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 8 * (player.TomatoStack % 3);
        }
    }
    public class OnionCardEx6 : Card
    {
        public string text = "+7/(лук + томат + перец)";
        public string type = "лук";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            if (player.OnionStack < player.TomatoStack)
            {
                if (player.OnionStack < player.PepperStack)
                {
                    player.Score += 7 * player.OnionStack;
                }
                else
                if (player.PepperStack < player.TomatoStack)
                {
                    player.Score += 7 * player.PepperStack;
                }
            }
            else
                player.Score += 7 * player.OnionStack;
        }
    }
    
    public class OnionCardEx7 : Card
    {
        public string text = "+7/(чётн. томата) +3/(нечетн. томата)";
        public string type = "лук";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
                if (player.TomatoStack % 2 == 0)
                    player.Score += 7;
                else
                    player.Score += 3;
        }
    }
    public class OnionCardEx8 : Card
    {
        public string text = "+7/(капуста + томат + салат)";
        public string type = "лук";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            if (player.CabbageStack < player.TomatoStack)
            {
                if (player.CabbageStack < player.LetucceStack)
                {
                    player.Score += 7 * player.CabbageStack;
                }
                else
                if (player.LetucceStack < player.TomatoStack)
                {
                    player.Score += 7 * player.LetucceStack;
                }
            }
            else
                player.Score += 7 * player.TomatoStack;
        }
    }
    public class OnionCardEx9 : Card
    {
        public string text = "+3/(томат) -2/(салат)";
        public string type = "лук";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.TomatoStack;
            player.Score -= 2 * player.LetucceStack;
        }
    }
}
