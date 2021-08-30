using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    public class Game <T> where T : Player
    {
        /// <summary>
        /// Счетчик раундов.
        /// </summary>
        public int roundCounter = 0;
        /// <summary>
        /// Массив игроков.
        /// </summary>
        public List <T> players = new List<T>();

        public string Name { get; set; }
        public Game(string name)
        {
            this.Name = name;
        }

        public void Create(AccountStateHandler CreatePlayerHandler,
                           AccountStateHandler TakeVegetableHandler,
                           AccountStateHandler TakeQuestHandler, int cp, string name) 
        {
            for (int i = 0; i < cp; i++)
            {
                Player newPlayer = new Player();
                newPlayer.HasCreatePlayer += CreatePlayerHandler;
                newPlayer.HasTakenQuest += TakeQuestHandler;
                newPlayer.HasTakenVegetable += TakeVegetableHandler;
                players.Add((T)(newPlayer));
            }
        }
        public void TakeQuest(Card card, int iD)
        {
            players[iD-1].TakeQuest(card);
        }
        public void TakeVegetable(Card card, int iD) 
        {
            players[iD-1].TakeVegetable(card);
        }
    }
}

