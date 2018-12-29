using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftOS.Metadata
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ProgramAttribute : Attribute
    {
        private string _exeName = "";
        private string _friendlyName = "";
        private string _description = "";

        public ProgramAttribute(string InExecutableName, string InFriendlyName, string InDescription)
        {
            _exeName = InExecutableName;
            _friendlyName = InFriendlyName;
            _description = InDescription;
        }

        public string ExecutableName => _exeName;
        public string FriendlyName => _friendlyName;
        public string Description => _description;
    }
}
