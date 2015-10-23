using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoDial.UtilLogMonitor
{
    public class TalkLogMonitorUtil
    {
        private Action m_strActionToCall;
        private Regex m_regExArr;
        private string m_strFilename;

        // Contructor with callback to call when we find the right log.
        public TalkLogMonitorUtil(string strFilename, Action callback, Regex regExArray)
        {
            m_strFilename = strFilename;
            m_strActionToCall = callback;
            m_regExArr = regExArray;

        }

        public bool startMonitoringLogFile()
        {
            return false;
        }

        public bool checkForPatterns(string strLastLine) 
        {
            // Check if any of the string is found in the provided line
            Match matchingPattern = m_regExArr.Match(strLastLine);
            if (matchingPattern.Success)
            {
                return true;
            }
            return false;
        }

        public string getTalkLogFileName(DateTime date, string strTalkPath)
        {
            
            // Get initial part of talk path
            Regex regE = new Regex(@"(.+NCH Software)");
            Match matchingPath = regE.Match(strTalkPath);
            if (matchingPath.Success)
            {
                // string strTalkPath = @"C:\Users\cati\AppData\Roaming\NCH Software\Program Files\Talk\talk.exe";
                string strInitialValue = matchingPath.Value;

                // Convert date in the talk log format
                string strDay = (date.Day.ToString().Length == 2) ? date.Day.ToString() : "0" + date.Day.ToString();
                string strMonth = (date.Month.ToString().Length == 2) ? date.Month.ToString() : "0" + date.Month.ToString();
                string strDate = date.Year.ToString() + '-' + strMonth + '-' + strDay;

                // Generate last part of file name
                string strLastPartOfLogPath = @"\Talk\Logs\" + strDate + " Express Talk Log.txt";

                // Add initial and ending to compose the complete path
                string strCompleteLogPath = strInitialValue + strLastPartOfLogPath;

                return strCompleteLogPath;
            }
            else
            {
                return null;
            }
        }
    }
}
