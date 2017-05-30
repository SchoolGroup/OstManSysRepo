using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using OstManSysMVVM.Model;

namespace UnitTests
{
    [TestClass]
    public class ApartmentTests
    {
        [TestMethod]
        public void ApartmentConditionTest()
        {
            Apartment newApartment = new Apartment();
            newApartment.Condition = "Good";
            Assert.AreEqual("Good", newApartment.Condition);
        }

        [TestMethod]
        public void ApartmentIDTest()
        {
            Apartment newApartment = new Apartment();
            newApartment.ApartmentID = 1;
            Assert.AreEqual(1, newApartment.ApartmentID);
        }

        [TestMethod]
        public void ApartmenAddressIDTest()
        {
            Apartment newApartment = new Apartment();
            newApartment.AddressID = 1;
            Assert.AreEqual(1, newApartment.AddressID);
        }

        [TestMethod]
        public void ApartmentDownpipeIDTest()
        {
            Apartment newApartment = new Apartment();
            newApartment.DownpipeID = 1;
            Assert.AreEqual(1, newApartment.DownpipeID);
        }

        [TestMethod]
        public void ApartmentRoomsTest()
        {
            Apartment newApartment = new Apartment();
            newApartment.NumberOfRooms = 1;
            Assert.AreEqual(1, newApartment.NumberOfRooms);
        }

        [TestMethod]
        public void ApartmentSizeTest()
        {
            Apartment newApartment = new Apartment();
            newApartment.Size = 1;
            Assert.AreEqual(1, newApartment.Size);
        }

        [TestMethod]
        public void ApartmentWindowIDTest()
        {
            Apartment newApartment = new Apartment();
            newApartment.WindowID = 1;
            Assert.AreEqual(1, newApartment.WindowID);
        }

        [TestMethod]
        public void ApartmentRentTest()
        {
            Apartment newApartment = new Apartment();
            newApartment.MonthlyRent = 1;
            Assert.AreEqual(1, newApartment.MonthlyRent);
        }

        [TestMethod]
        public void ApartmentIsRentedTest()
        {
            Apartment newApartment = new Apartment();
            newApartment.IsRented = false;
            Assert.IsFalse(newApartment.IsRented);
        }

        [TestMethod]
        public void ApartmentDateTimeTest()
        {
            Apartment newApartment = new Apartment();
            newApartment.LastCheck = new DateTime(0001, 01, 01);
            Assert.AreEqual(new DateTime(0001, 01, 01), newApartment.LastCheck);
        }
    }
}
