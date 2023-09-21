namespace WindowsFormsApp18
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_Remove = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.listBox_SearchFolders = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_SelectFolder = new System.Windows.Forms.Button();
            this.textBox_OutputFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_OutputFolder = new System.Windows.Forms.TextBox();
            this.textBox_ProcessBar = new System.Windows.Forms.TextBox();
            this.button_Run = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.cb1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown查前幾筆 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown查前幾筆)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Remove
            // 
            this.button_Remove.Location = new System.Drawing.Point(327, 183);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(75, 23);
            this.button_Remove.TabIndex = 23;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(327, 156);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 22;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // listBox_SearchFolders
            // 
            this.listBox_SearchFolders.AllowDrop = true;
            this.listBox_SearchFolders.FormattingEnabled = true;
            this.listBox_SearchFolders.HorizontalScrollbar = true;
            this.listBox_SearchFolders.ItemHeight = 12;
            this.listBox_SearchFolders.Location = new System.Drawing.Point(25, 106);
            this.listBox_SearchFolders.Name = "listBox_SearchFolders";
            this.listBox_SearchFolders.Size = new System.Drawing.Size(296, 100);
            this.listBox_SearchFolders.TabIndex = 21;
            this.listBox_SearchFolders.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox_SearchFolders.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "選擇檔案";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(8, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "\\";
            // 
            // button_SelectFolder
            // 
            this.button_SelectFolder.Location = new System.Drawing.Point(143, 66);
            this.button_SelectFolder.Name = "button_SelectFolder";
            this.button_SelectFolder.Size = new System.Drawing.Size(75, 23);
            this.button_SelectFolder.TabIndex = 18;
            this.button_SelectFolder.Text = "選擇資料夾";
            this.button_SelectFolder.UseVisualStyleBackColor = true;
            this.button_SelectFolder.Click += new System.EventHandler(this.button_SelectFolder_Click);
            // 
            // textBox_OutputFileName
            // 
            this.textBox_OutputFileName.Location = new System.Drawing.Point(237, 38);
            this.textBox_OutputFileName.Name = "textBox_OutputFileName";
            this.textBox_OutputFileName.Size = new System.Drawing.Size(84, 22);
            this.textBox_OutputFileName.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "輸出檔名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "輸出資料夾";
            // 
            // textBox_OutputFolder
            // 
            this.textBox_OutputFolder.Location = new System.Drawing.Point(25, 38);
            this.textBox_OutputFolder.Name = "textBox_OutputFolder";
            this.textBox_OutputFolder.Size = new System.Drawing.Size(193, 22);
            this.textBox_OutputFolder.TabIndex = 14;
            // 
            // textBox_ProcessBar
            // 
            this.textBox_ProcessBar.Enabled = false;
            this.textBox_ProcessBar.Location = new System.Drawing.Point(106, 223);
            this.textBox_ProcessBar.Name = "textBox_ProcessBar";
            this.textBox_ProcessBar.Size = new System.Drawing.Size(215, 22);
            this.textBox_ProcessBar.TabIndex = 13;
            // 
            // button_Run
            // 
            this.button_Run.Location = new System.Drawing.Point(25, 223);
            this.button_Run.Name = "button_Run";
            this.button_Run.Size = new System.Drawing.Size(75, 23);
            this.button_Run.TabIndex = 12;
            this.button_Run.Text = "執行";
            this.button_Run.UseVisualStyleBackColor = true;
            this.button_Run.Click += new System.EventHandler(this.button_Run_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(337, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "間隔(毫秒)";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(333, 81);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 22);
            this.numericUpDown1.TabIndex = 25;
            this.numericUpDown1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // cb1
            // 
            this.cb1.AutoSize = true;
            this.cb1.Checked = true;
            this.cb1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb1.Location = new System.Drawing.Point(333, 36);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(72, 16);
            this.cb1.TabIndex = 26;
            this.cb1.Text = "連網查詢";
            this.cb1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown查前幾筆
            // 
            this.numericUpDown查前幾筆.Location = new System.Drawing.Point(333, 128);
            this.numericUpDown查前幾筆.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown查前幾筆.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown查前幾筆.Name = "numericUpDown查前幾筆";
            this.numericUpDown查前幾筆.Size = new System.Drawing.Size(75, 22);
            this.numericUpDown查前幾筆.TabIndex = 27;
            this.numericUpDown查前幾筆.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(331, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "查前N頁(測試用)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 258);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDown查前幾筆);
            this.Controls.Add(this.cb1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.listBox_SearchFolders);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_SelectFolder);
            this.Controls.Add(this.textBox_OutputFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_OutputFolder);
            this.Controls.Add(this.textBox_ProcessBar);
            this.Controls.Add(this.button_Run);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown查前幾筆)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.ListBox listBox_SearchFolders;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_SelectFolder;
        private System.Windows.Forms.TextBox textBox_OutputFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_OutputFolder;
        private System.Windows.Forms.TextBox textBox_ProcessBar;
        private System.Windows.Forms.Button button_Run;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox cb1;
        private System.Windows.Forms.NumericUpDown numericUpDown查前幾筆;
        private System.Windows.Forms.Label label6;
    }
}

