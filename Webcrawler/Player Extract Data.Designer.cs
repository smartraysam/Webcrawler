namespace Webcrawler
{
    partial class Player_Extract_Data
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
            this.getData = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.playerName = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.Next = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.playerNO = new System.Windows.Forms.Label();
            this.getBAERA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.prodata = new System.Windows.Forms.Label();
            this.xDetails = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // getData
            // 
            this.getData.Location = new System.Drawing.Point(114, 377);
            this.getData.Name = "getData";
            this.getData.Size = new System.Drawing.Size(253, 23);
            this.getData.TabIndex = 1;
            this.getData.UseVisualStyleBackColor = true;
            this.getData.Click += new System.EventHandler(this.getData_Click);
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(12, 12);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(75, 23);
            this.Back.TabIndex = 3;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // playerName
            // 
            this.playerName.FormattingEnabled = true;
            this.playerName.Location = new System.Drawing.Point(12, 59);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(444, 225);
            this.playerName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 358);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Progress status";
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBar.Location = new System.Drawing.Point(96, 348);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(359, 23);
            this.progressBar.TabIndex = 17;
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(381, 12);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 23);
            this.Next.TabIndex = 19;
            this.Next.Text = "Next 2 of 3";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.Location = new System.Drawing.Point(186, 17);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(104, 18);
            this.status.TabIndex = 20;
            this.status.Text = "please wait ...";
            this.status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Total number";
            // 
            // playerNO
            // 
            this.playerNO.AutoSize = true;
            this.playerNO.Location = new System.Drawing.Point(186, 43);
            this.playerNO.Name = "playerNO";
            this.playerNO.Size = new System.Drawing.Size(0, 13);
            this.playerNO.TabIndex = 26;
            // 
            // getBAERA
            // 
            this.getBAERA.Location = new System.Drawing.Point(12, 59);
            this.getBAERA.Multiline = true;
            this.getBAERA.Name = "getBAERA";
            this.getBAERA.Size = new System.Drawing.Size(444, 233);
            this.getBAERA.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(278, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Total processed: ";
            // 
            // prodata
            // 
            this.prodata.AutoSize = true;
            this.prodata.Location = new System.Drawing.Point(367, 43);
            this.prodata.Name = "prodata";
            this.prodata.Size = new System.Drawing.Size(0, 13);
            this.prodata.TabIndex = 29;
            // 
            // xDetails
            // 
            this.xDetails.Location = new System.Drawing.Point(11, 311);
            this.xDetails.Multiline = true;
            this.xDetails.Name = "xDetails";
            this.xDetails.Size = new System.Drawing.Size(444, 31);
            this.xDetails.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Output Status";
            // 
            // Player_Extract_Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 403);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xDetails);
            this.Controls.Add(this.prodata);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.getBAERA);
            this.Controls.Add(this.playerNO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.status);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.playerName);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.getData);
            this.Name = "Player_Extract_Data";
            this.Text = "Player Extract Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button getData;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.ListBox playerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label playerNO;
        private System.Windows.Forms.TextBox getBAERA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label prodata;
        private System.Windows.Forms.TextBox xDetails;
        private System.Windows.Forms.Label label1;
    }
}