using System;
using System.Collections.Generic;
using System.Linq;
using PointSalad_Library;

namespace PointSalad_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя игрока");
            Player player = new Player(Convert.ToString(Console.ReadLine()));
            Console.WriteLine($"Имя игрока {player.Name}");
            
            
            Card tomatoCardEx1 = new TomatoCardEx1("tomato", "+2pts за лук, -1pts за перец");
            Card tomatoCardEx2 = new TomatoCardEx2("tomato", "-1pts за перец");
            Card tomatoCardEx3 = new TomatoCardEx3("tomato");
            Card tomatoCardEx4 = new TomatoCardEx4("tomato");
            
            Card PepperCardEx1 = new PepperCardEx1("pepper");
            Card PepperCardEx2 = new PepperCardEx2("pepper");

            //массив всех карт
            Card[] allCardsMassive = new Card [6] { tomatoCardEx1, tomatoCardEx2, tomatoCardEx3,
                                                    tomatoCardEx4, PepperCardEx1, PepperCardEx2};
            List<Card> allCardsList = new List<Card>();
            allCardsList.AddRange(allCardsMassive);
            var rand = new Random();

            List <Card> firstStackList = new List <Card>();
            List <Card> secondStackList = new List <Card>();
            List <Card> thirdStackList = new List <Card>();

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

            List<Card> vegetableOne = new List<Card>();
            List<Card> vegetableTwo = new List<Card>();
            List<Card> vegetableThree = new List<Card>();
            List<Card> vegetableFour = new List<Card>();
            List<Card> vegetableFive = new List<Card>();
            List<Card> vegetableSix = new List<Card>();

            Stack<Card> firstStackStack = new Stack<Card>(firstStackList);
            Stack<Card> secondStackStack = new Stack<Card>(secondStackList);
            Stack<Card> thirdStackStack = new Stack<Card>(thirdStackList);

            Console.WriteLine(firstStackStack.Peek().QuestText);
            Console.ReadLine();

            /*bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen; // выводим список команд зеленым цветом
                Console.WriteLine("1. Открыть счет \t 2. Вывести средства  \t 3. Добавить на счет");
                Console.WriteLine("4. Закрыть счет \t 5. Пропустить день \t 6. Выйти из программы");
                Console.WriteLine("Введите номер пункта:");
                Console.ForegroundColor = color;
            }*/
            












        }
    }
}
