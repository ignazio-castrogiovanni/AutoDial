using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLog;

namespace AutoDial
{
  
    class GeneralUtils
    {
        private string m_strImgPrefix = @"C:\AutoDial\Images\image_";
        private Logger m_logger;
        private LogAndErrorsUtils m_logAndErr;

        GeneralUtils(LogAndErrorsUtils logAndErr)
        {
            m_logAndErr = logAndErr;
            m_logger = logAndErr.getLogger();
        }
     
        
        public string generateImageFilename(string dateStamp)
        {
            return m_strImgPrefix + dateStamp + ".png";
        }

        public string generateImgBlackAndWhiteFilename(string dateStamp)
        {
            return m_strImgPrefix + dateStamp + "_grey.png";
        }

        public int convertStringToInt(string name, string source, Logger logger)
        {
            if (source == null)
            {
                logger.Error("Error: " + name + " Is Null, Check config file.");
                m_logAndErr.errorPopup("Config error", "Error: " + name + " is null, check config file.");

                return 0;
            }

            return Convert.ToInt32(source);
        }

        
    }
}
