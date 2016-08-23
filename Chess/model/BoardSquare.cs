using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    class BoardSquare: INotifyPropertyChanged
    {
        public bool _iswhite{ get; set;}
        public Piece piece { get
            {
                return _piece;
            }
            set
            {
                _piece = value;
                FieldChanged("piece");
            } }
        public bool canbehitbywhite { get; set; }
        public bool canbehitbyblack { get; set; }
        public bool whitechecker { get; set; }
        public bool blackchecker { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public bool check { get; set; }
        private Piece _piece { get; set; }
        public bool iswhite { get
            {
                return _iswhite;
            } set
            {
                _iswhite = value;
                FieldChanged();
            } }
        public BoardSquare(bool _iswhite,Piece _piece)
        {
            iswhite = _iswhite;
            piece = _piece;
            canbehitbyblack = false;
            canbehitbywhite = false;
        }
        protected void FieldChanged([CallerMemberName] string field = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(field));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
