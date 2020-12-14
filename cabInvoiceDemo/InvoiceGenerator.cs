using System;
using System.Collections.Generic;
using System.Text;

namespace cabInvoiceDemo
{
    public class InvoiceGenerator
    {

        /* //variable
         RideType rideType;
         private RideRepository rideRepository;

         //constants
         private readonly double MINIMUM_COST_PER_KM;
         private readonly int COST_PER_TIME;
         private readonly double MINIMUM_FARE;

         /// <summary>
         /// Initializes a new instance of the <see cref="InVoiceGenerator"/> class.
         /// </summary>
         /// <param name="rideType">Type of the ride.</param>
         /// <exception cref="CabInvoiceGenerator.CabInVoiceException">Invalid ride type</exception>
         public InVoiceGenerator(RideType rideType)
         {
             this.rideType = rideType;
             this.rideRepository = new RideRepository();
             try
             {
                 //if ride type is premium then rate will be set for premium
                 if (rideType.Equals(RideType.PREMIUM))
                 {
                     this.MINIMUM_COST_PER_KM = 15;
                     this.COST_PER_TIME = 2;
                     this.MINIMUM_FARE = 20;
                 }
                 //else rate will be set for normal
                 else if (rideType.Equals(RideType.NORMAL))
                 {
                     this.MINIMUM_COST_PER_KM = 10;
                     this.COST_PER_TIME = 1;
                     this.MINIMUM_FARE = 5;
                 }
             }
             catch (CabInVoiceException)
             {
                 throw new CabInVoiceException(CabInVoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
             }
         }

         /// <summary>
         /// Calculates the fare.
         /// </summary>
         /// <param name="distance">The distance.</param>
         /// <param name="time">The time.</param>
         /// <returns></returns>
         /// <exception cref="CabInvoiceGenerator.CabInVoiceException">
         /// Invalid ride type
         /// or
         /// Invalid distance
         /// or
         /// Invalid time
         /// </exception>
         public double CalculateFare(double distance, int time)
         {
             double totalFare = 0;
             // Exception handling for invalid  distance and time
             try
             {
                 //calculating total fare
                 totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
             }
             catch (CabInVoiceException)
             {
                 if (rideType.Equals(null))
                 {
                     //invalid ride type exception
                     throw new CabInVoiceException(CabInVoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
                 }
                 if (distance <= 0)
                 {
                     //invalid distance exception
                     throw new CabInVoiceException(CabInVoiceException.ExceptionType.INVALID_DISTANCE, "Invalid distance");
                 }
                 if (time < 0)
                 {
                     //invalid time exception
                     throw new CabInVoiceException(CabInVoiceException.ExceptionType.INVALID_TIME, "Invalid time");
                 }
             }
             //Mathmax is inbuilt function 
             //using mathmax returns maximum value
             return Math.Max(totalFare, MINIMUM_FARE);
         }

         /// <summary>
         /// Method to calculate total fare and generating summary for multiple rides
         /// </summary>
         /// <param name="rides">The rides.</param>
         /// <returns></returns>
         /// <exception cref="CabInvoiceException">Rides Are Null</exception>
         public InVoiceSummary CalculateFare(Ride[] rides)
         {
             double totalFare = 0;
             // Exception handling for the invalid  distance and time
             try
             {
                 //calculating Total Fare For All Rides using foreach loop
                 foreach (Ride ride in rides)
                 {
                     //returns totalfare
                     totalFare += this.CalculateFare(ride.distance, ride.time);
                 }
             }
             catch (CabInVoiceException)
             {
                 if (rides == null)
                 {
                     throw new CabInVoiceException(CabInVoiceException.ExceptionType.NULL_RIDES, "Rides Are Null");
                 }
             }
             //returning invoice summary which has total fare and number of rides
             return new InVoiceSummary(rides.Length, (int)totalFare);
         }

         /// <summary>
         /// Function to add rides for userId
         /// </summary>
         /// <param name="userId">The user identifier.</param>
         /// <param name="rides">The rides.</param>
         /// <exception cref="CabInvoiceGenerator.CabInVoiceException">Rides Are Null</exception>
         public void AddRides(string userId, Ride[] rides)
         {
             try
             {
                 //adding ride to the specified User
                 rideRepository.AddRide(userId, rides);
             }
             catch (CabInVoiceException)
             {
                 if (rides == null)
                 {
                     throw new CabInVoiceException(CabInVoiceException.ExceptionType.NULL_RIDES, "Rides Are Null");
                 }
             }
         }

         /// <summary>
         /// Function to Get Summary By UserId
         /// </summary>
         /// <param name="userId">The user identifier.</param>
         /// <returns></returns>
         /// <exception cref="CabInvoiceGenerator.CabInVoiceException">Invalid UserID</exception>
         public InVoiceSummary GetInvoiceSummary(string userId)
         {
             try
             {
                 return this.CalculateFare(rideRepository.GetRides(userId));
             }
             catch (CabInVoiceException)
             {
                 throw new CabInVoiceException(CabInVoiceException.ExceptionType.INVALID_USER_ID, "Invalid UserID");
             }
         }

         /// <summary>
         /// Calculates the average fare.
         /// </summary>
         /// <param name="rides">The rides.</param>
         /// <returns></returns>
         /// <exception cref="CabInVoiceException">Rides passed are null..</exception>
         public InvoiceSummary CalculateAvgFare(Ride[] rides)
         {
             double totalFare = 0;
             /// Adding a variable to compute average fare
             double averageFare = 0;
             /// Exception handling for the invalid  distance and time
             try
             {
                 // Using foreach loop to take one ride each time
                 foreach (Ride ride in rides)
                 {
                     // returning total fare
                     totalFare += this.CalculateFare(ride.distance, ride.time);
                 }
                 // Computing average fare = (total fare/ number of rides)
                 averageFare = (totalFare / rides.Length);
             }
             catch (CabInVoiceException)
             {
                 if (rides == null)
                 {
                     throw new CabInVoiceException(CabInVoiceException.ExceptionType.NULL_RIDES, "Rides passed are null..");
                 }
             }
             // Returning the invoice summary with average fare 
             return new InVoiceSummary(totalFare, rides.Length, averageFare);
         }*/
        public const double COST_PERKILOMETER = 10.0;
        public const int COST_PERMINUTE = 1;
        public const double MINIMUM_FARE = 5;

        
        public double CalculateFare(double distance, int time)
        {
            double totalFare = distance * COST_PERKILOMETER + time * COST_PERMINUTE;
            return Math.Max(totalFare, MINIMUM_FARE);
        }

        
        public InvoiceSummary CalculateTotalFare(Ride[] rides)
        {
            double totalFare = 0;
            foreach (Ride ride in rides)
            {
                totalFare += this.CalculateFare(ride.distance, ride.time);
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }
    }
}
