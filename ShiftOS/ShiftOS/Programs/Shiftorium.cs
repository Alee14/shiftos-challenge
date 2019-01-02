using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftOS.Windowing;
using ShiftOS;
using ShiftOS.Metadata;
using System.Windows.Forms;

namespace ShiftOS.Programs
{
    [Program("shiftorium", "Shiftorium", "Buy upgrades for ShiftOS.")]
    [AppLauncherRequirement("alshiftorium")]
    public partial class Shiftorium : Window
    {
        private Upgrade _currentUpgrade = null;
        private bool _started = false;

        public Shiftorium()
        {
            InitializeComponent();
        }

        private void UpdateUpgradeInfo()
        {
            if(_currentUpgrade!=null)
            {
                if (CurrentSystem.HasShiftoriumUpgrade(_currentUpgrade.ID))
                {
                    lbupgradename.Font = new Font("teen", 13, FontStyle.Bold);
                    lbupgradename.Text = "Purchased " + _currentUpgrade.Name;
                    lbudescription.Text = _currentUpgrade.Tutorial;
                    lbprice.Font = new Font("teen", 16, FontStyle.Bold);
                    lbprice.Text = $"Bought for {_currentUpgrade.Cost} CP";
                    picpreview.Image = CurrentSystem.FindBitmapResource("upgrade" + _currentUpgrade.ID);
                    if (picpreview.Image == null)
                        picpreview.Image = CurrentSystem.FindBitmapResource(_currentUpgrade.ImageResource);
                    btnbuy.Hide();
                }
                else
                {
                    lbupgradename.Font = new Font("teen", 20, FontStyle.Bold);
                    lbupgradename.Text = _currentUpgrade.Name;
                    lbudescription.Text = _currentUpgrade.Description;
                    if(_currentUpgrade.CanBuy(CurrentSystem))
                    {
                        btnbuy.Text = "Buy";
                    }
                    else
                    {
                        btnbuy.Text = "Can't afford.";
                    }
                    lbprice.Font = new Font("teen", 26, FontStyle.Bold);
                    lbprice.Text = _currentUpgrade.Cost.ToString() + " CP";
                    picpreview.Image = CurrentSystem.FindBitmapResource("upgrade" + _currentUpgrade.ID);
                    if(picpreview.Image == null)
                        picpreview.Image = CurrentSystem.FindBitmapResource(_currentUpgrade.ImageResource);
                    btnbuy.Show();
                }
            }
        }

        private void ResetUpgrades()
        {
            lbupgrades.Items.Clear();
            foreach(var upgrade in CurrentSystem.GetUpgrades().OrderBy(x=>x.Name))
            {
                lbupgrades.Items.Add($"{upgrade.Name} - {upgrade.Cost} CP");
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ResetUpgrades();
        }

        protected override void OnDesktopUpdate()
        {
            this.lbcodepoints.Text = $"Codepoints: {this.CurrentSystem.GetCodepoints()}";

            base.OnDesktopUpdate();
        }

        private void lbupgrades_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
            }
            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            // On Error Resume Next - ahhhh, lovely VB code porting...
            try
            {
                using (var b = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(lbupgrades.GetItemText(lbupgrades.Items[e.Index]), e.Font, b, e.Bounds, sf);
                }
            }
            catch { }
            e.DrawFocusRectangle();
        }

        private void lbupgrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbupgrades.SelectedIndex >= 0)
            {
                if (!_started)
                {
                    pnlinfo.Location = new Point(351, 0);
                    pnlintro.Hide();
                    _started = true;
                }


                var item = lbupgrades.GetItemText(lbupgrades.SelectedItem);

                int dash = item.LastIndexOf("-");

                string name = item.Substring(0, dash - 1);

                int cost = int.Parse(item.Substring(dash + 2, (item.Length - 2) - (dash + 2)));

                var upgrade = CurrentSystem.GetUpgrades().FirstOrDefault(x => x.Name == name && x.Cost == cost);

                _currentUpgrade = upgrade;

                UpdateUpgradeInfo();
            }
        }

        private void btnbuy_Click(object sender, EventArgs e)
        {
            if(_currentUpgrade!=null)
            {
                if(_currentUpgrade.CanBuy(CurrentSystem))
                {
                    CurrentSystem.Buy(_currentUpgrade);
                    ResetUpgrades();
                    UpdateUpgradeInfo();
                    
                }
            }
        }
    }
}
