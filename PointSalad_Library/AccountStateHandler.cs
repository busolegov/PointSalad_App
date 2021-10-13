using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    /// <summary>
    /// Делегат обработки события.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void AccountStateHandler(object sender, AccountEventArgs e);
    /// <summary>
    /// Вспомогательный класс для обработки события.
    /// </summary>
    public class AccountEventArgs
    {
        /// <summary>
        /// Сообщение о действии
        /// </summary>
        public string Message { get; set; }

        public int iD;
        /// <summary>
        /// Информация о взятой карте
        /// </summary>
        public Card c;
        public AccountEventArgs(string mes, Card card)
        {
            Message = mes;
            c = card;
        }
        public AccountEventArgs(string mes)
        {
            Message = mes;
        }
        public AccountEventArgs(string mes, int iD)
        {
            Message = mes;
            this.iD = iD;
        }
    }
    
}
