using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShiftOS.Metadata;
using ShiftOS.Windowing;
using System.Reflection;
using Newtonsoft.Json;
using ShiftOS.Commands;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;

namespace ShiftOS
{
    public class SystemContext : IDisposable
    {
        private readonly byte[] SAVE_MAGIC = Encoding.UTF8.GetBytes("7R3Y");

        private string _username = "user";
        private string _osname = "shiftos";
        private Desktop _desktop = null;
        private SkinContext _skinContext = null;
        private FilesystemContext _filesystem = null;
        private int _codepoints = 0;
        private List<Window> _windows = new List<Window>();
        private Dictionary<string, Type> _programTypeMap = new Dictionary<string, Type>();
        private List<ProgramAttribute> _programMetadata = new List<ProgramAttribute>();
        private List<Upgrade> _upgrades = new List<Upgrade>();
        private List<string> _installedUpgrades = new List<string>();
        public event EventHandler DesktopUpdated;
        private List<TerminalCommand> _commands = new List<TerminalCommand>();

        public Bitmap FindBitmapResource(string id)
        {
            var type = typeof(Properties.Resources);

            var property = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Static).FirstOrDefault(x => x.Name == id && x.PropertyType == typeof(Bitmap));

            if (property == null)
                return null;

            return property.GetValue(null) as Bitmap;
        }

        private void LoadSaveFile()
        {
            Console.WriteLine("Loading save file...");
            if(File.Exists("shiftos.sav"))
            {
                Console.WriteLine(" --> Checking file type...");
                using (var stream = File.OpenRead("shiftos.sav"))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8))
                    {
                        byte[] magic = reader.ReadBytes(SAVE_MAGIC.Length);

                        if (!magic.SequenceEqual(SAVE_MAGIC))
                        {
                            MessageBox.Show($"Your ShiftOS save file is incompatible with this version of ShiftOS. We cannot load it.{Environment.NewLine}{Environment.NewLine}The game will ignore the existence of your save file.", "Invalid or incompatible save file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        int hashLengthBytes = reader.ReadInt32();
                        byte[] hash = reader.ReadBytes(hashLengthBytes);

                        int dataLengthBytes = reader.ReadInt32();
                        byte[] data = reader.ReadBytes(dataLengthBytes);

                        using (SHA256 sha = SHA256.Create())
                        {
                            if (!sha.ComputeHash(data).SequenceEqual(hash))
                            {
                                MessageBox.Show("Your save file has been tampered with. Trying to cheat, fucker? Okay, cool. We just won't load your save. Bitch.", "Ass-tastic attempt at cheating there, brah.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        using (var dataStream = new MemoryStream(data))
                        {
                            using (var dataReader = new BinaryReader(dataStream, Encoding.UTF8))
                            {
                                _codepoints = dataReader.ReadInt32();
                                _installedUpgrades = new List<string>();
                                int upgradeCount = dataReader.ReadInt32();
                                for (int i = 0; i < upgradeCount; i++)
                                {
                                    _installedUpgrades.Add(dataReader.ReadString());
                                }
                                _username = dataReader.ReadString();
                                _osname = dataReader.ReadString();
                            }
                        }
                    }
                }
            }
        }

        public void SaveGame()
        {
            using (var stream = File.Open("shiftos.sav", FileMode.OpenOrCreate))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8))
                {
                    writer.Write(SAVE_MAGIC);

                    byte[] hash = null;
                    byte[] data = null;

                    using (var dataStream = new MemoryStream())
                    {
                        using (var dataWriter = new BinaryWriter(dataStream, Encoding.UTF8, true))
                        {
                            dataWriter.Write(_codepoints);
                            dataWriter.Write(_installedUpgrades.Count);
                            foreach(var upgrade in _installedUpgrades)
                            {
                                dataWriter.Write(upgrade);
                            }
                            dataWriter.Write(_username);
                            dataWriter.Write(_osname);
                        }

                        data = dataStream.ToArray();
                    }

                    using (var sha = SHA256.Create())
                    {
                        hash = sha.ComputeHash(data);
                    }

                    writer.Write(hash.Length);
                    writer.Write(hash);
                    writer.Write(data.Length);
                    writer.Write(data);
                }
            }
        }

        public string Username { get => _username; set => _username = value; }
        public string OSName { get => _osname; set => _osname = value; }

        private void LoadTerminalCommands()
        {
            Console.WriteLine("Loading Terminal Commands...");

            var ass = Assembly.GetExecutingAssembly();

            var types = ass.GetTypes().Where(x => x.BaseType == typeof(TerminalCommand));

            foreach(var type in types)
            {
                var command = Activator.CreateInstance(type, null) as TerminalCommand;

                if(_commands.Any(x=>x.Name == command.Name))
                {
                    Console.WriteLine(" --> WARNING: Duplicate command: {0}", command.Name);
                    continue;
                }

                Console.WriteLine(" --> Loaded {0} ({1})", command.Name, type.FullName);
                _commands.Add(command);
            }
        }

        private string[] Tokenize(string InCommand, ref string OutputError)
        {
            // Port of some Peacenet UE4 code - doesn't use anything specific to Unreal so...
            List<string> tokens = new List<string>();
            string current = "";
            bool escaping = false;
            bool inQuote = false;

            int cmdLength = InCommand.Length;

            char[] cmd = InCommand.ToCharArray();

            for (int i = 0; i < cmdLength; i++)
            {
                char c = cmd[i];
                if (c == '\\')
                {
                    if (escaping == false)
                        escaping = true;
                    else
                    {
                        escaping = false;
                        current += c;
                    }
                    continue;
                }
                if (escaping == true)
                {
                    switch (c)
                    {
                        case ' ':
                            current+=' ';
                            break;
                        case 'n':
                            current+='\n';
                            break;
                        case 'r':
                            current+='\r';
                            break;
                        case 't':
                            current+='\t';
                            break;
                        case '"':
                            current+='"';
                            break;
                        default:
                            OutputError = "unrecognized escape sequence.";
                            return new string[0];
                    }
                    escaping = false;
                    continue;
                }
                if (c == ' ')
                {
                    if (inQuote)
                    {
                        current+=c;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(current))
                        {
                            tokens.Add(current);
                            current = "";
                        }
                    }
                    continue;
                }
                if (c == '"')
                {
                    inQuote = !inQuote;
                    if (!inQuote)
                    {
                        if (i + 1 < cmdLength)
                        {
                            if (cmd[i + 1] == '"')
                            {
                                OutputError = "String splice detected. Did you mean to use a literal double-quote (\\\")?";
                                return new string[0];
                            }
                        }
                    }
                    continue;
                }
                current+=c;
            }
            if (inQuote)
            {
                OutputError = "expected ending double-quote, got end of command instead.";
                return new string[0];
            }
            if (escaping)
            {
                OutputError = "expected escape sequence, got end of command instead.";
                return new string[0];
            }
            if (!string.IsNullOrEmpty(current))
            {
                tokens.Add(current);
                current = "";
            }
            return tokens.ToArray();

        }

        public void ExecuteCommand(IConsoleContext InConsole, string InCommand)
        {
            if (string.IsNullOrWhiteSpace(InCommand))
                return;

            string err = "";
            var tokens = Tokenize(InCommand, ref err);
            if(!string.IsNullOrWhiteSpace(err))
            {
                InConsole.WriteLine(err);
                return;
            }

            var installedCommand = GetInstalledCommands().FirstOrDefault(x => x.Name == tokens[0]);

            if(installedCommand == null)
            {
                InConsole.WriteLine("Command not found - type \"help\" for a list of commands.");
                return;
            }

            var docoptUsage = "Usage: " + installedCommand.Usage;

            var docoptArgv = tokens.Skip(1).ToArray();

            var docopt = new DocoptNet.Docopt();

            try
            {
                var docoptValues = docopt.Apply(docoptUsage, docoptArgv, false, null, true, false);

                Dictionary<string, object> realValues = new Dictionary<string, object>();

                foreach(var kvs in docoptValues)
                {
                    realValues.Add(kvs.Key, kvs.Value.Value);
                }

                installedCommand.Run(InConsole, realValues);
            }
            catch(Exception ex)
            {
                InConsole.WriteLine(ex.Message);
                return;
            }

        }

        public IEnumerable<TerminalCommand> GetInstalledCommands()
        {
            foreach (var command in _commands)
            {
                var type = command.GetType();
                var requirements = type.GetCustomAttributes(true).Where(x => x is RequiresAttribute);

                if (requirements.Count() == 0)
                {
                    yield return command;
                    continue;
                }
                if (requirements.Any(x => !(x as RequiresAttribute).IsFulfilled(this)))
                    continue;
                yield return command;
            }
        }

        public void AddCodepoints(int InCodepoints)
        {
            _codepoints += Math.Abs(InCodepoints);
        }

        public IEnumerable<Upgrade> GetUpgrades()
        {
            return _upgrades.Where(x => x.IsAvailable(this));
        }

        public bool Buy(Upgrade InUpgrade)
        {
            if (!InUpgrade.CanBuy(this))
            {
                return false;
            }
            _codepoints -= InUpgrade.Cost;
            _installedUpgrades.Add(InUpgrade.ID);
            Console.WriteLine(" --> Bought {0}", InUpgrade.Name);
            _desktop.ResetAppLauncher();
            this.SaveGame();
            return true;
        }

        private void LoadUpgrades()
        {
            Console.WriteLine("Loading Shiftorium upgrade database...");
            Console.WriteLine(" --> Loading internal resource DB...");

            _upgrades = JsonConvert.DeserializeObject<List<Upgrade>>(Properties.Resources.UpgradeDatabase);
            Console.WriteLine(" --> {0} upgrades loaded. Finalizing upgrade data...", _upgrades.Count);

            foreach(var upgrade in _upgrades)
            {
                Console.WriteLine(" --> Finalizing {0} ({1})...", upgrade.Name, upgrade.ID);
                upgrade.FinalizeUpgrade();
            }

        }

        public bool HasShiftoriumUpgrade(string InUpgrade)
        {
            return _installedUpgrades.Contains(InUpgrade);
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

            var requirements = ProgramType.GetCustomAttributes(true).Where(x => x is RequiresAttribute);

            if (requirements.Count() > 0)
            {
                if (requirements.Any(x => !(x as RequiresAttribute).IsFulfilled(this)))
                    return false;
            }

            // If we don't have multitasking, we need to close all existing windows.
            if(!HasShiftoriumUpgrade("multitasking"))
            {
                while(_windows.Count>0)
                {
                    _windows[0].Close();
                }
            }

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

        public bool IsAppLauncherItemAvailable(string InExecutableName)
        {
            if (!_programTypeMap.ContainsKey(InExecutableName))
                return false;

            var type = _programTypeMap[InExecutableName];

            var attributes = type.GetCustomAttributes(true).Where(x => x is AppLauncherRequirementAttribute);

            if (attributes.Count() == 0)
                return true;

            return !attributes.Any(x => !(x as AppLauncherRequirementAttribute).IsFulfilled(this));
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

            LoadTerminalCommands();
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

        public void Shutdown()
        {
            _desktop.Close();
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

            this.LoadSaveFile();

            this.LoadUpgrades();

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

            this.SaveGame();
        }

        public string GetTimeOfDay()
        {
            // Get the current date/time.
            var now = DateTime.Now;

            if(HasShiftoriumUpgrade("splitsecondtime"))
            {
                return now.ToLongTimeString();
            }
            else
            {
                if(HasShiftoriumUpgrade("minuteaccuracytime"))
                {
                    return now.ToShortTimeString();
                }
                else
                {
                    if (HasShiftoriumUpgrade("hourssincemidnight"))
                    {
                        int hour = (int)now.TimeOfDay.TotalHours;

                        if(HasShiftoriumUpgrade("pmandam"))
                        {
                            string am = "AM";
                            if(hour > 12)
                            {
                                am = "PM";
                                hour = hour - 12;
                            }
                            return $"{hour} {am}";
                        }

                        return hour.ToString();
                    }
                    else if(HasShiftoriumUpgrade("minutessincemidnight"))
                    {
                        return ((int)now.TimeOfDay.TotalMinutes).ToString();
                    }
                    else
                    {
                        return ((int)now.TimeOfDay.TotalSeconds).ToString();
                    }
                }
            }
        }
    }
}
