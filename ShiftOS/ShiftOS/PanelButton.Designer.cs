namespace ShiftOS
{
    partial class PanelButton
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
            this.IconBox = new System.Windows.Forms.PictureBox();
            this.TitleText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // IconBox
            // 
            this.IconBox.BackColor = System.Drawing.Color.White;
            this.IconBox.Location = new System.Drawing.Point(2, 2);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(16, 16);
            this.IconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IconBox.TabIndex = 0;
            this.IconBox.TabStop = false;
            this.IconBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelButton_MouseClick);
            // 
            // TitleText
            // 
            this.TitleText.AutoSize = true;
            this.TitleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.TitleText.Location = new System.Drawing.Point(24, 3);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(89, 15);
            this.TitleText.TabIndex = 1;
            this.TitleText.Text = "Window Title";
            this.TitleText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelButton_MouseClick);
            // 
            // PanelButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.IconBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PanelButton";
            this.Size = new System.Drawing.Size(204, 20);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelButton_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox IconBox;
        private System.Windows.Forms.Label TitleText;
    }
}
