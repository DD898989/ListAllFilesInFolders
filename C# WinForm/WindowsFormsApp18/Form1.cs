using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System.Text.RegularExpressions;
using RestSharp;
using Aspose.Cells;
using Aspose;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;


namespace WindowsFormsApp18
{


    //          IronPdf  
    /*
     
                var pdfDocument = IronPdf.PdfDocument.FromFile(fileName);
                string AllText = pdfDocument.ExtractAllText();
                System.IO.File.WriteAllText("HERE.txt", AllText);
     */
    /*
                 SPX
                Z01-6-4-
                -6-4-0611-
                顧客繳款及門市寄件聯
                TW232475145431V
                請
                至
                OK
                寄
                件
                菲*
                物
                流
                蝦
                皮
                取
                件
                蝦皮訂單編號



                To extract all of the page text, obtain a license key from https://ironpdf.com/licensing/
     */



    //          TikaOnDotNet  
    /*
                 var fileInfo = new FileInfo(sFile);
                 var text = new TextExtractor().Extract(fileInfo.FullName).Text;
     */
    /*
                TikaOnDotNet.TextExtraction.TextExtractionException
                  HResult=0x80131500
                  Message=Extraction of text from the file 'C:\Users\DaveVivo\Downloads\案子\9-17 東280.pdf' failed.
                  Source=TikaOnDotNet.TextExtraction
                
                內部例外狀況 1:
                TextExtractionException: Extraction failed.
                
                內部例外狀況 2:
                OutOfMemoryException: Exception_WasThrown
     */


    public partial class Form1 : Form
    {
        string _nEvery = "";

        public Form1()
        {
            InitializeComponent();
            this.textBox_OutputFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.textBox_OutputFileName.Text = "AllFile.xlsx";
            this.listBox_SearchFolders.Items.Add("C:\\Users\\DaveVivo\\Desktop\\案子\\9-17 東280.pdf");
            //this.listBox_SearchFolders.Items.Add("D:\\");
        }


        public class Temp
        {
            public Temp(
                string 檔案,
                string 頁數,
                string 未命名編號,
                string OK訂單編號,
                string 姓名,
                string 姓名2,
                string 待補充欄位1,
                string 待補充欄位2,
                string 待補充欄位3,
                string 待補充欄位N,
                string 回傳,
                string 取件門市,
                string 原始字串


                )
            {
                
                this.檔案  = 檔案;
                this.頁數  = 頁數;
                this.未命名編號  = 未命名編號;
                this.OK訂單編號  = OK訂單編號;
                this.姓名  = 姓名;
                this.姓名2  = 姓名2;
                this.待補充欄位1  = 待補充欄位1;
                this.待補充欄位2  = 待補充欄位2;
                this.待補充欄位3  = 待補充欄位3;
                this.待補充欄位N  = 待補充欄位N;
                this.回傳  = 回傳;
                this.取件門市  = 取件門市;
                this.原始字串 = 原始字串;

            
            }


            public string 檔案 { get; set; }
            public string 頁數 { get; set; }
            public string 未命名編號 { get; set; }
            public string OK訂單編號 { get; set; }
            public string 姓名 { get; set; }
            public string 姓名2 { get; set; }
            public string 待補充欄位1 { get; set; }
            public string 待補充欄位2 { get; set; }
            public string 待補充欄位3 { get; set; }
            public string 待補充欄位N { get; set; }
            public string 回傳 { get; set; }
            public string 取件門市 { get; set; }
            public string 原始字串 { get; set; }

        }


        void Run()
        {
            var lists = new List<Temp>();






            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Reset();
            watch.Start();

            if (File.Exists(Path.Combine(this.textBox_OutputFolder.Text, this.textBox_OutputFileName.Text)))
                File.Delete(Path.Combine(this.textBox_OutputFolder.Text, this.textBox_OutputFileName.Text));


            lists.Add(new Temp(
                "檔案",
                "頁數",
                "未命名編號",
                "OK訂單編號",
                "姓名1",
                "姓名2",
                "待補充欄位1",
                "待補充欄位2",
                "待補充欄位3",
                "待補充欄位N",
                "回傳",
                "取件門市",
                "原始字串"));

            foreach (string path in this.listBox_SearchFolders.Items)
            {
                DirSearch(path,ref lists);
            }




            // 實例化一個代表 Excel 文件的工作簿對象。
            Workbook wb = new Workbook();
            wb.Worksheets.Add();

            Worksheet sheet1 = wb.Worksheets[0];
            var k = 0;
            foreach (var li in lists)
            {
                var j = 65;
                k++;

                { Cell cell1 = sheet1.Cells[$"{(char)j++}{k}"]; cell1.PutValue(li.檔案); }
                { Cell cell1 = sheet1.Cells[$"{(char)j++}{k}"]; cell1.PutValue(li.頁數); }
                { Cell cell1 = sheet1.Cells[$"{(char)j++}{k}"]; cell1.PutValue(li.未命名編號); }
                { Cell cell1 = sheet1.Cells[$"{(char)j++}{k}"]; cell1.PutValue(li.OK訂單編號); }
                { Cell cell1 = sheet1.Cells[$"{(char)j++}{k}"]; cell1.PutValue(li.姓名); }
                { Cell cell1 = sheet1.Cells[$"{(char)j++}{k}"]; cell1.PutValue(li.姓名2); }
                { Cell cell1 = sheet1.Cells[$"{(char)j++}{k}"]; cell1.PutValue(li.取件門市); }
                {
                    Cell cell1 = sheet1.Cells[$"{(char)j++}{k}"]; cell1.PutValue(li.回傳);
                    if (li.回傳 == "已取貨")
                    {
                        Style style1 = cell1.GetStyle();
                        style1.SetPatternColor(BackgroundType.Solid, Color.Orange, Color.Brown);
                        cell1.SetStyle(style1);
                    }
                }

            }

            var groups = lists
                .GroupBy(s => s.回傳)
                .Select(s => new {
                    Stuff = s.Key,
                    Count = s.Count()
                });


            Worksheet sheet2 = wb.Worksheets[1];

            var k2 = 0;
            foreach (var li in groups)
            {
                var j = 65;
                k2++;
                if (li.Stuff == "回傳")
                {
                    continue;
                }
                { Cell cell1 = sheet2.Cells[$"{(char)j++}{k2}"]; cell1.PutValue(li.Stuff); }
                { Cell cell1 = sheet2.Cells[$"{(char)j++}{k2}"]; cell1.PutValue(li.Count); }

            }


            // 將 Excel 另存為 .xlsx 文件。
            wb.Save(Path.Combine(this.textBox_OutputFolder.Text, this.textBox_OutputFileName.Text), SaveFormat.Xlsx);




            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds / 1000);
            this.textBox_ProcessBar.Text = "done";
        }


        void DirSearch(string sFile, ref List<Temp> lists)
        {
            var fileInfo = new FileStream(sFile,FileMode.Open);
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileInfo);

            var totalPages = loadedDocument.Pages.Count;

            //迴圈頁數
            for (var i = 0; i < totalPages; i++)
            {
                if(i > numericUpDown查前幾筆.Value)
                {
                    break ;
                }


                PdfPageBase page = loadedDocument.Pages[i];
                var text = page.ExtractText(true);

                ///// File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\HERE\\HERE{i + 1}.txt", text);


                var matchOK未命名編號 = new Regex("OK 寄件\r\n(\r\n)?.+\r\n?(?<未命名編號>.*)\r\n202\\d-\\d\\d-\\d\\d").Match(text);
                //                                            (\r\n)? 表示不一定會有 第三頁沒有
                var 未命名編號 = "";
                if (matchOK未命名編號.Success)
                {
                    未命名編號 = matchOK未命名編號.Groups["未命名編號"].Value;
                }


                var 回傳 = "";
                var 取件門市 = "";




                var matchOK訂單編號 = new Regex("\r\n(?<OK訂單編號>.*)OK 訂單編號 :\r\n").Match(text);
                var OK訂單編號 = "";
                if (matchOK訂單編號.Success)
                {
                    OK訂單編號 = matchOK訂單編號.Groups["OK訂單編號"].Value;

                    if (cb1.Checked)
                    {
                        try
                        {
                            var options = new RestClientOptions("https://ecservice.okmart.com.tw")
                            {
                                MaxTimeout = -1,
                            };
                            var client = new RestClient(options);
                            var request = new RestRequest("/Tracking/Result?inputOdNo=" + OK訂單編號 + "&inputCode1=FN5O9", Method.Get);
                            request.AddHeader("cookie", "_ga=GA1.3.1645060347.1692369316; _ga_1DPFC029V1=GS1.1.1692369316.1.0.1692369320.0.0.0; ValidateNumber=code=FN5O9&odno=" + OK訂單編號 + "&cutknm=&cutktl=");
                            RestResponse response = client.ExecuteAsync(request).Result;
                            var 回傳HTML = response.Content;

                            var match回傳 = new Regex("<span class=\"status\">(?<回傳>.*)</span>").Match(回傳HTML);
                            if (match回傳.Success)
                            {
                                回傳 = match回傳.Groups["回傳"].Value;
                                if (回傳?.Length > 0)
                                {
                                    //錯誤X = "";
                                }
                            }
                            else if (回傳HTML.Contains("查無單號，請重新查詢"))
                            {
                            }
                            else
                            {
                            }



                            var match取件門市 = new Regex("<span class=\"stNm\">(?<取件門市>.*)</span>").Match(回傳HTML);
                            if (match取件門市.Success)
                            {
                                取件門市 = match取件門市.Groups["取件門市"].Value;
                            }


                            System.Threading.Thread.Sleep(((int)this.numericUpDown1.Value)); //避免三方檔住惡意ip <h2>The request is blocked.</h2>
                                                                                             //   <span class="status">已離開寄件店</span>


                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("");
                        }

                    }
                }



                var match姓名 = new Regex("請\r\n至\r\nOK\r\n寄\r\n件\r\n(?<姓名>.*)\r\n物\r\n流\r\n").Match(text);
                var 姓名 = "";
                if (match姓名.Success)
                {
                    姓名 = match姓名.Groups["姓名"].Value;
                }
                else
                {
                    //錯誤 = "Y";
                }




                var match姓名2 = new Regex("\r\n202\\d-\\d\\d-\\d\\d.+\r\n.+\r\n(?<姓名2>.*)\r\n手機末三碼").Match(text);
                var 姓名2 = "";
                if (match姓名2.Success)
                {
                    姓名2 = match姓名2.Groups["姓名2"].Value;
                }
                else
                {

                    var match姓名2_2 = new Regex("末\r\n三\r\n碼.+\r\n\r\n.+\r\n(?<姓名2_2>.*)\r\n").Match(text);
                    if (match姓名2_2.Success)
                    {
                        姓名2 = match姓名2_2.Groups["姓名2_2"].Value;
                    }
                    else
                    {
                        //錯誤 = "Y";
                    }
                }

                lists.Add( new Temp(
                    sFile,
                    (i + 1).ToString(),
                    $"{未命名編號}",
                    $"{OK訂單編號}",
                    姓名,
                    姓名2,
                    "待補充欄位1",
                    "待補充欄位2",
                    "待補充欄位3",
                    "待補充欄位N",
                    回傳,
                    取件門市,
                    text.Replace("\r\n","\\r\\n"))
                    );


                if (_nEvery.Length % 30 == 0)
                {
                    _nEvery = "";
                }


                _nEvery = _nEvery + ">";

                this.textBox_ProcessBar.Text = _nEvery;// new string('o', _nEvery % 50);
                Application.DoEvents();
            }


            
            fileInfo.Close();
            loadedDocument.Close(true);



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Run_Click(object sender, EventArgs e)
        {
            if(DateTime.Now > new DateTime(2023, 9, 25))
            {
                return;
            }


            this.Enabled = false;
            Run();
            this.Enabled = true;
        }

        private void button_SelectFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowserDialog1 = new OpenFileDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox_OutputFolder.Text = folderBrowserDialog1.FileName;
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowserDialog1 = new OpenFileDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.listBox_SearchFolders.Items.Add(folderBrowserDialog1.FileName);
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
                listBox_SearchFolders.SelectedIndex = index - 1;
                return;
            }
            catch
            {
            }
        }
    }
}
