using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringssimulering
{
    /// <summary>
    /// 
    /// </summary>
    public class Car
    {
        /// <summary>
        /// The identifier
        /// </summary>
        public int id;
        /// <summary>
        /// The destination
        /// </summary>
        public Parkingspot Destination, originalDestination;
        /// <summary>
        /// The arrival from
        /// </summary>
        public ParkingQueue arrivalFrom;
        /// <summary>
        /// The time of parking
        /// </summary>
        public int timeOfParking, timeOfCreation;
        public double timeOfQueuing;

        /// <summary>
        /// Initializes a new instance of the <see cref="Car" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="arrivalFrom">The arrival from.</param>
        public Car(int id, Parkingspot destination, ParkingQueue arrivalFrom, int timeOfCreation)
        {
            this.id = id;
            this.Destination = destination;
            this.arrivalFrom = arrivalFrom;
            this.timeOfCreation = timeOfCreation;
            this.timeOfQueuing = timeOfCreation;
        }
        /// <summary>
        /// Gets the time of parking.
        /// </summary>
        /// <returns></returns>
        public int getTimeOfParking()
        {
            return timeOfParking;
        }
        public int getTimeOfCreation()
        {
            return timeOfCreation;
        }
        public void setTimeofParking(int timeOfParking)
        {
            this.timeOfParking = timeOfParking;
        }
        public void setTimeOfQueuing(double timeOfQueuing)
        {
            this.timeOfQueuing = timeOfQueuing;
        }
        public void setDestination(Parkingspot ps)
        {
            originalDestination = Destination;
            this.Destination = ps;
        }


    }
}
