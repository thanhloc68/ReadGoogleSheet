namespace ManageBunker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnUpdateSpreadsheet = new System.Windows.Forms.Button();
            this.btnCreateSpeardsheet = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnexit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(38, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(303, 23);
            this.textBox1.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(347, 25);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(37, 55);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            // 
            // btnUpdateSpreadsheet
            // 
            this.btnUpdateSpreadsheet.Location = new System.Drawing.Point(118, 55);
            this.btnUpdateSpreadsheet.Name = "btnUpdateSpreadsheet";
            this.btnUpdateSpreadsheet.Size = new System.Drawing.Size(141, 23);
            this.btnUpdateSpreadsheet.TabIndex = 3;
            this.btnUpdateSpreadsheet.Text = "Update Spreadsheet";
            this.btnUpdateSpreadsheet.UseVisualStyleBackColor = true;
            this.btnUpdateSpreadsheet.Click += new System.EventHandler(this.btnUpdateSpreadsheet_Click);
            // 
            // btnCreateSpeardsheet
            // 
            this.btnCreateSpeardsheet.Location = new System.Drawing.Point(37, 84);
            this.btnCreateSpeardsheet.Name = "btnCreateSpeardsheet";
            this.btnCreateSpeardsheet.Size = new System.Drawing.Size(144, 35);
            this.btnCreateSpeardsheet.TabIndex = 4;
            this.btnCreateSpeardsheet.Text = "Create SpreadSheet";
            this.btnCreateSpeardsheet.UseVisualStyleBackColor = true;
            this.btnCreateSpeardsheet.Click += new System.EventHandler(this.btnCreateSpeardsheet_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(37, 125);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(740, 313);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(478, 26);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(144, 35);
            this.btnexit.TabIndex = 6;
            this.btnexit.Text = "exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnCreateSpeardsheet);
            this.Controls.Add(this.btnUpdateSpreadsheet);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Button btnBrowse;
        private Button btnUpload;
        private Button btnUpdateSpreadsheet;
        private Button btnCreateSpeardsheet;
        private ListView listView1;
        private Button btnexit;
    }
}