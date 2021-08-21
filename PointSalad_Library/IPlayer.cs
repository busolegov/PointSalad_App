using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    public interface IPlayer
    {
        void TakeQuest(Card card);
        void TakeVegetable(Card card);
        void ShowInfo();
        

    }
}
