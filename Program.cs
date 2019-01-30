using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace ConsoleApplication91
{
    class Program
    {

        static List<string> listString = new List<string>();

        static void Main(string[] args)
        {
            DirSearch(@"C:\Users\dave.gan\Downloads");

            TextWriter tw = new StreamWriter(@"C:\Users\dave.gan\Desktop\output.txt");

            foreach (string s in listString)
                tw.WriteLine(s);

            tw.Close();
        }

        static int nEvery = 0;

        static void DirSearch(string sDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        listString.Add(f);
                        if (nEvery++ % 200 ==0)
                            Console.Write("*");
                    }
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                listString.Add("Error occured: " + excpt.Message);
            }
        }
    }
}
