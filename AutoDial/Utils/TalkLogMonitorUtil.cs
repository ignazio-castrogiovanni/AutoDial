using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoDial.UtilLogMonitor
{
    public class TalkLogMonitorUtil
    {
        private Action m_actionToCall;
        private Regex m_regExArr;
        private string m_strFilename;

        // Contructor with callback to call when we find the right log.
        public TalkLogMonitorUtil(string strFilename, Action callback, Regex regExArray)
        {
            // Get talk log file path from talk file path
            m_strFilename = getTalkLogFileName(DateTime.Now, strFilename);

            m_actionToCall = callback;
            m_regExArr = regExArray;

        }

        
        public void startMonitoringLogFile()
        {

            // Set file watcher
            FileSystemWatcher fileWatcher = new FileSystemWatcher();
            fileWatcher.Path = m_strFilename;
            fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            fileWatcher.Changed += new FileSystemEventHandler(OnChanged);
            
            // Start monitoring file
            fileWatcher.EnableRaisingEvents = true;
        }

        public void OnChanged(object source, FileSystemEventArgs e)
        {
            // When a change is witnessed 
            // (1) Get the last line from file
            string strLastLine = getLastLineFromFile();

            // (2) Check for pattern in the line
            bool bPatternFound = checkForPatterns(strLastLine);
            
            // (3) If the pattern applies, call callback
            if (bPatternFound)
            {
                m_actionToCall();
            }
        }

        public string getLastLineFromFile()
        {
            
            FileStream fs = new FileStream(m_strFilename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, Encoding.Default);

            string line;
            ArrayList lines = new ArrayList();
            while ((line = sr.ReadLine()) != null)
            {
                lines.Add(line);
            }
            sr.Close();

            if (lines.Count > 0)
            {
                return lines[lines.Count - 1].ToString();
            }

            return null;
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
