﻿namespace ShiftOS.Programs
{
    partial class FileSkimmer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSkimmer));
            this.lbllocation = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btndeletefile = new System.Windows.Forms.Button();
            this.btnnewfolder = new System.Windows.Forms.Button();
            this.pnlbreak = new System.Windows.Forms.Panel();
            this.pnloptions = new System.Windows.Forms.Panel();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lvfiles = new System.Windows.Forms.ListView();
            this.pgcontents = new System.Windows.Forms.Panel();
            this.pnlopenoptions = new System.Windows.Forms.Panel();
            this.txtfilename = new System.Windows.Forms.TextBox();
            this.lblfilenameprompt = new System.Windows.Forms.Label();
            this.cmbformatchooser = new System.Windows.Forms.ComboBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnopen = new System.Windows.Forms.Button();
            this.lbextention = new System.Windows.Forms.Label();
            this.lblcurrentlydisplayingprompt = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.pnloptions.SuspendLayout();
            this.pgcontents.SuspendLayout();
            this.pnlopenoptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbllocation
            // 
            this.lbllocation.BackColor = System.Drawing.Color.White;
            this.lbllocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbllocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllocation.ForeColor = System.Drawing.Color.Black;
            this.lbllocation.Location = new System.Drawing.Point(0, 0);
            this.lbllocation.Name = "lbllocation";
            this.lbllocation.Size = new System.Drawing.Size(796, 31);
            this.lbllocation.TabIndex = 0;
            this.lbllocation.Text = "C:/ShiftOS/";
            this.lbllocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(796, 2);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.lbllocation);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(796, 31);
            this.panel4.TabIndex = 4;
            // 
            // btndeletefile
            // 
            this.btndeletefile.BackColor = System.Drawing.Color.White;
            this.btndeletefile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeletefile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndeletefile.Image = global::ShiftOS.Properties.Resources.deletefile;
            this.btndeletefile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndeletefile.Location = new System.Drawing.Point(129, 4);
            this.btndeletefile.Name = "btndeletefile";
            this.btndeletefile.Size = new System.Drawing.Size(130, 31);
            this.btndeletefile.TabIndex = 4;
            this.btndeletefile.Text = "Delete Folder";
            this.btndeletefile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndeletefile.UseVisualStyleBackColor = false;
            this.btndeletefile.Click += new System.EventHandler(this.btndeletefile_Click);
            // 
            // btnnewfolder
            // 
            this.btnnewfolder.BackColor = System.Drawing.Color.White;
            this.btnnewfolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnewfolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnewfolder.Image = global::ShiftOS.Properties.Resources.newfolder;
            this.btnnewfolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnewfolder.Location = new System.Drawing.Point(6, 4);
            this.btnnewfolder.Name = "btnnewfolder";
            this.btnnewfolder.Size = new System.Drawing.Size(117, 31);
            this.btnnewfolder.TabIndex = 3;
            this.btnnewfolder.Text = "New Folder";
            this.btnnewfolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnnewfolder.UseVisualStyleBackColor = false;
            this.btnnewfolder.Click += new System.EventHandler(this.btnnewfolder_Click);
            // 
            // pnlbreak
            // 
            this.pnlbreak.BackColor = System.Drawing.Color.White;
            this.pnlbreak.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlbreak.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlbreak.ForeColor = System.Drawing.Color.Black;
            this.pnlbreak.Location = new System.Drawing.Point(0, 323);
            this.pnlbreak.Name = "pnlbreak";
            this.pnlbreak.Size = new System.Drawing.Size(796, 15);
            this.pnlbreak.TabIndex = 7;
            // 
            // pnloptions
            // 
            this.pnloptions.Controls.Add(this.btndeletefile);
            this.pnloptions.Controls.Add(this.btnnewfolder);
            this.pnloptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnloptions.Location = new System.Drawing.Point(0, 338);
            this.pnloptions.Name = "pnloptions";
            this.pnloptions.Size = new System.Drawing.Size(796, 38);
            this.pnloptions.TabIndex = 6;
            this.pnloptions.Visible = false;
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "folder");
            this.ImageList1.Images.SetKeyName(1, "unknown.png");
            this.ImageList1.Images.SetKeyName(2, "textfile.png");
            this.ImageList1.Images.SetKeyName(3, "imagefile.png");
            this.ImageList1.Images.SetKeyName(4, "videofile.png");
            this.ImageList1.Images.SetKeyName(5, "folderup");
            this.ImageList1.Images.SetKeyName(6, "philips dll.png");
            this.ImageList1.Images.SetKeyName(7, "philips exe.png");
            this.ImageList1.Images.SetKeyName(8, "config.png");
            this.ImageList1.Images.SetKeyName(9, "driver.png");
            this.ImageList1.Images.SetKeyName(10, "skinfile.png");
            this.ImageList1.Images.SetKeyName(11, "namelistfile.png");
            this.ImageList1.Images.SetKeyName(12, "iconpackfile.png");
            this.ImageList1.Images.SetKeyName(13, "iconins.png");
            this.ImageList1.Images.SetKeyName(14, "icontrm.png");
            this.ImageList1.Images.SetKeyName(15, "iconsaa 2.png");
            this.ImageList1.Images.SetKeyName(16, "iconflood.png");
            this.ImageList1.Images.SetKeyName(17, "iconurl.png");
            this.ImageList1.Images.SetKeyName(18, "iconurls.png");
            this.ImageList1.Images.SetKeyName(19, "iconsaag.png");
            // 
            // lvfiles
            // 
            this.lvfiles.BackColor = System.Drawing.Color.White;
            this.lvfiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvfiles.LargeImageList = this.ImageList1;
            this.lvfiles.Location = new System.Drawing.Point(0, 33);
            this.lvfiles.Name = "lvfiles";
            this.lvfiles.Size = new System.Drawing.Size(796, 290);
            this.lvfiles.TabIndex = 3;
            this.lvfiles.UseCompatibleStateImageBehavior = false;
            this.lvfiles.DoubleClick += new System.EventHandler(this.lvfiles_DoubleClick);
            // 
            // pgcontents
            // 
            this.pgcontents.Controls.Add(this.lvfiles);
            this.pgcontents.Controls.Add(this.pnlbreak);
            this.pgcontents.Controls.Add(this.pnloptions);
            this.pgcontents.Controls.Add(this.pnlopenoptions);
            this.pgcontents.Controls.Add(this.panel3);
            this.pgcontents.Controls.Add(this.panel4);
            this.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcontents.Location = new System.Drawing.Point(2, 30);
            this.pgcontents.Name = "pgcontents";
            this.pgcontents.Size = new System.Drawing.Size(796, 418);
            this.pgcontents.TabIndex = 25;
            // 
            // pnlopenoptions
            // 
            this.pnlopenoptions.Controls.Add(this.txtfilename);
            this.pnlopenoptions.Controls.Add(this.lblfilenameprompt);
            this.pnlopenoptions.Controls.Add(this.cmbformatchooser);
            this.pnlopenoptions.Controls.Add(this.btncancel);
            this.pnlopenoptions.Controls.Add(this.btnopen);
            this.pnlopenoptions.Controls.Add(this.lbextention);
            this.pnlopenoptions.Controls.Add(this.lblcurrentlydisplayingprompt);
            this.pnlopenoptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlopenoptions.Location = new System.Drawing.Point(0, 376);
            this.pnlopenoptions.Name = "pnlopenoptions";
            this.pnlopenoptions.Size = new System.Drawing.Size(796, 42);
            this.pnlopenoptions.TabIndex = 11;
            // 
            // txtfilename
            // 
            this.txtfilename.BackColor = System.Drawing.Color.White;
            this.txtfilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfilename.Location = new System.Drawing.Point(87, 10);
            this.txtfilename.Name = "txtfilename";
            this.txtfilename.Size = new System.Drawing.Size(480, 22);
            this.txtfilename.TabIndex = 0;
            // 
            // lblfilenameprompt
            // 
            this.lblfilenameprompt.AutoSize = true;
            this.lblfilenameprompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfilenameprompt.Location = new System.Drawing.Point(6, 13);
            this.lblfilenameprompt.Name = "lblfilenameprompt";
            this.lblfilenameprompt.Size = new System.Drawing.Size(73, 16);
            this.lblfilenameprompt.TabIndex = 1;
            this.lblfilenameprompt.Text = "File Name:";
            // 
            // cmbformatchooser
            // 
            this.cmbformatchooser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbformatchooser.FormattingEnabled = true;
            this.cmbformatchooser.Location = new System.Drawing.Point(579, 10);
            this.cmbformatchooser.Name = "cmbformatchooser";
            this.cmbformatchooser.Size = new System.Drawing.Size(45, 21);
            this.cmbformatchooser.TabIndex = 4;
            this.cmbformatchooser.SelectedIndexChanged += new System.EventHandler(this.cmbformatchooser_SelectedIndexChanged);
            // 
            // btncancel
            // 
            this.btncancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(630, 5);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 29);
            this.btncancel.TabIndex = 4;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnopen
            // 
            this.btnopen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnopen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnopen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnopen.Location = new System.Drawing.Point(711, 5);
            this.btnopen.Name = "btnopen";
            this.btnopen.Size = new System.Drawing.Size(75, 29);
            this.btnopen.TabIndex = 3;
            this.btnopen.Text = "Open";
            this.btnopen.UseVisualStyleBackColor = true;
            this.btnopen.Click += new System.EventHandler(this.btnopen_Click);
            // 
            // lbextention
            // 
            this.lbextention.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbextention.AutoSize = true;
            this.lbextention.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbextention.Location = new System.Drawing.Point(573, 3);
            this.lbextention.Name = "lbextention";
            this.lbextention.Size = new System.Drawing.Size(51, 31);
            this.lbextention.TabIndex = 2;
            this.lbextention.Text = ".txt";
            // 
            // lblcurrentlydisplayingprompt
            // 
            this.lblcurrentlydisplayingprompt.AutoSize = true;
            this.lblcurrentlydisplayingprompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcurrentlydisplayingprompt.Location = new System.Drawing.Point(8, 13);
            this.lblcurrentlydisplayingprompt.Name = "lblcurrentlydisplayingprompt";
            this.lblcurrentlydisplayingprompt.Size = new System.Drawing.Size(360, 16);
            this.lblcurrentlydisplayingprompt.TabIndex = 1;
            this.lblcurrentlydisplayingprompt.Text = "Currently displaying files to open with the following extention:";
            // 
            // FileSkimmer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pgcontents);
            this.Name = "FileSkimmer";
            this.Text = "FileSkimmer";
            this.WindowIcon = global::ShiftOS.Properties.Resources.iconFileSkimmer;
            this.WindowTitle = "File Skimmer";
            this.Controls.SetChildIndex(this.pgcontents, 0);
            this.panel4.ResumeLayout(false);
            this.pnloptions.ResumeLayout(false);
            this.pgcontents.ResumeLayout(false);
            this.pnlopenoptions.ResumeLayout(false);
            this.pnlopenoptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label lbllocation;
        internal System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.Button btndeletefile;
        internal System.Windows.Forms.Button btnnewfolder;
        internal System.Windows.Forms.Panel pnlbreak;
        internal System.Windows.Forms.Panel pnloptions;
        internal System.Windows.Forms.ImageList ImageList1;
        internal System.Windows.Forms.ListView lvfiles;
        internal System.Windows.Forms.Panel pgcontents;
        internal System.Windows.Forms.Panel pnlopenoptions;
        internal System.Windows.Forms.Button btncancel;
        internal System.Windows.Forms.Button btnopen;
        internal System.Windows.Forms.Label lbextention;
        internal System.Windows.Forms.Label lblcurrentlydisplayingprompt;
        internal System.Windows.Forms.TextBox txtfilename;
        internal System.Windows.Forms.Label lblfilenameprompt;
        internal System.Windows.Forms.ComboBox cmbformatchooser;
    }
}