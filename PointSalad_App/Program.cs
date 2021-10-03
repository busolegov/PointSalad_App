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
            Console.WriteLine(e.Message);
        }
        public static void TakeQuestHandler(object sender, AccountEventArgs e ) 
        {
            Console.WriteLine(e.Message);
        }
        public static void TakeVegetableHandler(object sender, AccountEventArgs e) 
        {
            Console.WriteLine(e.Message);
        }
        public static void CR(Game <Player> game, int cp, string name)
        {
            game.CreatePlayer(CreatePlayerHandler, TakeQuestHandler, TakeVegetableHandler, cp, name);
        }

        /// <summary>
        /// Метод замещения взятой карты верхней из колоды.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="stack"></param>
        /// <param name="massive"></param>
        /// <returns></returns>
        public static Array ReplaceEmptyQuestCard(int index, Stack<Card> stack, ref Card [] massive) 
        {
            if (stack.Count == 0)
            {
                massive[index] = null;
            }
            else
            {
                massive[index] = stack.Pop();
            }
            return massive;

            //try
            //{
            //    Card[] temp = new Card[_massive.Length];
            //    for (int i = 0; i < _massive.Length; i++)
            //    {
            //        temp[i] = _massive[i];
            //    }
            //    if (stack.Count == 0)
            //    {
            //        temp[index] = null;

        //    }
        //    else
        //    {
        //        temp[index] = stack.Pop();
        //    }
        //    Card[] massive = temp;
        //    return massive;
        //}
        //catch
        //{
        //    return _massive;
        //} 
        }
        /// <summary>
        /// Метод, заменяющий пустые овощи на рецепты
        /// </summary>
        /// <param name="index"></param>
        /// <param name="stack"></param>
        /// <param name="massive"></param>
        /// <returns></returns>
        public static Array ReplaceEmptyVegetablesCard(int index, Stack<Card> stack, ref Card[] massive) 
        {
            if (massive[0] == null)
            {
                massive[index] = null;
            }
            else
            {
                massive[index] = massive[0];
                if (stack.Count == 0)
                {
                    massive[0] = null;
                }
                else
                {
                    massive[0] = stack.Pop();
                }
            }
            return massive;
        }
        /// <summary>
        /// Метод, проверяющий закончились ли карты на поле.
        /// </summary>
        /// <param name="massive"></param>
        /// <returns></returns>
        public static bool CheckGameContinue(Card[] massive) 
        {
            bool isGoing = false;
            for (int i = 0; i < massive.Length-1; i++)
            {
                if (massive[i] != null)
                {
                    isGoing = true;
                    break;
                }

            }
            return isGoing;
        }

        static void Main(string[] args)
        {
            //Создание всех карт.
            #region Описание карт томатов
            Card tomatoCardEx1 = new TomatoCardEx1();
            Card tomatoCardEx2 = new TomatoCardEx2();
            Card tomatoCardEx3 = new TomatoCardEx3();
            Card tomatoCardEx4 = new TomatoCardEx4();
            Card tomatoCardEx5 = new TomatoCardEx5();
            Card tomatoCardEx6 = new TomatoCardEx6();
            Card tomatoCardEx7 = new TomatoCardEx7();
            Card tomatoCardEx8 = new TomatoCardEx8();
            Card tomatoCardEx9 = new TomatoCardEx9();
            /*Card tomatoCardEx10 = new TomatoCardEx10();
            Card tomatoCardEx11 = new TomatoCardEx11();
            Card tomatoCardEx12 = new TomatoCardEx12();
            Card tomatoCardEx13 = new TomatoCardEx13();
            Card tomatoCardEx14 = new TomatoCardEx14();
            Card tomatoCardEx15 = new TomatoCardEx15();
            Card tomatoCardEx16 = new TomatoCardEx16();
            Card tomatoCardEx17 = new TomatoCardEx17();
            Card tomatoCardEx18 = new TomatoCardEx18();*/

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


            //Массив всех карт.
            Card[] allCardsMassive = new Card [] { tomatoCardEx1, tomatoCardEx2, tomatoCardEx3,
                                                   tomatoCardEx4, tomatoCardEx5, tomatoCardEx6,
                                                   tomatoCardEx7, tomatoCardEx8, tomatoCardEx9};

            //Перемешиваем все карты.
            var rand = new Random();
            for (int i = allCardsMassive.Length-1; i >= 1; i--)
            {
                int j = rand.Next(i+1);
                Card tmp = allCardsMassive[j];
                allCardsMassive[j] = allCardsMassive[i];
                allCardsMassive[i] = tmp;
            }

            Stack<Card> allCardsStack = new Stack<Card>(allCardsMassive);

            Index index0 = 0;
            Index index1 = 1;
            Index index2 = 2;

            //Три колонки карт - рецепт + 2 овоща.
            Card[] column1 = new Card[3];
            Card[] column2 = new Card[3];
            Card[] column3 = new Card[3];

            for (int i = 0; i <= 2; i++)
            {
                column1[i] = allCardsStack.Pop();
                column2[i] = allCardsStack.Pop();
                column3[i] = allCardsStack.Pop();
            }
            bool alive = true;
            restart:
            if (alive)
            {
                foreach (var player in game.players)
                {
                    #region Раскладка
                    object emptySpace = "*****";
                    object place1;
                    if (column1[0] == null)
                        place1 = emptySpace;
                    else
                        place1 = column1[0].QuestText;

                    object place2;
                    if (column2[0] == null)
                        place2 = emptySpace;
                    else
                        place2 = column2[0].QuestText;

                    object place3;
                    if (column3[0] == null)
                        place3 = emptySpace;
                    else
                        place3 = column3[0].QuestText;

                    object place4;
                    if (column1[1] == null)
                        place4 = emptySpace;
                    else
                        place4 = column1[1].Type;

                    object place5;
                    if (column2[1] == null)
                        place5 = emptySpace;
                    else
                        place5 = column2[1].Type;

                    object place6;
                    if (column3[1] == null)
                        place6 = emptySpace;
                    else
                        place6 = column3[1].Type;

                    object place7;
                    if (column1[2] == null)
                        place7 = emptySpace;
                    else
                        place7 = column1[2].Type;

                    object place8;
                    if (column2[2] == null)
                        place8 = emptySpace;
                    else
                        place8 = column2[2].Type;

                    object place9;
                    if (column3[2] == null)
                        place9 = emptySpace;
                    else
                        place9 = column3[2].Type;

                    Console.WriteLine("1. " + place1 + "\t 2. " + place2 + "\t 3. " + place3);
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    Console.WriteLine("1. " + place4 + "\t 2. " + place5 + "\t 3. " + place6);
                    Console.WriteLine();
                    Console.WriteLine("4. " + place7 + "\t 5. " + place8 + "\t 6. " + place9);
                    Console.WriteLine();
                    #endregion

                    Console.WriteLine($"Ходит игрок {player.iD}.....");
                    Console.WriteLine();
                    Console.WriteLine($"салат: {player.lettuceStack}\n");
                    ConsoleColor color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkGreen; // выводим список команд зеленым цветом
                    Console.WriteLine("1. Взять карту рецепта \t 2. Взять два овоща  \t 3. Выйти из программы");
                    Console.WriteLine("Введите номер пункта:");
                    Console.ForegroundColor = color;
                    
                    try
                    {
                        int command1 = Convert.ToInt32(Console.ReadLine());
                        switch (command1)
                        {
                            case 1:
                                Console.WriteLine("Введи номер карты рецепта, которую хочешь взять: ");
                                int command2 = Convert.ToInt32(Console.ReadLine());
                                switch (command2)
                                {
                                    case 1:
                                        {
                                            try
                                            {
                                                TakeQuest(game, column1[0], player.iD - 1);
                                            }
                                            catch (Exception)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Такой карты рецепта нет, выбери другую");
                                                Console.WriteLine();
                                                Console.ResetColor();
                                            }
                                            finally
                                            {
                                                column1 = (Card[])ReplaceEmptyQuestCard(0, allCardsStack, ref column1);
                                            }
                                            continue;
                                        }
                                    case 2:
                                        {
                                            try
                                            {
                                                TakeQuest(game, column2[0], player.iD - 1);
                                            }
                                            catch (Exception)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Такой карты рецепта нет, выбери другую");
                                                Console.WriteLine();
                                                Console.ResetColor();
                                            }
                                            finally
                                            {
                                                column2 = (Card[])ReplaceEmptyQuestCard(0, allCardsStack, ref column2);
                                            }
                                            continue;
                                        }
                                    case 3:
                                        {
                                            try
                                            {
                                                TakeQuest(game, column3[0], player.iD - 1);
                                            }
                                            catch (Exception)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Такой карты рецепта нет, выбери другую");
                                                Console.WriteLine();
                                                Console.ResetColor();
                                            }
                                            finally
                                            {
                                                column3 = (Card[])ReplaceEmptyQuestCard(0, allCardsStack, ref column3);
                                            }
                                            continue;
                                        }
                                }
                                break;
                            case 2:
                                Console.WriteLine("Введите карту первого овоща:");
                                int command3 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите карту второго овоща:");
                                int command4 = Convert.ToInt32(Console.ReadLine());

                                if (command3 == command4)
                                {
                                    Console.WriteLine("Этот овощ уже взят тобой. Выбери другой.");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    switch (command3)
                                    {
                                        case 1:
                                            {
                                                try
                                                {
                                                    TakeVegetable(game, column1[1], player.iD - 1);
                                                }
                                                catch
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Такой карты овоща нет, выбери другую");
                                                    Console.ResetColor();
                                                    Console.WriteLine();
                                                }
                                                column1 = (Card[])ReplaceEmptyVegetablesCard(1, allCardsStack, ref column1);
                                            }
                                            break;
                                        case 2:
                                            {
                                                try
                                                {
                                                    TakeVegetable(game, column2[1], player.iD - 1);
                                                }
                                                catch
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Такой карты овоща нет, выбери другую");
                                                    Console.ResetColor();
                                                    Console.WriteLine();
                                                }
                                                column2 = (Card[])ReplaceEmptyVegetablesCard(1, allCardsStack, ref column2);
                                            }
                                            break;
                                        case 3:
                                            {
                                                try
                                                {
                                                    TakeVegetable(game, column3[1], player.iD - 1);
                                                }
                                                catch
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Такой карты овоща нет, выбери другую");
                                                    Console.ResetColor();
                                                    Console.WriteLine();
                                                }
                                                column3 = (Card[])ReplaceEmptyVegetablesCard(1, allCardsStack, ref column3);
                                            }
                                            break;
                                        case 4:
                                            {
                                                try
                                                {
                                                    TakeVegetable(game, column1[2], player.iD - 1);
                                                }
                                                catch
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Такой карты овоща нет, выбери другую");
                                                    Console.ResetColor();
                                                    Console.WriteLine();
                                                }
                                                column1 = (Card[])ReplaceEmptyVegetablesCard(2, allCardsStack, ref column1);
                                            }
                                            break;
                                        case 5:
                                            {
                                                try
                                                {
                                                    TakeVegetable(game, column2[2], player.iD - 1);
                                                }
                                                catch
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Такой карты овоща нет, выбери другую");
                                                    Console.ResetColor();
                                                    Console.WriteLine();
                                                }
                                                column2 = (Card[])ReplaceEmptyVegetablesCard(2, allCardsStack, ref column2);
                                            }
                                            break;
                                        case 6:
                                            {
                                                try
                                                {
                                                    TakeVegetable(game, column3[2], player.iD - 1);
                                                }
                                                catch
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Такой карты овоща нет, выбери другую");
                                                    Console.ResetColor();
                                                    Console.WriteLine();
                                                }
                                                column3 = (Card[])ReplaceEmptyVegetablesCard(2, allCardsStack, ref column3);
                                            }
                                            break;
                                    }
                                    switch (command4)
                                    {
                                        case 1:
                                            {
                                                try
                                                {
                                                    TakeVegetable(game, column1[1], player.iD - 1);
                                                }
                                                catch
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Такой карты овоща нет, выбери другую");
                                                    Console.ResetColor();
                                                    Console.WriteLine();
                                                }
                                                column1 = (Card[])ReplaceEmptyVegetablesCard(1, allCardsStack, ref column1);
                                            }
                                            break;
                                        case 2:
                                            {
                                                try
                                                {
                                                    TakeVegetable(game, column2[1], player.iD - 1);
                                                }
                                                catch
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Такой карты овоща нет, выбери другую");
                                                    Console.ResetColor();
                                                    Console.WriteLine();
                                                }
                                                column2 = (Card[])ReplaceEmptyVegetablesCard(1, allCardsStack, ref column2);
                                            }
                                            break;
                                        case 3:
                                            {
                                                try
                                                {
                                                    TakeVegetable(game, column3[1], player.iD - 1);
                                                }
                                                catch
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Такой карты овоща нет, выбери другую");
                                                    Console.ResetColor();
                                                    Console.WriteLine();
                                                }
                                                column3 = (Card[])ReplaceEmptyVegetablesCard(1, allCardsStack, ref column3);
                                            }
                                            break;
                                        case 4:
                                            {
                                                try
                                                {
                                                    TakeVegetable(game, column1[2], player.iD - 1);
                                                }
                                                catch
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Такой карты овоща нет, выбери другую");
                                                    Console.ResetColor();
                                                    Console.WriteLine();
                                                }
                                                column1 = (Card[])ReplaceEmptyVegetablesCard(2, allCardsStack, ref column1);
                                            }
                                            break;
                                        case 5:
                                            {
                                                try
                                                {
                                                    TakeVegetable(game, column2[2], player.iD - 1);
                                                }
                                                catch
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Такой карты овоща нет, выбери другую");
                                                    Console.ResetColor();
                                                    Console.WriteLine();
                                                }
                                                column2 = (Card[])ReplaceEmptyVegetablesCard(2, allCardsStack, ref column2);
                                            }
                                            break;
                                        case 6:
                                            {
                                                try
                                                {
                                                    TakeVegetable(game, column3[2], player.iD - 1);
                                                }
                                                catch
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Такой карты овоща нет, выбери другую");
                                                    Console.ResetColor();
                                                    Console.WriteLine();
                                                }
                                                column3 = (Card[])ReplaceEmptyVegetablesCard(2, allCardsStack, ref column3);
                                            }
                                            break;
                                    }
                                    break;
                                }
                                break;
                        }
                        Card[] cardsInPlayPre = new Card[9];

                        for (int k = 0, i = 0; i <= 2; i++, k++)
                        {
                            cardsInPlayPre[k] = column1[i];
                            k++;
                            cardsInPlayPre[k] = column2[i];
                            k++;
                            cardsInPlayPre[k] = column3[i];
                        }
                        bool isAlive1 = CheckGameContinue(cardsInPlayPre);
                        if (isAlive1)
                        {
                            continue;
                        }
                        else
                        {
                            alive = false;
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
                Card[] cardsInPlay = new Card[9];

                for (int k = 0, i = 0; i <= 2; i++, k++)
                {
                //    cardsInPlay[k] = column1[i];
                //    k++;
                //    cardsInPlay[k] = column2[i];
                //    k++;
                //    cardsInPlay[k] = column3[i];
                }
                //bool isAlive2 = CheckGameContinue(cardsInPlay);
                if (alive)
                {
                    goto restart;
                }
                //else
                //{
                //    alive = false;

                //}
            }

            for (int i = 0; i <= game.players.Count - 1; i++)
               {
                 game.players[i].Scoring();
                 Console.WriteLine($"Игрок {i + 1} набрал {game.players[i].Scoring()}");
               }
                Console.ReadLine();
            
        }
    }
}
