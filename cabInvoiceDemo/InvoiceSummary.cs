using System;
using System.Collections.Generic;
using System.Text;

namespace cabInvoiceDemo
{
    public class InvoiceSummary
    {
       
        CabInfo information;

        /// <summary>
        /// Gets the invoice.
        /// </summary>
        /// <param name="numberOfRides">The number of rides.</param>
        /// <param name="totalFare">The total fare.</param>
        /// <returns></returns>
        public CabInfo GetInvoice(int numberOfRides, double totalFare)
        {
            double averageFare = totalFare / numberOfRides;
            information = new CabInfo(numberOfRides, totalFare, averageFare);

            return information;
        }
    }
}
