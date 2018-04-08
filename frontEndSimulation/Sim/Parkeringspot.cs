using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringssimulering
{
    /// <summary>
    /// 
    /// </summary>
    public class Parkingspot
    {
        /// <summary>
        /// The name of the parkingspot.
        /// </summary>
        public String name;
        /// <summary>
        /// the variables used for this class: takenSpaces, freeSpaces and totalSpaces.
        /// </summary>
        public int takenSpaces, freeSpaces, totalParkingSpaces;
        /// <summary>
        /// The list of cars that are parked in this parkingspot.
        /// </summary>
        public ArrayList listOfCars = new ArrayList();

        /// <summary>
        /// Initializes a new instance of the <see cref="Parkingspot" /> class.
        /// </summary>
        /// <param name="name">The name of the parkingspot.</param>
        /// <param name="totalParkingSpaces">The totalparking spaces.</param>
        /// <param name="takenSpaces">The amount taken parkingspots.</param>
        public Parkingspot(string name, int totalParkingSpaces, int takenSpaces)
        {
            this.name = name;
            this.totalParkingSpaces = totalParkingSpaces;
            this.takenSpaces = listOfCars.Count;
            this.freeSpaces = totalParkingSpaces - listOfCars.Count;
        }
        /// <summary>
        /// Gets the amount of cars currently in this parkingspot.
        /// </summary>
        /// <returns></returns>
        public int getTakenSpaces()
        {
            return listOfCars.Count;
        }
        /// <summary>
        /// Gets the free parkingspaces.
        /// </summary>
        /// <returns></returns>
        public int getFreeSpaces()
        {
            return freeSpaces;
        }
        /// <summary>
        /// Gets the total parkingspaces.
        /// </summary>
        /// <returns></returns>
        public int getTotalParkingSpaces()
        {
            return totalParkingSpaces;
        }
        /// <summary>
        /// Returns true if the parkingspot is available
        /// </summary>
        /// <returns></returns>
        public bool Free()
        {
            if (listOfCars.Count < totalParkingSpaces)
                return true;
            else
                return false;
        }

    }
}
