using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace ConsoleApplication91
{
    class Program
    {
        static List<string> _listString = new List<string>(); //static List<string> listString = new List<string>(1000000);沒有比較快
        static int _nEvery = 0;

        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Reset();
            watch.Start();

            int nFiles;
            long nSize;

            nFiles = 0;
            nSize = 0;
            DirSearch(@"D:\", ref nFiles, ref nSize);

            nFiles = 0;
            nSize = 0;
            DirSearch(@"C:\", ref nFiles, ref nSize);

            TextWriter tw = new StreamWriter(@"C:\Users\lenovo\Desktop\CCCCCandDDDDD.txt", false, Encoding.Unicode);

            foreach (string s in _listString)
                tw.WriteLine(s);
            tw.Close();


            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds / 1000);
            Console.Read();
        }

        static void DirSearch(string sDir, ref int nFiles, ref long nSize)
        {
            string[] directories;
            try { directories = Directory.GetDirectories(sDir); }
            catch /*(System.Exception excpt)*/ { /*listString.Add("Error1 occured: " + excpt.Message);*/ return; }


            string sDirCode = "";
            if (sDir.Length < 15)
                sDirCode = sDir.ToString();
            else
                sDirCode = sDir.GetHashCode().ToString();

            long ori_size = nSize;
            int ori_num = nFiles;
            long new_size = 0;
            int new_num = 0;

            foreach (string d in directories)
            {
                DirSearch(d, ref nFiles, ref nSize);

                new_size += nSize;
                new_num += nFiles;

                nSize = ori_size;
                nFiles = ori_num;
            }

            nSize = new_size;
            nFiles = new_num;

            FileInfo[] Files;
            string f_;
            try { var dir = new DirectoryInfo(sDir); Files = dir.GetFiles(); }
            catch /*(System.Exception excpt)*/ { /*listString.Add("Error2 occured: " + excpt.Message);*/ /*continue*/return; }

            foreach (FileInfo f in Files)
            {
                f_ = Path.GetFileName(f.ToString());
                f_ = sDirCode + "\t" + f_;
                long 檔案大小 = f.Length;
                nSize += 檔案大小;
                nFiles++;
                f_ = f_ + "\t" + f.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss");
                f_ = f_ + "\t" + 檔案大小;

                _listString.Add(f_);//listString.Add(f.Substring(d.Length+1)); 沒有比較快           好像也沒有方法先讓f只留檔名而非全部路徑
                if (_nEvery++ % 500 == 0)
                    Console.Write("*");
            }


            _listString.Add("【】" + sDir + "\t" + sDirCode + "\t" + nFiles + "\t" + nSize / 1024 / 1024);//這邊是 Dirs 總結
        }

    }
}
