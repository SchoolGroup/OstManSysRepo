using System;
using System.Diagnostics.Contracts;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using OstManSysMVVM.Model;

namespace UnitTests
{
    [TestClass]
    public class OtherTests
    {
        [TestMethod]
        public void DownpipeIDTest()
        {
            Downpipe newDownpipe = new Downpipe();
            newDownpipe.DownpipeID = 1;
            Assert.AreEqual(newDownpipe.DownpipeID, 1);
        }

        [TestMethod]
        public void DownpipeConditionTest()
        {
            Downpipe newDownpipe = new Downpipe();
            newDownpipe.Condition = "Good";
            Assert.AreEqual(newDownpipe.Condition, "Good");
        }

        [TestMethod]
        public void DownpipeDateTimeTest()
        {
            Downpipe newDownpipe = new Downpipe();
            newDownpipe.LastChecked = new DateTime(0001, 01, 01);
            Assert.AreEqual(newDownpipe.LastChecked, new DateTime(0001, 01, 01));
        }

        [TestMethod]
        public void DownpipePictureTest()
        {
            Downpipe newDownpipe = new Downpipe();
            newDownpipe.Picture = "/Path/To/Picture.jpg";
            Assert.AreEqual(newDownpipe.Picture, "/Path/To/Picture.jpg");
        }

        [TestMethod]
        public void ResidentNameTest()
        {
            Resident newResident = new Resident();
            newResident.FirstName = "FirstName";
            newResident.LastName = "LastName";
            string name = newResident.FirstName + newResident.LastName;
            Assert.AreEqual(name, "FirstNameLastName");
        }

        [TestMethod]
        public void ResidentIDTest()
        {
            Resident newResident = new Resident();
            newResident.ResidentID = 1;
            Assert.AreEqual(newResident.ResidentID, 1);
        }
    }
}
