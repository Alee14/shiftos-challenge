using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftOS.Commands
{
    public class Cheat : TerminalCommand
    {
        public override string Name => "05tray";

        public override string HelpText => "Makes you a cheater.";

        public override string Usage => Name + " <amount>";

        public override void Run(IConsoleContext InConsole, Dictionary<string, object> InArguments)
        {
            int amount = 0;
            if(!int.TryParse(InArguments["<amount>"].ToString(), out amount))
            {
                InConsole.WriteLine("That's not a valid number.");
                return;
            }

            InConsole.WriteLine($"Congrats, you now have {amount} more Codepoints. :)");
            InConsole.CurrentSystem.AddCodepoints(amount);
        }
    }
}
