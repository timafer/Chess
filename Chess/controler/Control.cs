using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Controler
{
    class Control
    {
        string filepath;
        Model.Board board;
        List<string> input;
        const int asciibal = 65;
        const int firstbal = 49;
        const int arrayrange = 7;
        public Control(string filepathintial)
        {
            filepath = filepathintial;
            board = new Model.Board();
        }
        public void start()
        {
            Model.Fileinput finput = new Model.Fileinput(filepath);
            input = finput.runinput();
            process();
            Console.WriteLine("-----Finshed-----");
            board.print();
        }
        public void process()
        {
            foreach (string s in input)
            {
                string[] result = s.Split(null);
                if (result.Length == 1)
                {
                    if (s == "")
                    {
                        Console.WriteLine("ERROR Empty line");
                        Console.WriteLine();
                    }
                    else if (s.Length == 1 || s.Length == 2 || s.Length == 3)
                    {
                        Console.WriteLine("ERROR too few characters");
                        Console.WriteLine();
                    }
                    else {
                        if (Model.prossess.testrange(char.ToUpper(s[2]) - asciibal, char.ToUpper(s[3]) - firstbal))
                        {
                            Console.WriteLine("Out of range");
                            Console.WriteLine();
                        }
                        else
                        {
                            if (Model.prossess.processplace(s, board))
                            {
                                Console.WriteLine("-Placed the " + board.Piececolor(char.ToUpper(s[2]) - asciibal, char.ToUpper(s[3]) - firstbal) + " " + board.Piecename(char.ToUpper(s[2]) - asciibal, char.ToUpper(s[3]) - firstbal) + " on " + s[2] + s[3]);
                            }
                        }
                    }
                }
                else if (result.Length == 2)
                {
                    if (result[0].Length == 1 || result[1].Length == 1)
                    {
                        Console.WriteLine("ERROR too few characters");
                        Console.WriteLine();
                    }
                    else
                    {
                       
                        int x1 = char.ToUpper(result[0][0]) - asciibal;
                        int y1 = char.ToUpper(result[0][1]) - firstbal;
                        int x2 = char.ToUpper(result[1][0]) - asciibal;
                        int y2 = char.ToUpper(result[1][1]) - firstbal;
                        if (Model.prossess.testrange(x1, y1) || Model.prossess.testrange(x2, y2))
                        {
                            Console.WriteLine("Out of range");
                            Console.WriteLine();
                        }
                        else
                        {
                            String pc2 = Model.prossess.prossesmove(result, board);
                            if (pc2[0] != 'E')
                            {
                                Console.Write("-Moved the " + board.Piececolor(x2, y2) + " " + board.Piecename(x2, y2) + " at " + result[0][0] + result[0][1] + " to " + result[1][0] + result[1][1]);
                                if (result[1].Length == 3)
                                {
                                    if (result[1][2] == '*')
                                    {
                                        Console.WriteLine(" and captured " + pc2);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                }
                else if (result.Length == 4)
                {
                    if (result[0].Length == 1 || result[1].Length == 1 || result[2].Length == 1 || result[3].Length == 1)
                    {
                        Console.WriteLine("ERROR too few characters");
                        Console.WriteLine();
                    }
                    else
                    {
                        int x1 = char.ToUpper(result[0][0]) - asciibal;
                        int y1 = char.ToUpper(result[0][1]) - firstbal;
                        int x2 = char.ToUpper(result[1][0]) - asciibal;
                        int y2 = char.ToUpper(result[1][1]) - firstbal;
                        int x3 = char.ToUpper(result[2][0]) - asciibal;
                        int y3 = char.ToUpper(result[2][1]) - firstbal;
                        int x4 = char.ToUpper(result[3][0]) - asciibal;
                        int y4 = char.ToUpper(result[3][1]) - firstbal;
                        if (Model.prossess.testrange(x1, y1) || Model.prossess.testrange(x2, y2) || Model.prossess.testrange(x3, y3) || Model.prossess.testrange(x4, y4))
                        {
                            Console.WriteLine("Out of range");
                            Console.WriteLine();
                        }
                        else
                        {
                            string e = Model.prossess.prossesmove(result, board);
                            if (e[0] != 'E')
                            {
                                Console.WriteLine("-Castled the " + board.Piececolor(x2, y2) + " " + board.Piecename(x2, y2) + " at " + result[0][0] + result[0][1] + " to " + result[1][0] + result[1][1] + " and the " + board.Piececolor(x4, y4) + " " + board.Piecename(x4, y4) + " at " + result[2][0] + result[2][1] + " to " + result[3][0] + result[3][1]);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid line");
                    Console.WriteLine();
                }
                }
            }
        }

    }
