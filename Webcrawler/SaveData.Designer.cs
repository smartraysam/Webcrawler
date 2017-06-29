namespace Webcrawler
{
    partial class SaveData
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Save = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.Export = new System.Windows.Forms.Button();
            this.File_Path = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.process = new System.Windows.Forms.Label();
            this.tabletxt = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.playerNO = new System.Windows.Forms.Label();
            this.extract = new System.Windows.Forms.Button();
            this.table2txt = new System.Windows.Forms.TextBox();
            this.table3txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.extractstatus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(477, 294);
            this.dataGridView1.TabIndex = 0;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(495, 394);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(133, 23);
            this.Save.TabIndex = 1;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(12, 12);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(75, 23);
            this.Back.TabIndex = 2;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(495, 12);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(133, 23);
            this.Export.TabIndex = 3;
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // File_Path
            // 
            this.File_Path.Location = new System.Drawing.Point(12, 397);
            this.File_Path.Name = "File_Path";
            this.File_Path.ReadOnly = true;
            this.File_Path.Size = new System.Drawing.Size(476, 20);
            this.File_Path.TabIndex = 4;
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBar.Location = new System.Drawing.Point(93, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(397, 23);
            this.progressBar.TabIndex = 18;
            // 
            // process
            // 
            this.process.AutoSize = true;
            this.process.BackColor = System.Drawing.Color.Transparent;
            this.process.Font = new System.Drawing.Font("Monotype Corsiva", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.process.ForeColor = System.Drawing.Color.Black;
            this.process.Location = new System.Drawing.Point(241, 17);
            this.process.Name = "process";
            this.process.Size = new System.Drawing.Size(62, 15);
            this.process.TabIndex = 19;
            this.process.Text = "processing...";
            this.process.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabletxt
            // 
            this.tabletxt.Location = new System.Drawing.Point(13, 42);
            this.tabletxt.Multiline = true;
            this.tabletxt.Name = "tabletxt";
            this.tabletxt.Size = new System.Drawing.Size(477, 294);
            this.tabletxt.TabIndex = 20;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.CheckFileExists = true;
            this.saveFileDialog.InitialDirectory = "@\"C:\\\"";
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(492, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Total No:";
            // 
            // playerNO
            // 
            this.playerNO.AutoSize = true;
            this.playerNO.Location = new System.Drawing.Point(591, 60);
            this.playerNO.Name = "playerNO";
            this.playerNO.Size = new System.Drawing.Size(0, 13);
            this.playerNO.TabIndex = 27;
            // 
            // extract
            // 
            this.extract.Location = new System.Drawing.Point(495, 368);
            this.extract.Name = "extract";
            this.extract.Size = new System.Drawing.Size(133, 23);
            this.extract.TabIndex = 28;
            this.extract.Text = "Extract Data";
            this.extract.UseVisualStyleBackColor = true;
            this.extract.Click += new System.EventHandler(this.extract_Click);
            // 
            // table2txt
            // 
            this.table2txt.Location = new System.Drawing.Point(13, 42);
            this.table2txt.Multiline = true;
            this.table2txt.Name = "table2txt";
            this.table2txt.Size = new System.Drawing.Size(477, 294);
            this.table2txt.TabIndex = 29;
            // 
            // table3txt
            // 
            this.table3txt.Location = new System.Drawing.Point(12, 42);
            this.table3txt.Multiline = true;
            this.table3txt.Name = "table3txt";
            this.table3txt.Size = new System.Drawing.Size(477, 294);
            this.table3txt.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(492, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Processed Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(591, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 32;
            // 
            // extractstatus
            // 
            this.extractstatus.Location = new System.Drawing.Point(13, 349);
            this.extractstatus.Multiline = true;
            this.extractstatus.Name = "extractstatus";
            this.extractstatus.Size = new System.Drawing.Size(477, 42);
            this.extractstatus.TabIndex = 33;
          
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Extraction Status";
            // 
            // SaveData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 424);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.extractstatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.table3txt);
            this.Controls.Add(this.table2txt);
            this.Controls.Add(this.extract);
            this.Controls.Add(this.playerNO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabletxt);
            this.Controls.Add(this.process);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.File_Path);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SaveData";
            this.Text = "SaveData";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.TextBox File_Path;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label process;
        private System.Windows.Forms.TextBox tabletxt;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label playerNO;
        private System.Windows.Forms.Button extract;
        private System.Windows.Forms.TextBox table2txt;
        private System.Windows.Forms.TextBox table3txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox extractstatus;
        private System.Windows.Forms.Label label1;
    }
}