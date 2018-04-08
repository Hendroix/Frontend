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
    public class ParkingQueue
    {
        /// <summary>
        /// The name
        /// </summary>
        public String name;
        /// <summary>
        /// The cars in queue
        /// </summary>
        public Queue carsInQueue = new Queue();
        /// <summary>
        /// The maximum possible cars in this queue
        /// </summary>
        public int maxPossibleCarsInQueue;
        /// <summary>
        /// Initializes a new instance of the <see cref="ParkingQueue" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="carsInQueue">The cars in queue.</param>
        /// <param name="maxPossibleCarsInQueue">The maximum possible cars in queue.</param>
        public ParkingQueue(string name, Queue carsInQueue, int maxPossibleCarsInQueue)
        {
            this.name = name;
            this.carsInQueue = carsInQueue;
            this.maxPossibleCarsInQueue = maxPossibleCarsInQueue;
        }
        /// <summary>
        /// Checks if possible to place more cars in this queue.
        /// </summary>
        /// <returns></returns>
        public bool checkIfFree()
        {
            if (carsInQueue.Count < maxPossibleCarsInQueue)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

    }
}
