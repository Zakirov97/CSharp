using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KazTourApp.Shared.Models;

namespace KazTourApp.Tests.DLLTest
{
    [TestClass]
    public class TourServiceTests
    {
        public void should_find_ByCriteria()
        {
            List<TourRecord> tours = new List<TourRecord>();
            tours.Add(new TourRecord()
            {
                Country = "Japan",
                City = "Kyoto",
                StartTimes = new DateTime[] { new DateTime(2018, 08, 11) },
                BasePriceForPerson = 800000,
                MaxPersonsAllowed = 4,
                PlacesLeft = new int[] { 5 },
                DurationInDays = new int[] { 7 }
            });
            tours.Add(new TourRecord()
            {
                Country = "USA",
                City = "Virginia",
                StartTimes = new DateTime[] { new DateTime(2018, 07, 11) },
                BasePriceForPerson = 300000,
                MaxPersonsAllowed = 8,
                PlacesLeft = new int[] { 5 },
                DurationInDays = new int[] { 11 }
            });
            tours.Add(new TourRecord()
            {
                Country = "USA",
                City = "Virginia",
                StartTimes = new DateTime[] { new DateTime(2018, 07, 11) },
                BasePriceForPerson = 300000,
                MaxPersonsAllowed = 8,
                PlacesLeft = new int[] { 5 },
                DurationInDays = new int[] { 11 }
            });

        }
    }
}
