using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoDial;

namespace ADTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestExtractPhoneNumber()
        {
            Form1 form = new Form1();
            string strNum = form.extractPhoneNumber("Autodial: 3456782345");
            Assert.AreEqual("3456782345", strNum);
        }

        [TestMethod]
        public void TestExtractPhoneNumberZQuirk()
        {
            Form1 form = new Form1();
            // ':' read as 'Z', sometimes it happens
            string strNum = form.extractPhoneNumber("AutodialZ 3456782345");
            Assert.AreEqual("3456782345", strNum);
        }

        [TestMethod]
        public void TestExtractPhoneNumberSpaceQuirk()
        {
            Form1 form = new Form1();
            // ':' read as ' ' space, sometimes it happens
            string strNum = form.extractPhoneNumber("Autodial  3456782345");
            Assert.AreEqual("3456782345", strNum);
        }

        [TestMethod]
        public void TestExtractPhoneNumberSpaces()
        {
            Form1 form = new Form1();
            // Spaces
            string strNum = form.extractPhoneNumber("Autodial: 34 5678 2345");
            Assert.AreEqual("3456782345", strNum);
            strNum = form.extractPhoneNumber("Autodial: 3456 782 345");
            Assert.AreEqual("3456782345", strNum);
        }

        [TestMethod]
        public void TestWeirdSituations()
        {
            Form1 form = new Form1();
            // Other mixed weird situations
            string strNum = form.extractPhoneNumber("AutodialZ 34 5678 2345");
            Assert.AreEqual("3456782345", strNum);
            strNum = form.extractPhoneNumber("AutodialZ 3456 782 345");
            Assert.AreEqual("3456782345", strNum);
            strNum = form.extractPhoneNumber("Autodial  34 5678 2345");
            Assert.AreEqual("3456782345", strNum);
            strNum = form.extractPhoneNumber("Autodial  3456 782 345");
            Assert.AreEqual("3456782345", strNum);
        }

        [TestMethod]
        public void TestCleanNumber()
        {
            Form1 form = new Form1();
            string strCleanedNum = form.cleanNumber("12 344 5555 2");
            Assert.AreEqual("1234455552", strCleanedNum);

            strCleanedNum = form.cleanNumber("12 4455 5523");
            Assert.AreEqual("1244555523", strCleanedNum);

            strCleanedNum = form.cleanNumber("1244 555 523");
            Assert.AreEqual("1244555523", strCleanedNum);

        }
    }
}
