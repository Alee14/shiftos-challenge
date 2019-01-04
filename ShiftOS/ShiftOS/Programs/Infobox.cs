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
using System.Media;

namespace ShiftOS.Programs
{
    public partial class Infobox : Window
    {
        public Infobox()
        {
            InitializeComponent();
        }

        public string Info { get => txtmessage.Text; set => txtmessage.Text = value; }
        public InfoboxMode Mode { get; set; } = InfoboxMode.Regular;

        public Func<string, bool> TextSubmitted { get; set; }
        public Action<bool> ChoiceMade { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            using (var sp = new SoundPlayer(Properties.Resources.infobox))
            {
                sp.Play();
            }

            base.OnLoad(e);
        }

        protected override void OnDesktopUpdate()
        {
            switch (Mode)
            {
                case InfoboxMode.Regular:
                    pnlyesno.Hide();
                    txtuserinput.Hide();
                    break;
                case InfoboxMode.YesNo:
                    pnlyesno.Show();
                    txtuserinput.Hide();
                    break;
                case InfoboxMode.TextInput:
                    pnlyesno.Hide();
                    txtuserinput.Show();
                    break;
            }

            base.OnDesktopUpdate();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if(Mode == InfoboxMode.TextInput)
            {
                if(TextSubmitted == null)
                {
                    Close();
                    return;
                }

                bool result = TextSubmitted.Invoke(txtuserinput.Text);

                if(result)
                {
                    Close();
                    return;
                }
            }
            else
            {
                Close();
            }
        }

        private void btnyes_Click(object sender, EventArgs e)
        {
            ChoiceMade?.Invoke(true);
            Close();
        }

        private void btnno_Click(object sender, EventArgs e)
        {
            ChoiceMade?.Invoke(false);
            Close();
        }
    }

    public enum InfoboxMode
    {
        Regular,
        YesNo,
        TextInput
    }
}
