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
            DirSearch(@"C:\");
            DirSearch(@"D:\");

            TextWriter tw = new StreamWriter(@"C:\Users\dave.gan\Desktop\output.txt");

            foreach (string s in listString)
                tw.WriteLine(s);

            tw.Close();
        }

        static int nEvery = 0;

        static void DirSearch(string sDir)
        {
            string[] Dirs;
            try { Dirs = Directory.GetDirectories(sDir); }
            catch (System.Exception excpt) { listString.Add("Error1 occured: " + excpt.Message); return; }


            foreach (string d in Dirs)
            {
                string[] Files;
                try { Files = Directory.GetFiles(d); }
                catch (System.Exception excpt) { listString.Add("Error2 occured: " + excpt.Message); continue; }

                foreach (string f in Files)
                {
                    listString.Add(f);
                    if (nEvery++ % 200 == 0)
                        Console.Write("*");
                }
                DirSearch(d);
            }
        }
    }
}
