using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    class Fileinput
    {
        string filepath = "";
        List<string> lines = new List<string>();
        public Fileinput(string path)
        {
            filepath = path;
        }
        public List<string> runinput()
        {           
            try
            {
                string fileline;
                System.IO.StreamReader file =new System.IO.StreamReader(filepath);
                while ((fileline = file.ReadLine()) != null)
                {
                    lines.Add(fileline);
                }
                file.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
                Console.WriteLine(e.Message);
            }
            return lines;
        }

    }
}
