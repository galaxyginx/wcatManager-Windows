using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wcatManager
{
    public class Settings
    {
        public bool _AccuracyEnabled;
        public bool _ResultOnNewWindow;

        public bool AccuracyEnabled
        {
            get { return _AccuracyEnabled; }
            set { _AccuracyEnabled = value; }
        }
        public bool ResultOnNewWindow
        {
            get { return _ResultOnNewWindow; }
            set { _ResultOnNewWindow = value; }
        }
        public void Save(bool accuracy, bool result){
            _AccuracyEnabled = accuracy;
            _ResultOnNewWindow = result;
        }
    }
}
