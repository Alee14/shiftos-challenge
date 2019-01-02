namespace ShiftOS.Programs
{
    partial class Clock
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
            this.bottomtext = new System.Windows.Forms.Label();
            this.pgcontents = new System.Windows.Forms.Panel();
            this.toptext = new System.Windows.Forms.Label();
            this.lbmaintime = new System.Windows.Forms.Label();
            this.pgcontents.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomtext
            // 
            this.bottomtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomtext.Location = new System.Drawing.Point(10, 88);
            this.bottomtext.Name = "bottomtext";
            this.bottomtext.Size = new System.Drawing.Size(342, 23);
            this.bottomtext.TabIndex = 2;
            this.bottomtext.Text = "Seconds have passed";
            this.bottomtext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pgcontents
            // 
            this.pgcontents.BackColor = System.Drawing.Color.White;
            this.pgcontents.Controls.Add(this.bottomtext);
            this.pgcontents.Controls.Add(this.toptext);
            this.pgcontents.Controls.Add(this.lbmaintime);
            this.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcontents.Location = new System.Drawing.Point(2, 30);
            this.pgcontents.Name = "pgcontents";
            this.pgcontents.Size = new System.Drawing.Size(362, 135);
            this.pgcontents.TabIndex = 25;
            // 
            // toptext
            // 
            this.toptext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toptext.Location = new System.Drawing.Point(10, 22);
            this.toptext.Name = "toptext";
            this.toptext.Size = new System.Drawing.Size(342, 23);
            this.toptext.TabIndex = 1;
            this.toptext.Text = "The Time is";
            this.toptext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbmaintime
            // 
            this.lbmaintime.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmaintime.Location = new System.Drawing.Point(6, 38);
            this.lbmaintime.Name = "lbmaintime";
            this.lbmaintime.Size = new System.Drawing.Size(350, 52);
            this.lbmaintime.TabIndex = 0;
            this.lbmaintime.Text = "00000000";
            this.lbmaintime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Clock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 167);
            this.Controls.Add(this.pgcontents);
            this.Name = "Clock";
            this.Text = "Clock";
            this.WindowIcon = global::ShiftOS.Properties.Resources.iconClock;
            this.WindowTitle = "Clock";
            this.Controls.SetChildIndex(this.pgcontents, 0);
            this.pgcontents.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label bottomtext;
        internal System.Windows.Forms.Panel pgcontents;
        internal System.Windows.Forms.Label toptext;
        internal System.Windows.Forms.Label lbmaintime;
    }
}