using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftOS.Windowing;
using ShiftOS.Metadata;
using System.Windows.Forms;

namespace ShiftOS.Programs
{
    [Program("textpad", "TextPad", "Write and edit text documents.")]
    [Requires("textpad")]
    [AppLauncherRequirement("altextpad")]
    public partial class TextPad : Window
    {
        public TextPad()
        {
            InitializeComponent();
        }

        protected override void OnDesktopUpdate()
        {
            base.OnDesktopUpdate();

            pnloptions.Visible = CurrentSystem.HasShiftoriumUpgrade("textpadnew") | CurrentSystem.HasShiftoriumUpgrade("textpadopen") || CurrentSystem.HasShiftoriumUpgrade("textpadsave");

            btnnew.Visible = CurrentSystem.HasShiftoriumUpgrade("textpadnew");
            btnopen.Visible = CurrentSystem.HasShiftoriumUpgrade("textpadopen");
            btnsave.Visible = CurrentSystem.HasShiftoriumUpgrade("textpadsave");
            
            pnlbreak.Visible = pnloptions.Visible;
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            txtuserinput.Text = "";
        }

        private void btnopen_Click(object sender, EventArgs e)
        {
            CurrentSystem.AskForFile(new[] { ".txt" }, false, (path) =>
            {
                var fs = CurrentSystem.GetFilesystem();
                txtuserinput.Text = fs.ReadAllText(path);
                return true;
            });
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            CurrentSystem.AskForFile(new[] { ".txt" }, true, (path) =>
            {
                var fs = CurrentSystem.GetFilesystem();
                fs.WriteAllText(path, txtuserinput.Text);
                return true;
            });
        }
    }
}
