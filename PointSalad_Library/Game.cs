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
        private int roundCounter = 0;
        /// <summary>
        /// Массив игроков.
        /// </summary>
        public List <T> players = new List<T>();
        /// <summary>
        /// Имя игры - Новая игра
        /// </summary>
        public string Name { get; set; }
        public Game(string name)
        {
            this.Name = name;
        }
        public void CreatePlayer(AccountStateHandler CreatePlayerHandler,
                           AccountStateHandler TakeVegetableHandler,
                           AccountStateHandler TakeQuestHandler, int cp, string name) 
        {
            for (int i = 0; i < cp; i++)
            {
                T newPlayer = new Player() as T;
                newPlayer.HasCreatePlayer += CreatePlayerHandler;
                newPlayer.HasTakenQuest += TakeQuestHandler;
                newPlayer.HasTakenVegetable += TakeVegetableHandler;
                newPlayer.CreatePlayer();
                players.Add(newPlayer);
            }
        }
        public void TakeQuest(Card card, int iD)
        {
            players[iD].TakeQuest(card);
        }
        public void TakeVegetable(Card card, int iD) 
        {
            players[iD].TakeVegetable(card);
        }
    }
}

