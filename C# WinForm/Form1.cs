using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication32
{
    public partial class Form1 : Form
    {
        List<string> _listString = new List<string>(); //tested: init List with space needed won't improve efficiency in Add function
        int _nEvery = 0;
        int _nFiles;
        long _nSize;

        public Form1()
        {
            InitializeComponent();
            this.textBox_OutputFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.textBox_OutputFileName.Text = "AllFile.txt";
            this.listBox_SearchFolders.Items.Add("C:\\");
            this.listBox_SearchFolders.Items.Add("D:\\");
        }

        void ListAdd(string type, string directoryCode, string directoryCode_or_file, string fileCount_or_lastEditTime, string createTime, string size)
        {
            _listString.Add(type + "\t" + directoryCode + "\t" + directoryCode_or_file + "\t" + fileCount_or_lastEditTime + "\t" + createTime + "\t" + size);
        }

        void Run()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Reset();
            watch.Start();

            if (File.Exists(Path.Combine(this.textBox_OutputFolder.Text, this.textBox_OutputFileName.Text)))
                File.Delete(Path.Combine(this.textBox_OutputFolder.Text, this.textBox_OutputFileName.Text));

            ListAdd(
                "【D=directory】【f=file】",
                "【directory code】",
                "【directory code】【file】",
                "【file count】【last edit time】",
                "【create time】",
                "【size】"
                );


            foreach (string path in this.listBox_SearchFolders.Items)
            {
                _nFiles = 0;
                _nSize = 0;
                DirSearch(path);
            }
            writeFile();

            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds / 1000);
            this.textBox_ProcessBar.Text = "done";
        }

        void writeFile()
        {
            TextWriter tw = new StreamWriter(Path.Combine(this.textBox_OutputFolder.Text, this.textBox_OutputFileName.Text), true, Encoding.Unicode);

            foreach (string s in _listString)
                tw.WriteLine(s);
            tw.Close();

            _listString.Clear();
        }

        void DirSearch(string sDir)
        {
            long ori_size = _nSize;
            int ori_num = _nFiles;
            long new_size = 0;
            int new_num = 0;
            string[] directories;
            FileInfo[] files;
            DirectoryInfo dir;
            string sDirCode = "";

            try
            {
                directories = Directory.GetDirectories(sDir);
            }
            catch /*(System.Exception excpt)*/
            {
                /*listString.Add("Error1 occured: " + excpt.Message);*/
                return;
            }

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

            try
            {
                dir = new DirectoryInfo(sDir);
                files = dir.GetFiles();
            }
            catch /*(System.Exception excpt)*/
            {
                /*listString.Add("Error2 occured: " + excpt.Message);*/
                return;
            }

            long sizeMB;
            bool bPrintDir = false;
            foreach (FileInfo f in files)
            {
                _nSize += f.Length;
                _nFiles++;
                sizeMB = f.Length / 1024 / 1024;

                //if (
                //sizeMB > 10
                //&&
                //DateTime.Compare(new DateTime(2019, 2, 18, 0, 0, 0), f.LastWriteTime) < 0
                //||
                //f.ToString().ToLower().Contains(".txt")
                //    )
                {
                    bPrintDir = true;
                    ListAdd(
                            "f",
                            sDirCode,
                            Path.GetFileName(f.ToString())/*FileInfo only contains full path file*/,
                            f.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss"),
                            f.CreationTime.ToString("yyyy/MM/dd HH:mm:ss"),
                            sizeMB.ToString()
                        );
                }

                _nEvery++;

                if (_nEvery % 500 == 0)
                {
                    this.textBox_ProcessBar.Text = new string('*', (_nEvery / 500) % 50); //user experience
                    Application.DoEvents();
                    if (_nEvery % 50000 == 0)
                        writeFile();
                }

            }

            sizeMB = _nSize / 1024 / 1024;
            //if (
            //    bPrintDir
            //    sizeMB > 5000
            //    )
            {
                ListAdd(
                    "D",
                    sDir,
                    sDirCode,
                    _nFiles.ToString(),
                    dir.CreationTime.ToString("yyyy/MM/dd HH:mm:ss"),
                    sizeMB.ToString()
                    );
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Run_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Run();
            this.Enabled = true;
        }

        private void button_SelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox_OutputFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.listBox_SearchFolders.Items.Add(folderBrowserDialog1.SelectedPath);
            }
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string fileName in files)
            {
                listBox_SearchFolders.Items.Add(fileName);
            }
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(this.listBox_SearchFolders);
            selectedItems = this.listBox_SearchFolders.SelectedItems;
            int index = listBox_SearchFolders.SelectedIndex;
            if (this.listBox_SearchFolders.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    this.listBox_SearchFolders.Items.Remove(selectedItems[i]);
            }

            try
            {
                listBox_SearchFolders.SelectedIndex = index;
                return;
            }
            catch 
            {
            }

            try
            {
                listBox_SearchFolders.SelectedIndex = index-1;
                return;
            }
            catch
            {
            }
        }
    }
}
