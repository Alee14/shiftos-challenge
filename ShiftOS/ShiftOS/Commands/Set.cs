using System;
using System.Collections.Generic;
using System.Linq;
using ShiftOS.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ShiftOS.Commands
{
    [Requires("customusername")]
    public class Set : TerminalCommand
    {
        public override string Name => "set";

        public override string HelpText => "Change ShiftOS system settings.";

        public override string Usage => Name + " <setting> <value>";

        public override void Run(IConsoleContext InConsole, Dictionary<string, object> InArguments)
        {
            string setting = InArguments["<setting>"].ToString();
            string value = InArguments["<value>"].ToString();

            switch(setting)
            {
                case "username":
                    InConsole.CurrentSystem.Username = value;
                    break;
                case "osname":
                    if(!InConsole.CurrentSystem.HasShiftoriumUpgrade("osname"))
                    {
                        goto default;
                    }
                    InConsole.CurrentSystem.OSName = value;
                    break;
                default:
                    InConsole.WriteLine("Error: setting not found.");
                    break;
            }
        }
    }
}
