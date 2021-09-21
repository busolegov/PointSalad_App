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
        /// Вызов события взятия карты овоща. Виртупльный метод.
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
            if (card.Type == "tomato")
            {
                tomatoStack++;
            }
            if (card.Type == "onion")
            {
                onionStack++;
            }
            if (card.Type == "carrot")
            {
                carrotStack++;
            }
            if (card.Type == "cabbage")
            {
                cabbageStack++;
            }
            if (card.Type == "lettuce")
            {
                lettuceStack++;
            }
            if (card.Type == "pepper")
            {
                pepperStack++;
            }
            OnHasTakenVegetable(new AccountEventArgs("В стек овощей добавлена карта " + card.Type + "\n--------------------", card));
        }
        /// <summary>
        /// Метод взятия карты задания.
        /// </summary>
        /// <param name="card"></param>
        public virtual void TakeQuest(Card card)
        {
            questStack.Add(card);
            OnHasTakenQuest(new AccountEventArgs("В стек рецептов добавлена карта " + card.QuestText + "\n--------------------", card));
        }
        /// <summary>
        /// Метод подсчета очков.
        /// </summary>
        /// <returns></returns>
        public int Scoring()
        {
            foreach (var item in questStack)
            {
                item.Quest();
            }
            return Score;
        }
        public Player()
        {
            iD = ++counter;
        }

        /// <summary>
        /// Общее Количество очков игрока.
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Номер игрока.
        /// </summary>
        public int iD;
        static int counter = 0;

        #region VegetablesStacks
        /// <summary>
        /// Стек карт томатов игрока.
        /// </summary>
        public int tomatoStack { get; set; }
        /// <summary>
        /// Стек карт лука икрока.
        /// </summary>
        public int onionStack { get; set; }
        /// <summary>
        /// Стек карт морковки игрока.
        /// </summary>
        public int carrotStack { get; set; }
        /// <summary>
        /// Стек карт капусты игрока.
        /// </summary>
        public int cabbageStack { get; set; }
        /// <summary>
        /// Стек карт салата игрока.
        /// </summary>
        public int lettuceStack { get; set; }
        /// <summary>
        /// Стек карт перцев игрока.
        /// </summary>
        public int pepperStack { get; set; }
        /// <summary>
        /// Стек карт заданий игрока.
        /// </summary>
        #endregion

        public List<Card> questStack = new List<Card>();
    }
}
