using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSalad_Library
{
    public class PepperCardEx1 : PepperCards
    {

        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += player.cabbageStack;
            player.Score += player.tomatoStack;
        }
    }
    public class PepperCardEx2 : PepperCards
    {
        public override void Quest(Game<Player> game, Player player)
        {
            player.Score += 3 * player.cabbageStack;
            player.Score -= 2 * player.carrotStack;
        }
    }
}
