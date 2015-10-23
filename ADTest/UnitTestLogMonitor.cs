using System;
using System.IO;
using System.Text.RegularExpressions;
using AutoDial.UtilLogMonitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADTest
{
    [TestClass]
    public class UnitTestLogMonitor
    {
        [TestMethod]
        public void TestGetLogFile()
        {
        //  http://stackoverflow.com/questions/721714/notification-when-a-file-changes
            TalkLogMonitorUtil monUtil = new TalkLogMonitorUtil(null, null, null); // We don't require any of the parameters to test this method

            DateTime dTime = new DateTime(1983, 03, 12);
            string strTalkPath = @"C:\Users\cati\AppData\Roaming\NCH Software\Program Files\Talk\talk.exe";
           
            string strLogFileExpected = @"C:\Users\cati\AppData\Roaming\NCH Software\Talk\Logs\1983-03-12 Express Talk Log.txt";
            string strLogFileNameActual = monUtil.getTalkLogFileName(dTime, strTalkPath);

            Assert.AreEqual(strLogFileExpected, strLogFileNameActual);
        }

        [TestMethod]
        public void TestCheckForPatterns()
        {
            string strLineFromFile;
            bool patternFound;

            Regex regEx = new Regex("answered|disconnected");

            TalkLogMonitorUtil monUtil = new TalkLogMonitorUtil(null, null, regEx); // We just require a regular expression

            // Test patter one = 'answered'
            strLineFromFile = "20:28:46 Call answered";
            patternFound = monUtil.checkForPatterns(strLineFromFile);

            Assert.IsTrue(patternFound);

            // Test patter two = 'disconnected'
            strLineFromFile = "20:28:58 Call has disconnected";
            patternFound = monUtil.checkForPatterns(strLineFromFile);

            Assert.IsTrue(patternFound);
        }
        [TestMethod]
        public void TestGetLastLineFromFile()
        {
            TalkLogMonitorUtil monUtil = new TalkLogMonitorUtil(@"C:\Iggy\TestTalkMonitor.txt", null, null); // We just require the file path

            StreamWriter stWriter = File.AppendText(@"C:\Iggy\TestTalkMonitor.txt");
            //DateTime timestamp = new DateTime();
            string strExpectedLine = "Last line " + DateTime.Now.ToString();
            stWriter.WriteLine(strExpectedLine);
            stWriter.Flush();
            string strActual = monUtil.getLastLineFromFile();

            Assert.AreEqual(strExpectedLine, strActual);
        }
    }
}
