using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using OstManSysMVVM.Model;

namespace UnitTests
{
    [TestClass]
    public class ResidentTests
    {
        [TestMethod]
        public void ResidentTypeTest()
        {
            Resident newResident = new Resident();
            newResident.Type = "BoardMember";
            Assert.AreEqual(newResident.Type, "BoardMember");
        }

        [TestMethod]
        public void ResidentDatetimeTest()
        {
            Resident newResident = new Resident();
            newResident.DateOfBirth = new DateTime(0001, 01, 01);
            Assert.AreEqual(newResident.DateOfBirth, new DateTime(0001, 01, 01));
        }

        [TestMethod]
        public void ResidentEmailTest()
        {
            Resident newResident = new Resident();
            newResident.EmailAddress = "a@a.com";
            Assert.AreEqual(newResident.EmailAddress, "a@a.com");
        }

        [TestMethod]
        public void ResidentPhoneTest()
        {
            Resident newResident = new Resident();
            newResident.PhoneNumber = 392489032849023;
            Assert.AreEqual(newResident.PhoneNumber, 392489032849023);
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
