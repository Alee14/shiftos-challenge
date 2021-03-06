﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftOS.Windowing;
using System.Windows.Forms;

namespace ShiftOS
{
    public partial class Desktop : Form
    {
        private SystemContext CurrentSystem = null;
        private bool _inUnity = false;
        private int _lastWorkspaceChildCount = -1;
        
        public SystemContext GetCurrentSystem()
        {
            return CurrentSystem;
        }

        public Desktop(SystemContext InSystem)
        {
            this.CurrentSystem = InSystem;
            InitializeComponent();
            ResetAppLauncher();
            this.DoubleBuffered = true;
        }

        private void ResetPanelButtons()
        {
            // Clear the panel button list.
            this.PanelButtonList.Controls.Clear();

            foreach (var window in CurrentSystem.GetWindows())
            {
                // Create a panel button for the window.
                var panelButton = new PanelButton(this, window);

                // Add it to our UI.
                this.PanelButtonList.Controls.Add(panelButton);
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            // Update current time of day.
            this.CurrentTime.Text = CurrentSystem.GetTimeOfDay();

            // Grab the skin context.
            var skin = this.CurrentSystem.GetSkinContext();

            // If we're in unity mode...
            if(_inUnity)
            {
                // then we become transparent.
                this.BackgroundImage = null;
                this.BackColor = this.TransparencyKey;

                
            }
            else
            {
                // Otherwise, we get a wallpaper.
                if(skin.HasImage("desktopbackground"))
                {
                    if(this.BackgroundImage != skin.GetImage("desktopbackground"))
                        this.BackgroundImage = skin.GetImage("desktopbackground");
                    this.BackgroundImageLayout = skin.GetSkinData().desktopbackgroundlayout;
                }
                else
                {
                    this.BackgroundImage = null;
                    this.BackColor = skin.GetSkinData().desktopbackgroundcolour;
                }
            }

            // Do we have the desktop panel?
            if(CurrentSystem.HasShiftoriumUpgrade("desktoppanel"))
            {
                // Set the desktop panel background
                if(skin.HasImage("desktoppanel"))
                {
                    if(DesktopPanel.BackgroundImage != skin.GetImage("desktoppanel"))
                        DesktopPanel.BackgroundImage = skin.GetImage("desktoppanel");
                    DesktopPanel.BackgroundImageLayout = skin.GetSkinData().desktoppanellayout;
                    DesktopPanel.BackColor = Color.Transparent;
                }
                else
                {
                    DesktopPanel.BackgroundImage = null;
                    DesktopPanel.BackColor = skin.GetSkinData().desktoppanelcolour;
                }

                // Set the height of the desktop panel.
                DesktopPanel.Height = skin.GetSkinData().desktoppanelheight;

                // Position the desktop panel.
                if(skin.GetSkinData().desktoppanelposition == "Top")
                {
                    DesktopPanel.Dock = DockStyle.Top;
                }
                else
                {
                    DesktopPanel.Dock = DockStyle.Bottom;
                }

                // Show it.
                DesktopPanel.Show();
            }
            else
            {
                // Hide it.
                DesktopPanel.Hide();
            }

            // Do we have the panel clock?
            if(CurrentSystem.HasShiftoriumUpgrade("desktoppanelclock"))
            {
                CurrentTime.ForeColor = skin.GetSkinData().clocktextcolour;
                if(skin.HasImage("panelclock"))
                {
                    TimePanel.BackColor = Color.Transparent;
                    if(TimePanel.BackgroundImage != skin.GetImage("panelclock"))
                        TimePanel.BackgroundImage = skin.GetImage("panelclock");
                    TimePanel.BackgroundImageLayout = skin.GetSkinData().panelclocklayout;
                }
                else
                {
                    TimePanel.BackColor = skin.GetSkinData().clockbackgroundcolor;
                    TimePanel.BackgroundImage = null;
                }

                if(CurrentTime.Font.Name != skin.GetSkinData().panelclocktextfont || CurrentTime.Font.Size != skin.GetSkinData().panelclocktextsize || CurrentTime.Font.Style != skin.GetSkinData().panelclocktextstyle)
                {
                    CurrentTime.Font = new Font(skin.GetSkinData().panelclocktextfont, skin.GetSkinData().panelclocktextsize, skin.GetSkinData().panelclocktextstyle);
                }

                TimePanel.Width = CurrentTime.Width + 3;
                CurrentTime.Left = 0;
                CurrentTime.Top = skin.GetSkinData().panelclocktexttop;

                TimePanel.Show();
            }
            else
            {
                TimePanel.Hide();
            }

            // Set up the panel buttons.
            if(CurrentSystem.HasShiftoriumUpgrade("panelbuttons"))
            {
                PanelButtonList.Padding = new Padding(skin.GetSkinData().panelbuttoninitialgap, 0, 0, 0);

                PanelButtonList.Show();
            }
            else
            {
                PanelButtonList.Hide();
            }

            // Do we have an app launcher?
            if (CurrentSystem.HasShiftoriumUpgrade("applaunchermenu"))
            {
                // Set up the font.
                string appFontName = skin.GetSkinData().applicationbuttontextfont;
                int appFontSize = skin.GetSkinData().applicationbuttontextsize;
                FontStyle appFontStyle = skin.GetSkinData().applicationbuttontextstyle;


                if (AppLauncherMenu.Font.Name != appFontName || AppLauncherMenu.Font.Size != appFontSize || AppLauncherMenu.Font.Style != appFontStyle)
                {
                    AppLauncherMenu.Font = new Font(appFontName, appFontSize, appFontStyle);
                }

                string appItemFontName = skin.GetSkinData().launcheritemfont;
                int appItemFontSize = skin.GetSkinData().launcheritemsize;
                FontStyle appItemFontStyle = skin.GetSkinData().launcheritemstyle;

                foreach(var child in AppLauncherMenu.DropDownItems)
                {
                    if(child is ToolStripMenuItem)
                    {
                        ToolStripMenuItem menuItem = child as ToolStripMenuItem;
                        if(menuItem.Font.Name != appItemFontName || menuItem.Font.Size != appItemFontSize || menuItem.Font.Style != appItemFontStyle)
                        {
                            menuItem.Font = new Font(appItemFontName, appItemFontSize, appItemFontStyle);
                        }
                        menuItem.ForeColor = skin.GetSkinData().launcheritemcolour;
                    }
                }

                

                if (skin.HasImage("applauncher"))
                {
                    AppLauncherMenu.Text = "";
                    AppLauncherStrip.BackColor = Color.Transparent;
                    if(AppLauncherStrip.BackgroundImage != skin.GetImage("applauncher"))
                        AppLauncherStrip.BackgroundImage = skin.GetImage("applauncher");
                    AppLauncherStrip.BackgroundImageLayout = skin.GetSkinData().applauncherlayout;
                }
                else
                {
                    AppLauncherStrip.BackColor = skin.GetSkinData().applauncherbuttoncolour;
                    AppLauncherStrip.Text = skin.GetSkinData().applicationlaunchername;
                    AppLauncherStrip.BackgroundImage = null;
                }

                AppLauncherMenu.Height = skin.GetSkinData().applicationbuttonheight;
                AppLauncherHolder.Width = skin.GetSkinData().applaunchermenuholderwidth;
                AppLauncherMenu.Width = AppLauncherHolder.Width;
                AppLauncherStrip.Width = AppLauncherHolder.Width;
                AppLauncherStrip.Height = AppLauncherMenu.Height;
                
                AppLauncherHolder.Show();
            }
            else
            {
                AppLauncherHolder.Hide();
            }

            // Has the amount of children (windows) in the workspace changed?
            if(_lastWorkspaceChildCount != CurrentSystem.GetWindows().Count)
            {
                // Update it.
                _lastWorkspaceChildCount = CurrentSystem.GetWindows().Count;

                // Reset panel buttons.
                this.ResetPanelButtons();
            }

            // Tells any open programs that we've updated.
            this.CurrentSystem.UpdateDesktop();
        }

        public void ResetAppLauncher()
        {
            // Clear out the existing app launcher items, if any.
            this.AppLauncherMenu.DropDownItems.Clear();

            // Go through every installed program.
            foreach(var program in this.CurrentSystem.GetInstalledPrograms())
            {
                if (!CurrentSystem.IsAppLauncherItemAvailable(program))
                    continue;

                // Get the friendly (UI) name
                string friendlyName = this.CurrentSystem.GetProgramName(program);

                // Create a new toolstripmenuitem that runs the program when clicked.
                var item = new ToolStripMenuItem(friendlyName);

                // Bind click event to open program.
                item.Click += (o, a) =>
                {
                    this.CurrentSystem.LaunchProgram(program);
                };

                // Add it to the app launcher.
                AppLauncherMenu.DropDownItems.Add(item);
            }

            // TODO: Check if we actually have unity mode toggle and shutdown.

            if (CurrentSystem.HasShiftoriumUpgrade("alunitymode") || CurrentSystem.HasShiftoriumUpgrade("applaunchershutdown"))
            {
                var separator = new ToolStripSeparator();
                AppLauncherMenu.DropDownItems.Add(separator);
            }

            if (CurrentSystem.HasShiftoriumUpgrade("alunitymode"))
            {
                var unityToggle = new ToolStripMenuItem("Toggle Unity Mode");

                unityToggle.Click += (o, a) =>
                {
                    _inUnity = !_inUnity;
                };

                AppLauncherMenu.DropDownItems.Add(unityToggle);
            }

            if (CurrentSystem.HasShiftoriumUpgrade("applaunchershutdown"))
            {
                var shutdown = new ToolStripMenuItem("Shut Down");

                shutdown.Click += (o, a) =>
                {
                    // Closing this window causes the system context to shut down.
                    this.Close();
                };
                AppLauncherMenu.DropDownItems.Add(shutdown);
            }
        }

        private void Desktop_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.T && e.Control)
            {
                CurrentSystem.LaunchProgram("terminal");
            }
            else if(e.KeyCode == Keys.S && e.Control)
            {
                CurrentSystem.AskForColor("Desktop Panel color", CurrentSystem.GetSkinContext().GetSkinData().desktoppanelcolour, (color) =>
                {
                    CurrentSystem.GetSkinContext().GetSkinData().desktoppanelcolour = color;
                });
            }
                
        }
    }
}
