using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftOS.Commands
{
    public class Help : TerminalCommand
    {
        public override string Name => "help";

        public override string HelpText => "Shows command help and useful tips.";

        public override string Usage => Name;

        public override void Run(IConsoleContext InConsole, Dictionary<string, object> InArguments)
        {
            InConsole.WriteLine("");
            InConsole.WriteLine("ShiftOS Terminal help:");
            InConsole.WriteLine("");
            InConsole.WriteLine("Tips:");
            InConsole.WriteLine("");
            foreach (var tip in InConsole.CurrentSystem.GetUsefulTips().OrderBy(x=>x))
            {
                InConsole.WriteLine($" - {tip}");
            }
            InConsole.WriteLine("");
            InConsole.WriteLine("Terminal commands:");
            InConsole.WriteLine("");

            foreach(var command in InConsole.CurrentSystem.GetInstalledCommands().OrderBy(x=>x.Name))
            {
                InConsole.WriteLine($" - {command.Name}: {command.HelpText}");
            }

            InConsole.WriteLine("");
            InConsole.WriteLine("Programs:");
            InConsole.WriteLine("");
            foreach(var program in InConsole.CurrentSystem.GetInstalledPrograms().OrderBy(x=>x))
            {
                InConsole.WriteLine($" - {program}: {InConsole.CurrentSystem.GetProgramDescription(program)}");
            }
            InConsole.WriteLine("");
        }
    }
}
