using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    abstract class Piece
    {
        public bool diagplus { get; set; }
        public bool diagminus { get; set; }
        public string name { get; set; }
        public bool hasmoved { get; set; }
        public List<Chess.model.xy> moves { get; set; }
        public abstract bool movement(int x1,int x2,int y1,int y2);
        public Piece()
        {
            moves = new List<Chess.model.xy>();
        }
    }
}
