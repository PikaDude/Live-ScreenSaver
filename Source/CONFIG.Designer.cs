namespace Live_Screensaver
{
    partial class CONFIG
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
            this.SkipTitle = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Current = new System.Windows.Forms.Label();
            this.OTHERTITLE = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Open = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.kk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SkipTitle
            // 
            this.SkipTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SkipTitle.Location = new System.Drawing.Point(13, 13);
            this.SkipTitle.Name = "SkipTitle";
            this.SkipTitle.Size = new System.Drawing.Size(158, 30);
            this.SkipTitle.TabIndex = 0;
            this.SkipTitle.Text = "Skip Keybind";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Change";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "When this button is clicked, the next stream will be played.";
            // 
            // Current
            // 
            this.Current.Location = new System.Drawing.Point(121, 86);
            this.Current.Name = "Current";
            this.Current.Size = new System.Drawing.Size(308, 39);
            this.Current.TabIndex = 3;
            this.Current.Text = "???";
            // 
            // OTHERTITLE
            // 
            this.OTHERTITLE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OTHERTITLE.Location = new System.Drawing.Point(13, 165);
            this.OTHERTITLE.Name = "OTHERTITLE";
            this.OTHERTITLE.Size = new System.Drawing.Size(203, 31);
            this.OTHERTITLE.TabIndex = 4;
            this.OTHERTITLE.Text = "Open Stream List";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(427, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "A list containing all streams to be played. Edit to your liking!";
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(13, 231);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(101, 47);
            this.Open.TabIndex = 6;
            this.Open.Text = "Open";
            this.Open.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Supported Formats: MJPEG, CGI";
            // 
            // kk
            // 
            this.kk.Enabled = false;
            this.kk.Location = new System.Drawing.Point(12, 344);
            this.kk.Name = "kk";
            this.kk.Size = new System.Drawing.Size(117, 51);
            this.kk.TabIndex = 8;
            this.kk.Text = "OK";
            this.kk.UseVisualStyleBackColor = true;
            // 
            // CONFIG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 544);
            this.Controls.Add(this.kk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OTHERTITLE);
            this.Controls.Add(this.Current);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SkipTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CONFIG";
            this.Text = "Config";
            this.Load += new System.EventHandler(this.CONFIG_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keypress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SkipTitle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Current;
        private System.Windows.Forms.Label OTHERTITLE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button kk;
    }
}