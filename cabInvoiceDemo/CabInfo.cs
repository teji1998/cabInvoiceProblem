using System;
using System.Collections.Generic;
using System.Text;

namespace cabInvoiceDemo
{
    public class CabInfo
    {
        public int numberOfRides;
        public double totalFare;
        public double averageFare;

        public CabInfo(int numberOfRides, double totalFare, double averageFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = averageFare;
        }
    }
}
