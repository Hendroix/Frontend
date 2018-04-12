using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringssimulering
{
    /// <summary>
    /// This is a Car
    /// </summary>
    public class Car
    {
        /// <summary>
        /// The destination and original destination of the car
        /// </summary>
        public Parkingspot Destination, originalDestination;
        /// <summary>
        /// The arrival from
        /// </summary>
        public ParkingQueue arrivalFrom;
        /// <summary>
        /// The Identifier, Time of Parking, Time of Creation and the Distance Drivene for the Car
        /// </summary>
        public int id, timeOfParking, timeOfCreation, distanceDriven;
        /// <summary>
        /// The time of queuing
        /// </summary>
        public double timeOfQueuing;

        /// <summary>
        /// Initializes a new instance of the <see cref="Car" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="destination">Where the car is planed to park.</param>
        /// <param name="arrivalFrom">Where the car comes from.</param>
        /// <param name="timeOfCreation">The time of creation.</param>
        public Car(int id, Parkingspot destination, ParkingQueue arrivalFrom, int timeOfCreation)
        {
            this.id = id;
            this.Destination = destination;
            this.arrivalFrom = arrivalFrom;
            this.timeOfCreation = timeOfCreation;
            this.timeOfQueuing = timeOfCreation;
            this.distanceDriven = 0;
        }
        /// <summary>
        /// Gets the time of parking.
        /// </summary>
        /// <returns></returns>
        public int getTimeOfParking()
        {
            return timeOfParking;
        }
        /// <summary>
        /// Gets the time of creation.
        /// </summary>
        /// <returns></returns>
        public int getTimeOfCreation()
        {
            return timeOfCreation;
        }
        /// <summary>
        /// Sets the time of parking.
        /// </summary>
        /// <param name="timeOfParking">The time of parking.</param>
        public void setTimeofParking(int timeOfParking)
        {
            this.timeOfParking = timeOfParking;
        }
        /// <summary>
        /// Sets the time of queuing.
        /// </summary>
        /// <param name="timeOfQueuing">The time of queuing.</param>
        public void setTimeOfQueuing(double timeOfQueuing)
        {
            this.timeOfQueuing = timeOfQueuing;
        }
        /// <summary>
        /// Sets the destination.
        /// </summary>
        /// <param name="ps">The ps.</param>
        public void setDestination(Parkingspot ps)
        {
            originalDestination = Destination;
            this.Destination = ps;
        }
        /// <summary>
        /// Sets the distance driven.
        /// </summary>
        /// <param name="d">The d.</param>
        public void setDistanceDriven(int d)
        {
            distanceDriven += d;
        }
    }
}
