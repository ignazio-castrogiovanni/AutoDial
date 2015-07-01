using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace AutoDial
{
    class LogAndErrorsUtils
    {
        private bool m_bFirstError;
        private Logger m_logger;
        private System.Windows.Forms.NotifyIcon m_notifyIcon;
        private System.Windows.Forms.ToolTipIcon m_tooltypeIcon;

        public LogAndErrorsUtils(System.Windows.Forms.NotifyIcon notifyIcon, System.Windows.Forms.ToolTipIcon tooltypeIcon)
        {
            m_logger = LogManager.GetCurrentClassLogger();
            m_notifyIcon = notifyIcon;
            m_tooltypeIcon = tooltypeIcon;
            m_bFirstError = false;
        }

        public Logger getLogger()
        {
            return m_logger;
        }

        public void errorPopup(string title, string content)
        {
            if (m_bFirstError)
            {
                m_bFirstError = false;

                m_logger.Error("Showing Error popup: " + title + "_" + content);
                m_notifyIcon.ShowBalloonTip(5000, title, content, m_tooltypeIcon);
            }
            else
            {
                m_logger.Error("Supressed Error popup: " + title + "_" + content);
            }
        }

        public bool isFirstError()
        {
            return m_bFirstError;
        }

        public void setFirstErrorSignalled(bool bFirst)
        {
            m_bFirstError = bFirst;
        }
    }
}
