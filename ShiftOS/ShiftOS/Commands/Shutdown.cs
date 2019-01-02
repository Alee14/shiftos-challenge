using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftOS.Commands
{
    public class Shutdown : TerminalCommand
    {
        public override string Name => "shutdown";

        public override string HelpText => "Shut down ShiftOS";

        public override string Usage => Name;

        public override void Run(IConsoleContext InConsole, Dictionary<string, object> InArguments)
        {
            InConsole.CurrentSystem.Shutdown();
        }
    }
}
