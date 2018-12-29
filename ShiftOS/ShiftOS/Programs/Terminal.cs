using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftOS.Windowing;
using ShiftOS.Metadata;
using System.Windows.Forms;

namespace ShiftOS.Programs
{
    [Program("terminal", "Terminal", "Run commands in a bash-like shell.")]
    public partial class Terminal : Window
    {
        public Terminal()
        {
            InitializeComponent();
        }

        private void TerminalControl_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
