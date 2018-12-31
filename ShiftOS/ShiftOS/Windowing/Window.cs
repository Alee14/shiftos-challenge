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
        private int PreRollHeight = 0;
        private bool IsRolled = false;


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
            this.BackColor = Color.Transparent;

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

            // Set up the minimize button background.
            if (skin.HasImage("minbtn"))
            {
                MinimizeButton.BackColor = Color.Transparent;
                if (MinimizeButton.BackgroundImage != skin.GetImage("minbtn"))
                    MinimizeButton.BackgroundImage = skin.GetImage("minbtn");
                MinimizeButton.BackgroundImageLayout = skindata.minbtnlayout;
            }
            else
            {
                MinimizeButton.BackgroundImage = null;
                MinimizeButton.BackColor = skindata.minbtncolour;
            }

            // Set up the widths of our borders.
            this.LeftBar.Width = skindata.borderwidth;
            this.RightBar.Width = skindata.borderwidth;
            this.BottomBarHolder.Height = skindata.borderwidth;

            // Bottom corners get their heights from the bottom bar holder, but their widths must be set.
            this.BottomLeft.Width = this.LeftBar.Width;
            this.BottomRight.Width = this.RightBar.Width;
            
            // Should we show the titlebar corners?
            if(skindata.enablecorners)
            {
                // Show titlebar corners.
                this.TitleBarLeft.Show();
                this.TitleBarRight.Show();

                // Set their widths.
                this.TitleBarLeft.Width = skindata.titlebarcornerwidth;
                this.TitleBarRight.Width = this.TitleBarLeft.Width;

                // Set their backgrounds.
                if(skin.HasImage("leftcorner"))
                {
                    if (TitleBarLeft.BackgroundImage != skin.GetImage("leftcorner"))
                        TitleBarLeft.BackgroundImage = skin.GetImage("leftcorner");
                    TitleBarLeft.BackgroundImageLayout = skindata.leftcornerlayout;
                    TitleBarLeft.BackColor = Color.Transparent;
                }
                else
                {
                    TitleBarLeft.BackColor = skindata.leftcornercolour;
                    TitleBarLeft.BackgroundImage = null;
                }

                if (skin.HasImage("rightcorner"))
                {
                    if (TitleBarRight.BackgroundImage != skin.GetImage("rightcorner"))
                        TitleBarRight.BackgroundImage = skin.GetImage("rightcorner");
                    TitleBarRight.BackgroundImageLayout = skindata.rightcornerlayout;
                    TitleBarRight.BackColor = Color.Transparent;
                }
                else
                {
                    TitleBarRight.BackColor = skindata.rightcornercolour;
                    TitleBarRight.BackgroundImage = null;
                }

            }
            else
            {
                // Hide them.
                this.TitleBarLeft.Hide();
                this.TitleBarRight.Hide();
            }

            // Should we show the border corners?
            if (skindata.enablebordercorners)
            {
                // Show titlebar corners.
                this.BottomLeft.Show();
                this.BottomRight.Show();

                // Set their backgrounds.
                if (skin.HasImage("bottomleftcorner"))
                {
                    if (BottomLeft.BackgroundImage != skin.GetImage("bottomleftcorner"))
                        BottomLeft.BackgroundImage = skin.GetImage("bottomleftcorner");
                    BottomLeft.BackgroundImageLayout = skindata.bottomleftcornerlayout;
                    BottomLeft.BackColor = Color.Transparent;
                }
                else
                {
                    BottomLeft.BackColor = skindata.bottomleftcornercolour;
                    BottomLeft.BackgroundImage = null;
                }

                if (skin.HasImage("bottomrightcorner"))
                {
                    if (BottomRight.BackgroundImage != skin.GetImage("bottomrightcorner"))
                        BottomRight.BackgroundImage = skin.GetImage("bottomrightcorner");
                    BottomRight.BackgroundImageLayout = skindata.bottomrightcornerlayout;
                    BottomRight.BackColor = Color.Transparent;
                }
                else
                {
                    BottomRight.BackColor = skindata.bottomrightcornercolour;
                    BottomRight.BackgroundImage = null;
                }

            }
            else
            {
                // Hide them.
                this.BottomLeft.Hide();
                this.BottomRight.Hide();
            }


            // Set the titlebar background.
            if (skin.HasImage("titlebar"))
            {
                if(this.TitleBarHolder.BackgroundImage != skin.GetImage("titlebar"))
                {
                    this.TitleBarHolder.BackgroundImage = skin.GetImage("titlebar");
                }
                this.TitleBarHolder.BackColor = Color.Transparent;
                this.TitleBarHolder.BackgroundImageLayout = skindata.titlebarlayout;
            }
            else
            {
                this.TitleBarHolder.BackColor = skindata.titlebarcolour;
                this.TitleBarHolder.BackgroundImage = null;
            }

            if(skin.HasImage("borderleft"))
            {
                if(this.LeftBar.BackgroundImage != skin.GetImage("borderleft"))
                {
                    this.LeftBar.BackgroundImage = skin.GetImage("borderleft");
                }
                this.LeftBar.BackColor = Color.Transparent;
                this.LeftBar.BackgroundImageLayout = skindata.borderleftlayout;
            }
            else
            {
                this.LeftBar.BackColor = skindata.borderleftcolour;
                this.LeftBar.BackgroundImage = null;
            }

            if (skin.HasImage("borderright"))
            {
                if (this.RightBar.BackgroundImage != skin.GetImage("borderright"))
                {
                    this.RightBar.BackgroundImage = skin.GetImage("borderright");
                }
                this.RightBar.BackColor = Color.Transparent;
                this.RightBar.BackgroundImageLayout = skindata.borderrightlayout;
            }
            else
            {
                this.RightBar.BackColor = skindata.borderrightcolour;
                this.RightBar.BackgroundImage = null;
            }

            if (skin.HasImage("borderbottom"))
            {
                if (this.BottomBarHolder.BackgroundImage != skin.GetImage("borderbottom"))
                {
                    this.BottomBarHolder.BackgroundImage = skin.GetImage("borderbottom");
                }
                this.BottomBarHolder.BackColor = Color.Transparent;
                this.BottomBarHolder.BackgroundImageLayout = skindata.borderbottomlayout;
            }
            else
            {
                this.BottomBarHolder.BackColor = skindata.borderbottomcolour;
                this.BottomBarHolder.BackgroundImage = null;
            }

            if(IsRolled)
            {
                Height = TitleBarHolder.Height;
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

        private void TitleBarMouseDown(object sender, MouseEventArgs e)
        {
            if (this.CurrentSystem.HasShiftoriumUpgrade("draggablewindows"))
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.TitleBarHolder.Capture = false;
                    this.TitleText.Capture = false;
                    this.IconBox.Capture = false;
                    this.TitleBarLeft.Capture = false;
                    this.TitleBarRight.Capture = false;
                    const ushort WM_NCLBUTTONDOWN = 0xA1;
                    const long HTCAPTION = 2;
                    Message msg = Message.Create(this.Handle, WM_NCLBUTTONDOWN, new IntPtr(HTCAPTION), IntPtr.Zero);
                    this.DefWndProc(ref msg);
                }
            }
        }

        public event EventHandler WindowClosed;

        protected virtual void OnClose() { }

        public void Close()
        {
            WindowClosed?.Invoke(this, EventArgs.Empty);
            OnClose();
            this.Parent?.Controls.Remove(this);
        }

        private void CloseButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void RollButton_MouseClick(object sender, MouseEventArgs e)
        {
            if(IsRolled)
            {
                this.Height = PreRollHeight;
            }
            else
            {
                PreRollHeight = this.Height;
                this.Height = TitleBarHolder.Height;
            }
            IsRolled = !IsRolled;
        }
    }
}
