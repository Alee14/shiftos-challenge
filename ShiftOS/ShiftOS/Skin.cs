using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ShiftOS
{
    public class Skin
    {
        // WINDOW SETTINGS/IMAGES
        public ImageLayout titlebarlayout = ImageLayout.Stretch;
        public ImageLayout borderleftlayout = ImageLayout.Stretch;
        public ImageLayout borderrightlayout = ImageLayout.Stretch;
        public ImageLayout borderbottomlayout = ImageLayout.Stretch;
        public ImageLayout closebtnlayout = ImageLayout.Stretch;
        public ImageLayout rollbtnlayout = ImageLayout.Stretch;
        public ImageLayout minbtnlayout = ImageLayout.Stretch;
        public ImageLayout rightcornerlayout = ImageLayout.Stretch;
        public ImageLayout leftcornerlayout = ImageLayout.Stretch;
        public ImageLayout bottomleftcornerlayout = ImageLayout.Stretch;
        public ImageLayout bottomrightcornerlayout = ImageLayout.Stretch;
        public Color bottomleftcornercolour = Color.Gray;
        public Color bottomrightcornercolour = Color.Gray;
        public bool enablebordercorners = false;

        //  settings
        public Size closebtnsize = new Size(22, 22);
        public Size rollbtnsize = new Size(22, 22);
        public Size minbtnsize = new Size(22, 22);
        public int titlebarheight = 30;
        public int closebtnfromtop = 5;
        public int closebtnfromside = 2;
        public int rollbtnfromtop = 5;
        public int rollbtnfromside = 26;
        public int minbtnfromtop = 5;
        public int minbtnfromside = 52;
        public int borderwidth = 2;
        public bool enablecorners = false;
        public int titlebarcornerwidth = 5;
        public int titleiconfromside = 4;
        public int titleiconfromtop = 4;
        // colours
        public Color titlebarcolour = Color.Gray;
        public Color borderleftcolour = Color.Gray;
        public Color borderrightcolour = Color.Gray;
        public Color borderbottomcolour = Color.Gray;
        public Color closebtncolour = Color.Black;
        public Color closebtnhovercolour = Color.Black;
        public Color closebtnclickcolour = Color.Black;
        public Color rollbtncolour = Color.Black;
        public Color rollbtnhovercolour = Color.Black;
        public Color rollbtnclickcolour = Color.Black;
        public Color minbtncolour = Color.Black;
        public Color minbtnhovercolour = Color.Black;
        public Color minbtnclickcolour = Color.Black;
        public Color rightcornercolour = Color.Gray;
        public Color leftcornercolour = Color.Gray;
        //  Text
        public string titletextfontfamily = "Microsoft Sans Serif";
        public int titletextfontsize = 10;
        public FontStyle titletextfontstyle = FontStyle.Bold;
        public int titletextfromtop = 3;
        public int titletextfromside = 24;
        public Color titletextcolour = Color.White;

        // DESKTOP
        public Color desktoppanelcolour = Color.Gray;
        public Color desktopbackgroundcolour = Color.Black;
        public int desktoppanelheight = 24;
        public string desktoppanelposition = "Top";
        public Color clocktextcolour = Color.Black;
        public Color clockbackgroundcolor = Color.Gray;
        public int panelclocktexttop = 3;
        public int panelclocktextsize = 10;
        public string panelclocktextfont = "Byington";
        public FontStyle panelclocktextstyle = FontStyle.Bold;
        public Color applauncherbuttoncolour = Color.Gray;
        public Color applauncherbuttonclickedcolour = Color.Gray;
        public Color applauncherbackgroundcolour = Color.Gray;
        public Color applaunchermouseovercolour = Color.White;
        public Color applicationsbuttontextcolour = Color.Black;
        public int applicationbuttonheight = 24;
        public int applicationbuttontextsize = 10;
        public string applicationbuttontextfont = "Byington";
        public FontStyle applicationbuttontextstyle = FontStyle.Bold;
        public string applicationlaunchername = "Applications";
        public string titletextposition = "Left";
        public int applaunchermenuholderwidth = 100;
        public int panelbuttonicontop = 3;
        public int panelbuttoniconside = 4;
        public int panelbuttoniconsize = 16;
        public int panelbuttonheight = 20;
        public int panelbuttonwidth = 185;
        public Color panelbuttoncolour = Color.Black;
        public Color panelbuttontextcolour = Color.White;
        public int panelbuttontextsize = 10;
        public string panelbuttontextfont = "Byington";
        public FontStyle panelbuttontextstyle = FontStyle.Regular;
        public int panelbuttontextside = 16;
        public int panelbuttontexttop = 2;
        public int panelbuttongap = 4;
        public int panelbuttonfromtop = 2;
        public int panelbuttoninitialgap = 8;

        public int launcheritemsize = 10;
        public string launcheritemfont = "Byington";
        public FontStyle launcheritemstyle = FontStyle.Regular;
        public Color launcheritemcolour = Color.Black;

        //  Images
        public ImageLayout desktoppanellayout = ImageLayout.Stretch;
        public ImageLayout desktopbackgroundlayout = ImageLayout.Stretch;
        public ImageLayout panelclocklayout = ImageLayout.Stretch;
        public ImageLayout applauncherlayout = ImageLayout.Stretch;
        public ImageLayout panelbuttonlayout = ImageLayout.Stretch;
    }
}
