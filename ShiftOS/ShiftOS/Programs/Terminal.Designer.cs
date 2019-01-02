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
            this.components = new System.ComponentModel.Container();
            this.TerminalControl = new System.Windows.Forms.TextBox();
            this.CommandInterpreterTimer = new System.Windows.Forms.Timer(this.components);
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
            this.TerminalControl.Multiline = true;
            this.TerminalControl.Name = "TerminalControl";
            this.TerminalControl.Size = new System.Drawing.Size(581, 275);
            this.TerminalControl.TabIndex = 5;
            this.TerminalControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TerminalControl_KeyDown);
            this.TerminalControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TerminalControl_KeyPress);
            // 
            // CommandInterpreterTimer
            // 
            this.CommandInterpreterTimer.Enabled = true;
            this.CommandInterpreterTimer.Interval = 1;
            this.CommandInterpreterTimer.Tick += new System.EventHandler(this.CommandInterpreterTimer_Tick);
            // 
            // Terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 307);
            this.Controls.Add(this.TerminalControl);
            this.Name = "Terminal";
            this.WindowIcon = global::ShiftOS.Properties.Resources.iconTerminal;
            this.WindowTitle = "Terminal";
            this.Controls.SetChildIndex(this.TerminalControl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TerminalControl;
        private System.Windows.Forms.Timer CommandInterpreterTimer;
    }
}
