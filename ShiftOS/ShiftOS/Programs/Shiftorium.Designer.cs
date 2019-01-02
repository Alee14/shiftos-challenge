namespace ShiftOS.Programs
{
    partial class Shiftorium
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shiftorium));
            this.tmrcodepointsupdate = new System.Windows.Forms.Timer(this.components);
            this.pnlintro = new System.Windows.Forms.Panel();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnbuy = new System.Windows.Forms.Button();
            this.lbprice = new System.Windows.Forms.Label();
            this.picpreview = new System.Windows.Forms.PictureBox();
            this.lbudescription = new System.Windows.Forms.Label();
            this.lbupgradename = new System.Windows.Forms.Label();
            this.lbcodepoints = new System.Windows.Forms.Label();
            this.lbupgrades = new System.Windows.Forms.ListBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.pnlinfo = new System.Windows.Forms.Panel();
            this.pgcontents = new System.Windows.Forms.Panel();
            this.pnlintro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picpreview)).BeginInit();
            this.pnlinfo.SuspendLayout();
            this.pgcontents.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrcodepointsupdate
            // 
            this.tmrcodepointsupdate.Enabled = true;
            this.tmrcodepointsupdate.Interval = 1000;
            // 
            // pnlintro
            // 
            this.pnlintro.Controls.Add(this.Label4);
            this.pnlintro.Controls.Add(this.Label2);
            this.pnlintro.Controls.Add(this.Label5);
            this.pnlintro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlintro.Location = new System.Drawing.Point(0, 0);
            this.pnlintro.Name = "pnlintro";
            this.pnlintro.Size = new System.Drawing.Size(369, 430);
            this.pnlintro.TabIndex = 8;
            this.pnlintro.TabStop = true;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(-3, 397);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(358, 18);
            this.Label4.TabIndex = 7;
            this.Label4.Text = "Select an upgrade on the left to view its details";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(3, 53);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(340, 341);
            this.Label2.TabIndex = 5;
            this.Label2.Text = resources.GetString("Label2.Text");
            this.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(-4, 14);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(355, 31);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "Welcome to the Shiftorium";
            // 
            // btnbuy
            // 
            this.btnbuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuy.ForeColor = System.Drawing.Color.Black;
            this.btnbuy.Location = new System.Drawing.Point(160, 362);
            this.btnbuy.Name = "btnbuy";
            this.btnbuy.Size = new System.Drawing.Size(185, 56);
            this.btnbuy.TabIndex = 7;
            this.btnbuy.Text = "Buy";
            this.btnbuy.UseVisualStyleBackColor = true;
            this.btnbuy.Click += new System.EventHandler(this.btnbuy_Click);
            // 
            // lbprice
            // 
            this.lbprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbprice.ForeColor = System.Drawing.Color.Black;
            this.lbprice.Location = new System.Drawing.Point(15, 362);
            this.lbprice.Name = "lbprice";
            this.lbprice.Size = new System.Drawing.Size(139, 59);
            this.lbprice.TabIndex = 6;
            this.lbprice.Text = "50 CP";
            this.lbprice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picpreview
            // 
            this.picpreview.Location = new System.Drawing.Point(25, 218);
            this.picpreview.Name = "picpreview";
            this.picpreview.Size = new System.Drawing.Size(320, 130);
            this.picpreview.TabIndex = 5;
            this.picpreview.TabStop = false;
            // 
            // lbudescription
            // 
            this.lbudescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbudescription.ForeColor = System.Drawing.Color.Black;
            this.lbudescription.Location = new System.Drawing.Point(24, 63);
            this.lbudescription.Name = "lbudescription";
            this.lbudescription.Size = new System.Drawing.Size(321, 144);
            this.lbudescription.TabIndex = 4;
            this.lbudescription.Text = resources.GetString("lbudescription.Text");
            this.lbudescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbupgradename
            // 
            this.lbupgradename.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbupgradename.ForeColor = System.Drawing.Color.Black;
            this.lbupgradename.Location = new System.Drawing.Point(5, 17);
            this.lbupgradename.Name = "lbupgradename";
            this.lbupgradename.Size = new System.Drawing.Size(361, 43);
            this.lbupgradename.TabIndex = 3;
            this.lbupgradename.Text = "Upgradename";
            this.lbupgradename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbcodepoints
            // 
            this.lbcodepoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcodepoints.ForeColor = System.Drawing.Color.Black;
            this.lbcodepoints.Location = new System.Drawing.Point(16, 372);
            this.lbcodepoints.Name = "lbcodepoints";
            this.lbcodepoints.Size = new System.Drawing.Size(309, 43);
            this.lbcodepoints.TabIndex = 8;
            this.lbcodepoints.Text = "Codepoints: 25";
            this.lbcodepoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbupgrades
            // 
            this.lbupgrades.BackColor = System.Drawing.Color.White;
            this.lbupgrades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbupgrades.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbupgrades.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbupgrades.ForeColor = System.Drawing.Color.Black;
            this.lbupgrades.FormattingEnabled = true;
            this.lbupgrades.ItemHeight = 19;
            this.lbupgrades.Items.AddRange(new object[] {
            "Close Button - 100 CP",
            "Gray - 50 CP",
            "Program Titles - 60 CP",
            "Seconds Since Midnight - 10 CP",
            "Shifter - 500 CP",
            "Title Bar - 80 CP"});
            this.lbupgrades.Location = new System.Drawing.Point(21, 70);
            this.lbupgrades.Name = "lbupgrades";
            this.lbupgrades.Size = new System.Drawing.Size(304, 285);
            this.lbupgrades.Sorted = true;
            this.lbupgrades.TabIndex = 0;
            this.lbupgrades.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbupgrades_DrawItem);
            this.lbupgrades.SelectedIndexChanged += new System.EventHandler(this.lbupgrades_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(85, 17);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(175, 39);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Upgrades";
            // 
            // pnlinfo
            // 
            this.pnlinfo.Controls.Add(this.pnlintro);
            this.pnlinfo.Controls.Add(this.btnbuy);
            this.pnlinfo.Controls.Add(this.lbprice);
            this.pnlinfo.Controls.Add(this.picpreview);
            this.pnlinfo.Controls.Add(this.lbudescription);
            this.pnlinfo.Controls.Add(this.lbupgradename);
            this.pnlinfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlinfo.Location = new System.Drawing.Point(328, 0);
            this.pnlinfo.Name = "pnlinfo";
            this.pnlinfo.Size = new System.Drawing.Size(369, 430);
            this.pnlinfo.TabIndex = 0;
            // 
            // pgcontents
            // 
            this.pgcontents.BackColor = System.Drawing.Color.White;
            this.pgcontents.Controls.Add(this.lbcodepoints);
            this.pgcontents.Controls.Add(this.lbupgrades);
            this.pgcontents.Controls.Add(this.Label1);
            this.pgcontents.Controls.Add(this.pnlinfo);
            this.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcontents.Location = new System.Drawing.Point(2, 30);
            this.pgcontents.Name = "pgcontents";
            this.pgcontents.Size = new System.Drawing.Size(697, 430);
            this.pgcontents.TabIndex = 15;
            this.pgcontents.TabStop = true;
            // 
            // Shiftorium
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 462);
            this.Controls.Add(this.pgcontents);
            this.Name = "Shiftorium";
            this.Text = "Shiftorium";
            this.WindowIcon = global::ShiftOS.Properties.Resources.iconShiftorium;
            this.WindowTitle = "Shiftorium";
            this.Controls.SetChildIndex(this.pgcontents, 0);
            this.pnlintro.ResumeLayout(false);
            this.pnlintro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picpreview)).EndInit();
            this.pnlinfo.ResumeLayout(false);
            this.pgcontents.ResumeLayout(false);
            this.pgcontents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Timer tmrcodepointsupdate;
        internal System.Windows.Forms.Panel pnlintro;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button btnbuy;
        internal System.Windows.Forms.Label lbprice;
        internal System.Windows.Forms.PictureBox picpreview;
        internal System.Windows.Forms.Label lbudescription;
        internal System.Windows.Forms.Label lbupgradename;
        internal System.Windows.Forms.Label lbcodepoints;
        internal System.Windows.Forms.ListBox lbupgrades;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel pnlinfo;
        internal System.Windows.Forms.Panel pgcontents;
    }
}