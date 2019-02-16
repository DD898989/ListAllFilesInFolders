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

            TextWriter tw = new StreamWriter(@"C:\Users\lenovo\Desktop\CCCCCandDDDDD.txt",false,Encoding.Unicode);

            foreach (string s in listString)
                tw.WriteLine(s);

            tw.Close();


            watch.Stop(); Console.WriteLine(watch.ElapsedMilliseconds / 1000); Console.Read();
        }

        static int nEvery = 0;
        static void DirSearch(string sDir)
        {
            string[] Dirs;
            try { Dirs = Directory.GetDirectories(sDir); }
            catch /*(System.Exception excpt)*/ { /*listString.Add("Error1 occured: " + excpt.Message);*/ return; }

            FileSearch(sDir);

            foreach (string d in Dirs)
            {
                DirSearch(d);
            }

        }

        static void FileSearch(string d)
        {
            FileInfo[] Files;
            string f_;
            try { var dir = new DirectoryInfo(d); Files = dir.GetFiles(); }
            catch /*(System.Exception excpt)*/ { /*listString.Add("Error2 occured: " + excpt.Message);*/ /*continue*/return; }

            string 資料夾code = "";
            if (d.Length < 15)
                資料夾code = d.ToString();
            else
                資料夾code = d.GetHashCode().ToString();

            listString.Add("【】" + d + "\t" + 資料夾code + "\t" + "0" + "\t" + "0");

            foreach (FileInfo f in Files)
            {
                f_ = Path.GetFileName(f.ToString());
                f_ = 資料夾code + "\t" + f_;
                f_ = f_ + "\t" + f.Length / 1024 / 1024;
                f_ = f_ + "\t" + f.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss");

                listString.Add(f_);//listString.Add(f.Substring(d.Length+1)); 沒有比較快           好像也沒有方法先讓f只留檔名而非全部路徑
                if (nEvery++ % 200 == 0)
                    Console.Write("*");
            }



        }

    }
}
