using ShiftOS.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftOS.Commands
{
    [Requires("windowsanywhere")]
    public class Move : TerminalCommand
    {
        public override string Name => "move";

        public override string HelpText => "Move the specified window to the specified location on-screen.";

        public override string Usage => Name + " <window> to <x> <y>";

        public override void Run(IConsoleContext InConsole, Dictionary<string, object> InArguments)
        {
            var windowTitle = InArguments["<window>"].ToString();

            int x, y = 0;

            if(!int.TryParse(InArguments["<x>"].ToString(), out x))
            {
                InConsole.WriteLine("Error: invalid x coordinate");
                return;
            }
            if (!int.TryParse(InArguments["<y>"].ToString(), out y))
            {
                InConsole.WriteLine("Error: invalid y coordinate");
                return;
            }

            var window = InConsole.CurrentSystem.GetWindows().FirstOrDefault(z => z.WindowTitle == windowTitle);

            if(window == null)
            {
                InConsole.WriteLine($"Error: No window found with name {windowTitle}.");
                return;
            }

            window.Left = x;
            window.Top = y;
        }
    }
}
