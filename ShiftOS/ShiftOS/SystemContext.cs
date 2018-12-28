using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ShiftOS
{
    public class SystemContext : IDisposable
    {
        private Desktop _desktop = null;
        private SkinContext _skinContext = null;
        private int _codepoints = 0;

        private void LoadCurrentSkin()
        {
            // TODO: Load it from a filesystem of some sort.
            _skinContext = new SkinContext();
        }

        public void Dispose()
        {
            _desktop = null;
        }

        public int GetCodepoints()
        {
            return this._codepoints;
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
