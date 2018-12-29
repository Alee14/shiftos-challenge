using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace ShiftOS.Windowing
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class Window : UserControl
    {
        private SystemContext _currentSystem = null;

        public Window()
        {
            InitializeComponent();
        }

        public void SetSystemContext(SystemContext InSystemContext)
        {
            if (_currentSystem != null)
                throw new InvalidOperationException("This window has already been initialized.");

            if (InSystemContext == null)
                throw new ArgumentNullException("InSystemContext");

            _currentSystem = InSystemContext;
            _currentSystem.DesktopUpdated += OnDesktopUpdated;
        }

        private void OnDesktopUpdated(object sender, EventArgs e)
        {
            // Get the skin data.
            var skin = this.CurrentSystem.GetSkinContext();
            var skindata = skin.GetSkinData();

            // Set the titlebar height.
            this.TitleBarHolder.Height = skindata.titlebarheight;

            // Set the title text position.
            this.TitleText.Top = skindata.titletextfromtop;
            if(skindata.titletextpos == "Left")
            {
                this.TitleText.Left = skindata.titletextfromside;
            }
            else
            {
                this.TitleText.Left = (this.TitleBarHolder.Width - this.TitleText.Width) / 2;
            }

            // Set the title icon's position.
            this.IconBox.Left = skindata.titleiconfromside;
            this.IconBox.Top = skindata.titleiconfromtop;


            // Set the title button sizes
            this.CloseButton.Size = skindata.closebtnsize;
            this.RollButton.Size = skindata.rollbtnsize;
            this.MinimizeButton.Size = skindata.minbtnsize;

            // Set the close button location.
            this.CloseButton.Top = skindata.closebtnfromtop;
            this.CloseButton.Left = (this.TitleBarHolder.Width - this.CloseButton.Width) - skindata.closebtnfromside;

            // Set the rollup button's position.
            this.RollButton.Top = skindata.rollbtnfromtop;
            this.RollButton.Left = (this.TitleBarHolder.Width - this.RollButton.Width) - skindata.rollbtnfromside;

            // Set the minimize button's position.
            this.MinimizeButton.Top = skindata.minbtnfromtop;
            this.MinimizeButton.Left = (this.TitleBarHolder.Width - this.MinimizeButton.Width) - skindata.minbtnfromside;

            // Update the title text font if we need to.
            if(TitleText.Font.Name != skindata.titletextfontfamily || TitleText.Font.Size != skindata.titletextfontsize || TitleText.Font.Style != skindata.titletextfontstyle)
            {
                this.TitleText.Font = new Font(skindata.titletextfontfamily, skindata.titletextfontsize, skindata.titletextfontstyle);
            }

            // Set the title text color.
            this.TitleText.ForeColor = skindata.titletextcolour;

            // Set up the close button background.
            if(skin.HasImage("closebtn"))
            {
                CloseButton.BackColor = Color.Transparent;
                if (CloseButton.BackgroundImage != skin.GetImage("closebtn"))
                    CloseButton.BackgroundImage = skin.GetImage("closebtn");
                CloseButton.BackgroundImageLayout = skindata.closebtnlayout;
            }
            else
            {
                CloseButton.BackgroundImage = null;
                CloseButton.BackColor = skindata.closebtncolour;
            }

            // Set up the roll button background.
            if (skin.HasImage("rollbtn"))
            {
                RollButton.BackColor = Color.Transparent;
                if (RollButton.BackgroundImage != skin.GetImage("rollbtn"))
                    RollButton.BackgroundImage = skin.GetImage("rollbtn");
                RollButton.BackgroundImageLayout = skindata.rollbtnlayout;
            }
            else
            {
                RollButton.BackgroundImage = null;
                RollButton.BackColor = skindata.rollbtncolour;
            }

        }


        /// <summary>
        /// Gets a reference to the current system context.
        /// </summary>
        public SystemContext CurrentSystem => _currentSystem;

        /// <summary>
        /// Gets or sets the title text of this Window.
        /// </summary>
        public string WindowTitle
        {
            get => this.TitleText.Text;
            set => this.TitleText.Text = value;
        }

        public Image WindowIcon
        {
            get => this.IconBox.Image;
            set => this.IconBox.Image = value;
        }
    }
}
