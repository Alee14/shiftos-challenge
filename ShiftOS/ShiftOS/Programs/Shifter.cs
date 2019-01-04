using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShiftOS.Windowing;
using ShiftOS.Metadata;

namespace ShiftOS.Programs
{
    [Program("shifter", "Shifter", "Customize the look and feel of ShiftOS.")]
    [Requires("shifter")]
    [AppLauncherRequirement("alshifter")]
    public partial class Shifter : Window
    {
        private SkinContext EditingSkin = null;

        public enum ShifterCategory
        {
            Intro,
            Desktop,
            Windows,
            Reset
        }

        public enum ShifterDesktopCategory
        {
            Intro,
            Background,
            Panel,
            Clock,
            PanelButtons,
            AppLauncher,
            LauncherItems
        }

        public enum ShifterWindowCategory
        {
            Intro,
            TitleBar,
            TitleText,
            Buttons,
            Borders
        }

        public enum ShifterTitleButton
        {
            Close,
            Minimize,
            Roll
        }

        private ShifterDesktopCategory CurrentDesktopCategory = ShifterDesktopCategory.Intro;
        private ShifterCategory CurrentCategory = ShifterCategory.Intro;
        private ShifterWindowCategory CurrentWindowCategory = ShifterWindowCategory.Intro;
        private ShifterTitleButton CurrentTitleButton = ShifterTitleButton.Close;

        public Shifter()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AddFonts();

            EditingSkin = CurrentSystem.GetSkinContext().MakeClone();

            ResetAppLauncherRenderer();

            combobuttonoption.Items.Clear();

            foreach(var name in Enum.GetNames(typeof(ShifterTitleButton)))
            {
                combobuttonoption.Items.Add(name);
            }
        }

        private bool AssertModuleInstalled(Control InControl)
        {
            if(InControl.Text == "???")
            {
                CurrentSystem.ShowInfo("Shifter", "Shifter could not find the requested Shifter module.");
                return false;
            }
            return true;
        }

        private void ResetAppLauncherRenderer()
        {
            predesktopappmenu.Renderer = new ToolStripSkinRenderer(EditingSkin);
        }

        protected override void OnDesktopUpdate()
        {
            // Determine master category visibility.
            pnlshifterintro.Visible = CurrentCategory == ShifterCategory.Intro;
            pnldesktopoptions.Visible = CurrentCategory == ShifterCategory.Desktop;
            pnlwindowsoptions.Visible = CurrentCategory == ShifterCategory.Windows;
            pnlreset.Visible = CurrentCategory == ShifterCategory.Reset;

            // Set up window category visibility.
            pnlwindowsintro.Visible = CurrentWindowCategory == ShifterWindowCategory.Intro;
            pnltitlebaroptions.Visible = CurrentWindowCategory == ShifterWindowCategory.TitleBar;
            pnltitletextoptions.Visible = CurrentWindowCategory == ShifterWindowCategory.TitleText;
            pnlborderoptions.Visible = CurrentWindowCategory == ShifterWindowCategory.Borders;
            pnlbuttonoptions.Visible = CurrentWindowCategory == ShifterWindowCategory.Buttons;

            // Set up title button editor visibility.
            pnlclosebuttonoptions.Visible = CurrentTitleButton == ShifterTitleButton.Close;
            pnlrollupbuttonoptions.Visible = CurrentTitleButton == ShifterTitleButton.Roll;
            pnlminimizebuttonoptions.Visible = CurrentTitleButton == ShifterTitleButton.Minimize;

            // Is the title button combo box dropped down?
            if (!this.combobuttonoption.DroppedDown)
            {
                // Determine the text that gets displayed by the title button combo box.
                this.combobuttonoption.SelectedIndex = (int)CurrentTitleButton;
            }

            // Set up the preview for the Close Button.
            SetupCloseButton();
            SetupRollButton();
            SetupMinimizeButton();

            // Determine category accessibility.
            SetModuleText(btnbuttons, "Buttons", "shifttitlebuttons");
            SetModuleText(btnborders, "Borders", "shiftborders");
            SetModuleText(btntitlebar, "Title Bar", "shifttitlebar");
            SetModuleText(btntitletext, "Title Text", "shifttitletext");

            btnwindows.Text = (btntitlebar.Text == "???" && btntitletext.Text == "???" && btnborders.Text == "???" && btnbuttons.Text == "???") ? "???" : "Windows";

            // Set up the titlebar.
            SetupTitleBar();
            SetupTitleText();
            SetupBorders();

            // Wow, only took me 6 hours to get the window skinning shit working lol

            // Determine desktop category visibility.
            pnldesktopintro.Visible = CurrentDesktopCategory == ShifterDesktopCategory.Intro;
            pnldesktopbackgroundoptions.Visible = CurrentDesktopCategory == ShifterDesktopCategory.Background;
            pnldesktoppaneloptions.Visible = CurrentDesktopCategory == ShifterDesktopCategory.Panel;
            pnlpanelbuttonsoptions.Visible = CurrentDesktopCategory == ShifterDesktopCategory.PanelButtons;
            pnlapplauncheroptions.Visible = CurrentDesktopCategory == ShifterDesktopCategory.AppLauncher;
            pnllauncheritems.Visible = CurrentDesktopCategory == ShifterDesktopCategory.LauncherItems;
            pnlpanelclockoptions.Visible = CurrentDesktopCategory == ShifterDesktopCategory.Clock;

            // Determine desktop category accessibility.
            SetModuleText(btndesktopitself, "Desktop", "shiftdesktop");
            SetModuleText(btndesktop, "Desktop", "shiftdesktop");
            SetModuleText(btndesktoppanel, "Desktop Panel", "shiftdesktoppanel");
            SetModuleText(btnapplauncher, "App Launcher", "shiftapplauncher");
            SetModuleText(btnpanelclock, "Panel Clock", "shiftpanelclock");
            SetModuleText(btnpanelbuttons, "Panel Buttons", "shiftpanelbuttons");

            // Set up desktop preview.
            SetupDesktop();

            base.OnDesktopUpdate();
        }

        private void SetupDesktop()
        {
            if (EditingSkin.HasImage("desktopbackground"))
            {
                pnldesktoppreview.BackgroundImage = EditingSkin.GetImage("desktopbackground");
                pnldesktoppreview.BackColor = Color.Transparent;
                pnldesktoppreview.BackgroundImageLayout = EditingSkin.GetSkinData().desktopbackgroundlayout;
            }
            else
            {
                pnldesktoppreview.BackgroundImage = null;
                pnldesktoppreview.BackColor = EditingSkin.GetSkinData().desktopbackgroundcolour;
            }

            pnldesktopcolour.BackColor = pnldesktoppreview.BackColor;
            pnldesktopcolour.BackgroundImage = pnldesktoppreview.BackgroundImage;
            pnldesktopcolour.BackgroundImageLayout = pnldesktoppreview.BackgroundImageLayout;

            predesktoppanel.Height = EditingSkin.GetSkinData().desktoppanelheight;
            txtdesktoppanelheight.Text = predesktoppanel.Height.ToString();

            if (!combodesktoppanelposition.DroppedDown)
                combodesktoppanelposition.Text = EditingSkin.GetSkinData().desktoppanelposition;

            if (combodesktoppanelposition.Text == "Top")
            {
                predesktoppanel.Dock = DockStyle.Top;
            }
            else
            {
                predesktoppanel.Dock = DockStyle.Bottom;
            }

            if (EditingSkin.HasImage("desktoppanel"))
            {
                predesktoppanel.BackgroundImage = EditingSkin.GetImage("desktoppanel");
                predesktoppanel.BackColor = Color.Transparent;
                predesktoppanel.BackgroundImageLayout = EditingSkin.GetSkinData().desktoppanellayout;
            }
            else
            {
                predesktoppanel.BackColor = EditingSkin.GetSkinData().desktoppanelcolour;
                predesktoppanel.BackgroundImage = null;
            }

            pnldesktoppanelcolour.BackColor = predesktoppanel.BackColor;
            pnldesktoppanelcolour.BackgroundImage = predesktoppanel.BackgroundImage;
            pnldesktoppanelcolour.BackgroundImageLayout = predesktoppanel.BackgroundImageLayout;

            prepaneltimetext.Text = CurrentSystem.GetTimeOfDay();

            this.pnlpanelclocktextcolour.BackColor = prepaneltimetext.ForeColor = EditingSkin.GetSkinData().clocktextcolour;

            if (EditingSkin.HasImage("panelclock"))
            {
                pretimepanel.BackgroundImage = EditingSkin.GetImage("panelclock");
                pretimepanel.BackColor = Color.Transparent;
                pretimepanel.BackgroundImageLayout = EditingSkin.GetSkinData().panelclocklayout;
            }
            else
            {
                pretimepanel.BackColor = EditingSkin.GetSkinData().clockbackgroundcolor;
                pretimepanel.BackgroundImage = null;
            }

            pnlclockbackgroundcolour.BackColor = pretimepanel.BackColor;
            pnlclockbackgroundcolour.BackgroundImage = pretimepanel.BackgroundImage;
            pnlclockbackgroundcolour.BackgroundImageLayout = pretimepanel.BackgroundImageLayout;

            if (prepaneltimetext.Font.Name != EditingSkin.GetSkinData().panelclocktextfont || prepaneltimetext.Font.Size != EditingSkin.GetSkinData().panelclocktextsize || prepaneltimetext.Font.Style != EditingSkin.GetSkinData().panelclocktextstyle)
            {
                prepaneltimetext.Font = new Font(EditingSkin.GetSkinData().panelclocktextfont, EditingSkin.GetSkinData().panelclocktextsize, EditingSkin.GetSkinData().panelclocktextstyle);
            }

            if (!comboclocktextfont.DroppedDown)
                comboclocktextfont.Text = prepaneltimetext.Font.Name;

            if (!comboclocktextstyle.DroppedDown)
                comboclocktextstyle.Text = prepaneltimetext.Font.Style.ToString();

            txtclocktextsize.Text = prepaneltimetext.Font.Size.ToString();

            pretimepanel.Width = prepaneltimetext.Width + 3;

            prepaneltimetext.Left = 0;
            prepaneltimetext.Top = EditingSkin.GetSkinData().panelclocktexttop;
            txtclocktextfromtop.Text = prepaneltimetext.Top.ToString();

            // Most app launcher colors are dealt with by the skin renderer.
            // Unlike 0.0.x, we don't use a separate renderer for previews,
            // so the game already knows how to skin the app launcher preview
            // in the exact same way it does the real thing.
            //
            // We still need to skin the app launcher button itself though.

            // This handles the app launhcher's name.
            txtappbuttonlabel.Text = ApplicationsToolStripMenuItem.Text = EditingSkin.GetSkinData().applicationlaunchername;

            // I'm too lazy to do the font bullshit so I'm borrowing from the desktop code.
            // Set up the font.
            string appFontName = EditingSkin.GetSkinData().applicationbuttontextfont;
            int appFontSize = EditingSkin.GetSkinData().applicationbuttontextsize;
            FontStyle appFontStyle = EditingSkin.GetSkinData().applicationbuttontextstyle;

            if (ApplicationsToolStripMenuItem.Font.Name != appFontName || ApplicationsToolStripMenuItem.Font.Size != appFontSize || ApplicationsToolStripMenuItem.Font.Style != appFontStyle)
            {
                ApplicationsToolStripMenuItem.Font = new Font(appFontName, appFontSize, appFontStyle);
            }

            string appItemFontName = EditingSkin.GetSkinData().launcheritemfont;
            int appItemFontSize = EditingSkin.GetSkinData().launcheritemsize;
            FontStyle appItemFontStyle = EditingSkin.GetSkinData().launcheritemstyle;

            foreach (var child in ApplicationsToolStripMenuItem.DropDownItems)
            {
                if (child is ToolStripMenuItem)
                {
                    ToolStripMenuItem menuItem = child as ToolStripMenuItem;
                    if (menuItem.Font.Name != appItemFontName || menuItem.Font.Size != appItemFontSize || menuItem.Font.Style != appItemFontStyle)
                    {
                        menuItem.Font = new Font(appItemFontName, appItemFontSize, appItemFontStyle);
                    }
                    menuItem.ForeColor = EditingSkin.GetSkinData().launcheritemcolour;
                }
            }



            if (EditingSkin.HasImage("applauncher"))
            {
                predesktopappmenu.BackColor = Color.Transparent;
                predesktopappmenu.BackgroundImage = EditingSkin.GetImage("applauncher");
                predesktopappmenu.BackgroundImageLayout = EditingSkin.GetSkinData().applauncherlayout;
            }
            else
            {
                predesktopappmenu.BackColor = EditingSkin.GetSkinData().applauncherbuttoncolour;
                predesktopappmenu.BackgroundImage = null;
            }

            preapplaunchermenuholder.Width = EditingSkin.GetSkinData().applaunchermenuholderwidth;
            predesktopappmenu.Width = EditingSkin.GetSkinData().applaunchermenuholderwidth;
            ApplicationsToolStripMenuItem.Height = EditingSkin.GetSkinData().applicationbuttonheight;
            ApplicationsToolStripMenuItem.Width = EditingSkin.GetSkinData().applaunchermenuholderwidth;
            

            ApplicationsToolStripMenuItem.Margin = new Padding(0);
            ApplicationsToolStripMenuItem.Padding = new Padding(0);
            predesktopappmenu.Margin = new Padding(0);
            predesktopappmenu.Padding = new Padding(0);
            preapplaunchermenuholder.Margin = new Padding(0);
            preapplaunchermenuholder.Padding = new Padding(0);
            preapplaunchermenuholder.Left = 0;
            preapplaunchermenuholder.Top = 0;
            predesktopappmenu.Left = 0;
            predesktopappmenu.Top = 0;

            txtapplauncherwidth.Text = preapplaunchermenuholder.Width.ToString();
            txtapplicationsbuttonheight.Text = ApplicationsToolStripMenuItem.Height.ToString();
            txtappbuttontextsize.Text = ApplicationsToolStripMenuItem.Font.Size.ToString();

            if(!comboappbuttontextfont.DroppedDown)
                comboappbuttontextfont.Text = ApplicationsToolStripMenuItem.Font.Name;
            if (!comboappbuttontextstyle.DroppedDown)
                comboappbuttontextstyle.Text = ApplicationsToolStripMenuItem.Font.Style.ToString();

            pnlmaintextcolour.BackColor = EditingSkin.GetSkinData().applicationsbuttontextcolour;
            pnlmainbuttoncolour.BackColor = predesktopappmenu.BackColor;
            pnlmainbuttoncolour.BackgroundImage = predesktopappmenu.BackgroundImage;
            pnlmainbuttoncolour.BackgroundImageLayout = predesktopappmenu.BackgroundImageLayout;
            pnlmenuitemscolour.BackColor = EditingSkin.GetSkinData().applauncherbackgroundcolour;
            pnlmenuitemsmouseover.BackColor = EditingSkin.GetSkinData().applaunchermouseovercolour;
            pnlmainbuttonactivated.BackColor = EditingSkin.GetSkinData().applauncherbuttonclickedcolour;
            launcheritemtxtcolour.BackColor = EditingSkin.GetSkinData().launcheritemcolour;
            if (!launcheritemfont.DroppedDown)
                launcheritemfont.Text = EditingSkin.GetSkinData().launcheritemfont;
            txtlauncheritemtxtsize.Text = EditingSkin.GetSkinData().launcheritemsize.ToString();
            if(!launcheritemstyle.DroppedDown)
                launcheritemstyle.Text = EditingSkin.GetSkinData().launcheritemstyle.ToString();

            // Shit man, the App Launcher's done. Now let's do the panel buttons.
            prepnlpanelbuttonholder.Padding = new Padding(EditingSkin.GetSkinData().panelbuttoninitialgap, EditingSkin.GetSkinData().panelbuttonfromtop, 0, 0);
            prepnlpanelbutton.Padding = new Padding(0, 0, EditingSkin.GetSkinData().panelbuttongap, 0);
            prepnlpanelbutton.Size = new Size(EditingSkin.GetSkinData().panelbuttonwidth, EditingSkin.GetSkinData().panelbuttonheight);
            pretbicon.Location = new Point(EditingSkin.GetSkinData().panelbuttoniconside, EditingSkin.GetSkinData().panelbuttonicontop);
            pretbctext.Location = new Point(EditingSkin.GetSkinData().panelbuttontextside, EditingSkin.GetSkinData().panelbuttontexttop);
            pnlpanelbuttontextcolour.BackColor = pretbctext.ForeColor = EditingSkin.GetSkinData().panelbuttontextcolour;

            prepnlpanelbutton.Visible = prepnlpanelbuttonholder.Visible = CurrentSystem.HasShiftoriumUpgrade("panelbuttons");

            if(EditingSkin.HasImage("panelbutton"))
            {
                prepnlpanelbutton.BackColor = Color.Transparent;
                prepnlpanelbutton.BackgroundImage = EditingSkin.GetImage("panelbutton");
                prepnlpanelbutton.BackgroundImageLayout = EditingSkin.GetSkinData().panelbuttonlayout;
            }
            else
            {
                prepnlpanelbutton.BackgroundImage = null;
                prepnlpanelbutton.BackColor = EditingSkin.GetSkinData().panelbuttoncolour;
            }

            pnlpanelbuttoncolour.BackColor = prepnlpanelbutton.BackColor;
            pnlpanelbuttoncolour.BackgroundImage = prepnlpanelbutton.BackgroundImage;
            pnlpanelbuttoncolour.BackgroundImageLayout = prepnlpanelbutton.BackgroundImageLayout;
            pretbicon.Size = new Size(EditingSkin.GetSkinData().panelbuttoniconsize, EditingSkin.GetSkinData().panelbuttoniconsize);

            string pfont = EditingSkin.GetSkinData().panelbuttontextfont;
            int psize = EditingSkin.GetSkinData().panelbuttontextsize;
            FontStyle pstyle = EditingSkin.GetSkinData().panelbuttontextstyle;

            if(pretbctext.Font.Name != pfont || pretbctext.Font.Size != psize || pretbctext.Font.Style != pstyle)
            {
                pretbctext.Font = new Font(pfont, psize, pstyle);
            }

            txtpanelbuttoninitalgap.Text = prepnlpanelbuttonholder.Padding.Left.ToString();
            txtpanelbuttongap.Text = prepnlpanelbutton.Padding.Right.ToString();
            txtpanelbuttonwidth.Text = prepnlpanelbutton.Width.ToString();
            txtpanelbuttonheight.Text = prepnlpanelbutton.Height.ToString();
            txtpanelbuttontop.Text = prepnlpanelbuttonholder.Padding.Top.ToString();
            txtpanelbuttontextside.Text = pretbctext.Left.ToString();
            txtpanelbuttontexttop.Text = pretbctext.Top.ToString();
            txtpanelbuttoniconside.Text = pretbicon.Left.ToString();
            txtpanelbuttonicontop.Text = pretbicon.Top.ToString();
            txtpanelbuttoniconsize.Text = pretbicon.Width.ToString();
            txtpanelbuttontextsize.Text = pretbctext.Font.Size.ToString();
            if (!cbpanelbuttonfont.DroppedDown)
                cbpanelbuttonfont.Text = pretbctext.Font.Name;
            if (!cbpanelbuttontextstyle.DroppedDown)
                cbpanelbuttontextstyle.Text = pretbctext.Font.Style.ToString();
        }

        private void SetupTitleBar()
        {
            PreviewTitleBar.Height = EditingSkin.GetSkinData().titlebarheight;
            PreviewTitleRight.Width = PreviewTitleLeft.Width = EditingSkin.GetSkinData().titlebarcornerwidth;

            if(EditingSkin.HasImage("titlebar"))
            {
                PreviewTitleBar.BackColor = Color.Transparent;
                PreviewTitleBar.BackgroundImage = EditingSkin.GetImage("titlebar");
                PreviewTitleBar.BackgroundImageLayout = EditingSkin.GetSkinData().titlebarlayout;
            }
            else
            {
                PreviewTitleBar.BackColor = EditingSkin.GetSkinData().titlebarcolour;
                PreviewTitleBar.BackgroundImage = null;
            }

            pnltitlebarcolour.BackColor = PreviewTitleBar.BackColor;
            pnltitlebarcolour.BackgroundImage = PreviewTitleBar.BackgroundImage;
            pnltitlebarcolour.BackgroundImageLayout = PreviewTitleBar.BackgroundImageLayout;

            txttitlebarheight.Text = PreviewTitleBar.Height.ToString();

            cboxtitlebarcorners.Checked = EditingSkin.GetSkinData().enablecorners;

            txttitlebarcornerwidth.Text = PreviewTitleRight.Width.ToString();

            foreach(Control control in pnltitlebaroptions.Controls)
            {
                if (control.Tag == null)
                    continue;

                if(control.Tag.ToString() == "TitleCornerOptions")
                {
                    control.Visible = EditingSkin.GetSkinData().enablecorners;
                }
                else if(control.Tag.ToString() == "TitleIconsInstalled")
                {
                    control.Visible = CurrentSystem.HasShiftoriumUpgrade("titleicons");
                }
            }

            PreviewIconBox.Left = EditingSkin.GetSkinData().titleiconfromside;
            PreviewIconBox.Top = EditingSkin.GetSkinData().titleiconfromtop;

            txticonfromside.Text = PreviewIconBox.Left.ToString();
            txticonfromtop.Text = PreviewIconBox.Top.ToString();

            if (EditingSkin.HasImage("leftcorner"))
            {
                if (PreviewTitleLeft.BackgroundImage != EditingSkin.GetImage("leftcorner"))
                    PreviewTitleLeft.BackgroundImage = EditingSkin.GetImage("leftcorner");
                PreviewTitleLeft.BackgroundImageLayout = EditingSkin.GetSkinData().leftcornerlayout;
                PreviewTitleLeft.BackColor = Color.Transparent;
            }
            else
            {
                PreviewTitleLeft.BackColor = EditingSkin.GetSkinData().leftcornercolour;
                PreviewTitleLeft.BackgroundImage = null;
            }

            if (EditingSkin.HasImage("rightcorner"))
            {
                if (PreviewTitleRight.BackgroundImage != EditingSkin.GetImage("rightcorner"))
                    PreviewTitleRight.BackgroundImage = EditingSkin.GetImage("rightcorner");
                PreviewTitleRight.BackgroundImageLayout = EditingSkin.GetSkinData().rightcornerlayout;
                PreviewTitleRight.BackColor = Color.Transparent;
            }
            else
            {
                PreviewTitleRight.BackColor = EditingSkin.GetSkinData().rightcornercolour;
                PreviewTitleRight.BackgroundImage = null;
            }

            pnltitlebarleftcornercolour.BackColor = PreviewTitleLeft.BackColor;
            pnltitlebarleftcornercolour.BackgroundImage = PreviewTitleLeft.BackgroundImage;
            pnltitlebarleftcornercolour.BackgroundImageLayout = PreviewTitleLeft.BackgroundImageLayout;

            pnltitlebarrightcornercolour.BackColor = PreviewTitleRight.BackColor;
            pnltitlebarrightcornercolour.BackgroundImage = PreviewTitleRight.BackgroundImage;
            pnltitlebarrightcornercolour.BackgroundImageLayout = PreviewTitleRight.BackgroundImageLayout;

        }

        private void SetModuleText(Control InControl, string InText, string InUpgrade)
        {
            if(CurrentSystem.HasShiftoriumUpgrade(InUpgrade))
            {
                InControl.Text = InText;
            }
            else
            {
                InControl.Text = "???";
            }
        }

        private void SetupCloseButton()
        {
            PreviewClose.Size = EditingSkin.GetSkinData().closebtnsize;
            PreviewClose.Left = PreviewTitleBar.Width - PreviewClose.Width - EditingSkin.GetSkinData().closebtnfromside;
            PreviewClose.Top = EditingSkin.GetSkinData().closebtnfromtop;

            if (EditingSkin.HasImage("closebtn"))
            {
                PreviewClose.BackgroundImage = EditingSkin.GetImage("closebtn");
                PreviewClose.BackgroundImageLayout = EditingSkin.GetSkinData().closebtnlayout;
                PreviewClose.BackColor = Color.Transparent;
            }
            else
            {
                PreviewClose.BackColor = EditingSkin.GetSkinData().closebtncolour;
                PreviewClose.BackgroundImage = null;
            }

            pnlclosebuttoncolour.BackColor = PreviewClose.BackColor;
            pnlclosebuttoncolour.BackgroundImage = PreviewClose.BackgroundImage;
            pnlclosebuttoncolour.BackgroundImageLayout = PreviewClose.BackgroundImageLayout;

            txtclosebuttonwidth.Text = PreviewClose.Width.ToString();
            txtclosebuttonheight.Text = PreviewClose.Height.ToString();

            txtclosebuttonfromtop.Text = EditingSkin.GetSkinData().closebtnfromtop.ToString();
            txtclosebuttonfromside.Text = EditingSkin.GetSkinData().closebtnfromside.ToString();
        }

        private void SetupRollButton()
        {
            PreviewRoll.Size = EditingSkin.GetSkinData().rollbtnsize;
            PreviewRoll.Left = PreviewTitleBar.Width - PreviewRoll.Width - EditingSkin.GetSkinData().rollbtnfromside;
            PreviewRoll.Top = EditingSkin.GetSkinData().rollbtnfromtop;

            if (EditingSkin.HasImage("rollbtn"))
            {
                PreviewRoll.BackgroundImage = EditingSkin.GetImage("rollbtn");
                PreviewRoll.BackgroundImageLayout = EditingSkin.GetSkinData().rollbtnlayout;
                PreviewRoll.BackColor = Color.Transparent;
            }
            else
            {
                PreviewRoll.BackColor = EditingSkin.GetSkinData().rollbtncolour;
                PreviewRoll.BackgroundImage = null;
            }

            pnlrollupbuttoncolour.BackColor = PreviewRoll.BackColor;
            pnlrollupbuttoncolour.BackgroundImage = PreviewRoll.BackgroundImage;
            pnlrollupbuttoncolour.BackgroundImageLayout = PreviewRoll.BackgroundImageLayout;

            txtrollupbuttonwidth.Text = PreviewRoll.Width.ToString();
            txtrollupbuttonheight.Text = PreviewRoll.Height.ToString();

            txtrollupbuttontop.Text = EditingSkin.GetSkinData().rollbtnfromtop.ToString();
            txtrollupbuttonside.Text = EditingSkin.GetSkinData().rollbtnfromside.ToString();
        }

        private void AddFonts()
        {
            // Get the installed fonts collection.
            var allFonts = new System.Drawing.Text.InstalledFontCollection();

            // Get an array of the system's font familiies.
            FontFamily[] fontFamilies = allFonts.Families;

            // Display the font families.
            foreach (FontFamily myFont in fontFamilies)
            {
                combotitletextfont.Items.Add(myFont.Name);
                comboclocktextfont.Items.Add(myFont.Name);
                comboappbuttontextfont.Items.Add(myFont.Name);
                cbpanelbuttonfont.Items.Add(myFont.Name);
                launcheritemfont.Items.Add(myFont.Name);
            }
        }


        private void SetupMinimizeButton()
        {
            PreviewMinimize.Size = EditingSkin.GetSkinData().minbtnsize;
            PreviewMinimize.Left = PreviewTitleBar.Width - PreviewMinimize.Width - EditingSkin.GetSkinData().minbtnfromside;
            PreviewMinimize.Top = EditingSkin.GetSkinData().minbtnfromtop;

            if (EditingSkin.HasImage("minbtn"))
            {
                PreviewMinimize.BackgroundImage = EditingSkin.GetImage("minbtn");
                PreviewMinimize.BackgroundImageLayout = EditingSkin.GetSkinData().minbtnlayout;
                PreviewMinimize.BackColor = Color.Transparent;
            }
            else
            {
                PreviewMinimize.BackColor = EditingSkin.GetSkinData().minbtncolour;
                PreviewMinimize.BackgroundImage = null;
            }

            pnlminimizebuttoncolour.BackColor = PreviewMinimize.BackColor;
            pnlminimizebuttoncolour.BackgroundImage = PreviewMinimize.BackgroundImage;
            pnlminimizebuttoncolour.BackgroundImageLayout = PreviewMinimize.BackgroundImageLayout;

            txtminimizebuttonwidth.Text = PreviewMinimize.Width.ToString();
            txtminimizebuttonheight.Text = PreviewMinimize.Height.ToString();

            txtminimizebuttontop.Text = EditingSkin.GetSkinData().minbtnfromtop.ToString();
            txtminimizebuttonside.Text = EditingSkin.GetSkinData().minbtnfromside.ToString();
        }

        private void SetupBorders()
        {
            foreach (Control ctrl in pnlborderoptions.Controls)
            {
                if (ctrl.Tag == null)
                    continue;

                if (ctrl.Tag.ToString() == "BorderCorners")
                    ctrl.Visible = EditingSkin.GetSkinData().enablebordercorners;
            }

            cbindividualbordercolours.Checked = EditingSkin.GetSkinData().enablebordercorners;

            // The left border will be our background pivot. If individual border skinning is
            // off, every other border will steal properties from this one.

            if (EditingSkin.HasImage("borderleft"))
            {
                PreviewLeft.BackgroundImage = EditingSkin.GetImage("borderleft");
                PreviewLeft.BackgroundImageLayout = EditingSkin.GetSkinData().borderleftlayout;
                PreviewLeft.BackColor = Color.Transparent;
            }
            else
            {
                PreviewLeft.BackgroundImage = null;
                PreviewLeft.BackColor = EditingSkin.GetSkinData().borderleftcolour;
            }

            if (!EditingSkin.GetSkinData().enablebordercorners)
            {
                pnlbordercolour.BackColor = PreviewRight.BackColor = PreviewBottom.BackColor = PreviewBottomLeft.BackColor = PreviewBottomRight.BackColor = PreviewLeft.BackColor;
                pnlbordercolour.BackgroundImage = PreviewRight.BackgroundImage = PreviewBottom.BackgroundImage = PreviewBottomLeft.BackgroundImage = PreviewBottomRight.BackgroundImage = PreviewLeft.BackgroundImage;
                pnlbordercolour.BackgroundImageLayout = PreviewRight.BackgroundImageLayout = PreviewBottom.BackgroundImageLayout = PreviewBottomLeft.BackgroundImageLayout = PreviewBottomRight.BackgroundImageLayout = PreviewLeft.BackgroundImageLayout;
            }
            else
            {
                // Left Border button
                pnlborderleftcolour.BackColor = pnlbordercolour.BackColor = PreviewLeft.BackColor;
                pnlborderleftcolour.BackgroundImage = pnlbordercolour.BackgroundImage = PreviewLeft.BackgroundImage;
                pnlborderleftcolour.BackgroundImageLayout = pnlbordercolour.BackgroundImageLayout = PreviewLeft.BackgroundImageLayout;


                // Right border
                if (EditingSkin.HasImage("borderright"))
                {
                    PreviewRight.BackgroundImage = EditingSkin.GetImage("borderright");
                    PreviewRight.BackColor = Color.Transparent;
                    PreviewRight.BackgroundImageLayout = EditingSkin.GetSkinData().borderrightlayout;
                }
                else
                {
                    PreviewRight.BackgroundImage = null;
                    PreviewRight.BackColor = EditingSkin.GetSkinData().borderrightcolour;
                }

                pnlborderrightcolour.BackColor = PreviewRight.BackColor;
                pnlborderrightcolour.BackgroundImage = PreviewRight.BackgroundImage;
                pnlborderrightcolour.BackgroundImageLayout = PreviewRight.BackgroundImageLayout;

                // Bottom border
                if (EditingSkin.HasImage("borderbottom"))
                {
                    PreviewBottom.BackgroundImage = EditingSkin.GetImage("borderbottom");
                    PreviewBottom.BackColor = Color.Transparent;
                    PreviewBottom.BackgroundImageLayout = EditingSkin.GetSkinData().borderbottomlayout;
                }
                else
                {
                    PreviewBottom.BackgroundImage = null;
                    PreviewBottom.BackColor = EditingSkin.GetSkinData().borderbottomcolour;
                }

                pnlborderbottomcolour.BackColor = PreviewBottom.BackColor;
                pnlborderbottomcolour.BackgroundImage = PreviewBottom.BackgroundImage;
                pnlborderbottomcolour.BackgroundImageLayout = PreviewBottom.BackgroundImageLayout;

                // Bottom Right border
                if (EditingSkin.HasImage("bottomrightcorner"))
                {
                    PreviewBottomRight.BackgroundImage = EditingSkin.GetImage("bottomrightcorner");
                    PreviewBottomRight.BackColor = Color.Transparent;
                    PreviewBottomRight.BackgroundImageLayout = EditingSkin.GetSkinData().bottomrightcornerlayout;
                }
                else
                {
                    PreviewBottomRight.BackgroundImage = null;
                    PreviewBottomRight.BackColor = EditingSkin.GetSkinData().bottomrightcornercolour;
                }

                pnlborderbottomrightcolour.BackColor = PreviewBottomRight.BackColor;
                pnlborderbottomrightcolour.BackgroundImage = PreviewBottomRight.BackgroundImage;
                pnlborderbottomrightcolour.BackgroundImageLayout = PreviewBottomRight.BackgroundImageLayout;

                // Bottom Left border
                if (EditingSkin.HasImage("bottomleftcorner"))
                {
                    PreviewBottomLeft.BackgroundImage = EditingSkin.GetImage("bottomleftcorner");
                    PreviewBottomLeft.BackColor = Color.Transparent;
                    PreviewBottomLeft.BackgroundImageLayout = EditingSkin.GetSkinData().bottomleftcornerlayout;
                }
                else
                {
                    PreviewBottomLeft.BackgroundImage = null;
                    PreviewBottomLeft.BackColor = EditingSkin.GetSkinData().bottomleftcornercolour;
                }

                pnlborderbottomleftcolour.BackColor = PreviewBottomLeft.BackColor;
                pnlborderbottomleftcolour.BackgroundImage = PreviewBottomLeft.BackgroundImage;
                pnlborderbottomleftcolour.BackgroundImageLayout = PreviewBottomLeft.BackgroundImageLayout;

            }

            // Set the border width for ALL borders.
            PreviewLeft.Width = PreviewRight.Width = PreviewBottom.Height = EditingSkin.GetSkinData().borderwidth;

            // Set the text of the Border Width textbox.
            txtbordersize.Text = PreviewLeft.Width.ToString();
        }

        private void SetupTitleText()
        {
            PreviewTitleText.ForeColor = EditingSkin.GetSkinData().titletextcolour;
            pnltitletextcolour.BackColor = PreviewTitleText.ForeColor;

            if(PreviewTitleText.Font.Name != EditingSkin.GetSkinData().titletextfontfamily || PreviewTitleText.Font.Size != EditingSkin.GetSkinData().titletextfontsize || PreviewTitleText.Font.Style != EditingSkin.GetSkinData().titletextfontstyle)
            {
                PreviewTitleText.Font = new Font(EditingSkin.GetSkinData().titletextfontfamily, EditingSkin.GetSkinData().titletextfontsize, EditingSkin.GetSkinData().titletextfontstyle);
            }

            if(!combotitletextfont.DroppedDown)
                combotitletextfont.Text = PreviewTitleText.Font.Name;
            if (!combotitletextstyle.DroppedDown)
                combotitletextstyle.Text = PreviewTitleText.Font.Style.ToString();
            if (!combotitletextposition.DroppedDown)
                combotitletextposition.Text = EditingSkin.GetSkinData().titletextposition;

            if(EditingSkin.GetSkinData().titletextposition == "Left")
            {
                PreviewTitleText.Left = EditingSkin.GetSkinData().titletextfromside;
                txttitletextside.Text = PreviewTitleText.Left.ToString();
            }
            else
            {
                PreviewTitleText.Left = (PreviewTitleBar.Width - PreviewTitleText.Width) / 2;
                txttitletextside.Text = EditingSkin.GetSkinData().titletextfromside.ToString();
            }
            PreviewTitleText.Top = EditingSkin.GetSkinData().titletextfromtop;
            txttitletexttop.Text = PreviewTitleText.Top.ToString();

            this.txttitletextsize.Text = PreviewTitleText.Font.Size.ToString();
        }

        private void btndesktop_Click(object sender, EventArgs e)
        {
            if (AssertModuleInstalled(sender as Control))
            {
                CurrentCategory = ShifterCategory.Desktop;
                CurrentDesktopCategory = ShifterDesktopCategory.Intro;
            }
        }

        private void btnwindows_Click(object sender, EventArgs e)
        {
            if (AssertModuleInstalled(sender as Control))
            {
                CurrentCategory = ShifterCategory.Windows;
                CurrentWindowCategory = ShifterWindowCategory.Intro;
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            if(AssertModuleInstalled(sender as Control))
                CurrentCategory = ShifterCategory.Reset;
        }

        private void btnresetallsettings_Click(object sender, EventArgs e)
        {
            CurrentSystem.AskYesNo("Shifter - Global Reset", "Do you really want to globally reset ShiftOS's settings?", (answer) =>
            {
                if(answer)
                {
                    // Reset the shifter skin context as well.
                    EditingSkin.Reset();

                    // Reset the system skin context.
                    this.CurrentSystem.GetSkinContext().Reset();
                    
                    // Notify of the reset.
                    CurrentSystem.ShowInfo("Shifter - Global Reset", "Global reset complete - all settings have been reset to their factory defaults.");
                }
            });
        }

        private void btntitlebar_Click(object sender, EventArgs e)
        {
            if(AssertModuleInstalled(sender as Control))
                CurrentWindowCategory = ShifterWindowCategory.TitleBar;
        }

        private void btntitletext_Click(object sender, EventArgs e)
        {
            if (AssertModuleInstalled(sender as Control))
                CurrentWindowCategory = ShifterWindowCategory.TitleText;
        }

        

        private void btnbuttons_Click(object sender, EventArgs e)
        {
            if (AssertModuleInstalled(sender as Control))
            {
                CurrentWindowCategory = ShifterWindowCategory.Buttons;
                CurrentTitleButton = ShifterTitleButton.Close;
            }
        }

        private void btnborders_Click(object sender, EventArgs e)
        {
            if (AssertModuleInstalled(sender as Control))
                CurrentWindowCategory = ShifterWindowCategory.Borders;
        }

        private void combobuttonoption_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = combobuttonoption.SelectedIndex;
            if (index != (int)CurrentTitleButton)
                CurrentTitleButton = (ShifterTitleButton)index;
        }

        private void pnlclosebuttoncolour_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Close Button Color", EditingSkin.GetSkinData().closebtncolour, (color) =>
                {
                    EditingSkin.GetSkinData().closebtncolour = color;
                });
            }
            else if(e.Button == MouseButtons.Right && CurrentSystem.HasShiftoriumUpgrade("skinning"))
            {
                CurrentSystem.AskForGraphic("Close Button", EditingSkin.GetImage("closebtn"), EditingSkin.GetSkinData().closebtnlayout, (image, layout) =>
                {
                    EditingSkin.SetImage("closebtn", image);
                    EditingSkin.GetSkinData().closebtnlayout = layout;
                });
            }
        }

        private void btnapply_Click(object sender, EventArgs e)
        {
            // Apply the skin.
            CurrentSystem.ApplySkin(EditingSkin);

            // Notify the player.
            CurrentSystem.ShowInfo("Shifter", "Your new settings have successfully been applied!");
        }

        private void cboxtitlebarcorners_CheckedChanged(object sender, EventArgs e)
        {
            EditingSkin.GetSkinData().enablecorners = cboxtitlebarcorners.Checked;
        }

        private void txtclosebuttonheight_TextChanged(object sender, EventArgs e)
        {
            int height = 0;
            if (int.TryParse(txtclosebuttonheight.Text, out height))
                EditingSkin.GetSkinData().closebtnsize.Height = height;
        }

        private void txtclosebuttonwidth_TextChanged(object sender, EventArgs e)
        {
            int width = 0;
            if (int.TryParse(txtclosebuttonwidth.Text, out width))
                EditingSkin.GetSkinData().closebtnsize.Width = width;

        }

        private void txtclosebuttonfromtop_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().closebtnfromtop = x;
        }

        private void txtclosebuttonfromside_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().closebtnfromside = x;

        }

        private void txtminimizebuttonheight_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().minbtnsize.Height = x;

        }

        private void txtminimizebuttonwidth_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().minbtnsize.Width = x;

        }

        private void txtminimizebuttontop_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().minbtnfromtop = x;

        }

        private void txtminimizebuttonside_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().minbtnfromside = x;

        }

        private void pnlminimizebuttoncolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if(e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Minimize Button Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().minbtncolour = color;
                });
            }
            else if(e.Button == MouseButtons.Right && CurrentSystem.HasShiftoriumUpgrade("skinning"))
            {
                CurrentSystem.AskForGraphic("Minimize Button", control.BackgroundImage, control.BackgroundImageLayout, (image, layout) =>
                {
                    EditingSkin.SetImage("minbtn", image);
                    EditingSkin.GetSkinData().minbtnlayout = layout;
                });
            }
        }

        private void pnlrollupbuttoncolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Roll Button Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().rollbtncolour = color;
                });
            }
            else if (e.Button == MouseButtons.Right && CurrentSystem.HasShiftoriumUpgrade("skinning"))
            {
                CurrentSystem.AskForGraphic("Roll Button", control.BackgroundImage, control.BackgroundImageLayout, (image, layout) =>
                {
                    EditingSkin.SetImage("rollbtn", image);
                    EditingSkin.GetSkinData().rollbtnlayout = layout;
                });
            }

        }

        private void txtrollupbuttonheight_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().rollbtnsize.Height = x;

        }

        private void txtrollupbuttonwidth_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().rollbtnsize.Width = x;

        }

        private void txtrollupbuttontop_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().rollbtnfromtop = x;

        }

        private void txtrollupbuttonside_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().rollbtnfromside = x;

        }

        private void txttitlebarheight_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().titlebarheight = x;

        }

        private void txttitlebarcornerwidth_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().titlebarcornerwidth = x;

        }

        private void txticonfromside_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().titleiconfromside = x;

        }

        private void txticonfromtop_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().titleiconfromtop = x;

        }

        private void pnltitlebarcolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Title Bar Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().titlebarcolour = color;
                });
            }
            else if (e.Button == MouseButtons.Right && CurrentSystem.HasShiftoriumUpgrade("skinning"))
            {
                CurrentSystem.AskForGraphic("Title Bar", control.BackgroundImage, control.BackgroundImageLayout, (image, layout) =>
                {
                    EditingSkin.SetImage("titlebar", image);
                    EditingSkin.GetSkinData().titlebarlayout = layout;
                });
            }

        }

        private void pnltitlebarleftcornercolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Title Left Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().leftcornercolour = color;
                });
            }
            else if (e.Button == MouseButtons.Right && CurrentSystem.HasShiftoriumUpgrade("skinning"))
            {
                CurrentSystem.AskForGraphic("Title Left", control.BackgroundImage, control.BackgroundImageLayout, (image, layout) =>
                {
                    EditingSkin.SetImage("leftcorner", image);
                    EditingSkin.GetSkinData().leftcornerlayout = layout;
                });
            }

        }

        private void pnltitlebarrightcornercolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Title Right Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().rightcornercolour = color;
                });
            }
            else if (e.Button == MouseButtons.Right && CurrentSystem.HasShiftoriumUpgrade("skinning"))
            {
                CurrentSystem.AskForGraphic("Title Right", control.BackgroundImage, control.BackgroundImageLayout, (image, layout) =>
                {
                    EditingSkin.SetImage("rightcorner", image);
                    EditingSkin.GetSkinData().rightcornerlayout = layout;
                });
            }

        }

        private void pnltitletextcolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Title Text Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().titletextcolour = color;
                });
            }

        }

        private void combotitletextfont_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditingSkin.GetSkinData().titletextfontfamily = combotitletextfont.Text;
        }

        private void combotitletextposition_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditingSkin.GetSkinData().titletextposition = combotitletextposition.Text;
        }

        private void combotitletextstyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditingSkin.GetSkinData().titletextfontstyle = (FontStyle)Enum.Parse(typeof(FontStyle), combotitletextstyle.Text);
        }

        private void txttitletextsize_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().titletextfontsize = x;

        }

        private void txttitletexttop_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().titletextfromtop = x;

        }

        private void txttitletextside_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().titletextfromside = x;

        }

        private void cbindividualbordercolours_CheckedChanged(object sender, EventArgs e)
        {
            EditingSkin.GetSkinData().enablebordercorners = cbindividualbordercolours.Checked;
        }

        private void txtbordersize_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().borderwidth = x;

        }

        private void pnlbordercolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Window Border Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().borderleftcolour = color;
                });
            }
            else if (e.Button == MouseButtons.Right && CurrentSystem.HasShiftoriumUpgrade("skinning"))
            {
                CurrentSystem.AskForGraphic("Window Border Color", control.BackgroundImage, control.BackgroundImageLayout, (image, layout) =>
                {
                    EditingSkin.SetImage("borderleft", image);
                    EditingSkin.GetSkinData().borderleftlayout = layout;
                });
            }

        }

        private void pnlborderbottomcolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Window Border Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().borderbottomcolour = color;
                });
            }
            else if (e.Button == MouseButtons.Right && CurrentSystem.HasShiftoriumUpgrade("skinning"))
            {
                CurrentSystem.AskForGraphic("Window Border Color", control.BackgroundImage, control.BackgroundImageLayout, (image, layout) =>
                {
                    EditingSkin.SetImage("borderbottom", image);
                    EditingSkin.GetSkinData().borderbottomlayout = layout;
                });
            }

        }

        private void pnlborderrightcolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Window Border Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().borderrightcolour = color;
                });
            }
            else if (e.Button == MouseButtons.Right && CurrentSystem.HasShiftoriumUpgrade("skinning"))
            {
                CurrentSystem.AskForGraphic("Window Border Color", control.BackgroundImage, control.BackgroundImageLayout, (image, layout) =>
                {
                    EditingSkin.SetImage("borderright", image);
                    EditingSkin.GetSkinData().borderrightlayout = layout;
                });
            }

        }

        private void pnlborderbottomleftcolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Window Border Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().bottomleftcornercolour = color;
                });
            }
            else if (e.Button == MouseButtons.Right && CurrentSystem.HasShiftoriumUpgrade("skinning"))
            {
                CurrentSystem.AskForGraphic("Window Border Color", control.BackgroundImage, control.BackgroundImageLayout, (image, layout) =>
                {
                    EditingSkin.SetImage("bottomleftcorner", image);
                    EditingSkin.GetSkinData().bottomleftcornerlayout = layout;
                });
            }

        }

        private void pnlborderbottomrightcolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Window Border Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().bottomrightcornercolour = color;
                });
            }
            else if (e.Button == MouseButtons.Right && CurrentSystem.HasShiftoriumUpgrade("skinning"))
            {
                CurrentSystem.AskForGraphic("Window Border Color", control.BackgroundImage, control.BackgroundImageLayout, (image, layout) =>
                {
                    EditingSkin.SetImage("bottomrightcorner", image);
                    EditingSkin.GetSkinData().bottomrightcornerlayout = layout;
                });
            }

        }

        private void btndesktopitself_Click(object sender, EventArgs e)
        {
            if (AssertModuleInstalled(sender as Control))
                CurrentDesktopCategory = ShifterDesktopCategory.Background;
        }

        private void btnpanelclock_Click(object sender, EventArgs e)
        {
            if (AssertModuleInstalled(sender as Control))
                CurrentDesktopCategory = ShifterDesktopCategory.Clock;

        }

        private void btnapplauncher_Click(object sender, EventArgs e)
        {
            if (AssertModuleInstalled(sender as Control))
                CurrentDesktopCategory = ShifterDesktopCategory.AppLauncher;

        }

        private void btndesktoppanel_Click(object sender, EventArgs e)
        {
            if (AssertModuleInstalled(sender as Control))
                CurrentDesktopCategory = ShifterDesktopCategory.Panel;
        }

        private void btnshowlauncheritems_Click(object sender, EventArgs e)
        {
            if (AssertModuleInstalled(sender as Control))
                CurrentDesktopCategory = ShifterDesktopCategory.LauncherItems;
        }

        private void btnpanelbuttons_Click(object sender, EventArgs e)
        {
            if (AssertModuleInstalled(sender as Control))
                CurrentDesktopCategory = ShifterDesktopCategory.PanelButtons;
        }

        private void combodesktoppanelposition_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditingSkin.GetSkinData().desktoppanelposition = combodesktoppanelposition.Text;
        }

        private void txtdesktoppanelheight_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().desktoppanelheight = x;
        }

        private void pnldesktoppanelcolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Desktop Panel Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().desktoppanelcolour = color;
                });
            }
            else if (e.Button == MouseButtons.Right && CurrentSystem.HasShiftoriumUpgrade("skinning"))
            {
                CurrentSystem.AskForGraphic("Desktop Panel", control.BackgroundImage, control.BackgroundImageLayout, (image, layout) =>
                {
                    EditingSkin.SetImage("desktoppanel", image);
                    EditingSkin.GetSkinData().desktoppanellayout = layout;
                });
            }

        }

        private void pnldesktopcolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Desktop Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().desktopbackgroundcolour = color;
                });
            }
            else if (e.Button == MouseButtons.Right && CurrentSystem.HasShiftoriumUpgrade("skinning"))
            {
                CurrentSystem.AskForGraphic("Desktop Background", control.BackgroundImage, control.BackgroundImageLayout, (image, layout) =>
                {
                    EditingSkin.SetImage("desktopbackground", image);
                    EditingSkin.GetSkinData().desktopbackgroundlayout = layout;
                });
            }
        }

        private void comboclocktextfont_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditingSkin.GetSkinData().panelclocktextfont = comboclocktextfont.Text;
        }

        private void comboclocktextstyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditingSkin.GetSkinData().panelclocktextstyle = (FontStyle)Enum.Parse(typeof(FontStyle), comboclocktextstyle.Text);
        }

        private void txtclocktextsize_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().panelclocktextsize = x;
        }

        private void txtclocktextfromtop_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().panelclocktexttop = x;
        }

        private void pnlpanelclocktextcolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if(e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Panel Clock Text Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().clocktextcolour = color;
                });
            }
        }

        private void pnlclockbackgroundcolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Panel Clock Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().clockbackgroundcolor = color;
                });
            }
            else if (e.Button == MouseButtons.Right && CurrentSystem.HasShiftoriumUpgrade("skinning"))
            {
                CurrentSystem.AskForGraphic("Panel Clock", control.BackgroundImage, control.BackgroundImageLayout, (image, layout) =>
                {
                    EditingSkin.SetImage("panelclock", image);
                    EditingSkin.GetSkinData().panelclocklayout = layout;
                });
            }

        }

        private void txtappbuttonlabel_TextChanged(object sender, EventArgs e)
        {
            EditingSkin.GetSkinData().applicationlaunchername = txtappbuttonlabel.Text;
        }

        private void txtlauncheritemtxtsize_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().launcheritemsize = x;

        }

        private void launcheritemfont_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditingSkin.GetSkinData().launcheritemfont = launcheritemfont.Text;
        }

        private void launcheritemstyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditingSkin.GetSkinData().launcheritemstyle = (FontStyle)Enum.Parse(typeof(FontStyle), launcheritemstyle.Text);
        }

        private void txtappbuttontextsize_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().applicationbuttontextsize = x;

        }

        private void txtapplicationsbuttonheight_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().applicationbuttonheight = x;
        }

        private void txtapplauncherwidth_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().applaunchermenuholderwidth = x;
        }

        private void comboappbuttontextfont_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditingSkin.GetSkinData().applicationbuttontextfont = (sender as Control).Text;
        }

        private void comboappbuttontextstyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditingSkin.GetSkinData().applicationbuttontextstyle = (FontStyle)Enum.Parse(typeof(FontStyle), (sender as Control).Text);
        }

        private void pnlmenuitemscolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("App Launcher Menu Item Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().applauncherbackgroundcolour = color;
                });
            }

        }

        private void pnlmaintextcolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("App Launcher Text Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().applicationsbuttontextcolour = color;
                });
            }

        }

        private void pnlmainbuttoncolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("App Launcher Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().applauncherbuttoncolour = color;
                });
            }
            else if (e.Button == MouseButtons.Right && CurrentSystem.HasShiftoriumUpgrade("skinning"))
            {
                CurrentSystem.AskForGraphic("App Launcher", control.BackgroundImage, control.BackgroundImageLayout, (image, layout) =>
                {
                    EditingSkin.SetImage("applauncher", image);
                    EditingSkin.GetSkinData().applauncherlayout = layout;
                });
            }

        }

        private void pnlmenuitemsmouseover_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("App Launcher Item Mouse Over", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().applaunchermouseovercolour = color;
                });
            }
        }

        private void pnlmainbuttonactivated_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("App Launcher Activated Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().applauncherbuttonclickedcolour = color;
                });
            }

        }

        private void launcheritemtxtcolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("App Launcher Item Text Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().launcheritemcolour = color;
                });
            }

        }

        private void cbpanelbuttontextstyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditingSkin.GetSkinData().panelbuttontextstyle = (FontStyle)Enum.Parse(typeof(FontStyle), cbpanelbuttontextstyle.Text);
        }

        private void cbpanelbuttonfont_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditingSkin.GetSkinData().panelbuttontextfont = cbpanelbuttonfont.Text;
        }

        private void txtpanelbuttoniconsize_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().panelbuttoniconsize = x;
        }

        private void txtpanelbuttoniconside_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().panelbuttoniconside = x;
        }

        private void txtpanelbuttonicontop_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().panelbuttonicontop = x;
        }

        private void txtpanelbuttontextsize_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().panelbuttontextsize = x;
        }

        private void txtpanelbuttontexttop_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().panelbuttontexttop = x;
        }

        private void txtpanelbuttontextside_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().panelbuttontextside = x;
        }

        private void txtpanelbuttongap_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().panelbuttongap = x;
        }

        private void txtpanelbuttonheight_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().panelbuttonheight = x;
        }

        private void txtpanelbuttonwidth_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().panelbuttonwidth = x;
        }

        private void txtpanelbuttontop_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().panelbuttonfromtop = x;
        }

        private void txtpanelbuttoninitalgap_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (int.TryParse((sender as Control).Text, out x))
                EditingSkin.GetSkinData().panelbuttoninitialgap = x;
        }

        private void pnlpanelbuttontextcolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Panel Button Text Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().panelbuttontextcolour = color;
                });
            }

        }

        private void pnlpanelbuttoncolour_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                CurrentSystem.AskForColor("Panel Button Color", control.BackColor, (color) =>
                {
                    EditingSkin.GetSkinData().panelbuttoncolour = color;
                });
            }
            else if (e.Button == MouseButtons.Right && CurrentSystem.HasShiftoriumUpgrade("skinning"))
            {
                CurrentSystem.AskForGraphic("Panel Button", control.BackgroundImage, control.BackgroundImageLayout, (image, layout) =>
                {
                    EditingSkin.SetImage("panelbutton", image);
                    EditingSkin.GetSkinData().panelbuttonlayout = layout;
                });
            }

        }
    }
}
