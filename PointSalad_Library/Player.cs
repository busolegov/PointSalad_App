using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    public class Player : IPlayer
    {
        /// <summary>
        /// Событие, возникающее присоздании игрока.
        /// </summary>
        public event AccountStateHandler HasCreatePlayer;

        /// <summary>
        /// Событие, возникающее при взятии карты овоща.
        /// </summary>
        public event AccountStateHandler HasTakenVegetable;

        /// <summary>
        /// Событие, возникающее при взятии карты задания.
        /// </summary>
        public event AccountStateHandler HasTakenQuest;

        /// <summary>
        /// Метод вызова события.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="handler"></param>
        public void CallEvent(AccountEventArgs e, AccountStateHandler handler)
        {
            if (e != null) handler?.Invoke(this, e);

        }

        /// <summary>
        /// Вызов события взятия карты овоща. Виртуальный метод.
        /// </summary>
        /// <param name="e"></param>
        /// 
        public virtual void OnHasTakenVegetable(AccountEventArgs e)
        {
            CallEvent(e, HasTakenVegetable);
        }

        /// <summary>
        /// Вызов события взятия карты рецепты. Виртуальный метод.
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnHasTakenQuest(AccountEventArgs e)
        {
            CallEvent(e, HasTakenQuest);
        }

        /// <summary>
        /// Вызов события содания игрока. Виртуальный метод.
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnCreatePlayer(AccountEventArgs e)
        {
            CallEvent(e, HasCreatePlayer);
        }

        public virtual void CreatePlayer() 
        {
            OnCreatePlayer(new AccountEventArgs($"Создан игрок {this.iD}"));        
        }

        /// <summary>
        /// Метод взятия карты овоща.
        /// </summary>
        /// <param name="card"></param>
        public virtual void TakeVegetable(Card card)
        {
            if (card.Type == "томат")
            {
                TomatoStack++;
            }
            if (card.Type == "лук")
            {
                OnionStack++;
            }
            if (card.Type == "морковь")
            {
                CarrotStack++;
            }
            if (card.Type == "капуста")
            {
                CabbageStack++;
            }
            if (card.Type == "салат")
            {
                LetucceStack++;
            }
            if (card.Type == "перец")
            {
                PepperStack++;
            }
            OnHasTakenVegetable(new AccountEventArgs("В стек овощей добавлена карта " + card.Type + "\n--------------------", card));
        }

        /// <summary>
        /// Метод взятия карты задания.
        /// </summary>
        /// <param name="card"></param>
        public virtual void TakeQuest(Card card)
        {
            QuestStack.Add(card);
            OnHasTakenQuest(new AccountEventArgs("В стек рецептов добавлена карта " + card.QuestText + "\n--------------------", card));
        }

        public int iD;
        static int counter = 0;
        public Player()
        {
            iD = ++counter;
        }

        /// <summary>
        /// Общее Количество очков игрока.
        /// </summary>
        public int Score { get; set; }

        #region VegetablesStacks
        /// <summary>
        /// Стек карт томатов игрока.
        /// </summary>
        public int TomatoStack { get; set; }
        /// <summary>
        /// Стек карт лука игрока.
        /// </summary>
        public int OnionStack { get; set; }
        /// <summary>
        /// Стек карт морковки игрока.
        /// </summary>
        public int CarrotStack { get; set; }
        /// <summary>
        /// Стек карт капусты игрока.
        /// </summary>
        public int CabbageStack { get; set; }
        /// <summary>
        /// Стек карт салата игрока.
        /// </summary>
        public int LetucceStack { get; set; }
        /// <summary>
        /// Стек карт перцев игрока.
        /// </summary>
        public int PepperStack { get; set; }
        #endregion

        public List<Card> QuestStack = new List<Card>();

        public void ShowInfo(int iD)
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"Ходит игрок {iD}.....");
            Console.WriteLine();
            Console.WriteLine($"салат: {LetucceStack}  лук: {OnionStack}  капуста: {CabbageStack}");
            Console.WriteLine($"перец: {PepperStack}  томат: {TomatoStack}  морковь: {CarrotStack}");
            Console.WriteLine();

            for (int i = 0; i < QuestStack.Count; i++)
            {
                if (QuestStack.Count == 0)
                {
                    Console.WriteLine("Нет карт рецептов");
                }

                else
                {
                    Console.WriteLine($"{i+1}. {QuestStack[i].QuestText}");
                }
            }
            Console.WriteLine("---------------------------------------------------------------");
        }
    }
}
