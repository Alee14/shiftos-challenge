using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace ShiftOS
{
    public class SkinContext
    {
        const string PHIL_SKIN_00X_FORMAT_HEADER = "ShiftOS skin data - Beware: Editing may result in skinning errors";
        const int PHIL_OLD_IMAGE_COUNT = 50;

        private Dictionary<string, Image> _skinimages = new Dictionary<string, Image>();
        private Skin _skin = null;

        public SkinContext()
        {
            _skin = new Skin();
        }

        public Skin GetSkinData()
        {
            return _skin;
        }

        public void LoadFromDisk(SystemContext InSystemContext)
        {
            var fs = InSystemContext.GetFilesystem();

            if(!fs.DirectoryExists("/Shiftum42/Skins/Loaded") || !fs.FileExists("/Shiftum42/Skins/Loaded/data.dat"))
            {
                fs.CreateDirectory("/Shiftum42/Skins/Loaded");

                _skin = new Skin();
                _skinimages = new Dictionary<string, Image>();

                Console.WriteLine("No existing skin found. Writing default skin as Michael skin format...");

                fs.WriteAllText("/Shiftum42/Skins/Loaded/data.dat", JsonConvert.SerializeObject(_skin));
            }
            else
            {
                _skinimages.Clear();

                Console.WriteLine("Existing skin found.");
                Console.WriteLine("Opening skin data...");

                using (var stream = fs.OpenText("/Shiftum42/Skins/Loaded/data.dat"))
                {
                    Console.WriteLine(" --> Determining skin format...");

                    // Michael format is JSON, Phil format is not. JSON must start with a "{".
                    if(stream.Peek() == '{')
                    {
                        Console.WriteLine(" --> Detected Michael-formatted skin.");

                        _skin = JsonConvert.DeserializeObject<Skin>(stream.ReadToEnd());

                        Console.WriteLine(" --> JSON skin data loaded.");
                    }
                    else
                    {
                        Console.WriteLine(" --> Detected Philip Skin.");
                        Console.WriteLine(" --> Ladies and gentlemen, fasten your seatbelts. This is gonna fucking suck.");

                        LoadPhilipSkin(fs, stream);
                    }
                }

                Console.WriteLine(" --> Done loading skin data file.");

                if (_skinimages.Keys.Count == 0)
                {
                    Console.WriteLine(" --> Loading images...");


                    foreach (var path in fs.GetFiles("/Shiftum42/Skins/Loaded"))
                    {
                        if (!path.EndsWith("data.dat"))
                        {
                            using (var stream = fs.OpenRead(path))
                            {
                                var image = Image.FromStream(stream);

                                string filenameWithoutExtension = Path.GetFileNameWithoutExtension(path);

                                Console.WriteLine(" --> Loaded: {0}", path);
                                Console.WriteLine(" --> Storing as: {0}", filenameWithoutExtension);

                                _skinimages.Add(filenameWithoutExtension, image);
                            }
                        }
                    }
                }
            }

        }

        private void LoadOldPhilipSkin(FilesystemContext fs, StreamReader stream)
        {
            _skin = new Skin();

            // First line is the title bar color.
            Console.WriteLine(" --> Read titlebar color");
            _skin.titlebarcolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));

            // Line 2 is window border color, no individual colors it seems.
            Console.WriteLine(" --> Read window border color");
            _skin.borderleftcolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.borderrightcolour = _skin.borderleftcolour;
            _skin.borderbottomcolour = _skin.borderleftcolour;

            // Line 3 is the window border size.
            Console.WriteLine(" --> Read border width");
            _skin.borderwidth = Convert.ToInt32(stream.ReadLine());

            // Line 4 is the title bar's height.
            Console.WriteLine(" --> Read title height");
            _skin.titlebarheight = Convert.ToInt32(stream.ReadLine());

            // Next 5 lines are all the close button's data.
            Console.WriteLine(" --> Read close button color");
            _skin.closebtncolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));

            Console.WriteLine(" --> Read close button size");
            int closeHeight = Convert.ToInt32(stream.ReadLine());
            int closeWidth = Convert.ToInt32(stream.ReadLine());
            _skin.closebtnsize = new Size(closeWidth, closeHeight);

            Console.WriteLine(" --> Read close button position");
            _skin.closebtnfromside = Convert.ToInt32(stream.ReadLine());
            _skin.closebtnfromtop = Convert.ToInt32(stream.ReadLine());

            // Next 3 lines are the title text color and position.
            Console.WriteLine(" --> Read title text color");
            _skin.titletextcolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));

            Console.WriteLine(" --> Read absolute title text position");
            _skin.titletextfromtop = Convert.ToInt32(stream.ReadLine());
            _skin.titletextfromside = Convert.ToInt32(stream.ReadLine());

            Console.WriteLine(" --> Read title text font");
            // Next 3 lines are a font descriptor for the title text.
            _skin.titletextfontsize = Convert.ToInt32(stream.ReadLine());
            _skin.titletextfontfamily = stream.ReadLine();
            _skin.titletextfontstyle = (FontStyle)Convert.ToInt32(stream.ReadLine());

            PhilLoadDesktopPanelAndClock(stream);
            PhilLoadAppLauncher(stream);

            Console.WriteLine(" --> Read roll button color");
            _skin.rollbtncolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));

            Console.WriteLine(" --> Read roll button size");
            int rollHeight = Convert.ToInt32(stream.ReadLine());
            int rollWidth = Convert.ToInt32(stream.ReadLine());
            _skin.rollbtnsize = new Size(rollWidth, rollHeight);

            Console.WriteLine(" --> Read roll button position");
            _skin.rollbtnfromside = Convert.ToInt32(stream.ReadLine());
            _skin.rollbtnfromtop = Convert.ToInt32(stream.ReadLine());

            Console.WriteLine(" --> Read title icon position");
            _skin.titleiconfromside = Convert.ToInt32(stream.ReadLine());
            _skin.titleiconfromtop = Convert.ToInt32(stream.ReadLine());

            Console.WriteLine(" --> Read enable window corners...");
            _skin.enablecorners = bool.Parse(stream.ReadLine());
            _skin.enablebordercorners = _skin.enablecorners;

            Console.WriteLine(" --> Read titlebar corner width...");
            _skin.titlebarcornerwidth = Convert.ToInt32(stream.ReadLine());

            Console.WriteLine(" --> Read titlebar corner colors");
            _skin.rightcornercolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.leftcornercolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));

            Console.WriteLine(" --> Read app launcher menu holder width");
            _skin.applaunchermenuholderwidth = Convert.ToInt32(stream.ReadLine());

            /// WARNING: Trey, if you're looking at this, I know this code looks like burning canine defecation.
            /// So is Phil's 0.0.7 skin format. All these properties aren't even in the format, they were just
            /// patched in - i.e, you need to check if they're there. FUCK.
            string line = stream.ReadLine();
            if(!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read left border color");
                _skin.borderleftcolour = Color.FromArgb(Convert.ToInt32(line));
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read right border color");
                _skin.borderrightcolour = Color.FromArgb(Convert.ToInt32(line));
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read bottom border color");
                _skin.borderbottomcolour = Color.FromArgb(Convert.ToInt32(line));
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read bottom left border color");
                _skin.bottomleftcornercolour = Color.FromArgb(Convert.ToInt32(line));
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read bottom right border color");
                _skin.bottomrightcornercolour = Color.FromArgb(Convert.ToInt32(line));
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read panel button icon from top");
                _skin.panelbuttonicontop = Convert.ToInt32(line);
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read panel button icon from side");
                _skin.panelbuttoniconside = Convert.ToInt32(line);
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read panel button icon size");
                _skin.panelbuttoniconsize = Convert.ToInt32(line);
            }

            // Skip the next line - duplicate of above
            stream.ReadLine();

            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read panel button height");
                _skin.panelbuttonheight = Convert.ToInt32(line);
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read panel button width");
                _skin.panelbuttonwidth = Convert.ToInt32(line);
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read panel button color");
                _skin.panelbuttoncolour = Color.FromArgb(Convert.ToInt32(line));
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read panel button text color");
                _skin.panelbuttontextcolour = Color.FromArgb(Convert.ToInt32(line));
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read panel button text size");
                _skin.panelbuttontextsize = Convert.ToInt32(line);
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read panel button text font");
                _skin.panelbuttontextfont = line;
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read panel button text style");
                _skin.panelbuttontextstyle = (FontStyle)Convert.ToInt32(line);
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read panel button text side");
                _skin.panelbuttontextside = Convert.ToInt32(line);
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read panel button text top");
                _skin.panelbuttontexttop = Convert.ToInt32(line);
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read panel button gap");
                _skin.panelbuttongap = Convert.ToInt32(line);
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read panel button from top");
                _skin.panelbuttonfromtop = Convert.ToInt32(line);
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read panel button initial gap");
                _skin.panelbuttoninitialgap = Convert.ToInt32(line);
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read minimize button color");
                _skin.minbtncolour = Color.FromArgb(Convert.ToInt32(line));
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read minimize size");
                _skin.minbtnsize = new Size(Convert.ToInt32(stream.ReadLine()), Convert.ToInt32(line));
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read minimize button from side");
                _skin.minbtnfromside = Convert.ToInt32(line);
            }
            line = stream.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(" --> Read minimize button from top");
                _skin.minbtnfromtop = Convert.ToInt32(line);
            }

            // BLANK AREA
            //
            // Presumably this area is for newer features that were implemented in 0.0.8,
            // but never made it into this format because of the 0.0.8 format being implemented
            // by William.

            for(int i = 0; i < (100 - 73) - 1; i++)
            {
                stream.ReadLine();
            }

            // IMAGE LOADER.
            //
            // 0.0.7 skins store direct paths (in Windows) to image assets.
            // In order for us to load them, we need to get their file names and map them to in-game paths.
            // Why, oh why, did Phil do this...

            Console.WriteLine(" --> Reading image file paths from 0.0.7 skin data...");

            string[] ImageFileNames = new string[PHIL_OLD_IMAGE_COUNT];

            for(int i = 0; i < ImageFileNames.Length; i++)
            {
                string path = stream.ReadLine();
                ImageFileNames[i] = "/Shiftum42/Skins/Loaded/" + Path.GetFileName(path);
            }

            _skinimages.Add("closebtn", GetImage(fs, ImageFileNames[0]));
            _skinimages.Add("closebtnhover", GetImage(fs, ImageFileNames[1]));
            _skinimages.Add("closebtnclick", GetImage(fs, ImageFileNames[2]));
            _skinimages.Add("titlebar", GetImage(fs, ImageFileNames[3]));
            _skinimages.Add("desktopbackground", GetImage(fs, ImageFileNames[6]));
            _skinimages.Add("rollbtn", GetImage(fs, ImageFileNames[9]));
            _skinimages.Add("rollbtnhover", GetImage(fs, ImageFileNames[10]));
            _skinimages.Add("rollbtnclick", GetImage(fs, ImageFileNames[11]));
            _skinimages.Add("rightcorner", GetImage(fs, ImageFileNames[12]));
            _skinimages.Add("leftcorner", GetImage(fs, ImageFileNames[15]));
            _skinimages.Add("desktoppanel", GetImage(fs, ImageFileNames[18]));
            _skinimages.Add("panelclock", GetImage(fs, ImageFileNames[21]));
            _skinimages.Add("applauncher", GetImage(fs, ImageFileNames[24]));
            _skinimages.Add("applaunchermouseover", GetImage(fs, ImageFileNames[25]));
            _skinimages.Add("applauncherclick", GetImage(fs, ImageFileNames[26]));
            _skinimages.Add("borderleft", GetImage(fs, ImageFileNames[27]));
            _skinimages.Add("borderright", GetImage(fs, ImageFileNames[30]));
            _skinimages.Add("borderbottom", GetImage(fs, ImageFileNames[33]));
            _skinimages.Add("bottomrightcorner", GetImage(fs, ImageFileNames[36]));
            _skinimages.Add("bottomleftcorner", GetImage(fs, ImageFileNames[39]));
            _skinimages.Add("minbtn", GetImage(fs, ImageFileNames[42]));
            _skinimages.Add("minbtnhover", GetImage(fs, ImageFileNames[43]));
            _skinimages.Add("minbtnclick", GetImage(fs, ImageFileNames[44]));
            _skinimages.Add("panelbutton", GetImage(fs, ImageFileNames[45]));

        }

        private Image GetImage(FilesystemContext fs, string path)
        {
            if (!fs.FileExists(path))
                return null;
            using (var stream = fs.OpenRead(path))
            {
                return Image.FromStream(stream);
            }
        }

        private void PhilLoadDesktopPanelAndClock(StreamReader stream)
        {
            Console.WriteLine(" --> Read desktop panel color");
            _skin.desktoppanelcolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));

            Console.WriteLine(" --> Read desktop background color");
            _skin.desktopbackgroundcolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));

            Console.WriteLine(" --> Read desktop panel height");
            _skin.desktoppanelheight = Convert.ToInt32(stream.ReadLine());

            Console.WriteLine(" --> Read desktop panel position");
            _skin.desktoppanelposition = stream.ReadLine();

            Console.WriteLine(" --> Read panel clock text and background color");
            _skin.clocktextcolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.clockbackgroundcolor = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));

            Console.WriteLine(" --> Read desktop panel clock position");
            _skin.panelclocktexttop = Convert.ToInt32(stream.ReadLine());

            Console.WriteLine(" --> Read desktop panel clock font");
            _skin.panelclocktextsize = Convert.ToInt32(stream.ReadLine());
            _skin.panelclocktextfont = stream.ReadLine();
            _skin.panelclocktextstyle = (FontStyle)Convert.ToInt32(stream.ReadLine());

            
        }

        private void LoadPhilipSkin(FilesystemContext fs, StreamReader stream)
        {
            // Skip the first line in the file for it is a header.
            string head = stream.ReadLine();

            if(head == PHIL_SKIN_00X_FORMAT_HEADER)
            {
                Console.WriteLine(" --> Detected 0.0.8 skin file.");
                Console.WriteLine(" --> {0}", head);
            }
            else
            {
                Console.WriteLine(" --> Detected 0.0.7 skin file.");
                stream.BaseStream.Position = 0;
                stream.DiscardBufferedData();
                LoadOldPhilipSkin(fs, stream);
                return;
            }
            
            _skin = new Skin();

            // First 6 lines are the title button sizes.
            _skin.closebtnsize = new Size(Convert.ToInt32(stream.ReadLine()), Convert.ToInt32(stream.ReadLine()));
            _skin.rollbtnsize = new Size(Convert.ToInt32(stream.ReadLine()), Convert.ToInt32(stream.ReadLine()));
            _skin.minbtnsize = new Size(Convert.ToInt32(stream.ReadLine()), Convert.ToInt32(stream.ReadLine()));

            // Line 7 is the title bar height.
            _skin.titlebarheight = Convert.ToInt32(stream.ReadLine());

            // Next 6 lines are the title button positions.
            _skin.closebtnfromtop = Convert.ToInt32(stream.ReadLine());
            _skin.closebtnfromside = Convert.ToInt32(stream.ReadLine());
            _skin.rollbtnfromtop = Convert.ToInt32(stream.ReadLine());
            _skin.rollbtnfromside = Convert.ToInt32(stream.ReadLine());
            _skin.minbtnfromtop = Convert.ToInt32(stream.ReadLine());
            _skin.minbtnfromside = Convert.ToInt32(stream.ReadLine());

            // Line 14 is the uniform window border width, for skins that don't set individual border widths.
            _skin.borderwidth = Convert.ToInt32(stream.ReadLine());

            // Line 15 contains whether title corners are enabled.
            _skin.enablecorners = bool.Parse(stream.ReadLine());

            // Line 16 is the width of those corners.
            _skin.titlebarcornerwidth = Convert.ToInt32(stream.ReadLine());

            Console.WriteLine(" --> Read title icon position");
            _skin.titleiconfromside = Convert.ToInt32(stream.ReadLine());
            _skin.titleiconfromtop = Convert.ToInt32(stream.ReadLine());

            // Next 4 lines are packed RGB values for the titlebar and window border colors.
            _skin.titlebarcolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.borderleftcolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.borderrightcolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.borderbottomcolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));

            // Next 9 lines are packed RGB values for the background colors for each state of the three title buttons.
            _skin.closebtncolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.closebtnhovercolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.closebtnclickcolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.rollbtncolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.rollbtnhovercolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.rollbtnclickcolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.minbtncolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.minbtnhovercolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.minbtnclickcolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));

            // Next 4 lines are packed RGB values for the window border corner colors.
            _skin.rightcornercolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.leftcornercolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.bottomrightcornercolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.bottomleftcornercolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));

            // Next 3 lines are a font descriptor for the title text.
            _skin.titletextfontfamily = stream.ReadLine();
            _skin.titletextfontsize = Convert.ToInt32(stream.ReadLine());
            _skin.titletextfontstyle = (FontStyle)Convert.ToInt32(stream.ReadLine());

            // Line 38 is a string representing the title text position - centered or
            // left. Why Phil decided a string is a good idea instead of a boolean, we may never know.
            _skin.titletextpos = stream.ReadLine();

            // And right after that - line 39 and 40 - is the position for the title text as a 2d point.
            _skin.titletextfromtop = Convert.ToInt32(stream.ReadLine());
            _skin.titletextfromside = Convert.ToInt32(stream.ReadLine());

            // Line 41 is the title text color.
            _skin.titletextcolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));

            PhilLoadDesktopPanelAndClock(stream);

            PhilLoadAppLauncher(stream);

        }

        private void PhilLoadAppLauncher(StreamReader stream)
        {
            Console.WriteLine(" --> Read app launcher button colors");
            _skin.applauncherbuttoncolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            _skin.applauncherbuttonclickedcolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));

            Console.WriteLine(" --> Read app launcher background color");
            _skin.applauncherbackgroundcolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));

            Console.WriteLine(" --> Read app launcher mouse over color");
            _skin.applaunchermouseovercolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));

            Console.WriteLine(" --> Read app launcher text color");
            _skin.applicationsbuttontextcolour = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));

            Console.WriteLine(" --> Read app launcher height");
            _skin.applicationbuttonheight = Convert.ToInt32(stream.ReadLine());

            Console.WriteLine(" --> Read App Launcher Font");
            _skin.applicationbuttontextsize = Convert.ToInt32(stream.ReadLine());
            _skin.applicationbuttontextfont = stream.ReadLine();
            _skin.applicationbuttontextstyle = (FontStyle)Convert.ToInt32(stream.ReadLine());

            Console.WriteLine(" --> Read App Launcher Name");
            _skin.applicationlaunchername = stream.ReadLine();

            Console.WriteLine(" --> Read Title Text Position");
            _skin.titletextpos = stream.ReadLine();
        }

        public bool HasImage(string ImageKey)
        {
            return _skinimages.ContainsKey(ImageKey) && (_skinimages[ImageKey] != null);
        }

        public Image GetImage(string ImageKey)
        {
            if(_skinimages.ContainsKey(ImageKey))
            {
                return _skinimages[ImageKey];
            }
            return null;
        }
    }
}
