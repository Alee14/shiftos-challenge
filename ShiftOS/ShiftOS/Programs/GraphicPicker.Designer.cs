namespace ShiftOS.Programs
{
    partial class GraphicPicker
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
            this.btncancel = new System.Windows.Forms.Button();
            this.btnreset = new System.Windows.Forms.Button();
            this.btnapply = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnidlebrowse = new System.Windows.Forms.Button();
            this.txtidlefile = new System.Windows.Forms.TextBox();
            this.picidle = new System.Windows.Forms.PictureBox();
            this.btnzoom = new System.Windows.Forms.Button();
            this.btnstretch = new System.Windows.Forms.Button();
            this.lblobjecttoskin = new System.Windows.Forms.Label();
            this.picgraphic = new System.Windows.Forms.PictureBox();
            this.btncentre = new System.Windows.Forms.Button();
            this.btntile = new System.Windows.Forms.Button();
            this.pnlgraphicholder = new System.Windows.Forms.Panel();
            this.pgcontents = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picidle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picgraphic)).BeginInit();
            this.pnlgraphicholder.SuspendLayout();
            this.pgcontents.SuspendLayout();
            this.SuspendLayout();
            // 
            // btncancel
            // 
            this.btncancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Location = new System.Drawing.Point(19, 298);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(109, 32);
            this.btncancel.TabIndex = 23;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnreset
            // 
            this.btnreset.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreset.Location = new System.Drawing.Point(134, 298);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(109, 32);
            this.btnreset.TabIndex = 22;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnapply
            // 
            this.btnapply.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnapply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnapply.Location = new System.Drawing.Point(249, 298);
            this.btnapply.Name = "btnapply";
            this.btnapply.Size = new System.Drawing.Size(118, 32);
            this.btnapply.TabIndex = 21;
            this.btnapply.Text = "Apply";
            this.btnapply.UseVisualStyleBackColor = true;
            this.btnapply.Click += new System.EventHandler(this.btnapply_Click);
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(124, 215);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(163, 28);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "Idle";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnidlebrowse
            // 
            this.btnidlebrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnidlebrowse.Location = new System.Drawing.Point(294, 215);
            this.btnidlebrowse.Name = "btnidlebrowse";
            this.btnidlebrowse.Size = new System.Drawing.Size(73, 60);
            this.btnidlebrowse.TabIndex = 10;
            this.btnidlebrowse.Text = "Browse";
            this.btnidlebrowse.UseVisualStyleBackColor = true;
            this.btnidlebrowse.Click += new System.EventHandler(this.btnidlebrowse_Click);
            // 
            // txtidlefile
            // 
            this.txtidlefile.BackColor = System.Drawing.Color.White;
            this.txtidlefile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtidlefile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidlefile.Location = new System.Drawing.Point(124, 246);
            this.txtidlefile.Multiline = true;
            this.txtidlefile.Name = "txtidlefile";
            this.txtidlefile.Size = new System.Drawing.Size(163, 29);
            this.txtidlefile.TabIndex = 9;
            this.txtidlefile.Text = "None";
            this.txtidlefile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // picidle
            // 
            this.picidle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picidle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picidle.Location = new System.Drawing.Point(18, 215);
            this.picidle.Name = "picidle";
            this.picidle.Size = new System.Drawing.Size(100, 60);
            this.picidle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picidle.TabIndex = 8;
            this.picidle.TabStop = false;
            // 
            // btnzoom
            // 
            this.btnzoom.BackgroundImage = global::ShiftOS.Properties.Resources.zoombutton;
            this.btnzoom.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnzoom.FlatAppearance.BorderSize = 0;
            this.btnzoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnzoom.Location = new System.Drawing.Point(286, 144);
            this.btnzoom.Name = "btnzoom";
            this.btnzoom.Size = new System.Drawing.Size(82, 65);
            this.btnzoom.TabIndex = 7;
            this.btnzoom.UseVisualStyleBackColor = true;
            this.btnzoom.Click += new System.EventHandler(this.btnzoom_Click);
            // 
            // btnstretch
            // 
            this.btnstretch.BackgroundImage = global::ShiftOS.Properties.Resources.stretchbutton;
            this.btnstretch.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnstretch.FlatAppearance.BorderSize = 0;
            this.btnstretch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstretch.Location = new System.Drawing.Point(197, 144);
            this.btnstretch.Name = "btnstretch";
            this.btnstretch.Size = new System.Drawing.Size(82, 65);
            this.btnstretch.TabIndex = 6;
            this.btnstretch.UseVisualStyleBackColor = true;
            this.btnstretch.Click += new System.EventHandler(this.btnstretch_Click);
            // 
            // lblobjecttoskin
            // 
            this.lblobjecttoskin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblobjecttoskin.Location = new System.Drawing.Point(19, 9);
            this.lblobjecttoskin.Name = "lblobjecttoskin";
            this.lblobjecttoskin.Size = new System.Drawing.Size(350, 23);
            this.lblobjecttoskin.TabIndex = 2;
            this.lblobjecttoskin.Text = "Close Button";
            this.lblobjecttoskin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picgraphic
            // 
            this.picgraphic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picgraphic.Location = new System.Drawing.Point(0, 0);
            this.picgraphic.Name = "picgraphic";
            this.picgraphic.Size = new System.Drawing.Size(350, 100);
            this.picgraphic.TabIndex = 0;
            this.picgraphic.TabStop = false;
            // 
            // btncentre
            // 
            this.btncentre.BackgroundImage = global::ShiftOS.Properties.Resources.centrebutton;
            this.btncentre.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btncentre.FlatAppearance.BorderSize = 0;
            this.btncentre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncentre.Location = new System.Drawing.Point(108, 144);
            this.btncentre.Name = "btncentre";
            this.btncentre.Size = new System.Drawing.Size(82, 65);
            this.btncentre.TabIndex = 5;
            this.btncentre.UseVisualStyleBackColor = true;
            this.btncentre.Click += new System.EventHandler(this.btncentre_Click);
            // 
            // btntile
            // 
            this.btntile.BackgroundImage = global::ShiftOS.Properties.Resources.tilebutton;
            this.btntile.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btntile.FlatAppearance.BorderSize = 0;
            this.btntile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntile.Location = new System.Drawing.Point(19, 144);
            this.btntile.Name = "btntile";
            this.btntile.Size = new System.Drawing.Size(82, 65);
            this.btntile.TabIndex = 4;
            this.btntile.UseVisualStyleBackColor = true;
            this.btntile.Click += new System.EventHandler(this.btntile_Click);
            // 
            // pnlgraphicholder
            // 
            this.pnlgraphicholder.Controls.Add(this.picgraphic);
            this.pnlgraphicholder.Location = new System.Drawing.Point(19, 38);
            this.pnlgraphicholder.Name = "pnlgraphicholder";
            this.pnlgraphicholder.Size = new System.Drawing.Size(350, 100);
            this.pnlgraphicholder.TabIndex = 3;
            // 
            // pgcontents
            // 
            this.pgcontents.BackColor = System.Drawing.Color.White;
            this.pgcontents.Controls.Add(this.btncancel);
            this.pgcontents.Controls.Add(this.btnreset);
            this.pgcontents.Controls.Add(this.btnapply);
            this.pgcontents.Controls.Add(this.Label2);
            this.pgcontents.Controls.Add(this.btnidlebrowse);
            this.pgcontents.Controls.Add(this.txtidlefile);
            this.pgcontents.Controls.Add(this.picidle);
            this.pgcontents.Controls.Add(this.btnzoom);
            this.pgcontents.Controls.Add(this.btnstretch);
            this.pgcontents.Controls.Add(this.btncentre);
            this.pgcontents.Controls.Add(this.btntile);
            this.pgcontents.Controls.Add(this.pnlgraphicholder);
            this.pgcontents.Controls.Add(this.lblobjecttoskin);
            this.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcontents.Location = new System.Drawing.Point(2, 30);
            this.pgcontents.Name = "pgcontents";
            this.pgcontents.Size = new System.Drawing.Size(386, 346);
            this.pgcontents.TabIndex = 25;
            // 
            // GraphicPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 378);
            this.Controls.Add(this.pgcontents);
            this.Name = "GraphicPicker";
            this.Text = "GraphicPicker";
            this.WindowIcon = global::ShiftOS.Properties.Resources.icongraphicpicker;
            this.WindowTitle = "Graphic Picker";
            this.Controls.SetChildIndex(this.pgcontents, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picidle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picgraphic)).EndInit();
            this.pnlgraphicholder.ResumeLayout(false);
            this.pgcontents.ResumeLayout(false);
            this.pgcontents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button btncancel;
        internal System.Windows.Forms.Button btnreset;
        internal System.Windows.Forms.Button btnapply;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnidlebrowse;
        internal System.Windows.Forms.TextBox txtidlefile;
        internal System.Windows.Forms.PictureBox picidle;
        internal System.Windows.Forms.Button btnzoom;
        internal System.Windows.Forms.Button btnstretch;
        internal System.Windows.Forms.Label lblobjecttoskin;
        internal System.Windows.Forms.PictureBox picgraphic;
        internal System.Windows.Forms.Button btncentre;
        internal System.Windows.Forms.Button btntile;
        internal System.Windows.Forms.Panel pnlgraphicholder;
        internal System.Windows.Forms.Panel pgcontents;
    }
}