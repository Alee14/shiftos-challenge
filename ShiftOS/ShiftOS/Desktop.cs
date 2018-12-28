using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{
    public partial class Desktop : Form
    {
        private SystemContext CurrentSystem = null;

        public Desktop(SystemContext InSystem)
        {
            this.CurrentSystem = InSystem;
            InitializeComponent();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            // Update current time of day.
            this.CurrentTime.Text = CurrentSystem.GetTimeOfDay();

            // We get our background colors from the skin.
            this.BackColor = this.CurrentSystem.GetSkinContext().GetSkinData().DesktopBackgroundColor;
            this.DesktopPanel.BackColor = this.CurrentSystem.GetSkinContext().GetSkinData().DesktopPanelBackgroundColor;

            // Desktop panel must get its height from the skin.
            this.DesktopPanel.Height = this.CurrentSystem.GetSkinContext().GetSkinData().DesktopPanelHeight;

            // Set up the panel clock's position.
            this.CurrentTime.Top = this.CurrentSystem.GetSkinContext().GetSkinData().PanelClockFromTop;
            this.CurrentTime.Left = (DesktopPanel.Width - CurrentTime.Width) - this.CurrentSystem.GetSkinContext().GetSkinData().PanelClockFromSide;

            // Determine the desktop panel dock
            if(this.CurrentSystem.GetSkinContext().GetSkinData().IsDesktopPanelAtTop)
            {
                this.DesktopPanel.Dock = DockStyle.Top;
            }
            else
            {
                this.DesktopPanel.Dock = DockStyle.Bottom;
            }
        }
    }
}
