using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftOS.Windowing;
using System.Windows.Forms;

namespace ShiftOS
{
    public partial class PanelButton : UserControl
    {
        private Window _window = null;
        private Desktop _desktop = null;

        public PanelButton(Desktop InDesktop, Window InWindow)
        {
            InitializeComponent();

            _desktop = InDesktop;
            _window = InWindow;

            _desktop.GetCurrentSystem().DesktopUpdated += OnDesktopUpdated;
        }

        private void OnDesktopUpdated(object sender, EventArgs e)
        {
            // Update our window data.
            TitleText.Text = _window.WindowTitle;
            IconBox.Image = _window.WindowIcon;

            IconBox.Visible = _window.CurrentSystem.HasShiftoriumUpgrade("titleicons");

            // Get the current skin.
            var skin = _window.CurrentSystem.GetSkinContext();

            // Set up our margin to take in account our skin's "panel button from top" and "panel button gap" values.
            this.Margin = new Padding(0, skin.GetSkinData().panelbuttonfromtop, skin.GetSkinData().panelbuttongap, 0);

            // Set the location of the panel button icon.
            this.IconBox.Left = skin.GetSkinData().panelbuttoniconside;
            this.IconBox.Top = skin.GetSkinData().panelbuttonicontop;

            // Set the size of the icon.
            this.IconBox.Width = this.IconBox.Height = skin.GetSkinData().panelbuttoniconsize; // Some spoopy C++ shit right there.

            // Update our width and height.
            this.Width = skin.GetSkinData().panelbuttonwidth;
            this.Height = skin.GetSkinData().panelbuttonheight;

            // Set our background color/image.
            if (skin.HasImage("panelbutton"))
            {
                this.BackColor = Color.Transparent;
                this.BackgroundImage = skin.GetImage("panelbutton");
                this.BackgroundImageLayout = skin.GetSkinData().panelbuttonlayout;
            }
            else
            {
                this.BackColor = skin.GetSkinData().panelbuttoncolour;
                this.BackgroundImage = null;
            }
            // Set the text color.
            this.TitleText.ForeColor = skin.GetSkinData().panelbuttontextcolour;

            // Set the text location.
            this.TitleText.Left = skin.GetSkinData().panelbuttontextside;
            this.TitleText.Top = skin.GetSkinData().panelbuttontexttop;

            // Get the font values for panel button text.
            string fontname = skin.GetSkinData().panelbuttontextfont;
            int fontsize = skin.GetSkinData().panelbuttontextsize;
            FontStyle fontstyle = skin.GetSkinData().panelbuttontextstyle;

            // Do we need to update our font?
            if(TitleText.Font.Name != fontname || TitleText.Font.Size != fontsize || this.TitleText.Font.Style != fontstyle)
            {
                // Update it.
                TitleText.Font = new Font(fontname, fontsize, fontstyle);
            }


        }

        private void PanelButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (_desktop.GetCurrentSystem().HasShiftoriumUpgrade("usefulpanelbuttons"))
            {
                if (_window.Enabled == false)
                {
                    _window.Enabled = true;
                    _window.Opacity = 1;
                }
                else
                {
                    _window.Opacity = 0;
                    _window.Enabled = false;
                }
            }
        }
    }
}
