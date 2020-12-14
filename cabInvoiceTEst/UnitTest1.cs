using NUnit.Framework;
using Xunit;
using cabInvoiceDemo;
using Assert = NUnit.Framework.Assert;
using System.Collections.Generic;

namespace cabInvoiceTEst
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator;
        List<Ride> rideList;

        [SetUp]
        public void Setup()
        {
            invoiceGenerator = new InvoiceGenerator();
        }

        /// <summary>
        /// Givens the distance and time when calculated should give fare.
        /// </summary>
        [Test]
        public void givenDistanceAndTime_WhenCalculated_ShouldGiveFare()
        {
            double distance = 5; 
            int time = 20;
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double fare = invoiceGenerator.CalculateFare(new Ride(distance, time));

            Assert.AreEqual(70, fare);
        }

        /// <summary>
        /// Givens the distance and time should return premium calculate the fare.
        /// </summary>
        [Test]
        public void givenDistanceAndTime_ShouldReturnPremiumCalculateTheFare()
        {
            double distance = 2.0;
            int time = 5;
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double result = invoiceGenerator.CalculateFare(new Ride(distance, time));
            Assert.AreEqual(result, 40);
        }

        /// <summary>
        /// Givens the list of rides when calculated should give total fare.
        /// </summary>
        [Test]
        public void givenListOfRides_WhenCalculated_ShouldGiveTotalFare()
        {
            rideList = new List<Ride> { new Ride(5, 20), new Ride(3, 15), new Ride(2, 10) };

            double fare = invoiceGenerator.CalculateFareForMultipleRides(rideList);

            Assert.AreEqual(145, fare);

        }

        /// <summary>
        /// Givens the list of rides when calculated should return invoice information.
        /// </summary>
        [Test]
        public void givenListOfRides_WhenCalculated_ShouldReturnInvoiceInformation()
        {
            rideList = new List<Ride> { new Ride(5, 20), new Ride(3, 15), new Ride(2, 10) };
            double expectedFare = 145;
            int expectedRides = 3;
            double expectedAverage = expectedFare / expectedRides;

            CabInfo info = invoiceGenerator.GetInvoiceSummary(rideList);

            Assert.IsTrue(info.numberOfRides == expectedRides && info.totalFare == expectedFare && info.averageFare == expectedAverage);
        }

        /// <summary>
        /// Givens the user identifier when checked if present should return invoice information.
        /// </summary>
        [Test]
        public void givenUserId_WhenCheckedIfPresent_ShouldReturnInvoiceInfo()
        {
            rideList = new List<Ride> { new Ride(5, 20), new Ride(3, 15), new Ride(2, 10) };
            double expectedFare = 145;
            int expectedRides = 3;
            double expectedAverage = expectedFare / expectedRides;

            invoiceGenerator.AddRides(1, rideList);
            CabInfo info = invoiceGenerator.GetUserInvoice(1);

            Assert.IsTrue(info.numberOfRides == expectedRides && info.totalFare == expectedFare && info.averageFare == expectedAverage);
        }
        


    }
}