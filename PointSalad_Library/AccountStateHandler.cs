using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    public delegate void AccountStateHandler(object sender, AccountEventArgs e);
    public class AccountEventArgs
    {
        public string Message { get; set; } //сообщение
        public Card c; // взятая карта
        public AccountEventArgs(string _mes, Card _card)
        {
            Message = _mes;
            c = _card;

        }
    }
    
}
