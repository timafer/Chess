using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
     static class prossess
    {
        const int asciibal = 65;
        const int firstbal = 49;
        const int arrayrange = 7;
        public static bool testrange(int i1, int i2)
        {
            bool outofrange = false;
            if (i1 > arrayrange || i2 > arrayrange || i1 < 0 || i2 < 0)
            {
                outofrange = true;
            }
            return outofrange;
        }
        public static bool processplace(string line,Board board)
        {
            line = line.ToUpper();
            bool success = true;
            bool iswhite = false;
            switch (line[1])
            {
                case 'L':
                    iswhite = true;
                    break;
                case 'D':
                    iswhite = false;
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid color");
                    success = false;
                    break;

            }
            switch (line[0])
            {
                case 'K':
                    board.place(char.ToUpper(line[2]) - asciibal, char.ToUpper(line[3]) - firstbal,iswhite ,"King");
                    break;
                case 'Q':
                    board.place(char.ToUpper(line[2]) - asciibal, char.ToUpper(line[3]) - firstbal, iswhite, "Queen");
                    break;
                case 'B':
                    board.place(char.ToUpper(line[2]) - asciibal, char.ToUpper(line[3]) - firstbal, iswhite, "Bishop");
                    break;
                case 'N':
                    board.place(char.ToUpper(line[2]) - asciibal, char.ToUpper(line[3]) - firstbal, iswhite, "Knight");
                    break;
                case 'R':
                    board.place(char.ToUpper(line[2]) - asciibal, char.ToUpper(line[3]) - firstbal, iswhite, "Rook");
                    break;
                case 'P':
                    board.place(char.ToUpper(line[2]) - asciibal, char.ToUpper(line[3]) - firstbal, iswhite, "Pawn");
                    break;
                default:
                    if (success)
                    {
                        Console.WriteLine();
                    }
                    Console.WriteLine("Invalid Piece");
                    success = false;
                    break;
            }
            if (!success)
            {
                Console.WriteLine();
            }
            return success;
        }
        public static string prossesmove(string[] result,Board board)
        {
            string print="Place Holder";
            int s11 = char.ToUpper(result[0][0]) - asciibal;
            int s12 = char.ToUpper(result[0][1]) - firstbal;
            int s21 = char.ToUpper(result[1][0]) - asciibal;
            int s22 = char.ToUpper(result[1][1]) - firstbal;
            if (board.Piecename(s21, s22)!="ERROR")
            {
                print = board.Piececolor(s21, s22) + " " + board.Piecename(s21, s22);
            }

            if (testrange(s11, s12))
            {
                print = "ERROR OUT OF RANGE";
                Console.WriteLine();
            }
            else if (testrange(s21, s22))
            {
                print = "ERROR OUT OF RANGE";
                Console.WriteLine();
            }
            else {
                if (result.Length==2&&result[1].Length == 2)
                {
                    if (board.move(s11, s12, s21, s22))
                    {
                    }
                    else {
                        Console.WriteLine("ERROR INVALAD MOVE NOT MOVED");
                        print = "ERROR INVALAD MOVE NOT MOVED";
                    }
                }
                else if (result.Length == 4)
                {
                    int s31 = char.ToUpper(result[2][0]) - asciibal;
                    int s32 = char.ToUpper(result[2][1]) - firstbal;
                    int s41 = char.ToUpper(result[3][0]) - asciibal;
                    int s42 = char.ToUpper(result[3][1]) - firstbal;
                    if (board.castle(s11, s12, s21, s22,s31,s32,s41,s42))
                    {
                    }
                    else
                    {
                        Console.WriteLine("ERROR INVALID CASTLE NOT MOVED");
                        Console.WriteLine();
                        print = "ERROR INVALID CASTLE NOT MOVED";
                    }
                }
                else if (result[1][2].Equals('*'))
                {
                    if (board.capture(s11, s12, s21, s22))
                    {
                    }
                    else
                    {
                        Console.WriteLine("ERROR INVALID NOT MOVED AND PIECE NOT TAKEN");
                        Console.WriteLine();
                        print = "ERROR INVALID NOT MOVED AND PIECE NOT TAKEN";
                    }
                }
                else
                {
                    Console.WriteLine("ERROR INVALID ELMENT AT INDEX 3");
                    Console.WriteLine();
                    print = "ERROR INVALID ELMENT AT INDEX 3";
                }
            }
            return print;
        }
    }
}
