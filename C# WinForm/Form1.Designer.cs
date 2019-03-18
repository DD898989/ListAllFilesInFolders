namespace WindowsFormsApplication32
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
            this.button_Run = new System.Windows.Forms.Button();
            this.textBox_ProcessBar = new System.Windows.Forms.TextBox();
            this.textBox_OutputFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_OutputFileName = new System.Windows.Forms.TextBox();
            this.button_SelectFolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox_SearchFolders = new System.Windows.Forms.ListBox();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Run
            // 
            this.button_Run.Location = new System.Drawing.Point(189, 238);
            this.button_Run.Name = "button_Run";
            this.button_Run.Size = new System.Drawing.Size(75, 23);
            this.button_Run.TabIndex = 0;
            this.button_Run.Text = "Run";
            this.button_Run.UseVisualStyleBackColor = true;
            this.button_Run.Click += new System.EventHandler(this.button_Run_Click);
            // 
            // textBox_ProcessBar
            // 
            this.textBox_ProcessBar.Enabled = false;
            this.textBox_ProcessBar.Location = new System.Drawing.Point(76, 267);
            this.textBox_ProcessBar.Name = "textBox_ProcessBar";
            this.textBox_ProcessBar.Size = new System.Drawing.Size(317, 22);
            this.textBox_ProcessBar.TabIndex = 1;
            // 
            // textBox_OutputFolder
            // 
            this.textBox_OutputFolder.Location = new System.Drawing.Point(14, 46);
            this.textBox_OutputFolder.Name = "textBox_OutputFolder";
            this.textBox_OutputFolder.Size = new System.Drawing.Size(420, 22);
            this.textBox_OutputFolder.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Output Folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output File Name";
            // 
            // textBox_OutputFileName
            // 
            this.textBox_OutputFileName.Location = new System.Drawing.Point(452, 46);
            this.textBox_OutputFileName.Name = "textBox_OutputFileName";
            this.textBox_OutputFileName.Size = new System.Drawing.Size(84, 22);
            this.textBox_OutputFileName.TabIndex = 5;
            // 
            // button_SelectFolder
            // 
            this.button_SelectFolder.Location = new System.Drawing.Point(359, 74);
            this.button_SelectFolder.Name = "button_SelectFolder";
            this.button_SelectFolder.Size = new System.Drawing.Size(75, 23);
            this.button_SelectFolder.TabIndex = 6;
            this.button_SelectFolder.Text = "Select Folder";
            this.button_SelectFolder.UseVisualStyleBackColor = true;
            this.button_SelectFolder.Click += new System.EventHandler(this.button_SelectFolder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(8, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "\\";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Search Folders";
            // 
            // listBox_SearchFolders
            // 
            this.listBox_SearchFolders.AllowDrop = true;
            this.listBox_SearchFolders.FormattingEnabled = true;
            this.listBox_SearchFolders.HorizontalScrollbar = true;
            this.listBox_SearchFolders.ItemHeight = 12;
            this.listBox_SearchFolders.Location = new System.Drawing.Point(14, 114);
            this.listBox_SearchFolders.Name = "listBox_SearchFolders";
            this.listBox_SearchFolders.Size = new System.Drawing.Size(456, 100);
            this.listBox_SearchFolders.TabIndex = 9;
            this.listBox_SearchFolders.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox_SearchFolders.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(476, 162);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 10;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.Location = new System.Drawing.Point(476, 191);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(75, 23);
            this.button_Remove.TabIndex = 11;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 304);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Run;
        private System.Windows.Forms.TextBox textBox_ProcessBar;
        private System.Windows.Forms.TextBox textBox_OutputFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_OutputFileName;
        private System.Windows.Forms.Button button_SelectFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox_SearchFolders;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Remove;
    }
}

