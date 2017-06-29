namespace Webcrawler
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
            this.player_initials = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.but_exit = new System.Windows.Forms.Button();
            this.get_info = new System.Windows.Forms.Button();
            this.player_list = new System.Windows.Forms.ListBox();
            this.extract = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // player_initials
            // 
            this.player_initials.FormattingEnabled = true;
            this.player_initials.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.player_initials.Location = new System.Drawing.Point(168, 17);
            this.player_initials.Name = "player_initials";
            this.player_initials.Size = new System.Drawing.Size(270, 21);
            this.player_initials.TabIndex = 0;
            this.player_initials.SelectedIndexChanged += new System.EventHandler(this.player_initials_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Player Last Name Initial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Players List with initial";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "PlayerDetails";
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // but_exit
            // 
            this.but_exit.Location = new System.Drawing.Point(15, 330);
            this.but_exit.Name = "but_exit";
            this.but_exit.Size = new System.Drawing.Size(75, 23);
            this.but_exit.TabIndex = 8;
            this.but_exit.Text = "Exit";
            this.but_exit.UseVisualStyleBackColor = true;
            this.but_exit.Click += new System.EventHandler(this.but_exit_Click);
            // 
            // get_info
            // 
            this.get_info.Location = new System.Drawing.Point(187, 330);
            this.get_info.Name = "get_info";
            this.get_info.Size = new System.Drawing.Size(98, 23);
            this.get_info.TabIndex = 9;
            this.get_info.Text = "Get Player names";
            this.get_info.UseVisualStyleBackColor = true;
            this.get_info.Click += new System.EventHandler(this.get_info_Click);
            // 
            // player_list
            // 
            this.player_list.FormattingEnabled = true;
            this.player_list.Location = new System.Drawing.Point(15, 63);
            this.player_list.Name = "player_list";
            this.player_list.Size = new System.Drawing.Size(423, 225);
            this.player_list.TabIndex = 10;
            // 
            // extract
            // 
            this.extract.Location = new System.Drawing.Point(363, 330);
            this.extract.Name = "extract";
            this.extract.Size = new System.Drawing.Size(75, 23);
            this.extract.TabIndex = 14;
            this.extract.Text = "Next 1 of 3";
            this.extract.UseVisualStyleBackColor = true;
            this.extract.Click += new System.EventHandler(this.extract_Click);
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBar.Location = new System.Drawing.Point(100, 294);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(338, 23);
            this.progressBar.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Progress status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 365);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.extract);
            this.Controls.Add(this.player_list);
            this.Controls.Add(this.get_info);
            this.Controls.Add(this.but_exit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.player_initials);
            this.Name = "Form1";
            this.Text = "Baseball Players Data Extractor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox player_initials;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button but_exit;
        private System.Windows.Forms.Button get_info;
        private System.Windows.Forms.ListBox player_list;
        private System.Windows.Forms.Button extract;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label3;
    }
}

