namespace ShiftOS.Programs
{
    partial class Infobox
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
            this.lblintructtext = new System.Windows.Forms.Label();
            this.pboximage = new System.Windows.Forms.PictureBox();
            this.txtmessage = new System.Windows.Forms.Label();
            this.btnok = new System.Windows.Forms.Button();
            this.txtuserinput = new System.Windows.Forms.TextBox();
            this.pnlyesno = new System.Windows.Forms.Panel();
            this.btnno = new System.Windows.Forms.Button();
            this.btnyes = new System.Windows.Forms.Button();
            this.pgcontents = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pboximage)).BeginInit();
            this.pnlyesno.SuspendLayout();
            this.pgcontents.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblintructtext
            // 
            this.lblintructtext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblintructtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblintructtext.Location = new System.Drawing.Point(101, 7);
            this.lblintructtext.Name = "lblintructtext";
            this.lblintructtext.Size = new System.Drawing.Size(256, 44);
            this.lblintructtext.TabIndex = 9;
            this.lblintructtext.Text = "Please enter a name for your new folder:\r\nOr \r\nDie\r\n";
            this.lblintructtext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblintructtext.Visible = false;
            // 
            // pboximage
            // 
            this.pboximage.Image = global::ShiftOS.Properties.Resources.Symbolinfo;
            this.pboximage.Location = new System.Drawing.Point(12, 7);
            this.pboximage.Name = "pboximage";
            this.pboximage.Size = new System.Drawing.Size(80, 70);
            this.pboximage.TabIndex = 0;
            this.pboximage.TabStop = false;
            // 
            // txtmessage
            // 
            this.txtmessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmessage.Location = new System.Drawing.Point(98, 7);
            this.txtmessage.Name = "txtmessage";
            this.txtmessage.Size = new System.Drawing.Size(266, 70);
            this.txtmessage.TabIndex = 2;
            this.txtmessage.Text = "It appears that this application may be infected. It is highly recommended that y" +
    "ou close it immediatly with a terminal emulator such as Sterm. To close this app" +
    "lication just type \"Close\"\r\n";
            this.txtmessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnok
            // 
            this.btnok.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnok.ForeColor = System.Drawing.Color.Black;
            this.btnok.Location = new System.Drawing.Point(134, 86);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(105, 30);
            this.btnok.TabIndex = 7;
            this.btnok.TabStop = false;
            this.btnok.Text = "Ok";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // txtuserinput
            // 
            this.txtuserinput.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtuserinput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtuserinput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuserinput.Location = new System.Drawing.Point(101, 54);
            this.txtuserinput.Multiline = true;
            this.txtuserinput.Name = "txtuserinput";
            this.txtuserinput.Size = new System.Drawing.Size(256, 23);
            this.txtuserinput.TabIndex = 8;
            this.txtuserinput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtuserinput.Visible = false;
            // 
            // pnlyesno
            // 
            this.pnlyesno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlyesno.Controls.Add(this.btnno);
            this.pnlyesno.Controls.Add(this.btnyes);
            this.pnlyesno.Location = new System.Drawing.Point(57, 83);
            this.pnlyesno.Name = "pnlyesno";
            this.pnlyesno.Size = new System.Drawing.Size(265, 33);
            this.pnlyesno.TabIndex = 10;
            this.pnlyesno.Visible = false;
            // 
            // btnno
            // 
            this.btnno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnno.ForeColor = System.Drawing.Color.Black;
            this.btnno.Location = new System.Drawing.Point(142, 2);
            this.btnno.Name = "btnno";
            this.btnno.Size = new System.Drawing.Size(105, 30);
            this.btnno.TabIndex = 9;
            this.btnno.TabStop = false;
            this.btnno.Text = "No";
            this.btnno.UseVisualStyleBackColor = true;
            this.btnno.Click += new System.EventHandler(this.btnno_Click);
            // 
            // btnyes
            // 
            this.btnyes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnyes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnyes.ForeColor = System.Drawing.Color.Black;
            this.btnyes.Location = new System.Drawing.Point(29, 2);
            this.btnyes.Name = "btnyes";
            this.btnyes.Size = new System.Drawing.Size(105, 30);
            this.btnyes.TabIndex = 8;
            this.btnyes.TabStop = false;
            this.btnyes.Text = "Yes";
            this.btnyes.UseVisualStyleBackColor = true;
            this.btnyes.Click += new System.EventHandler(this.btnyes_Click);
            // 
            // pgcontents
            // 
            this.pgcontents.BackColor = System.Drawing.Color.White;
            this.pgcontents.Controls.Add(this.pnlyesno);
            this.pgcontents.Controls.Add(this.txtuserinput);
            this.pgcontents.Controls.Add(this.btnok);
            this.pgcontents.Controls.Add(this.txtmessage);
            this.pgcontents.Controls.Add(this.pboximage);
            this.pgcontents.Controls.Add(this.lblintructtext);
            this.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcontents.Location = new System.Drawing.Point(2, 30);
            this.pgcontents.Name = "pgcontents";
            this.pgcontents.Size = new System.Drawing.Size(367, 122);
            this.pgcontents.TabIndex = 25;
            // 
            // Infobox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 154);
            this.Controls.Add(this.pgcontents);
            this.Name = "Infobox";
            this.Text = "Infobox";
            this.WindowIcon = global::ShiftOS.Properties.Resources.iconInfoBox_fw;
            this.WindowTitle = "Info";
            this.Controls.SetChildIndex(this.pgcontents, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pboximage)).EndInit();
            this.pnlyesno.ResumeLayout(false);
            this.pgcontents.ResumeLayout(false);
            this.pgcontents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblintructtext;
        internal System.Windows.Forms.PictureBox pboximage;
        internal System.Windows.Forms.Label txtmessage;
        internal System.Windows.Forms.Button btnok;
        internal System.Windows.Forms.TextBox txtuserinput;
        internal System.Windows.Forms.Panel pnlyesno;
        internal System.Windows.Forms.Button btnno;
        internal System.Windows.Forms.Button btnyes;
        internal System.Windows.Forms.Panel pgcontents;
    }
}