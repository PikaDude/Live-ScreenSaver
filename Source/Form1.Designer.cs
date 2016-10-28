namespace Drawn_Screensaver
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
            this.stream = new System.Windows.Forms.PictureBox();
            this.NowShowing = new System.Windows.Forms.Label();
            this.ping = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.stream)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ping)).BeginInit();
            this.SuspendLayout();
            // 
            // stream
            // 
            this.stream.Location = new System.Drawing.Point(0, -1);
            this.stream.Name = "stream";
            this.stream.Size = new System.Drawing.Size(200, 200);
            this.stream.TabIndex = 0;
            this.stream.TabStop = false;
            this.stream.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_Click);
            this.stream.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // NowShowing
            // 
            this.NowShowing.BackColor = System.Drawing.Color.Transparent;
            this.NowShowing.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NowShowing.ForeColor = System.Drawing.Color.White;
            this.NowShowing.Location = new System.Drawing.Point(-1, 511);
            this.NowShowing.Name = "NowShowing";
            this.NowShowing.Size = new System.Drawing.Size(582, 1000);
            this.NowShowing.TabIndex = 1;
            this.NowShowing.Text = "Connecting...";
            // 
            // ping
            // 
            this.ping.InitialImage = null;
            this.ping.Location = new System.Drawing.Point(425, 218);
            this.ping.Name = "ping";
            this.ping.Size = new System.Drawing.Size(100, 100);
            this.ping.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ping.TabIndex = 2;
            this.ping.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(778, 544);
            this.Controls.Add(this.ping);
            this.Controls.Add(this.NowShowing);
            this.Controls.Add(this.stream);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Screensaver";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.stream)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ping)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox stream;
        private System.Windows.Forms.Label NowShowing;
        private System.Windows.Forms.PictureBox ping;
    }
}

