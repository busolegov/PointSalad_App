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
        public virtual void OnHasTakenVegetable(AccountEventArgs e) 
        {
            CallEvent(e, HasTakenVegetable);
        }
        public virtual void OnHasTakenQuest(AccountEventArgs e)
        {
            CallEvent(e, HasTakenQuest);
        }
        public void TakeVegetable(Card card)
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
            OnHasTakenVegetable(new AccountEventArgs("В стек овощей добавлена карта " + card.Type, card));
        }
        public void TakeQuest(Card card)
        {
            if (questStack == null)
            {
                Card[] questStack = new Card[1] { card };
            }
            else
            {
                Card[] tempQuestStack = new Card[questStack.Length + 1];
                for (int i = 0; i < tempQuestStack.Length - 1; i++)
                {
                    tempQuestStack[i] = questStack[i];
                }
                tempQuestStack[tempQuestStack.Length] = card;
                questStack = tempQuestStack;
            }
            OnHasTakenQuest(new AccountEventArgs("В стек заданий добавлена карта " + card.QuestText, card));
        }

        /// <summary>
        /// Количество очков игрока.
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Имя игрока.
        /// </summary>
        public string Name { get; set; }
        public Player(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Имя не может быть null", nameof(name));
            }
            Name = name;
        }
        /// <summary>
        /// Счетчик раундов.
        /// </summary>
        public int roundCounter = 0;
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
        public static Card [] questStack;
        public void ShowInfo()
        {
            
        }
                
    }
}
