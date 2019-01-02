using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftOS.Metadata
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class AppLauncherRequirementAttribute : Attribute
    {
        private string _id;

        public string ID => _id;

        public AppLauncherRequirementAttribute(string id)
        {
            _id = id;
        }

        public bool IsFulfilled(SystemContext InSystemContext)
        {
            return InSystemContext.HasShiftoriumUpgrade(_id);
        }
    }
}
