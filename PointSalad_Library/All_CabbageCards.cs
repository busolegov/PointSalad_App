using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    public class CabbageCardEx1 : Card
    {
        public string type = "капуста";
        public string text = "+4/(морковь) -2/(салат) -2/(томат)";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 4 * player.CarrotStack;
            player.Score -= 2 * player.LetucceStack;
            player.Score -= 2 * player.TomatoStack;
        }
    }
    public class CabbageCardEx2 : Card
    {
        public string text = "+2/(морковь) +1/(перец) -2/(капуста)";
        public string type = "капуста";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.CarrotStack;
            player.Score += player.PepperStack;
            player.Score -= 2 * player.CabbageStack;
        }
    }
    public class CabbageCardEx3 : Card
    {

        public string text = "+2/(морковь) +2/(лук) -4/(перец)";
        public string type = "капуста";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 2 * player.CarrotStack;
            player.Score += 2 * player.OnionStack;
            player.Score -= 4 * player.PepperStack;
        }
    }
    public class CabbageCardEx4 : Card
    {
        public string text = "+3/(морковь) -1/(перец) -1/(капуста)";
        public string type = "капуста";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.CarrotStack;
            player.Score -= player.PepperStack;
            player.Score -= player.CabbageStack;
        }
    }
    public class CabbageCardEx5 : Card
    {
        public string text = "+7/(капуста + морковь + томат)";
        public string type = "капуста";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
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
    public class CabbageCardEx6 : Card
    {
        public string text = "+7/(салат + морковь + лук)";
        public string type = "капуста";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
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
    public class CabbageCardEx7 : Card
    {
        public string text = "+3/(морковь) & -1/(перец) & -1/(капуста)";
        public string type = "капуста";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.CarrotStack;
            player.Score -= player.PepperStack;
            player.Score -= player.CabbageStack;
        }
    }

    public class CabbageCardEx8 : Card
    {
        public string text = "+3/(морковь) & -1/(перец) & -1/(капуста)";
        public string type = "капуста";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.CarrotStack;
            player.Score -= player.PepperStack;
            player.Score -= player.CabbageStack;
        }
    }

    public class CabbageCardEx9 : Card
    {
        public string text = "+3/(морковь) & -1/(перец) & -1/(капуста)";
        public string type = "капуста";
        public override string QuestText { get => text; set => text = value; }
        public override string Type { get => type; set => type = value; }
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.CarrotStack;
            player.Score -= player.PepperStack;
            player.Score -= player.CabbageStack;
        }
    }
}




