using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace ConsoleApplication91
{
    class Program
    {
        static List<string> listString = new List<string>(); //static List<string> listString = new List<string>(1000000);沒有比較快

        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Reset(); watch.Start();


            DirSearch(@"C:\");
            DirSearch(@"D:\");

            TextWriter tw = new StreamWriter(@"C:\Users\dave.gan\Desktop\CCCCCandDDDDD.txt");

            foreach (string s in listString)
                tw.WriteLine(s);

            tw.Close();



            watch.Stop(); Console.WriteLine(watch.ElapsedMilliseconds); Console.Read();
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


                bool first = true;
                foreach (string f in Files)
                {
                    if (first)
                    {
                        listString.Add(f);
                        first=false;
                    }
                    else
                    {
                        listString.Add(Path.GetFileName(f));//listString.Add(f.Substring(d.Length+1)); 沒有比較快           好像也沒有方法先讓f只留檔名而非全部路徑
                    }

                    if (nEvery++ % 200 == 0)
                        Console.Write("*");
                }
                DirSearch(d);
            }
        }
    }
}
