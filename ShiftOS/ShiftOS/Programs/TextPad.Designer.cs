namespace ShiftOS.Programs
{
    partial class TextPad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextPad));
            this.btnopen = new System.Windows.Forms.Button();
            this.btnnew = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.pnlbreak = new System.Windows.Forms.Panel();
            this.pnloptions = new System.Windows.Forms.Panel();
            this.pgcontents = new System.Windows.Forms.Panel();
            this.txtuserinput = new System.Windows.Forms.TextBox();
            this.pnloptions.SuspendLayout();
            this.pgcontents.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnopen
            // 
            this.btnopen.BackColor = System.Drawing.Color.White;
            this.btnopen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnopen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnopen.Image = global::ShiftOS.Properties.Resources.openicon;
            this.btnopen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnopen.Location = new System.Drawing.Point(86, 4);
            this.btnopen.Name = "btnopen";
            this.btnopen.Size = new System.Drawing.Size(76, 31);
            this.btnopen.TabIndex = 1;
            this.btnopen.Text = "Open";
            this.btnopen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnopen.UseVisualStyleBackColor = false;
            this.btnopen.Click += new System.EventHandler(this.btnopen_Click);
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.White;
            this.btnnew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnew.Image = ((System.Drawing.Image)(resources.GetObject("btnnew.Image")));
            this.btnnew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnew.Location = new System.Drawing.Point(4, 4);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(76, 31);
            this.btnnew.TabIndex = 0;
            this.btnnew.Text = "New";
            this.btnnew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnnew.UseVisualStyleBackColor = false;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.White;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Image = global::ShiftOS.Properties.Resources.saveicon;
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.Location = new System.Drawing.Point(168, 4);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(76, 31);
            this.btnsave.TabIndex = 2;
            this.btnsave.Text = "Save";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // pnlbreak
            // 
            this.pnlbreak.BackColor = System.Drawing.Color.White;
            this.pnlbreak.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlbreak.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlbreak.ForeColor = System.Drawing.Color.Black;
            this.pnlbreak.Location = new System.Drawing.Point(0, 365);
            this.pnlbreak.Name = "pnlbreak";
            this.pnlbreak.Size = new System.Drawing.Size(796, 15);
            this.pnlbreak.TabIndex = 2;
            // 
            // pnloptions
            // 
            this.pnloptions.BackColor = System.Drawing.Color.White;
            this.pnloptions.Controls.Add(this.btnsave);
            this.pnloptions.Controls.Add(this.btnopen);
            this.pnloptions.Controls.Add(this.btnnew);
            this.pnloptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnloptions.Location = new System.Drawing.Point(0, 380);
            this.pnloptions.Name = "pnloptions";
            this.pnloptions.Size = new System.Drawing.Size(796, 38);
            this.pnloptions.TabIndex = 1;
            this.pnloptions.Visible = false;
            // 
            // pgcontents
            // 
            this.pgcontents.Controls.Add(this.txtuserinput);
            this.pgcontents.Controls.Add(this.pnlbreak);
            this.pgcontents.Controls.Add(this.pnloptions);
            this.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcontents.Location = new System.Drawing.Point(2, 30);
            this.pgcontents.Name = "pgcontents";
            this.pgcontents.Size = new System.Drawing.Size(796, 418);
            this.pgcontents.TabIndex = 25;
            // 
            // txtuserinput
            // 
            this.txtuserinput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtuserinput.BackColor = System.Drawing.Color.White;
            this.txtuserinput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtuserinput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuserinput.ForeColor = System.Drawing.Color.Black;
            this.txtuserinput.Location = new System.Drawing.Point(4, 2);
            this.txtuserinput.Multiline = true;
            this.txtuserinput.Name = "txtuserinput";
            this.txtuserinput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtuserinput.Size = new System.Drawing.Size(794, 360);
            this.txtuserinput.TabIndex = 0;
            // 
            // TextPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pgcontents);
            this.Name = "TextPad";
            this.Text = "TextPad";
            this.WindowIcon = global::ShiftOS.Properties.Resources.iconTextPad;
            this.WindowTitle = "TextPad";
            this.Controls.SetChildIndex(this.pgcontents, 0);
            this.pnloptions.ResumeLayout(false);
            this.pgcontents.ResumeLayout(false);
            this.pgcontents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button btnopen;
        internal System.Windows.Forms.Button btnnew;
        internal System.Windows.Forms.Button btnsave;
        internal System.Windows.Forms.Panel pnlbreak;
        internal System.Windows.Forms.Panel pnloptions;
        internal System.Windows.Forms.Panel pgcontents;
        internal System.Windows.Forms.TextBox txtuserinput;
    }
}