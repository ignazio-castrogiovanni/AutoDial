using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDial.UtilLogMonitor
{
    public class TalkLogMonitorUtil
    {
        // Contructor with callback to call when we find the right log.
        public TalkLogMonitorUtil(Action callback)
        {
        }

        public bool startMonitoringLogFile()
        {
            return false;
        }

        public string getTalkLogFileName()
        {
            return null;
        }
    }
}
