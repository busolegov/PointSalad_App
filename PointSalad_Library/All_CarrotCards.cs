using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    public class CarrotCardEx1 : Card
    {
        public string type = "морковь";
        public string text = "+4/(капуста) -2/(перец) -2(лук)";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 4 * player.CabbageStack;
            player.Score -= 2 * player.PepperStack;
            player.Score -= 2 * player.OnionStack;
        }
    }

    public class CarrotCardEx2 : Card
    {
        public string type = "морковь";
        public string text = "+2/(капуста) +2/(томат) -4(салат)";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.CabbageStack;
            player.Score += 2 * player.TomatoStack;
            player.Score -= 4 * player.LetucceStack;
        }
    }

    public class CarrotCardEx3 : Card
    {
        public string type = "морковь";
        public string text = "+3/(капуста) -1/(салат) -1(морковь)";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.CabbageStack;
            player.Score -= player.LetucceStack;
            player.Score -= player.CarrotStack;
        }
    }

    public class CarrotCardEx4 : Card
    {
        public string type = "морковь";
        public string text = "+2/(капуста) +1/(салат) -2(морковь)";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.CabbageStack;
            player.Score -= player.LetucceStack;
            player.Score -= 2 * player.CarrotStack;
        }
    }

    public class CarrotCardEx5 : Card
    {
        public string type = "морковь";
        public string text = "+8/(3 капусты)";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 8 * (player.CabbageStack % 3);
        }
    }

    public class CarrotCardEx6 : Card
    {
        public string type = "морковь";
        public string text = "+7/(чётн. капуста) +3/(нечетн. капусты)";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            if (player.CabbageStack % 2 == 0)
                player.Score += 7;
            else
                player.Score += 3;
        }
    }

    public class CarrotCardEx7 : Card
    {
        public string type = "морковь";
        public string text = "+7/(перец + капуста + томат)";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            
        }
    }

    public class CarrotCardEx8 : Card
    {
        public string type = "морковь";
        public string text = "+7/(морковь + капуста + лук)";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            if (player.CarrotStack < player.OnionStack)
            {
                if (player.CarrotStack < player.CabbageStack)
                {
                    player.Score += 7 * player.CarrotStack;
                }
                else
                if (player.CabbageStack < player.OnionStack)
                    player.Score += 7 * player.CabbageStack;
            }
            else
                player.Score += 7 * player.OnionStack;
        }
    }

    public class CarrotCardEx9 : Card
    {
        public string type = "морковь";
        public string text = "+3/(капуста) -2/(томат)";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.CabbageStack;
            player.Score -= 2 * player.TomatoStack;
        }
    }
}
