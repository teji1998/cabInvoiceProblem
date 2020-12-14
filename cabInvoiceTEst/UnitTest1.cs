using NUnit.Framework;
using Xunit;
using cabInvoiceDemo;
using Assert = NUnit.Framework.Assert;

namespace cabInvoiceTEst
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator;

        [SetUp]
        public void Setup()
        {
            invoiceGenerator = new InvoiceGenerator();
        }

        [Test]
        public void givenDistanceAndTime_WhenCalculated_ShouldReturnTotalFare()
        {
            double distance = 4.0;
            int time = 10;
            double expectedFare = 50;
            double actualFare = invoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(expectedFare, actualFare);
        }

        [Test]
        public void givenMultipleRides_WhenCalculated_ShouldReturnTotalFare()
        {
            Ride[] rides = {new Ride(4.0,10),
                            new Ride(1.0,1)};

            double expectedFare = 61;
            double actualFare = invoiceGenerator.CalculateTotalFare(rides);
            Assert.AreEqual(expectedFare, actualFare);
        }


    }
}