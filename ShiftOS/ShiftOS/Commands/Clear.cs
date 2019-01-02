using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftOS.Commands
{
    public class Clear : TerminalCommand
    {
        public override string Name => "clear";

        public override string HelpText => "Clear the screen of all text.";

        public override string Usage => Name;

        public override void Run(IConsoleContext InConsole, Dictionary<string, object> InArguments)
        {
            InConsole.Clear();
        }
    }
}
