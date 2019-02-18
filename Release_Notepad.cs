using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace ConsoleApplication91
{
    class Program
    {
        static List<string> _listString = new List<string>(); //tested: init List with space needed won't improve efficiency in Add function
        static int _nEvery = 0;
        static int _nFiles;
        static long _nSize;

        static void ListAdd(string type, string directoryCode, string directoryCode_or_file, string fileCount_or_lastEditTime, string size)
        {
            _listString.Add(type + "\t" + directoryCode + "\t" + directoryCode_or_file + "\t" + fileCount_or_lastEditTime + "\t" + size);
        }

        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Reset();
            watch.Start();

            _nFiles = 0;
            _nSize = 0;
            DirSearch(@"C:\");

            _nFiles = 0;
            _nSize = 0;
            DirSearch(@"D:\");

            TextWriter tw = new StreamWriter(@"C:\Users\dave.gan\Desktop\FilesInAllDisks.txt", false, Encoding.Unicode);

            ListAdd(
                "【D=directory】【f=file】",
                "【directory code】",
                "【directory code】【file】",
                "【file count】【last edit time】",
                "【size】"
                );

            foreach (string s in _listString)
                tw.WriteLine(s);
            tw.Close();

            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds / 1000);
            Console.Read();
        }

        static void DirSearch(string sDir)
        {
            long ori_size = _nSize;
            int ori_num = _nFiles;
            long new_size = 0;
            int new_num = 0;
            string[] directories;
            FileInfo[] files;
            string sDirCode = "";

            try { directories = Directory.GetDirectories(sDir); }
            catch /*(System.Exception excpt)*/ { /*listString.Add("Error1 occured: " + excpt.Message);*/ return; }

            if (sDir.Length < 15)
                sDirCode = sDir.ToString();
            else
                sDirCode = sDir.GetHashCode().ToString();


            foreach (string d in directories)
            {
                DirSearch(d);

                new_size += _nSize;
                new_num += _nFiles;

                _nSize = ori_size;
                _nFiles = ori_num;
            }

            _nSize = new_size;
            _nFiles = new_num;

            try { var dir = new DirectoryInfo(sDir); files = dir.GetFiles(); }
            catch /*(System.Exception excpt)*/ { /*listString.Add("Error2 occured: " + excpt.Message);*/ /*continue*/return; }

            foreach (FileInfo f in files)
            {
                _nSize += f.Length;
                _nFiles++;

                ListAdd(
                        "f",
                        sDirCode,
                        Path.GetFileName(f.ToString())/*FileInfo only contains full path file*/,
                        f.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss"),
                        (f.Length / 1024 / 1024).ToString()
                    );

                if (_nEvery++ % 500 == 0)
                    Console.Write("*"); //user experience
            }

            ListAdd(
                "D",
                sDir,
                sDirCode,
                _nFiles.ToString(),
                (_nSize / 1024 / 1024).ToString()
                );
        }

    }
}
