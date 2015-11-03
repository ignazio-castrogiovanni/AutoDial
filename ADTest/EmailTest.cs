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
            MailUtils.Email("akton29@gmail.com",
                "Test AutoDial Body",
                "Test AutoDial Subject",
                "autodial.log@gmail.com",
                "Auto Dial Log",
                "autodial.log@gmail.com",
                "270McNair",
                null);
        }
    }
}
