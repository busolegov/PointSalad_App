using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    public class Game <T> where T : Player
    {
        public int roundCounter = 0;
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
                           AccountStateHandler TakeQuestHandler,
                           AccountStateHandler ScoringHandler,
                           int count, string name) 
        {
            for (int i = 0; i < count; i++)
            {
                T newPlayer = new Player() as T;
                newPlayer.HasCreatePlayer += CreatePlayerHandler;
                newPlayer.HasTakenQuest += TakeQuestHandler;
                newPlayer.HasTakenVegetable += TakeVegetableHandler;
                newPlayer.HasScoring += ScoringHandler;
                newPlayer.CreatePlayer();
                players.Add(newPlayer);
            }
        }
        public void Scoring(int iD) 
        {
            players[iD].Scoring(iD);
        }
        public void TakeQuest(Card card, int iD)
        {
            players[iD].TakeQuest(card);
        }
        public void TakeVegetable(Card card, int iD) 
        {
            players[iD].TakeVegetable(card);
        }
        public void ShowInfo(int iD) 
        {
            Console.WriteLine($"Ходит игрок {iD}.....");
            Console.WriteLine();

            Console.WriteLine($"салат: {players[iD].LetucceStack}");
            Console.WriteLine($"лук: {players[iD].OnionStack}");
            Console.WriteLine($"капуста: {players[iD].CabbageStack}");
            Console.WriteLine($"перец: {players[iD].PepperStack}");
            Console.WriteLine($"томат: {players[iD].TomatoStack}");
            Console.WriteLine($"морковь: {players[iD].CarrotStack}");
            Console.WriteLine("---------------------------------------------------------------");
            foreach (Card questCards in players[iD].QuestStack)
            {
                Console.WriteLine(questCards.QuestText);
            }
        }
    }
}

