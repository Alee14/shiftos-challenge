namespace ShiftOS.Windowing
{
    partial class Window
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleBarHolder = new System.Windows.Forms.Panel();
            this.TitleBarLeft = new System.Windows.Forms.Panel();
            this.TitleBarRight = new System.Windows.Forms.Panel();
            this.BottomBarHolder = new System.Windows.Forms.Panel();
            this.BottomBar = new System.Windows.Forms.Panel();
            this.BottomRight = new System.Windows.Forms.Panel();
            this.BottomLeft = new System.Windows.Forms.Panel();
            this.RightBar = new System.Windows.Forms.Panel();
            this.LeftBar = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Panel();
            this.RollButton = new System.Windows.Forms.Panel();
            this.MinimizeButton = new System.Windows.Forms.Panel();
            this.TitleText = new System.Windows.Forms.Label();
            this.IconBox = new System.Windows.Forms.PictureBox();
            this.TitleBarHolder.SuspendLayout();
            this.BottomBarHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleBarHolder
            // 
            this.TitleBarHolder.BackColor = System.Drawing.Color.Gray;
            this.TitleBarHolder.Controls.Add(this.IconBox);
            this.TitleBarHolder.Controls.Add(this.TitleText);
            this.TitleBarHolder.Controls.Add(this.MinimizeButton);
            this.TitleBarHolder.Controls.Add(this.RollButton);
            this.TitleBarHolder.Controls.Add(this.CloseButton);
            this.TitleBarHolder.Controls.Add(this.TitleBarRight);
            this.TitleBarHolder.Controls.Add(this.TitleBarLeft);
            this.TitleBarHolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBarHolder.Location = new System.Drawing.Point(0, 0);
            this.TitleBarHolder.Name = "TitleBarHolder";
            this.TitleBarHolder.Size = new System.Drawing.Size(601, 30);
            this.TitleBarHolder.TabIndex = 0;
            // 
            // TitleBarLeft
            // 
            this.TitleBarLeft.BackColor = System.Drawing.Color.Gray;
            this.TitleBarLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.TitleBarLeft.Location = new System.Drawing.Point(0, 0);
            this.TitleBarLeft.Name = "TitleBarLeft";
            this.TitleBarLeft.Size = new System.Drawing.Size(2, 30);
            this.TitleBarLeft.TabIndex = 1;
            // 
            // TitleBarRight
            // 
            this.TitleBarRight.BackColor = System.Drawing.Color.Gray;
            this.TitleBarRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.TitleBarRight.Location = new System.Drawing.Point(599, 0);
            this.TitleBarRight.Name = "TitleBarRight";
            this.TitleBarRight.Size = new System.Drawing.Size(2, 30);
            this.TitleBarRight.TabIndex = 2;
            // 
            // BottomBarHolder
            // 
            this.BottomBarHolder.BackColor = System.Drawing.Color.Transparent;
            this.BottomBarHolder.Controls.Add(this.BottomBar);
            this.BottomBarHolder.Controls.Add(this.BottomRight);
            this.BottomBarHolder.Controls.Add(this.BottomLeft);
            this.BottomBarHolder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomBarHolder.Location = new System.Drawing.Point(0, 344);
            this.BottomBarHolder.Name = "BottomBarHolder";
            this.BottomBarHolder.Size = new System.Drawing.Size(601, 2);
            this.BottomBarHolder.TabIndex = 1;
            // 
            // BottomBar
            // 
            this.BottomBar.BackColor = System.Drawing.Color.Gray;
            this.BottomBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomBar.ForeColor = System.Drawing.Color.White;
            this.BottomBar.Location = new System.Drawing.Point(2, 0);
            this.BottomBar.Name = "BottomBar";
            this.BottomBar.Size = new System.Drawing.Size(597, 2);
            this.BottomBar.TabIndex = 0;
            // 
            // BottomRight
            // 
            this.BottomRight.BackColor = System.Drawing.Color.Gray;
            this.BottomRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.BottomRight.Location = new System.Drawing.Point(599, 0);
            this.BottomRight.Name = "BottomRight";
            this.BottomRight.Size = new System.Drawing.Size(2, 2);
            this.BottomRight.TabIndex = 2;
            // 
            // BottomLeft
            // 
            this.BottomLeft.BackColor = System.Drawing.Color.Gray;
            this.BottomLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.BottomLeft.Location = new System.Drawing.Point(0, 0);
            this.BottomLeft.Name = "BottomLeft";
            this.BottomLeft.Size = new System.Drawing.Size(2, 2);
            this.BottomLeft.TabIndex = 1;
            // 
            // RightBar
            // 
            this.RightBar.BackColor = System.Drawing.Color.Gray;
            this.RightBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightBar.Location = new System.Drawing.Point(599, 30);
            this.RightBar.Name = "RightBar";
            this.RightBar.Size = new System.Drawing.Size(2, 314);
            this.RightBar.TabIndex = 3;
            // 
            // LeftBar
            // 
            this.LeftBar.BackColor = System.Drawing.Color.Gray;
            this.LeftBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftBar.Location = new System.Drawing.Point(0, 30);
            this.LeftBar.Name = "LeftBar";
            this.LeftBar.Size = new System.Drawing.Size(2, 314);
            this.LeftBar.TabIndex = 4;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.BackColor = System.Drawing.Color.Black;
            this.CloseButton.Location = new System.Drawing.Point(574, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(24, 24);
            this.CloseButton.TabIndex = 5;
            // 
            // RollButton
            // 
            this.RollButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RollButton.BackColor = System.Drawing.Color.Black;
            this.RollButton.Location = new System.Drawing.Point(547, 3);
            this.RollButton.Name = "RollButton";
            this.RollButton.Size = new System.Drawing.Size(24, 24);
            this.RollButton.TabIndex = 6;
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeButton.BackColor = System.Drawing.Color.Black;
            this.MinimizeButton.Location = new System.Drawing.Point(520, 3);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(24, 24);
            this.MinimizeButton.TabIndex = 7;
            // 
            // TitleText
            // 
            this.TitleText.AutoSize = true;
            this.TitleText.BackColor = System.Drawing.Color.Transparent;
            this.TitleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.TitleText.ForeColor = System.Drawing.Color.White;
            this.TitleText.Location = new System.Drawing.Point(26, 6);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(100, 17);
            this.TitleText.TabIndex = 5;
            this.TitleText.Text = "Window Title";
            // 
            // IconBox
            // 
            this.IconBox.BackColor = System.Drawing.Color.Black;
            this.IconBox.Location = new System.Drawing.Point(7, 7);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(16, 16);
            this.IconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IconBox.TabIndex = 8;
            this.IconBox.TabStop = false;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.LeftBar);
            this.Controls.Add(this.RightBar);
            this.Controls.Add(this.BottomBarHolder);
            this.Controls.Add(this.TitleBarHolder);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Window";
            this.Size = new System.Drawing.Size(601, 346);
            this.TitleBarHolder.ResumeLayout(false);
            this.TitleBarHolder.PerformLayout();
            this.BottomBarHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitleBarHolder;
        private System.Windows.Forms.Panel TitleBarRight;
        private System.Windows.Forms.Panel TitleBarLeft;
        private System.Windows.Forms.Panel BottomBarHolder;
        private System.Windows.Forms.Panel BottomBar;
        private System.Windows.Forms.Panel BottomRight;
        private System.Windows.Forms.Panel BottomLeft;
        private System.Windows.Forms.Panel RightBar;
        private System.Windows.Forms.Panel LeftBar;
        private System.Windows.Forms.Panel CloseButton;
        private System.Windows.Forms.Panel MinimizeButton;
        private System.Windows.Forms.Panel RollButton;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.PictureBox IconBox;
    }
}
