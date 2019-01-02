using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShiftOS.Metadata;
using System.Threading.Tasks;

namespace ShiftOS.Commands
{
    [Requires("minimizecommand")]
    public class Minimize : TerminalCommand
    {
        public override string Name => "minimize";

        public override string HelpText => "Minimizes or unminimizes the specified window.";

        public override string Usage => Name + " <window>";

        public override void Run(IConsoleContext InConsole, Dictionary<string, object> InArguments)
        {
            string window = InArguments["<window>"].ToString();

            var win = InConsole.CurrentSystem.GetWindows().FirstOrDefault(x => x.WindowTitle == window);

            if(win == null)
            {
                InConsole.WriteLine($"Error: No window named {window} found.");
                return;
            }

            if (win.Enabled == false)
            {
                win.Enabled = true;
                win.Opacity = 1;
            }
            else
            {
                win.Opacity = 0;
                win.Enabled = false;
            }

        }
    }
}
