using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftOS.Commands
{
    public class Codepoints : TerminalCommand
    {
        public override string Name => "codepoints";

        public override string HelpText => "Display your current Codepoints.";

        public override string Usage => Name;

        public override void Run(IConsoleContext InConsole, Dictionary<string, object> InArguments)
        {
            InConsole.WriteLine($"You have {InConsole.CurrentSystem.GetCodepoints()} Codepoints.");
        }
    }
}
