using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShiftOS.Metadata;
using System.Threading.Tasks;

namespace ShiftOS.Commands
{
    [Requires("secondssincemidnight")]
    public class Clock : TerminalCommand
    {
        public override string Name => "time";

        public override string HelpText => "Display the current time.";

        public override string Usage => Name;

        public override void Run(IConsoleContext InConsole, Dictionary<string, object> InArguments)
        {
            InConsole.WriteLine(InConsole.CurrentSystem.GetTimeOfDay());
        }
    }
}
