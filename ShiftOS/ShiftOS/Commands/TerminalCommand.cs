using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftOS.Commands
{
    public abstract class TerminalCommand
    {
        public abstract string Name { get; }
        public abstract string HelpText { get; }
        public abstract string Usage { get; }

        public abstract void Run(IConsoleContext InConsole, Dictionary<string, object> InArguments);
    }
}
