using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    class Queen : Piece
    {
        public Queen()
        {
            name = "Queen";
        }
        public override bool movement(int x1, int x2, int y1, int y2)
        {
            if ((x2 == x1 && y1 != y2) || (y1 == y2 && x1 != x2) || Math.Abs(x2 - x1) == Math.Abs(y2 - y1))
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
