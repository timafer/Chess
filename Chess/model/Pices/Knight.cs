using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    class Knight : Piece
    {
        public Knight()
        {
            name = "Knight";
        }
        public override bool movement(int x1, int x2, int y1, int y2)
        {
            if ((x2 - x1 == 2 && y2 - y1 == 1) || (x2 - x1 == -2 && y2 - y1 == 1) || (x2 - x1 == -2 && y2 - y1 == -1) || (x2 - x1 == 2 && y2 - y1 == -1) ||
                (x2 - x1 == 1 && y2 - y1 == 2) || (x2 - x1 == -1 && y2 - y1 == 2) || (x2 - x1 == -1 && y2 - y1 == -2) || (x2 - x1 == 1 && y2 - y1 == -2))
            {

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
