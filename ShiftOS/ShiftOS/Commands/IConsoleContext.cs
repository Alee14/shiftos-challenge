using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftOS.Commands
{
    public interface IConsoleContext
    {
        void Write(string InText);
        void WriteLine(string InText);
        void Clear();

        SystemContext CurrentSystem { get; }

        bool ReadLine(ref string OutLine);

        void Latent_ReadLine(Action<string> Callback);
    }
}
