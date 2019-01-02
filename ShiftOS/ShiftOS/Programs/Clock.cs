using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftOS.Metadata;
using ShiftOS.Windowing;
using System.Windows.Forms;

namespace ShiftOS.Programs
{
    [Program("clock", "Clock", "Show the current time of day.")]
    [Requires("clock")]
    [AppLauncherRequirement("alclock")]
    public partial class Clock : Window
    {
        public Clock()
        {
            InitializeComponent();
        }

        protected override void OnDesktopUpdate()
        {
            if(CurrentSystem.HasShiftoriumUpgrade("pmandam"))
            {
                toptext.Text = "The Time is";
                bottomtext.Hide();
            }
            else
            {
                toptext.Text = "Since midnight,";
                bottomtext.Show();

                if(CurrentSystem.HasShiftoriumUpgrade("hourssincemidnight"))
                {
                    bottomtext.Text = "hours have passed.";
                }
                else if(CurrentSystem.HasShiftoriumUpgrade("minutessincemidnight"))
                {
                    bottomtext.Text = "minutes have passed.";
                }
                else
                {
                    bottomtext.Text = "seconds have passed.";
                }
            }

            this.lbmaintime.Text = CurrentSystem.GetTimeOfDay();

            base.OnDesktopUpdate();
        }
    }
}
