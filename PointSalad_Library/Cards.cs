using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    
    public abstract class Card
    {
        public Card()
        {

        }
        public Card(string type, string questText)
        {
            Type = type;
            QuestText = questText;
        }
        public string Type { get; set; }
        public string QuestText { get; set; }
        public abstract void Quest(Player player);
        

    }
    
    public class TomatoCardEx1 : Card
    {
        public TomatoCardEx1(string type, string questText)
        {
            Type = type;
            QuestText = questText;
        }
        public override void Quest(Player player)
        {
            player.Score += player.onionStack % 2;
            player.Score -= player.pepperStack;
        }
    }

    public class TomatoCardEx2 : Card
    {
        public TomatoCardEx2(string type, string questText)
        {
            Type = type;
            QuestText = questText;
        }
        public override void Quest(Player player)
        {
            player.Score += player.onionStack;
            player.Score += player.carrotStack;
        }
    }

    public class TomatoCardEx3 : Card
    {
        public TomatoCardEx3(string type)
        {
            Type = type;
        }
        public override void Quest(Player player)
        {
            player.Score += 5*(player.onionStack%2);
        }
    }
    public class TomatoCardEx4 : Card
    {
        public TomatoCardEx4(string type)
        {
            Type = type;
        }
        public override void Quest(Player player)
        {
            player.Score += player.onionStack%2;
        }
    }







    /*public class OnionCardEx1 : Card
    {
        public OnionCard(string type) : base(type)
        {
            Type = type;
        }
        
        public new string Type;
    }
    public class CarrotCard : Card
    {
        public CarrotCard(string type) : base(type)
        {
            Type = type;
        }
       
        public new string Type;
    }
    public class CabbageCard : Card
    {
        public CabbageCard(string type) : base(type)
        {
            Type = type;
        }
       
        public new string Type;
    }
    public class LettuceCard : Card
    {
        public LettuceCard(string type) : base(type)
        {
            Type = type;
        }
        
        public new string Type;
    }*/
    public class PepperCardEx1 : Card
    {
        public PepperCardEx1(string type)
        {
            Type = type;
        }
        public override void Quest(Player player)
        {
            player.Score += player.cabbageStack;
            player.Score += player.tomatoStack;
        }
    }
    public class PepperCardEx2 : Card
    {
        public PepperCardEx2(string type)
        {
            Type = type;
        }
        public override void Quest(Player player)
        {
            player.Score += 3*player.cabbageStack;
            player.Score -= 2*player.carrotStack;
        }
    }









}
