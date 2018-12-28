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
            this.CurrentTime.Text = CurrentSystem.GetTimeOfDay();
        }
    }
}
