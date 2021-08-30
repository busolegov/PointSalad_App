using System;
using System.Collections.Generic;
using System.Linq;
using PointSalad_Library;

namespace PointSalad_App
{
    class Program
    {
        public static void TakeQuest(Game <Player> game, Card card, int iD)
        {
            game.TakeQuest(card, iD);
        }
        public static void TakeVegetable(Game<Player> game, Card card, int iD) 
        {
            game.TakeVegetable(card, iD);
        }
        public static void CreatePlayerHandler(object sender, AccountEventArgs e) 
        {
            Console.WriteLine(e);
        }
        public static void TakeQuestHandler(object sender, AccountEventArgs e ) 
        {
            Console.WriteLine(e);
        }
        public static void TakeVegetableHandler(object sender, AccountEventArgs e) 
        {
            Console.WriteLine(e);
        }
        public static void CR(Game <Player> game, int cp, string name)
        {
            game.Create(CreatePlayerHandler, TakeQuestHandler, TakeVegetableHandler, cp, name);
        }

        /// <summary>
        /// Метод проверки пустого стека рецептов.
        /// </summary>
        /// <param name="firstStackList"></param>
        /// <param name="secondStackList"></param>
        /// <param name="thirdStackList"></param>
        public static void CheckEmptyQuestStack(List<Card> firstStackList, List<Card> secondStackList, List<Card> thirdStackList) 
        {
            if (firstStackList == null || secondStackList == null || thirdStackList == null)
            {
                ShuffleMethod(firstStackList, secondStackList, thirdStackList);
            }
        }
        /// <summary>
        /// Метод перетасовки кар рецептов, при пустом стеке.
        /// </summary>
        /// <param name="firstStackList"></param>
        /// <param name="secondStackList"></param>
        /// <param name="thirdStackList"></param>
        public static void ShuffleMethod(List<Card> firstStackList, List<Card> secondStackList, List<Card> thirdStackList) 
        {
            List<Card> testList = new List<Card>();
            if (firstStackList != null)
            {
                testList.AddRange(firstStackList);
            }
            if (secondStackList != null)
            {
                testList.AddRange(secondStackList);
            }
            if (thirdStackList != null)
            {
                testList.AddRange(thirdStackList);
            }

        }
        static void Main(string[] args)
        {
            //Описание всех карт.
            #region Описание карт томатов
            Card tomatoCardEx1 = new TomatoCardEx1();
            Card tomatoCardEx2 = new TomatoCardEx2();
            Card tomatoCardEx3 = new TomatoCardEx3();
            Card tomatoCardEx4 = new TomatoCardEx4();
            Card tomatoCardEx5 = new TomatoCardEx4();
            Card tomatoCardEx6 = new TomatoCardEx4();
            Card tomatoCardEx7 = new TomatoCardEx4();
            Card tomatoCardEx8 = new TomatoCardEx4();
            Card tomatoCardEx9 = new TomatoCardEx4();
            Card tomatoCardEx10 = new TomatoCardEx4();
            Card tomatoCardEx11 = new TomatoCardEx4();
            Card tomatoCardEx12 = new TomatoCardEx4();
            Card tomatoCardEx13 = new TomatoCardEx4();
            Card tomatoCardEx14 = new TomatoCardEx4();
            Card tomatoCardEx15 = new TomatoCardEx4();
            Card tomatoCardEx16 = new TomatoCardEx4();
            Card tomatoCardEx17 = new TomatoCardEx4();
            Card tomatoCardEx18 = new TomatoCardEx4();
            #endregion
            #region Описание карт перцев
            Card PepperCardEx1 = new PepperCardEx1();
            Card PepperCardEx2 = new PepperCardEx2();
            #endregion

            string name = "Новая игра";
            Console.WriteLine(name);
            Game <Player> game = new Game <Player> (name);
            Console.WriteLine("Введите количество игроков");
            string cp = Console.ReadLine();
            int countPlayers = Convert.ToInt32(cp);
            if (countPlayers > 5 || countPlayers < 2)
            {
                throw new Exception("Количество игроков должно быть от 2 до 5");
            }
            Console.WriteLine($"В игре принимает участие {countPlayers} игрока:");

            CR(game, countPlayers, name);

            Console.WriteLine("Игра начинается...");

            #region DefaultStatement

            //Массив всех карт
            Card[] allCardsMassive = new Card [] { tomatoCardEx1, tomatoCardEx2, tomatoCardEx3,
                                                   tomatoCardEx4, PepperCardEx1, PepperCardEx2};
            
            List<Card> allCardsList = new List<Card>();
            allCardsList.AddRange(allCardsMassive);
            var rand = new Random();
            
            // Три стека карт заданий.
            List <Card> firstStackList = new List <Card>();
            List <Card> secondStackList = new List <Card>();
            List <Card> thirdStackList = new List <Card>();

            //Случайное формирование трех стеков карт заданий из всех карт.
            for (int i = 0; i <= 1; i++)
            {
                int k = rand.Next(0, (5 - i));
                firstStackList.Add(allCardsList[k]);
                allCardsList.Remove(allCardsList[k]);
            }
            for (int i = 0; i <= 1; i++)
            {
                int k = rand.Next(0, (3 - i));
                secondStackList.Add(allCardsList[k]);
                allCardsList.Remove(allCardsList[k]);
            }
            thirdStackList = allCardsList;

            //Шесть карты овощей.
            List<Card> vegetableOne = new List<Card>();
            List<Card> vegetableTwo = new List<Card>();
            List<Card> vegetableThree = new List<Card>();
           List<Card> vegetableFour = new List<Card>();
            List<Card> vegetableFive = new List<Card>();
            List<Card> vegetableSix = new List<Card>();

            //Три стека карт рецептов.
            Stack<Card> firstStackStack = new Stack<Card>(firstStackList);
            Stack<Card> secondStackStack = new Stack<Card>(secondStackList);
            Stack<Card> thirdStackStack = new Stack<Card>(thirdStackList);

            //Шесть карт овощей.
            Card card1 = firstStackStack.Pop();
            vegetableOne.Add(card1);
            Card card2 = secondStackStack.Pop();
            vegetableTwo.Add(card2);
            Card card3 = thirdStackStack.Pop();
            vegetableThree.Add(card3);
            Card card4 = firstStackStack.Pop();
            vegetableFour.Add(card4);
            Card card5 = secondStackStack.Pop();
            vegetableFive.Add(card5);
            Card card6 = thirdStackStack.Pop();
            vegetableSix.Add(card6);


            Console.WriteLine(firstStackStack.Peek().QuestText + "\t" + secondStackStack.Peek().QuestText + "\t" + thirdStackStack.Peek().QuestText);
            Console.WriteLine(card1.Type +"\t"+ card2.Type +"\t"+ card3.Type);

            Console.WriteLine();
            #endregion

            bool alive = true;
            for (int i = 0; i < game.players.Count; i++)
            {
                while (alive)
                {
                    {
                        ConsoleColor color = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.DarkGreen; // выводим список команд зеленым цветом
                        Console.WriteLine("1. Взять карту рецепта \t 2. Взять два овоща  \t 3. Выйти из программы");
                        Console.WriteLine("Введите номер пункта:");
                        Console.ForegroundColor = color;
                        try
                        {
                            int firstCommand = Convert.ToInt32(Console.ReadLine());
                            int secondCommand = Convert.ToInt32(Console.ReadLine());
                            int thirdCommand = Convert.ToInt32(Console.ReadLine());
                            int fourth = Convert.ToInt32(Console.ReadLine());
                            switch (firstCommand)
                            {
                                case 1:
                                    Console.WriteLine("Введи карту рецепта, которую требуется добавить в свой стек:");
                                    switch (secondCommand)
                                    {
                                        case 1:
                                            {
                                                game.players[i].TakeQuest(firstStackStack.Pop());
                                                break;
                                            }
                                        case 2:
                                            {
                                                game.players[i].TakeQuest(secondStackStack.Pop());
                                                break;
                                            }
                                        case 3:
                                            {
                                                game.players[i].TakeQuest(thirdStackStack.Pop());
                                                break;
                                            }
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("Введите карту первого овоща:");
                                    switch (thirdCommand)
                                    {
                                        case 1:
                                            {
                                                game.players[i].TakeVegetable(card1);
                                            }
                                            break;
                                        case 2:
                                            {
                                                game.players[i].TakeVegetable(card2);
                                            }
                                            break;
                                        case 3:
                                            {
                                                game.players[i].TakeVegetable(card3);
                                            }
                                            break;
                                        case 4:
                                            {
                                                game.players[i].TakeVegetable(card4);
                                            }
                                            break;
                                        case 5:
                                            {
                                                game.players[i].TakeVegetable(card5);
                                            }
                                            break;
                                        case 6:
                                            {
                                                game.players[i].TakeVegetable(card6);
                                            }
                                            break;
                                    }
                                    Console.WriteLine("Введите карту второго овоща:");
                                    switch (fourth)
                                    {
                                        case 1:
                                            {
                                                game.players[i].TakeVegetable(card1);
                                            }
                                            break;
                                        case 2:
                                            {
                                                game.players[i].TakeVegetable(card2);
                                            }
                                            break;
                                        case 3:
                                            {
                                                game.players[i].TakeVegetable(card3);
                                            }
                                            break;
                                        case 4:
                                            {
                                                game.players[i].TakeVegetable(card4);
                                            }
                                            break;
                                        case 5:
                                            {
                                                game.players[i].TakeVegetable(card5);
                                            }
                                            break;
                                        case 6:
                                            {
                                                game.players[i].TakeVegetable(card6);
                                            }
                                            break;
                                    }
                                    break;
                        }
                    }
                    catch (Exception ex)
                    {
                        // выводим сообщение об ошибке красным цветом
                        color = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = color;
                    }
                }
                    
                }
            }
            
            












        }
    }
}
