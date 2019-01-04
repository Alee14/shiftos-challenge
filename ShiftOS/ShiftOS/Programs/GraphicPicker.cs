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

namespace ShiftOS.Programs
{
    public partial class GraphicPicker : Window
    {
        public Image CurrentGraphic { get; set; }
        public ImageLayout CurrentLayout { get; set; } = ImageLayout.Center;
        public Action<Image, ImageLayout> Callback { get; set; }
        public string GraphicName { get => lblobjecttoskin.Text; set => lblobjecttoskin.Text = value; }

        public GraphicPicker()
        {
            InitializeComponent();
        }

        protected override void OnDesktopUpdate()
        {
            picgraphic.BackgroundImage = CurrentGraphic;
            picgraphic.BackgroundImageLayout = CurrentLayout;

            picidle.BackgroundImage = CurrentGraphic;
            picidle.BackgroundImageLayout = CurrentLayout;

            btntile.BackgroundImage = (CurrentLayout == ImageLayout.Tile) ? Properties.Resources.tilebuttonpressed : Properties.Resources.tilebutton;
            btncentre.BackgroundImage = (CurrentLayout == ImageLayout.Center) ? Properties.Resources.centrebuttonpressed : Properties.Resources.centrebutton;
            btnstretch.BackgroundImage = (CurrentLayout == ImageLayout.Stretch) ? Properties.Resources.stretchbuttonpressed : Properties.Resources.stretchbutton;
            btnzoom.BackgroundImage = (CurrentLayout == ImageLayout.Zoom) ? Properties.Resources.zoombuttonpressed : Properties.Resources.zoombutton;

            base.OnDesktopUpdate();
        }

        private void btnidlebrowse_Click(object sender, EventArgs e)
        {
            CurrentSystem.AskForFile(new[]
            {
                ".pic",
                ".png",
                ".jpg",
                ".jpeg",
                ".bmp",
                ".gif"
            }, false, (path) =>
            {
                try
                {
                        if (CurrentGraphic != null)
                            CurrentGraphic.Dispose();
                    CurrentGraphic = CurrentSystem.GetFilesystem().LoadImage(path);
                    return true;
                }
                catch
                {
                    CurrentSystem.ShowInfo("Graphic Picker", "Graphic Picker could not open the graphic you selected.");
                    return false;
                }
            });
        }

        private void btntile_Click(object sender, EventArgs e)
        {
            CurrentLayout = ImageLayout.Tile;
        }

        private void btncentre_Click(object sender, EventArgs e)
        {
            CurrentLayout = ImageLayout.Center;
        }

        private void btnstretch_Click(object sender, EventArgs e)
        {
            CurrentLayout = ImageLayout.Stretch;
        }

        private void btnzoom_Click(object sender, EventArgs e)
        {
            CurrentLayout = ImageLayout.Zoom;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            CurrentGraphic = null;
            CurrentLayout = ImageLayout.Center;
        }

        private void btnapply_Click(object sender, EventArgs e)
        {
            Callback?.Invoke(CurrentGraphic, CurrentLayout);
            Close();
        }
    }
}
