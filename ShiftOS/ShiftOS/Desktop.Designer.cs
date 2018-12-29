namespace ShiftOS
{
    partial class Desktop
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
            this.DesktopPanel = new System.Windows.Forms.Panel();
            this.CurrentTime = new System.Windows.Forms.Label();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.Workspace = new System.Windows.Forms.Panel();
            this.AppLauncherStrip = new System.Windows.Forms.MenuStrip();
            this.AppLauncherMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelButtonList = new System.Windows.Forms.FlowLayoutPanel();
            this.TimePanel = new System.Windows.Forms.Panel();
            this.AppLauncherHolder = new System.Windows.Forms.Panel();
            this.DesktopPanel.SuspendLayout();
            this.AppLauncherStrip.SuspendLayout();
            this.TimePanel.SuspendLayout();
            this.AppLauncherHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // DesktopPanel
            // 
            this.DesktopPanel.BackColor = System.Drawing.Color.Gray;
            this.DesktopPanel.Controls.Add(this.PanelButtonList);
            this.DesktopPanel.Controls.Add(this.AppLauncherHolder);
            this.DesktopPanel.Controls.Add(this.TimePanel);
            this.DesktopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DesktopPanel.ForeColor = System.Drawing.Color.Black;
            this.DesktopPanel.Location = new System.Drawing.Point(0, 0);
            this.DesktopPanel.Name = "DesktopPanel";
            this.DesktopPanel.Size = new System.Drawing.Size(800, 24);
            this.DesktopPanel.TabIndex = 0;
            // 
            // CurrentTime
            // 
            this.CurrentTime.AutoSize = true;
            this.CurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.CurrentTime.Location = new System.Drawing.Point(0, 3);
            this.CurrentTime.Name = "CurrentTime";
            this.CurrentTime.Size = new System.Drawing.Size(101, 18);
            this.CurrentTime.TabIndex = 0;
            this.CurrentTime.Text = "12:00:00 AM";
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Interval = 10;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // Workspace
            // 
            this.Workspace.BackColor = System.Drawing.Color.Transparent;
            this.Workspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Workspace.Location = new System.Drawing.Point(0, 24);
            this.Workspace.Name = "Workspace";
            this.Workspace.Size = new System.Drawing.Size(800, 426);
            this.Workspace.TabIndex = 1;
            // 
            // AppLauncherStrip
            // 
            this.AppLauncherStrip.GripMargin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.AppLauncherStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AppLauncherMenu});
            this.AppLauncherStrip.Location = new System.Drawing.Point(0, 0);
            this.AppLauncherStrip.Name = "AppLauncherStrip";
            this.AppLauncherStrip.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.AppLauncherStrip.Size = new System.Drawing.Size(88, 24);
            this.AppLauncherStrip.TabIndex = 1;
            this.AppLauncherStrip.Text = "menuStrip1";
            // 
            // AppLauncherMenu
            // 
            this.AppLauncherMenu.AutoSize = false;
            this.AppLauncherMenu.Name = "AppLauncherMenu";
            this.AppLauncherMenu.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.AppLauncherMenu.Size = new System.Drawing.Size(77, 24);
            this.AppLauncherMenu.Text = "Applications";
            // 
            // PanelButtonList
            // 
            this.PanelButtonList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelButtonList.Location = new System.Drawing.Point(88, 0);
            this.PanelButtonList.Margin = new System.Windows.Forms.Padding(0);
            this.PanelButtonList.Name = "PanelButtonList";
            this.PanelButtonList.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.PanelButtonList.Size = new System.Drawing.Size(605, 24);
            this.PanelButtonList.TabIndex = 2;
            // 
            // TimePanel
            // 
            this.TimePanel.Controls.Add(this.CurrentTime);
            this.TimePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.TimePanel.Location = new System.Drawing.Point(693, 0);
            this.TimePanel.Name = "TimePanel";
            this.TimePanel.Size = new System.Drawing.Size(107, 24);
            this.TimePanel.TabIndex = 3;
            // 
            // AppLauncherHolder
            // 
            this.AppLauncherHolder.BackColor = System.Drawing.Color.Gray;
            this.AppLauncherHolder.Controls.Add(this.AppLauncherStrip);
            this.AppLauncherHolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.AppLauncherHolder.Location = new System.Drawing.Point(0, 0);
            this.AppLauncherHolder.Name = "AppLauncherHolder";
            this.AppLauncherHolder.Size = new System.Drawing.Size(88, 24);
            this.AppLauncherHolder.TabIndex = 0;
            // 
            // Desktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Workspace);
            this.Controls.Add(this.DesktopPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.AppLauncherStrip;
            this.Name = "Desktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Desktop_KeyDown);
            this.DesktopPanel.ResumeLayout(false);
            this.AppLauncherStrip.ResumeLayout(false);
            this.AppLauncherStrip.PerformLayout();
            this.TimePanel.ResumeLayout(false);
            this.TimePanel.PerformLayout();
            this.AppLauncherHolder.ResumeLayout(false);
            this.AppLauncherHolder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DesktopPanel;
        private System.Windows.Forms.Label CurrentTime;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Panel Workspace;
        private System.Windows.Forms.MenuStrip AppLauncherStrip;
        private System.Windows.Forms.ToolStripMenuItem AppLauncherMenu;
        private System.Windows.Forms.FlowLayoutPanel PanelButtonList;
        private System.Windows.Forms.Panel TimePanel;
        private System.Windows.Forms.Panel AppLauncherHolder;
    }
}

