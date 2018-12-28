using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftOS
{
    public class SkinContext
    {
        private Skin _skin = null;

        public SkinContext()
        {
            _skin = new Skin();
        }

        public Skin GetSkinData()
        {
            return _skin;
        }
    }
}
