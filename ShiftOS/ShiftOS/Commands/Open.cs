using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftOS.Commands
{
    public class Open : TerminalCommand
    {
        public override string Name => "open";

        public override string HelpText => "Open the specified program.";

        public override string Usage => Name + " <program>";

        public override void Run(IConsoleContext InConsole, Dictionary<string, object> InArguments)
        {
            string program = InArguments["<program>"].ToString();

            if(!InConsole.CurrentSystem.LaunchProgram(program))
            {
                InConsole.WriteLine("Error: Program not found.");
            }
        }
    }
}
