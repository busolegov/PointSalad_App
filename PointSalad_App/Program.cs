using PointSalad_Library;
using System;
using System.Collections.Generic;

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
        public static bool CheckGameContinue(List<Card> massive) 
        {
            bool isGoing = false;

                foreach (var item in massive)
                {
                    if (item != null)
                    {
                        isGoing = true;
                        break;
                    }
                }
            return isGoing;
        }

        /// <summary>
        /// Метод, отбирающий карты для игры, в зависимости от количества игроков.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <param name="list3"></param>
        /// <param name="list4"></param>
        /// <param name="list5"></param>
        /// <param name="list6"></param>
        /// <returns></returns>
        public static List<Card> MixCardsForGame(int count, List<Card> list1, List<Card> list2, List<Card> list3,
                                            List<Card> list4, List<Card> list5, List<Card> list6) 
        {
            List<Card> tmp1 = new List<Card>();
            List<Card> tmp2 = new List<Card>();
            List<Card> tmp3 = new List<Card>();
            List<Card> tmp4 = new List<Card>();
            List<Card> tmp5 = new List<Card>();
            List<Card> tmp6 = new List<Card>();

            Random rand = new Random();
            int cardsQuantity = list1.Count - 1;
            for (int i = 0; i < (count-1)*3 ; i++)
            {
                int j = rand.Next(0, cardsQuantity);
                tmp1.Add(list1[j]);
                list1.RemoveAt(j);

                int k = rand.Next(0, cardsQuantity);
                tmp2.Add(list2[k]);
                list2.RemoveAt(k);

                int o = rand.Next(0, cardsQuantity);
                tmp3.Add(list3[o]);
                list3.RemoveAt(o);

                int p = rand.Next(0, cardsQuantity);
                tmp4.Add(list4[p]);
                list4.RemoveAt(p);

                int q = rand.Next(0, cardsQuantity);
                tmp5.Add(list5[q]);
                list5.RemoveAt(q);

                int r = rand.Next(0, cardsQuantity);
                tmp6.Add(list6[r]);
                list6.RemoveAt(r);

                cardsQuantity--;
            }
            list1 = tmp1;
            list2 = tmp2;
            list3 = tmp3;
            list4 = tmp4;
            list5 = tmp5;
            list6 = tmp6;

            List<Card> CardsForGameList = new List<Card>();
            CardsForGameList.AddRange(list1);
            CardsForGameList.AddRange(list2);
            CardsForGameList.AddRange(list3);
            CardsForGameList.AddRange(list4);
            CardsForGameList.AddRange(list5);
            CardsForGameList.AddRange(list6);

            var rand1 = new Random();
            for (int i = CardsForGameList.Count - 1; i >= 0; i--)
            {
                int j = rand1.Next(i + 1);
                Card temp = CardsForGameList[j];
                CardsForGameList[j] = CardsForGameList[i];
                CardsForGameList[i] = temp;
            }
            return CardsForGameList;
        }

        /// <summary>
        /// Метод пердупреждения об ошибке. Красный цвет текста.
        /// </summary>
        public static void ShowMessageRed(string mes) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mes);
            Console.ForegroundColor = ConsoleColor.White;
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
            Card tomatoCardEx7 = new TomatoCardEx7();
            Card tomatoCardEx8 = new TomatoCardEx8();
            Card tomatoCardEx9 = new TomatoCardEx9();
            List<Card> TomatoCards = new List<Card>();

            TomatoCards.Add(tomatoCardEx1);
            TomatoCards.Add(tomatoCardEx2);
            TomatoCards.Add(tomatoCardEx3);
            TomatoCards.Add(tomatoCardEx4);
            TomatoCards.Add(tomatoCardEx5);
            TomatoCards.Add(tomatoCardEx6);
            TomatoCards.Add(tomatoCardEx7);
            TomatoCards.Add(tomatoCardEx8);
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
                    ShowMessageRed("Неверный формат или количество игроков.");
                }
            }
            Console.WriteLine($"В игре принимает участие {countPlayers} игрока:");
            CR(game, countPlayers, name);
            Console.WriteLine("Игра начинается...");

            Stack<Card> allCardsStack = new Stack<Card>(MixCardsForGame(countPlayers, TomatoCards, CarrotCards,
                                                        OnionCards, CabbageCards, PepperCards, LettuceCards));

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
                Console.WriteLine();
                Console.WriteLine($"РАУНД {game.roundCounter}");
                Console.WriteLine();
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

                    Console.WriteLine("####################################################################################");
                    Console.WriteLine("1. " + place1 + "   2. " + place2 + "   3. " + place3);
                    Console.WriteLine("####################################################################################");
                    Console.WriteLine("1. " + place4 + "\t 2. " + place5 + "\t 3. " + place6);
                    Console.WriteLine();
                    Console.WriteLine("4. " + place7 + "\t 5. " + place8 + "\t 6. " + place9);
                    Console.WriteLine("####################################################################################");
                    #endregion

                    player.ShowInfo(game.players.IndexOf(player) + 1);
                    foreach (var card in player.QuestStack)
                    {
                        card.Quest(game, player);
                    }

                    Console.WriteLine("Промежуточное количество очков: " + player.Score);
                    player.Score = 0;
                    Console.WriteLine();

                    ConsoleColor color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("1. Взять карту рецепта \t 2. Взять два овоща  \t 3. Выйти из программы");
                    Console.WriteLine("Введите номер пункта:");
                    Console.ForegroundColor = color;

                    try
                    {
                        int command1;
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out command1) & command1 >= 1 & command1 <= 3)
                            {
                                if (column1[0] == null & column2[0] == null & column3[0] == null)
                                {
                                    ShowMessageRed("Рецепты закончились, возьми овощи.");
                                    command1 = 2;
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                ShowMessageRed("Неверный формат, выбрана ошибочная команда.");
                                continue;
                            }
                        }
                        switch (command1)
                        {
                            case 1:
                                Console.WriteLine("Введи номер карты рецепта, которую хочешь взять: ");
                                int command2;
                                while (true)
                                {
                                    Card[] tempQuestMassive = new Card[] { column1[0], column2[0], column3[0] };
                                    if (int.TryParse(Console.ReadLine(), out command2) && command2 >= 1 && command2 <= 3 && tempQuestMassive[command2 - 1] != null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        ShowMessageRed("Неверный формат, выбрана ошибочная команда или такой карты нет.");
                                    }
                                }
                                switch (command2)
                                {
                                    case 1:
                                        {
                                            TakeQuest(game, column1[0], player.iD - 1);
                                            column1 = (Card[])ReplaceEmptyQuestCard(0, allCardsStack, ref column1);
                                            continue;
                                        }
                                    case 2:
                                        {
                                            TakeQuest(game, column2[0], player.iD - 1);
                                            column2 = (Card[])ReplaceEmptyQuestCard(0, allCardsStack, ref column2);
                                            continue;
                                        }
                                    case 3:
                                        {
                                            TakeQuest(game, column3[0], player.iD - 1);
                                            column3 = (Card[])ReplaceEmptyQuestCard(0, allCardsStack, ref column3);
                                            continue;
                                        }
                                }
                                break;
                            case 2:
                                Console.WriteLine("Введите карту первого овоща:");
                                int command3;
                                Card[] tempVegetablesMassive1 = new Card[6] { column1[1], column2[1], column3[1],
                                                                             column1[2],column2[2],column3[2]};
                                while (true)
                                {
                                    if (int.TryParse(Console.ReadLine(), out command3) && command3 >= 1 && command3 <= 6 && tempVegetablesMassive1[command3 - 1] != null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        ShowMessageRed("Неверный формат или такого овоща нет.");
                                    }
                                }
                                switch (command3)
                                {
                                    case 1:
                                        {
                                            TakeVegetable(game, column1[1], player.iD - 1);
                                            column1 = (Card[])ReplaceEmptyVegetablesCard(1, allCardsStack, ref column1);
                                        }
                                        break;
                                    case 2:
                                        {
                                            TakeVegetable(game, column2[1], player.iD - 1);
                                            column2 = (Card[])ReplaceEmptyVegetablesCard(1, allCardsStack, ref column2);
                                        }
                                        break;
                                    case 3:
                                        {
                                            TakeVegetable(game, column3[1], player.iD - 1);
                                            column3 = (Card[])ReplaceEmptyVegetablesCard(1, allCardsStack, ref column3);
                                        }
                                        break;
                                    case 4:
                                        {
                                            TakeVegetable(game, column1[2], player.iD - 1);
                                            column1 = (Card[])ReplaceEmptyVegetablesCard(2, allCardsStack, ref column1);
                                        }
                                        break;
                                    case 5:
                                        {
                                            TakeVegetable(game, column2[2], player.iD - 1);
                                            column2 = (Card[])ReplaceEmptyVegetablesCard(2, allCardsStack, ref column2);
                                        }
                                        break;
                                    case 6:
                                        {
                                            TakeVegetable(game, column3[2], player.iD - 1);
                                            column3 = (Card[])ReplaceEmptyVegetablesCard(2, allCardsStack, ref column3);
                                        }
                                        break;
                                }

                                List<Card> cardsInGame = new List<Card>();
                                for (int i = 0; i < 2; i++)
                                {
                                    cardsInGame.Add(column1[i]);
                                    cardsInGame.Add(column2[i]);
                                    cardsInGame.Add(column3[i]);
                                }

                                if (CheckGameContinue(cardsInGame))
                                {
                                    Console.WriteLine("Введите карту второго овоща:");
                                    int command4;
                                    Card[] tempVegetablesMassive2 = new Card[6] { column1[1], column2[1], column3[1],
                                                                             column1[2],column2[2],column3[2]};
                                    while (true)
                                    {
                                        if (int.TryParse(Console.ReadLine(), out command4) && command4 >= 1 && command4 <= 6 && (tempVegetablesMassive2[command4 - 1] != null))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            ShowMessageRed("Неверный формат или такого овоща нет.");
                                        }
                                    }
                                    switch (command4)
                                    {
                                        case 1:
                                            {
                                                TakeVegetable(game, column1[1], player.iD - 1);
                                                column1 = (Card[])ReplaceEmptyVegetablesCard(1, allCardsStack, ref column1);
                                            }
                                            break;
                                        case 2:
                                            {
                                                TakeVegetable(game, column2[1], player.iD - 1);
                                                column2 = (Card[])ReplaceEmptyVegetablesCard(1, allCardsStack, ref column2);
                                            }
                                            break;
                                        case 3:
                                            {
                                                TakeVegetable(game, column3[1], player.iD - 1);
                                                column3 = (Card[])ReplaceEmptyVegetablesCard(1, allCardsStack, ref column3);
                                            }
                                            break;
                                        case 4:
                                            {
                                                TakeVegetable(game, column1[2], player.iD - 1);
                                                column1 = (Card[])ReplaceEmptyVegetablesCard(2, allCardsStack, ref column1);
                                            }
                                            break;
                                        case 5:
                                            {
                                                TakeVegetable(game, column2[2], player.iD - 1);
                                                column2 = (Card[])ReplaceEmptyVegetablesCard(2, allCardsStack, ref column2);
                                            }
                                            break;
                                        case 6:
                                            {
                                                TakeVegetable(game, column3[2], player.iD - 1);
                                                column3 = (Card[])ReplaceEmptyVegetablesCard(2, allCardsStack, ref column3);
                                            }
                                            break;
                                    }
                                }
                                else
                                {
                                    alive = false;
                                    break;
                                }
                                List<Card> tempCardsInGame = new List<Card>();
                                for (int i = 0; i < 2; i++)
                                {
                                    tempCardsInGame.Add(column1[i]);
                                    tempCardsInGame.Add(column2[i]);
                                    tempCardsInGame.Add(column3[i]);
                                }
                                if (CheckGameContinue(tempCardsInGame)) break;
                                else
                                {
                                    alive = false;
                                    break;
                                }
                            case 3:
                                alive = false;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowMessageRed(ex.Message);
                    }
                }
                if (alive)
                    game.roundCounter++;
                goto restart;
            }
            else 
            {
                //Scoring:
                //Подсчет очков
                Console.WriteLine("КОНЕЦ ИГРЫ!!!");
                for (int i = 0; i <= game.players.Count - 1; i++)
                {
                    game.players[i].Score = 0;
                    foreach (var card in game.players[i].QuestStack)
                    {
                        card.Quest(game, game.players[i]);
                    }

                    Console.WriteLine($"Игрок {i + 1} набрал {game.players[i].Score} очков.");
                }
                Console.ReadLine();
            }

        }
    }
}
