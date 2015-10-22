using System;
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
            TalkLogMonitorUtil monUtil = new TalkLogMonitorUtil(LogMonCB);

            DateTime today = DateTime.Today;
            string strLogFileName = monUtil.getTalkLogFileName();

            Assert.AreEqual(today.ToString(), strLogFileName);
        }

        public void LogMonCB()
        {
            //http://stackoverflow.com/questions/9931723/passing-a-callback-function-to-another-class
        }
    }
}
