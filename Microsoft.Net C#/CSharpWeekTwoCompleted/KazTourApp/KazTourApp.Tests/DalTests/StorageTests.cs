using KazTourApp.DAL;
using KazTourApp.Shared.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTourApp.Tests.DalTests
{
    [TestClass]
    public class StorageTests
    {
        [TestMethod]
        public void Should_Add_Tour_Record_ToDb()
        {
            // Arrange
            string pathToFile = @"C:\Users\РаимбаевИ\Databases\LiteDb.db";
            var tour = new TourRecord()
            {
                Country = "Japan",
                City = "Kyoto",
                StartTimes = new DateTime[] { new DateTime(2018, 08, 11) },
                BasePriceForPerson = 800000,
                MaxPersonsAllowed =  4,
                PlacesLeft = new int[] { 5 },
                DurationInDays = new int[] { 7 }
            };

            TourStorage storage = new TourStorage();
            int itemsCountBeforeInsert = storage.ReadAll().Count;

            // Act
            storage.AddTour(tour);

            // Assert
            Assert.IsTrue(File.Exists(pathToFile));

            TourStorage secondStorage = new TourStorage();
            int itemsCountAfterInsert = storage.ReadAll().Count;

            Assert.IsTrue(itemsCountBeforeInsert == itemsCountAfterInsert - 1);

        }
    }
}
