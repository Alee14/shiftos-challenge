using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftOS
{
    public class Upgrade
    {
        private string _id;
        private string _name;
        private string _description;
        private string _buyTutorial;
        private int _codepoints;
        private string[] _dependencies;
        private bool _finalized = false;
        
        public string ImageResource { get; set; }

        public string Tutorial
        {
            get
            {
                return _buyTutorial;
            }
            set
            {
                if (_finalized)
                    throw new InvalidOperationException("This upgrade is finalized. Its data cannot be modified.");
                _buyTutorial = value;
            }
        }

        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (_finalized)
                    throw new InvalidOperationException("This upgrade is finalized. Its data cannot be modified.");
                _id = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_finalized)
                    throw new InvalidOperationException("This upgrade is finalized. Its data cannot be modified.");

                _name = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_finalized)
                    throw new InvalidOperationException("This upgrade is finalized. Its data cannot be modified.");
                _description = value;
            }
        }
        public string[] Requires
        {
            get
            {
                return _dependencies;
            }
            set
            {
                if (_finalized)
                    throw new InvalidOperationException("This upgrade is finalized. Its data cannot be modified.");
                _dependencies = value;
            }
        }
        public int Cost
        {
            get
            {
                return _codepoints;
            }
            set
            {
                if (_finalized)
                    throw new InvalidOperationException("This upgrade is finalized. Its data cannot be modified.");
                _codepoints = value;
            }
        }

        public void FinalizeUpgrade()
        {
            if (_finalized == true)
                throw new InvalidOperationException("This upgrade has already been finalized.");
            _finalized = true;
        }

        public bool IsAvailable(SystemContext InSystemContext)
        {
            if (InSystemContext.HasShiftoriumUpgrade(_id))
                return false;

            if (_dependencies == null || _dependencies.Length == 0)
                return true;

            return _dependencies.Where(x => !InSystemContext.HasShiftoriumUpgrade(x)).Count() == 0;
        }

        public bool CanBuy(SystemContext InSystemContext)
        {
            return IsAvailable(InSystemContext) && InSystemContext.GetCodepoints() >= _codepoints;
        }
    }
}
