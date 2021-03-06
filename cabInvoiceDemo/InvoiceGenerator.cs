﻿using System;
using System.Collections.Generic;
using System.Text;

namespace cabInvoiceDemo
{
    public class InvoiceGenerator
    {

        readonly int COST_PER_KILOMETER = 10;
        readonly int COST_PER_MINUTE = 1;
        readonly int MINIMUM_FARE = 5;
        double totalFare;
        RideType rideType;

        InvoiceSummary invoiceSummary = null;
        RideRepository rideRepository = null;

        /// <summary>
        /// Default constructor
        /// </summary>
        public InvoiceGenerator()
        {
            invoiceSummary = new InvoiceSummary();
            rideRepository = new RideRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceGenerator"/> class.
        /// </summary>
        /// <param name="rideType">Type of the ride.</param>
        /// <exception cref="CabInvoiceException">Ride type is Invalid</exception>
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;

            if (rideType.Equals(RideType.NORMAL))
            {
                this.COST_PER_KILOMETER = 10;
                this.COST_PER_MINUTE = 1;
                this.MINIMUM_FARE = 5;
            }
            else if (rideType.Equals(RideType.PREMIUM))
            {
                this.COST_PER_KILOMETER = 15;
                this.COST_PER_MINUTE = 2;
                this.MINIMUM_FARE = 20;
            }
            else
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Ride type is Invalid");
            }
        }

        /// <summary>
        /// Calculates the fare.
        /// </summary>
        /// <param name="ride">The ride.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceException">
        /// There is no ride
        /// or
        /// Distance is not valid
        /// or
        /// Time is valid
        /// </exception>
        public double CalculateFare(Ride ride)
        {
            if (ride == null)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "There is no ride");
            }
            if (ride.distance <= 0)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Distance is not valid");
            }
            if (ride.time <= 0)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Time is not valid");
            }

            double fare = (ride.distance * COST_PER_KILOMETER) + (ride.time * COST_PER_MINUTE);
            return Math.Max(fare, MINIMUM_FARE);
        }

        /// <summary>
        /// Calculates the fare for multiple rides.
        /// </summary>
        /// <param name="rideList">The ride list.</param>
        /// <returns></returns>
        public double CalculateFareForMultipleRides(List<Ride> rideList)
        {
            this.totalFare = 0;
            foreach (var ride in rideList)
            {
                this.totalFare = totalFare + CalculateFare(ride);
            }
            return this.totalFare;
        }

        /// <summary>
        /// Gets the invoice summary.
        /// </summary>
        /// <param name="rideList">The ride list.</param>
        /// <returns></returns>
        public CabInfo GetInvoiceSummary(List<Ride> rideList)
        {
            double fare = CalculateFareForMultipleRides(rideList);
            CabInfo data = invoiceSummary.GetInvoice(rideList.Count, totalFare);
            return data;
        }

        /// <summary>
        /// Add rides to dictionary according to user id
        /// </summary>
        /// <param name="userId"></param>
        public void AddRides(int userId, List<Ride> rideList)
        {
            rideRepository.AddRides(userId, rideList);
        }

        /// <summary>
        /// Given user id get invoice
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public CabInfo GetUserInvoice(int userId)
        {
            List<Ride> rideList = rideRepository.GetRides(userId);
            CabInfo information = GetInvoiceSummary(rideList);
            return information;
        }
    }
}
