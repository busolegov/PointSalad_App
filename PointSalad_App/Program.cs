using System;
using System.Collections.Generic;
using System.Linq;
using PointSalad_Library;

namespace PointSalad_App
{
    class Program
    {
        public static void Scoring(Game <Player> game, int iD) 
        {
            game.Scoring(iD);
        }
        public static void TakeQuest(Game <Player> game, Card card, int iD)
        {
            game.TakeQuest(card, iD);
        }
        public static void TakeVegetable(Game<Player> game, Card card, int iD) 
        {
            game.TakeVegetable(card, iD);
        }
        public static void ScoringHandler(object sender, AccountEventArgs e) 
        {
            Console.WriteLine(e.Message);
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
            game.CreatePlayer(ScoringHandler, CreatePlayerHandler, TakeQuestHandler, TakeVegetableHandler, cp, name);
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

        public static void MixCardsForGame(int count, List<Card> Massive1, Card[] Massive2, Card[] Massive3,
                                            Card[] Massive4, Card[] Massive5, Card[] Massive6) 
        {
            //Random rndm = new Random();
            //for (int i = 0; i < count; i++)
            //{
            //    for (int k = 0; k < count; k++)
            //    {
            //        int j = rndm.Next(0, Massive1.Length-k);
            //    }
            //}

            Random rand = new Random();
            for (int i = Massive1.Count; i >= Massive1.Count - count ; i--)
            {
                int j = rand.Next(0, i);
                List<Card> tmp = new List<Card>();
                tmp.Add(Massive1[j]);
                Massive1.RemoveAt(j);
            }

        }



        static void Main(string[] args)
        {
            #region Создание карт

            //Создание всех карт.
            #region Описание карт томатов
            Card tomatoCardEx1 = new TomatoCardEx1();
            Card tomatoCardEx2 = new TomatoCardEx2();
            Card tomatoCardEx3 = new TomatoCardEx3();
            Card tomatoCardEx4 = new TomatoCardEx4();
            Card tomatoCardEx5 = new TomatoCardEx5();
            Card tomatoCardEx6 = new TomatoCardEx6();
            //Card tomatoCardEx7 = new TomatoCardEx7();
            //Card tomatoCardEx8 = new TomatoCardEx8();
            Card tomatoCardEx9 = new TomatoCardEx9();

            //Card[] TomatoMassive = new Card[] { tomatoCardEx1, tomatoCardEx2, tomatoCardEx3,
            //                                    tomatoCardEx4,tomatoCardEx5,tomatoCardEx6,
            //                                    tomatoCardEx9};

            List<Card> TomatoCards = new List<Card>();
            TomatoCards.Add(tomatoCardEx1);
            TomatoCards.Add(tomatoCardEx2);
            TomatoCards.Add(tomatoCardEx3);
            TomatoCards.Add(tomatoCardEx4);
            TomatoCards.Add(tomatoCardEx5);
            TomatoCards.Add(tomatoCardEx6);
            //TomatoCards.Add(tomatoCardEx7);
            //TomatoCards.Add(tomatoCardEx8);
            TomatoCards.Add(tomatoCardEx9);
            #endregion

            #region Описание карт перцев
            Card pepperCardEx1 = new PepperCardEx1();
            Card pepperCardEx2 = new PepperCardEx2();
            Card pepperCardEx3 = new PepperCardEx2();
            Card pepperCardEx4 = new PepperCardEx2();
            Card pepperCardEx5 = new PepperCardEx2();
            Card pepperCardEx6 = new PepperCardEx2();
            Card pepperCardEx7 = new PepperCardEx2();
            Card pepperCardEx8 = new PepperCardEx2();
            Card pepperCardEx9 = new PepperCardEx2();

            //Card [] PepperMassive = new Card [] { pepperCardEx1, pepperCardEx2, pepperCardEx3,
            //                                      pepperCardEx4, pepperCardEx5, pepperCardEx6,
            //                                      pepperCardEx7, pepperCardEx8, pepperCardEx9};

            List<Card> PepperCards = new List<Card>();
            PepperCards.Add(pepperCardEx1);
            PepperCards.Add(pepperCardEx2);
            PepperCards.Add(pepperCardEx3);
            PepperCards.Add(pepperCardEx4);
            PepperCards.Add(pepperCardEx5);
            PepperCards.Add(pepperCardEx6);
            PepperCards.Add(pepperCardEx7);
            PepperCards.Add(pepperCardEx8);
            PepperCards.Add(pepperCardEx9);
            #endregion

            #region Описание карт салата
            Card lettuceCardEx1 = new LettuceCardEx1();
            Card lettuceCardEx2 = new LettuceCardEx2();
            Card lettuceCardEx3 = new LettuceCardEx3();
            Card lettuceCardEx4 = new LettuceCardEx4();
            Card lettuceCardEx5 = new LettuceCardEx5();
            Card lettuceCardEx6 = new LettuceCardEx6();
            Card lettuceCardEx7 = new LettuceCardEx7();
            Card lettuceCardEx8 = new LettuceCardEx8();
            Card lettuceCardEx9 = new LettuceCardEx9();

            //Card[] LettuceMassive = new Card[] { lettuceCardEx1, lettuceCardEx2, lettuceCardEx3,
            //                                      lettuceCardEx4, lettuceCardEx5, lettuceCardEx6,
            //                                      lettuceCardEx7, lettuceCardEx8, lettuceCardEx9};
            List<Card> LettuceCards = new List<Card>();
            LettuceCards.Add(lettuceCardEx1);
            LettuceCards.Add(lettuceCardEx2);
            LettuceCards.Add(lettuceCardEx3);
            LettuceCards.Add(lettuceCardEx4);
            LettuceCards.Add(lettuceCardEx5);
            LettuceCards.Add(lettuceCardEx6);
            LettuceCards.Add(lettuceCardEx7);
            LettuceCards.Add(lettuceCardEx8);
            LettuceCards.Add(lettuceCardEx9);
            #endregion

            #region Описание карт капусты
            Card cabbageCardEx1 = new CabbageCardEx1();
            Card cabbageCardEx2 = new CabbageCardEx2();
            Card cabbageCardEx3 = new CabbageCardEx3();
            Card cabbageCardEx4 = new CabbageCardEx4();
            Card cabbageCardEx5 = new CabbageCardEx5();
            Card cabbageCardEx6 = new CabbageCardEx6();
            Card cabbageCardEx7 = new CabbageCardEx7();
            Card cabbageCardEx8 = new CabbageCardEx8();
            Card cabbageCardEx9 = new CabbageCardEx9();

            //Card[] CabbageMassive = new Card[] { pepperCardEx1, pepperCardEx2, pepperCardEx3,
            //                                     pepperCardEx4, pepperCardEx5, pepperCardEx6,
            //                                     pepperCardEx7, pepperCardEx8, pepperCardEx9};
            List<Card> CabbageCards = new List<Card>();
            CabbageCards.Add(cabbageCardEx1);
            CabbageCards.Add(cabbageCardEx2);
            CabbageCards.Add(cabbageCardEx3);
            CabbageCards.Add(cabbageCardEx4);
            CabbageCards.Add(cabbageCardEx5);
            CabbageCards.Add(cabbageCardEx6);
            CabbageCards.Add(cabbageCardEx7);
            CabbageCards.Add(cabbageCardEx8);
            CabbageCards.Add(cabbageCardEx9);

            #endregion

            #region Описание карт лука
            Card onionCardEx1 = new OnionCardEx1();
            Card onionCardEx2 = new OnionCardEx2();
            Card onionCardEx3 = new OnionCardEx3();
            Card onionCardEx4 = new OnionCardEx4();
            Card onionCardEx5 = new OnionCardEx5();
            Card onionCardEx6 = new OnionCardEx6();
            Card onionCardEx7 = new OnionCardEx7();
            Card onionCardEx8 = new OnionCardEx8();
            Card onionCardEx9 = new OnionCardEx9();

            //Card[] OnionMassive = new Card[] { onionCardEx1, onionCardEx2, onionCardEx3,
            //                                   onionCardEx4, onionCardEx5, onionCardEx6,
            //                                   onionCardEx7, onionCardEx8, onionCardEx9};

            List<Card> OnionCards = new List<Card>();
            OnionCards.Add(onionCardEx1);
            OnionCards.Add(onionCardEx2);
            OnionCards.Add(onionCardEx3);
            OnionCards.Add(onionCardEx4);
            OnionCards.Add(onionCardEx5);
            OnionCards.Add(onionCardEx6);
            OnionCards.Add(onionCardEx7);
            OnionCards.Add(onionCardEx8);
            OnionCards.Add(onionCardEx9);
            #endregion

            #region Описание карт моркови
            Card carrotCardEx1 = new CarrotCardEx1();
            Card carrotCardEx2 = new CarrotCardEx2();
            Card carrotCardEx3 = new CarrotCardEx3();
            Card carrotCardEx4 = new CarrotCardEx4();
            Card carrotCardEx5 = new CarrotCardEx5();
            Card carrotCardEx6 = new CarrotCardEx6();
            Card carrotCardEx7 = new CarrotCardEx7();
            Card carrotCardEx8 = new CarrotCardEx8();
            Card carrotCardEx9 = new CarrotCardEx9();

            //Card[] CarroteMassive = new Card[] { carrotCardEx1, carrotCardEx2, carrotCardEx3,
            //                                     carrotCardEx4, carrotCardEx5, carrotCardEx6,
            //                                     carrotCardEx7, carrotCardEx8, carrotCardEx9};

            List<Card> CarrotCards = new List<Card>();
            CarrotCards.Add(carrotCardEx1);
            CarrotCards.Add(carrotCardEx2);
            CarrotCards.Add(carrotCardEx3);
            CarrotCards.Add(carrotCardEx4);
            CarrotCards.Add(carrotCardEx5);
            CarrotCards.Add(carrotCardEx6);
            CarrotCards.Add(carrotCardEx7);
            CarrotCards.Add(carrotCardEx8);
            CarrotCards.Add(carrotCardEx9);
            #endregion
            #endregion

            string name = "Новая игра";
            Console.WriteLine(name);
            Game <Player> game = new Game <Player> (name);
            int countPlayers;
            while (true)
            {
                Console.WriteLine("Введите количество игроков от 2 до 5");
                if (int.TryParse(Console.ReadLine(), out countPlayers) & (countPlayers >1 & countPlayers < 6))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат или количество игроков.");
                }
            }
            Console.WriteLine($"В игре принимает участие {countPlayers} игрока:");
            CR(game, countPlayers, name);
            Console.WriteLine("Игра начинается...");

            //Массив всех карт.
            List<Card> CardsForGameList = new List<Card>();
            CardsForGameList.AddRange(TomatoCards);
            CardsForGameList.AddRange(PepperCards);
            CardsForGameList.AddRange(LettuceCards);
            CardsForGameList.AddRange(CabbageCards);
            CardsForGameList.AddRange(OnionCards);
            CardsForGameList.AddRange(CarrotCards);


            //Перемешиваем все карты.
            var rand = new Random();
            for (int i = CardsForGameList.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                Card temp = CardsForGameList[j];
                CardsForGameList[j] = CardsForGameList[i];
                CardsForGameList[i] = temp;
            }

            Stack<Card> allCardsStack = new Stack<Card>(CardsForGameList);

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
                Console.WriteLine($"Начинается раунд {game.roundCounter}");    
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

                    player.Scoring(game.players.IndexOf(player) + 1);
                    Console.WriteLine(player.Score);

                    player.ShowInfo(game.players.IndexOf(player)+1);

                    

                    ConsoleColor color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkGreen; // выводим список команд зеленым цветом
                    Console.WriteLine("1. Взять карту рецепта \t 2. Взять два овоща  \t 3. Выйти из программы");
                    Console.WriteLine("Введите номер пункта:");
                    Console.ForegroundColor = color;
                    
                    try
                    {
                        int command1 = int.Parse(Console.ReadLine());
                        switch (command1)
                        {
                            case 1:
                                Console.WriteLine("Введи номер карты рецепта, которую хочешь взять: ");
                                int command2 = int.Parse(Console.ReadLine());
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
                

                if (alive)
                    game.roundCounter ++;
                    goto restart;
            }

            for (int i = 1; i <= game.players.Count - 1; i++)
               {
                    Scoring(game, i);
               }
                Console.ReadLine();
            
        }
    }
}
