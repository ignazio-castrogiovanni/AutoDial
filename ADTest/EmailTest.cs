using System;
using AutoDial.MailUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADTest
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            MailUtils.sendit("autodial.log@gmail.com", "Machine 17", "Problem found", @"C:\AUTODIAL\log\AutoDial_2015-10-28_trace.log");
        }
    }
}
