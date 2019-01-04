using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftOS.Windowing;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ShiftOS.Programs
{
    public partial class ColorPicker : Window
    {
        public ColorPicker()
        {
            InitializeComponent();

            ColorDatabase = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<int, List<Color>>>>(Properties.Resources.ColorPickerDefaults);
        }

        private Dictionary<string, Dictionary<int, List<Color>>> ColorDatabase = new Dictionary<string, Dictionary<int, List<Color>>>();

        public string ColorName { get => lblobjecttocolour.Text; set => lblobjecttocolour.Text = value; }
        public Action<Color> Callback { get; set; }
        public Color OldColor { get; set; } = Color.Black;
        private int graylevel, redlevel, bluelevel, greenlevel, pinklevel, purplelevel, orangelevel, yellowlevel, brownlevel, anylevel = 0;

        private void pnloldcolour_MouseClick(object sender, MouseEventArgs e)
        {
            Callback?.Invoke(OldColor);
            Close();
        }

        private void pnlnewcolour_MouseClick(object sender, MouseEventArgs e)
        {
            Callback?.Invoke(pnlnewcolour.BackColor);
            Close();
        }

        private void determinecolor(Panel container, int level, string color)
        {
            if(ColorDatabase.ContainsKey(color))
            {
                var colorlistmap = ColorDatabase[color];
                if(colorlistmap.ContainsKey(level))
                {
                    var colors = colorlistmap[level];
                    foreach (Control control in container.Controls.OfType<Panel>().Where(x => char.IsNumber(x.Name.Last())).OrderBy(x => (int)x.Tag))
                    {
                        if (control is Panel)
                        {
                            int tag = (int)control.Tag - 1;
                            if(tag >= 0 && tag < colors.Count)
                            {
                                control.BackColor = colors[tag];
                                control.Show();
                            }
                            else
                            {
                                control.BackColor = Color.White;
                                control.Hide();
                            }
                        }
                    }

                }
            }
        }

        private void determinelevels()
        {
            if (CurrentSystem.HasShiftoriumUpgrade("gray")) graylevel = 1;
            if (CurrentSystem.HasShiftoriumUpgrade("grayshades")) graylevel = 2;
            if (CurrentSystem.HasShiftoriumUpgrade("fullgrayshadeset")) graylevel = 3;
            if (CurrentSystem.HasShiftoriumUpgrade("customgrayshades")) graylevel = 4;
            if (CurrentSystem.HasShiftoriumUpgrade("basiccustomshade")) anylevel = 1;
            if (CurrentSystem.HasShiftoriumUpgrade("generalcustomshades")) anylevel = 2;
            if (CurrentSystem.HasShiftoriumUpgrade("advancedcustomshades")) anylevel = 3;
            if (CurrentSystem.HasShiftoriumUpgrade("limitlesscustomshades")) anylevel = 4;
            if (CurrentSystem.HasShiftoriumUpgrade("purple")) purplelevel = 1;
            if (CurrentSystem.HasShiftoriumUpgrade("purpleshades")) purplelevel = 2;
            if (CurrentSystem.HasShiftoriumUpgrade("fullpurpleshadeset")) purplelevel = 3;
            if (CurrentSystem.HasShiftoriumUpgrade("custompurpleshades")) purplelevel = 4;
            if (CurrentSystem.HasShiftoriumUpgrade("blue")) bluelevel = 1;
            if (CurrentSystem.HasShiftoriumUpgrade("blueshades")) bluelevel = 2;
            if (CurrentSystem.HasShiftoriumUpgrade("fullblueshadeset")) bluelevel = 3;
            if (CurrentSystem.HasShiftoriumUpgrade("customblueshades")) bluelevel = 4;
            if (CurrentSystem.HasShiftoriumUpgrade("green")) greenlevel = 1;
            if (CurrentSystem.HasShiftoriumUpgrade("greenshades")) greenlevel = 2;
            if (CurrentSystem.HasShiftoriumUpgrade("fullgreenshadeset")) greenlevel = 3;
            if (CurrentSystem.HasShiftoriumUpgrade("customgreenshades")) greenlevel = 4;
            if (CurrentSystem.HasShiftoriumUpgrade("yellow")) yellowlevel = 1;
            if (CurrentSystem.HasShiftoriumUpgrade("yellowshades")) yellowlevel = 2;
            if (CurrentSystem.HasShiftoriumUpgrade("fullyellowshadeset")) yellowlevel = 3;
            if (CurrentSystem.HasShiftoriumUpgrade("customyellowshades")) yellowlevel = 4;
            if (CurrentSystem.HasShiftoriumUpgrade("orange")) orangelevel = 1;
            if (CurrentSystem.HasShiftoriumUpgrade("orangeshades")) orangelevel = 2;
            if (CurrentSystem.HasShiftoriumUpgrade("fullorangeshadeset")) orangelevel = 3;
            if (CurrentSystem.HasShiftoriumUpgrade("customorangeshades")) orangelevel = 4;
            if (CurrentSystem.HasShiftoriumUpgrade("brown")) brownlevel = 1;
            if (CurrentSystem.HasShiftoriumUpgrade("brownshades")) brownlevel = 2;
            if (CurrentSystem.HasShiftoriumUpgrade("fullbrownshadeset")) brownlevel = 3;
            if (CurrentSystem.HasShiftoriumUpgrade("custombrownshades")) brownlevel = 4;
            if (CurrentSystem.HasShiftoriumUpgrade("red")) redlevel = 1;
            if (CurrentSystem.HasShiftoriumUpgrade("redshades")) redlevel = 2;
            if (CurrentSystem.HasShiftoriumUpgrade("fullredshadeset")) redlevel = 3;
            if (CurrentSystem.HasShiftoriumUpgrade("customredshades")) redlevel = 4;
            if (CurrentSystem.HasShiftoriumUpgrade("pink")) pinklevel = 1;
            if (CurrentSystem.HasShiftoriumUpgrade("pinkshades")) pinklevel = 2;
            if (CurrentSystem.HasShiftoriumUpgrade("fullpinkshadeset")) pinklevel = 3;
            if (CurrentSystem.HasShiftoriumUpgrade("custompinkshades")) pinklevel = 4;
    }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            foreach(Panel panel in pnlcolorgroups.Controls)
            {
                foreach(Control child in panel.Controls)
                {
                    if (child is Panel)
                    {
                        (child as Panel).BorderStyle = BorderStyle.FixedSingle;

                        string name = child.Name;
                        if(char.IsNumber(name.Last()))
                        {
                            string number = string.Join("", name.Where(x => char.IsNumber(x)).ToArray());

                            child.Tag = Convert.ToInt32(number);

                            child.MouseClick += (o, a) =>
                            {
                                pnlnewcolour.BackColor = child.BackColor;
                            };
                        }
                    }
                }
            }
        }

        protected override void OnDesktopUpdate()
        {
            base.OnDesktopUpdate();

            pnloldcolour.BackColor = OldColor;
            lbloldcolourname.Text = $"{OldColor.Name} :Name";
            lbloldcolourrgb.Text = $"{OldColor.R} {OldColor.G} {OldColor.B} :RGB";

            var NewColor = pnlnewcolour.BackColor;
            lblnewcolourname.Text = $"{NewColor.Name} :Name";
            lblnewcolourrgb.Text = $"{NewColor.R} {NewColor.G} {NewColor.B} :RGB";

            // Determine color levels based on Shiftorium state.
            determinelevels();

            // Set color level visibility.
            pnlgraycolours.Visible = graylevel > 0;
            pnlredcolours.Visible = redlevel > 0;
            pnlgreencolours.Visible = greenlevel > 0;
            pnlbluecolours.Visible = bluelevel > 0;
            pnlorangecolours.Visible = orangelevel > 0;
            pnlyellowcolours.Visible = yellowlevel > 0;
            pnlpinkcolours.Visible = pinklevel > 0;
            pnlpurplecolours.Visible = purplelevel > 0;
            pnlbrowncolours.Visible = brownlevel > 0;
            pnlanycolours.Visible = anylevel > 0;

            // Set color level text.
            lblgraylevel.Text = $"Level {graylevel}";
            lblredlevel.Text = $"Level {redlevel}";
            lblgreenlevel.Text = $"Level {greenlevel}";
            lblbluelevel.Text = $"Level {bluelevel}";
            lblyellowlevel.Text = $"Level {yellowlevel}";
            lblorangelevel.Text = $"Level {orangelevel}";
            lblpinklevel.Text = $"Level {pinklevel}";
            lblpurplelevel.Text = $"Level {purplelevel}";
            lblbrownlevel.Text = $"Level {brownlevel}";
            lblanylevel.Text = $"Level {anylevel}";

            // Determine the actual colors.
            determinecolor(pnlgraycolours, graylevel, "gray");
            determinecolor(pnlredcolours, redlevel, "red");
            determinecolor(pnlgreencolours, greenlevel, "green");
            determinecolor(pnlbluecolours, bluelevel, "blue");
            determinecolor(pnlyellowcolours, yellowlevel, "yellow");
            determinecolor(pnlorangecolours, orangelevel, "orange");
            determinecolor(pnlpinkcolours, pinklevel, "pink");
            determinecolor(pnlpurplecolours, purplelevel, "purple");
            determinecolor(pnlbrowncolours, brownlevel, "brown");
            determinecolor(pnlanycolours, anylevel, "any");

        }
    }
}
