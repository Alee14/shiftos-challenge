using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShiftOS.Metadata;
using ShiftOS.Windowing;
using System.Reflection;
using System.Threading.Tasks;

namespace ShiftOS
{
    public class SystemContext : IDisposable
    {
        private Desktop _desktop = null;
        private SkinContext _skinContext = null;
        private FilesystemContext _filesystem = null;
        private int _codepoints = 0;
        private List<Window> _windows = new List<Window>();
        private Dictionary<string, Type> _programTypeMap = new Dictionary<string, Type>();
        private List<ProgramAttribute> _programMetadata = new List<ProgramAttribute>();


        public event EventHandler DesktopUpdated;

        public bool HasShiftoriumUpgrade(string InUpgrade)
        {
            // TODO: Shiftorium.
            return true;
        }

        public bool LaunchProgram(string InExecutableName)
        {
            // Does the program exist in our typemap?
            if (!_programTypeMap.ContainsKey(InExecutableName))
            {
                // Program doesn't exist.
                return false;
            }

            Type ProgramType = this._programTypeMap[InExecutableName];

            // TODO: Check if the program is installed...

            // Create the program window.
            var window = (Window)Activator.CreateInstance(ProgramType, null);

            // Log that we've launched the program
            Console.WriteLine(" --> Opening {0}...", window.WindowTitle);

            // Set the system context of the window.
            window.SetSystemContext(this);
            _windows.Add(window);
            window.Show();

            window.FormClosed += (o, a) =>
            {
                _windows.Remove(window);
                Console.WriteLine(" --> Closed {0}", window.WindowTitle);
            };

            // Program was successfully launched.
            return true;
        }

        public IEnumerable<string> GetInstalledPrograms()
        {
            // TODO: Check if programs are installed/unlocked first.
            foreach(var program in _programMetadata.OrderBy(x=>x.FriendlyName))
            {
                yield return program.ExecutableName;
            }
        }

        public List<Window> GetWindows()
        {
            return _windows;
        }

        public string GetProgramName(string InExecutableName)
        {
            // TODO: Check if the program is installed or unlocked.
            return this._programMetadata.FirstOrDefault(x => x.ExecutableName == InExecutableName)?.FriendlyName;
        }

        private void LoadProgramData()
        {
            Console.WriteLine("Loading program metadata...");
            foreach(var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if(type.BaseType == typeof(Window))
                {
                    ProgramAttribute ProgramData = type.GetCustomAttributes(false).FirstOrDefault(x => x is ProgramAttribute) as ProgramAttribute;
                    if(ProgramData != null)
                    {
                        if(this._programTypeMap.ContainsKey(ProgramData.ExecutableName))
                        {
                            throw new InvalidOperationException("Duplicate programs found.");
                        }

                        Console.WriteLine(" --> Found {0} ({1}) in {2}.", ProgramData.ExecutableName, ProgramData.FriendlyName, type.FullName);
                        this._programMetadata.Add(ProgramData);
                        this._programTypeMap.Add(ProgramData.ExecutableName, type);
                    }
                }
            }
        }

        private void LoadCurrentSkin()
        {
            // TODO: Load it from a filesystem of some sort.
            _skinContext = new SkinContext();

            _skinContext.LoadFromDisk(this);
        }

        private void LoadFilesystem()
        {
            Console.WriteLine("Loading filesystem context...");
            this._filesystem = new FilesystemContext();

            _filesystem.CreateDirectory("/Home");
            _filesystem.CreateDirectory("/Home/Desktop");
            _filesystem.CreateDirectory("/Home/Documents");
            _filesystem.CreateDirectory("/Home/Music");
            _filesystem.CreateDirectory("/Home/Pictures");
            _filesystem.CreateDirectory("/Home/Videos");
            _filesystem.CreateDirectory("/Shiftum42");
            _filesystem.CreateDirectory("/Shiftum42/Drivers");
            _filesystem.CreateDirectory("/Shiftum42/Languages");
            _filesystem.CreateDirectory("/Shiftum42/Skins");
            _filesystem.CreateDirectory("/SoftwareData");
            _filesystem.CreateDirectory("/SoftwareData/KnowledgeInput");


        }

        public void Dispose()
        {
            _desktop = null;
        }

        public void UpdateDesktop()
        {
            DesktopUpdated?.Invoke(this, EventArgs.Empty);
        }

        public int GetCodepoints()
        {
            return this._codepoints;
        }

        public FilesystemContext GetFilesystem()
        {
            return this._filesystem;
        }

        public SkinContext GetSkinContext()
        {
            return this._skinContext;
        }

        public void Initialize()
        {
            // We can't initialize the game twice.
            if (_desktop != null)
                throw new InvalidOperationException("ShiftOS is already initialized.");

            Console.WriteLine("Bootstrapping WinForms...");

            // Set up WinForms to run normally.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            ToolStripManager.Renderer = new ToolStripSkinRenderer(this);

            // Load all programs in the game.
            this.LoadProgramData();

            // Load up the filesystem.
            this.LoadFilesystem();

            Console.WriteLine("Loading current skin...");
            this.LoadCurrentSkin();

            Console.WriteLine("Loading desktop...");
            using (_desktop = new Desktop(this))
            {
                // Run Windows Forms.
                Application.Run(_desktop);
            }
        }

        public string GetTimeOfDay()
        {
            // TODO: Shiftorium time upgrades.
            return DateTime.Now.ToShortTimeString();
        }
    }
}
