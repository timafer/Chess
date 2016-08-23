using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    class Pawn:Piece
    {
        bool iswhite { get; set; }
        public Pawn(bool Iswhite)
        {
            name = "Pawn";
            iswhite = Iswhite;
        }
        public override bool movement(int y1, int y2, int x1, int x2)
        {
            if ((!hasmoved && x2 - x1 == 2 && y1 == y2) || (!hasmoved && x2 - x1 == -2 && y1 == y2) || (x2 - x1 == 1 && y1 == y2) || (x2 - x1 == -1 && y1 == y2))
            {
                return true;
            }
            else if((diagminus && y2 - y1 == -1 && x2 - x1 == 1) || (diagminus && y2 - y1 == 1 && x2 - x1 == 1) ||
                (diagplus && y2 - y1 == -1 && x2 - x1 == -1) || ( diagplus && y2 - y1 == 1 && x2 - x1 == -1))
            {
                diagminus = false;
                diagplus = false;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
