namespace ShiftOS.Programs
{
    partial class Terminal
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
            this.TerminalControl = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // TerminalControl
            // 
            this.TerminalControl.BackColor = System.Drawing.Color.Black;
            this.TerminalControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TerminalControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TerminalControl.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.TerminalControl.ForeColor = System.Drawing.Color.White;
            this.TerminalControl.Location = new System.Drawing.Point(2, 30);
            this.TerminalControl.Name = "TerminalControl";
            this.TerminalControl.Size = new System.Drawing.Size(597, 314);
            this.TerminalControl.TabIndex = 5;
            this.TerminalControl.Text = "";
            this.TerminalControl.TextChanged += new System.EventHandler(this.TerminalControl_TextChanged);
            // 
            // Terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TerminalControl);
            this.Name = "Terminal";
            this.WindowTitle = "Terminal";
            this.Controls.SetChildIndex(this.TerminalControl, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox TerminalControl;
    }
}
