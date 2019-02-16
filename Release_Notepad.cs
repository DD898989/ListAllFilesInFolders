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



             int num = 0;
             long size = 0;
            DirSearch(@"D:\", ref num, ref size);
             num = 0;
             size = 0;
            DirSearch(@"C:\", ref num, ref size);

            TextWriter tw = new StreamWriter(@"C:\Users\lenovo\Desktop\CCCCCandDDDDD.txt",false,Encoding.Unicode);

            foreach (string s in listString)
                tw.WriteLine(s);

            tw.Close();


            watch.Stop(); Console.WriteLine(watch.ElapsedMilliseconds / 1000); Console.Read();
        }

        static int nEvery = 0;
        static void DirSearch(string sDir,ref int num,ref long size)
        {
            string[] Dirs;
            try { Dirs = Directory.GetDirectories(sDir); }
            catch /*(System.Exception excpt)*/ { /*listString.Add("Error1 occured: " + excpt.Message);*/ return; }


            string Dirs_code = "";
            if (sDir.Length < 15)
                Dirs_code = sDir.ToString();
            else
                Dirs_code = sDir.GetHashCode().ToString();

            long ori_size = size;
            int ori_num = num;


            long new_size = 0;
            int new_num = 0;

            foreach (string d in Dirs)
            {
                DirSearch(d, ref num, ref size);

                new_size += size;
                new_num += num;

                    size = ori_size;
                    num = ori_num;
            }

            size = new_size;
            num = new_num;


            FileInfo[] Files;
            string f_;
            try { var dir = new DirectoryInfo(sDir); Files = dir.GetFiles(); }
            catch /*(System.Exception excpt)*/ { /*listString.Add("Error2 occured: " + excpt.Message);*/ /*continue*/return; }



            foreach (FileInfo f in Files)
            {
                f_ = Path.GetFileName(f.ToString());
                f_ = Dirs_code + "\t" + f_;
                long 檔案大小 = f.Length ;
                size += 檔案大小;
                num++;
                f_ = f_ + "\t" + 檔案大小;
                f_ = f_ + "\t" + f.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss");

                listString.Add(f_);//listString.Add(f.Substring(d.Length+1)); 沒有比較快           好像也沒有方法先讓f只留檔名而非全部路徑
                if (nEvery++ % 200 == 0)
                    Console.Write("*");
            }


            listString.Add("【】" + sDir + "\t" + Dirs_code + "\t" + num + "\t" + size/1024/1024);//這邊是 Dirs 總結
        }



    }
}
