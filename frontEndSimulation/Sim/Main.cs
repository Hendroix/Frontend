using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringssimulering
{
    /// <summary>
    /// the Main main
    /// </summary>
    public class main
    {
        public static string returnStringContext;
        public static Random random;
        public static Random s_Random = new Random();
        public static int[] randomArray = new int[1000000], randomArray3 = new int[1000000];
        public static double[] randomArray2 = new double[1000000];
        public static int randomPointer = 1, randomPointer2 = 1, randomPointer3 = 1;
        public static Parkingspot inspiria, inspiriaBak, superland, quality, kiwi, politi, caverion, k5, tuneSenter, adeccoAndIf, fagforbundet;
        public static int Kiwi, Inspiria, InspiriaBak, Superland, Quality, Politi, Caverion, K5, TuneSenter, AdeccoAndIf, Fagforbundet;
        public static int arrivingCars, maxParkingspots, freeSpaces, takenSpaces, totalAmountOfCars, currentSimTime, finalSimTime, counldtFindParking, delaySleepTime, currentlyMade, totalAmountOfCarsCounter;
        /// <summary>
        /// Initializes the specified parking spots.
        /// </summary>
        /// <param name="parkingSpots">The parking spots.</param>
        /// <param name="parkingPercentage">The parking percentage.</param>
        /// <param name="amountOfCars">The amount of cars.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="speed">The speed.</param>
        /// <returns></returns>
        public static string Initialize(int[] parkingSpots, int[] parkingPercentage, int amountOfCars, int timeFrom, int timeTo, int speed)
        {
            returnStringContext = "";
            //Trafic queues.
            //E6
            Queue e6Queue = new Queue(); 

            //Sykehusveien North
            Queue sykehusVeienQueueNorth = new Queue(); 
            Queue sykehusVeienQueueNorth_1 = new Queue(); 
            Queue sykehusVeienQueueNorth_2 = new Queue(); 
            Queue sykehusVeienQueueNorth_3 = new Queue(); 
            Queue sykehusVeienQueueNorth_4 = new Queue();
            //Sykehusveien South
            Queue sykehusVeienQueueSouth = new Queue(); 
            Queue sykehusVeienQueueSouth_1 = new Queue();
            Queue sykehusVeienQueueSouth_2 = new Queue();
            Queue sykehusVeienQueueSouth_3 = new Queue(); 
            Queue sykehusVeienQueueSouth_4 = new Queue();

            //Tuneveien North
            Queue tuneVeienQueueNorth = new Queue();
            Queue tuneVeienQueueNorth_1 = new Queue();
            //Tuneveien South
            Queue tuneVeienQueueSouth = new Queue();

            //Grålumveien North
            Queue grålumVeienQueueNorth = new Queue();
            Queue grålumVeienQueueNorth_1 = new Queue();

            //Parkingspots that are avaliable to park on. There are some descrepencies here because we need more parkingspots to meet the 1200 cars that are arriving in this simulation.
            inspiria = new Parkingspot("Inspiria", parkingSpots[0], 0);
            inspiriaBak = new Parkingspot("Inspiria Bak", parkingSpots[1], 0);
            superland = new Parkingspot("Superland", parkingSpots[2], 0);
            quality = new Parkingspot("Quality Hotell", parkingSpots[3], 0);
            kiwi = new Parkingspot("Kiwi", parkingSpots[4], 0);
            politi = new Parkingspot("Politihuset", parkingSpots[5], 0);
            caverion = new Parkingspot("Caverion", parkingSpots[6], 0);
            k5 = new Parkingspot("K5", parkingSpots[7], 0);
            tuneSenter = new Parkingspot("Tune Senter", parkingSpots[8], 0);
            adeccoAndIf = new Parkingspot("Adecco and If", parkingSpots[9], 0);
            fagforbundet = new Parkingspot("Fagforbundet", parkingSpots[10], 0);

            //Parking queues...
            //E6
            ParkingQueue e6South = new ParkingQueue("E6", e6Queue, 29);

            //Tuneveien North
            ParkingQueue tuneVeienNorth = new ParkingQueue("TuneveienNorth", tuneVeienQueueNorth, 29);
            ParkingQueue tuneVeienNorth_1 = new ParkingQueue("TuneveienNorth_1", tuneVeienQueueNorth_1, 29);
            //Tuneveien South
            ParkingQueue tuneVeienSouth = new ParkingQueue("TuneveienSouth", tuneVeienQueueSouth, 29);

            //Grålumveien North
            ParkingQueue gralumVeienNorth = new ParkingQueue("GrålumveienNorth", grålumVeienQueueNorth, 29);
            ParkingQueue gralumVeienNorth_1 = new ParkingQueue("GrålumveienNorth_1", grålumVeienQueueNorth_1, 29);

            //Sykehusveien North
            ParkingQueue sykehusVeienNorth = new ParkingQueue("SykehusveienNorth", sykehusVeienQueueNorth, 37);
            ParkingQueue sykehusVeienNorth_1 = new ParkingQueue("SykehusveienNorth_1", sykehusVeienQueueNorth_1, 14);
            ParkingQueue sykehusVeienNorth_2 = new ParkingQueue("SykehusveienNorth_2", sykehusVeienQueueNorth_2, 29);
            ParkingQueue sykehusVeienNorth_3 = new ParkingQueue("SykehusveienNorth_3", sykehusVeienQueueNorth_3, 29);
            ParkingQueue sykehusVeienNorth_4 = new ParkingQueue("SykehusveienNorth_4", sykehusVeienQueueNorth_4, 29);
            //Sykehusveien South
            ParkingQueue sykehusVeienSouth = new ParkingQueue("SykehusveienSouth", sykehusVeienQueueSouth, 29);
            ParkingQueue sykehusVeienSouth_1 = new ParkingQueue("SykehusveienSouth_1", sykehusVeienQueueSouth_1, 29);
            ParkingQueue sykehusVeienSouth_2 = new ParkingQueue("SykehusveienSouth_2", sykehusVeienQueueSouth_2, 29);
            ParkingQueue sykehusVeienSouth_3 = new ParkingQueue("SykehusveienSouth_3", sykehusVeienQueueSouth_3, 17);
            ParkingQueue sykehusVeienSouth_4 = new ParkingQueue("SykehusveienSouth_4", sykehusVeienQueueSouth_4, 37);

            Parkingspot[] parkingspotArray = { inspiria, inspiriaBak, superland, quality, kiwi, politi, caverion, k5, tuneSenter, adeccoAndIf, fagforbundet };
            ParkingQueue[] parkingQueueArrayArrivingCars = { e6South, tuneVeienNorth, gralumVeienNorth, sykehusVeienSouth };
            ParkingQueue[] parkingQueueArrayCheck = { e6South, tuneVeienNorth, tuneVeienNorth_1, tuneVeienSouth, gralumVeienNorth, gralumVeienNorth_1,
                sykehusVeienNorth, sykehusVeienNorth_1, sykehusVeienNorth_2, sykehusVeienNorth_3, sykehusVeienNorth_4, sykehusVeienSouth, sykehusVeienSouth_1, sykehusVeienSouth_2,
                sykehusVeienSouth_3, sykehusVeienSouth_4 };
            
            //Defines the starting criterias
            currentSimTime = timeFrom;
            finalSimTime = timeTo;
            delaySleepTime = speed;
            currentlyMade = 0;
            //Uncomment this for a shit tun of cars to arrive
            totalAmountOfCarsCounter = 0;
            totalAmountOfCars = amountOfCars - amountOfCars;
            generateRandomNumbers();
            //Start of While simulation loop
            while (currentSimTime <= finalSimTime)
            {
                returnStringContext += ("Runde: " + currentSimTime + " Tid: " + calculateTimeFromIntervals(currentSimTime));
                //Intervall round 1
                if (currentSimTime <= 30)
                {
                    returnStringContext += "\r\n";
                    if (currentlyMade == 0)
                    {
                        int carsToBeMade = getArrivingCarsRandom(2.93f);
                        if (totalAmountOfCars < (amountOfCars * 0.083))
                        {
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
                            Task.Delay(delaySleepTime).Wait();
                        }
                        returnStringContext += "Biler lagd: " + (totalAmountOfCars - currentlyMade) + "\r\n";
                    }
                }
                //Intervall round 2
                if (currentSimTime <= 90 && currentSimTime > 30)
                {
                    returnStringContext += "\r\n";
                    if (currentlyMade == 0)
                    {
                        int carsToBeMade = getArrivingCarsRandom(0.8f);
                        if (totalAmountOfCars < (amountOfCars * 0.1241))
                        {
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
                            Task.Delay(delaySleepTime).Wait();
                        }
                        returnStringContext += "Biler lagd: " + (totalAmountOfCars - currentlyMade) + "\r\n";
                    }
                }
                //Intervall round 3
                if (currentSimTime <= 114 && currentSimTime > 90)
                {
                    returnStringContext += "\r\n";
                    if (currentlyMade == 0)
                    {
                        int carsToBeMade = getArrivingCarsRandom(0.58f);
                        if (totalAmountOfCars < (amountOfCars * 0.1369))
                        {
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
                            Task.Delay(delaySleepTime).Wait();
                        }
                        returnStringContext += "Biler lagd: " + (totalAmountOfCars - currentlyMade) + "\r\n";
                    }
                }
                //Intervall round 4
                if (currentSimTime <= 180 && currentSimTime > 114)
                {
                    returnStringContext += "\r\n";
                    if (currentlyMade == 0)
                    {
                        int carsToBeMade = getArrivingCarsRandom(2.15f);
                        if (totalAmountOfCars < (amountOfCars * 0.2664))
                        {
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
                            Task.Delay(delaySleepTime).Wait();
                        }
                        returnStringContext += "Biler lagd: " + (totalAmountOfCars - currentlyMade) + "\r\n";
                    }
                }
                //Intervall round 5
                if (currentSimTime <= 234 && currentSimTime > 180)
                {
                    returnStringContext += "\r\n";
                    if (currentlyMade == 0)
                    {
                        int carsToBeMade = getArrivingCarsRandom(0.22f);
                        if (totalAmountOfCars < (amountOfCars * 0.2774))
                        {
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
                            Task.Delay(delaySleepTime).Wait();
                        }
                        returnStringContext += "Biler lagd: " + (totalAmountOfCars - currentlyMade) + "\r\n";
                    }
                }
                //Intervall round 6
                if (currentSimTime <= 270 && currentSimTime > 234)
                {
                    returnStringContext += "\r\n";
                    if (currentlyMade == 0)
                    {
                        int carsToBeMade = getArrivingCarsRandom(2.25f);
                        if (totalAmountOfCars < (amountOfCars * 0.3513))
                        {
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
                            Task.Delay(delaySleepTime).Wait();
                        }
                        returnStringContext += "Biler lagd: " + (totalAmountOfCars - currentlyMade) + "\r\n";
                    }
                }
                //Intervall round 7
                if (currentSimTime <= 312 && currentSimTime > 270)
                {
                    returnStringContext += "\r\n";
                    if (currentlyMade == 0)
                    {
                        int carsToBeMade = getArrivingCarsRandom(1.36f);
                        if (totalAmountOfCars < (amountOfCars * 0.4033))
                        {
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
                            Task.Delay(delaySleepTime).Wait();
                        }
                        returnStringContext += "Biler lagd: " + (totalAmountOfCars - currentlyMade) + "\r\n";
                    }
                }
                //Intervall round 8
                if (currentSimTime <= 336 && currentSimTime > 312)
                {
                    returnStringContext += "\r\n";
                    if (currentlyMade == 0)
                    {
                        int carsToBeMade = getArrivingCarsRandom(1.58f);
                        if (totalAmountOfCars < (amountOfCars * 0.4380))
                        {
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
                            Task.Delay(delaySleepTime).Wait();
                        }
                        returnStringContext += "Biler lagd: " + (totalAmountOfCars - currentlyMade) + "\r\n";
                    }
                }
                //Intervall round 9
                if (currentSimTime <= 390 && currentSimTime > 336)
                {
                    returnStringContext += "\r\n";
                    if (currentlyMade == 0)
                    {
                        int carsToBeMade = getArrivingCarsRandom(6.89f);
                        if (totalAmountOfCars < (amountOfCars * 0.7774))
                        {
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
                            Task.Delay(delaySleepTime).Wait();
                        }
                        returnStringContext += "Biler lagd: " + (totalAmountOfCars - currentlyMade) + "\r\n";
                    }
                }
                //Intervall round 10
                if (currentSimTime <= 450 && currentSimTime > 390)
                {
                    returnStringContext += "\r\n";
                    if (currentlyMade == 0)
                    {
                        int carsToBeMade = getArrivingCarsRandom(0.7f);
                        if (totalAmountOfCars < (amountOfCars * 0.8157))
                        {
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
                            Task.Delay(delaySleepTime).Wait();
                        }
                        returnStringContext += "Biler lagd: " + (totalAmountOfCars - currentlyMade) + "\r\n";
                    }
                }
                //Intervall round 11
                if (currentSimTime <= 540 && currentSimTime > 450)
                {
                    returnStringContext += "\r\n";
                    if (currentlyMade == 0)
                    {
                        int carsToBeMade = getArrivingCarsRandom(1.41f);
                        if (totalAmountOfCars < (amountOfCars * 0.9316))
                        {
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
                            Task.Delay(delaySleepTime).Wait();
                        }
                        returnStringContext += "Biler lagd: " + (totalAmountOfCars - currentlyMade) + "\r\n";
                    }
                }
                //Intervall round 12
                if (currentSimTime <= 630 && currentSimTime > 540)
                {
                    returnStringContext += "\r\n";
                    if (currentlyMade == 0)
                    {
                        int carsToBeMade = getArrivingCarsRandom(0.18f);
                        if (totalAmountOfCars < (amountOfCars * 0.9462))
                        {
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
                            Task.Delay(delaySleepTime).Wait();
                        }
                        returnStringContext += "Biler lagd: " + (totalAmountOfCars - currentlyMade) + "\r\n";
                    }
                }
                //Intervall round 13
                if (currentSimTime <= 786 && currentSimTime > 630)
                {
                    returnStringContext += "\r\n";
                    if (currentlyMade == 0)
                    {
                        int carsToBeMade = getArrivingCarsRandom(0.20f);
                        if (totalAmountOfCars < (amountOfCars * 0.9745))
                        {
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
                            Task.Delay(delaySleepTime).Wait();
                        }
                        returnStringContext += "Biler lagd: " + (totalAmountOfCars - currentlyMade) + "\r\n";
                    }
                }
                //Intervall round 14
                if (currentSimTime <= 900 && currentSimTime > 786)
                {
                    returnStringContext += "\r\n";
                    if (currentlyMade == 0)
                    {
                        int carsToBeMade = getArrivingCarsRandom(0.11f);
                        if (totalAmountOfCars < (amountOfCars * 0.9854))
                        {
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
                            Task.Delay(delaySleepTime).Wait();
                        }
                        returnStringContext += "Biler lagd: " + (totalAmountOfCars - currentlyMade) + "\r\n";
                    }
                }
                //Intervall round 15
                if (currentSimTime <= 1080 && currentSimTime > 900)
                {
                    returnStringContext += "\r\n";
                    if (currentlyMade == 0)
                    {
                        int carsToBeMade = getArrivingCarsRandom(0.09f);
                        if (totalAmountOfCars < (amountOfCars))
                        {
                            createAndGivePurposeToCars(carsToBeMade, currentlyMade, parkingQueueArrayArrivingCars);
                            Task.Delay(delaySleepTime).Wait();
                        }
                        returnStringContext += "Biler lagd: " + (totalAmountOfCars - currentlyMade) + "\r\n";
                    }
                }
                //Traverse the parkingqueues and move cars that are in the queue.
                for (int i = 0; i < 2; i++) { 
                foreach (ParkingQueue pq in parkingQueueArrayCheck)
                {
                    //Fra E6
                    if (pq.name == e6South.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Kiwi/Tuneveien
                            if (ps.name == kiwi.name && tuneVeienSouth.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                tuneVeienSouth.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                c.setDistanceDriven(100);
                            }
                            //all annen trafikk fra E6 skal til sykehusveien
                            else if (sykehusVeienNorth.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienNorth.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                c.setDistanceDriven(100);
                            }
                        }
                    }
                    //Fra Tuneveien Sør
                    if (pq.name == tuneVeienSouth.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Kiwi/Tuneveien
                            if (ps.name == kiwi.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(100);
                            }
                            else if (ps.name == kiwi.name && !ps.Free())
                            {
                                c.setDestination(quality);
                            }
                            else if (tuneVeienNorth_1.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                tuneVeienNorth_1.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                c.setDistanceDriven(100);
                            }
                        }
                    }
                    //Fra TuneveienNord
                    if (pq.name == tuneVeienNorth.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Kiwi
                            if (ps.name == kiwi.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(100);
                            }
                            else if (ps.name == kiwi.name && !ps.Free())
                            {
                                c.setDestination(quality);
                            }
                            else if (tuneVeienNorth_1.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                tuneVeienNorth_1.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                c.setDistanceDriven(100);
                            }
                        }
                    }
                    //Fra TuneveienNord_1
                    if (pq.name == tuneVeienNorth_1.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til SykehusveienNord
                            if (sykehusVeienNorth.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienNorth.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                c.setDistanceDriven(100);
                            }
                        }
                    }
                    //Fra grålumveien
                    if (pq.name == gralumVeienNorth.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til grålumveienNord_1
                            if (gralumVeienNorth_1.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                gralumVeienNorth_1.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                c.setDistanceDriven(100);
                            }
                        }
                    }
                    //Fra grålumveienNord_1
                    if (pq.name == gralumVeienNorth_1.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Kiwi
                            if (ps.name == kiwi.name && tuneVeienSouth.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                tuneVeienSouth.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(100);
                            }
                            //Til sykehusveien
                            else if (sykehusVeienNorth.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienNorth.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                c.setDistanceDriven(100);
                            }
                        }
                    }
                    //Fra sykehusveienNord
                    if (pq.name == sykehusVeienNorth.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Politihuset
                            if (ps.name == politi.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(130);
                            }
                            //Om politiet er fullt
                            else if (ps.name == politi.name && !ps.Free())
                            {
                                c.setDestination(tuneSenter);
                            }
                            //Til Quality
                            else if (ps.name == quality.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(130);
                            }
                            //Om Quality er fullt
                            else if (ps.name == quality.name && !ps.Free())
                            {
                                c.setDestination(superland);
                            }
                            //Til Superland
                            else if (ps.name == superland.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(130);
                            }
                            //Om Superland er fult
                            else if (ps.name == superland.name && !ps.Free())
                            {
                                c.setDestination(inspiria);
                            }
                            //Til If og Adecco
                            else if (ps.name == adeccoAndIf.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(130);
                            }
                            //Om if og Adecco er fullt
                            else if (ps.name == adeccoAndIf.name && !ps.Free())
                            {
                                c.setDestination(politi);
                            }
                            //Til Tunesenteret
                            else if (ps.name == tuneSenter.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(130);
                            }
                            //Om Tunesenteret er fullt
                            else if (ps.name == tuneSenter.name && !ps.Free())
                            {
                                c.setDestination(fagforbundet);
                            }
                            //Til Fagforbundet
                            else if (ps.name == fagforbundet.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(130);
                            }
                            //Om Fagforbundet er fullt
                            else if (ps.name == fagforbundet.name && !ps.Free())
                            {
                                c.setDestination(kiwi);
                            }
                            //Send videre til SykehusveienNorth_1
                            else if (sykehusVeienNorth_1.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienNorth_1.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                c.setDistanceDriven(130);
                            }
                        }
                    }
                    //Fra sykehusveienNord_1
                    if (pq.name == sykehusVeienNorth_1.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Inspiria
                            if (ps.name == inspiria.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(50);
                            }
                            //Om inspiria er fullt
                            else if (ps.name == inspiria.name && !ps.Free())
                            {
                                c.setDestination(inspiriaBak);
                            }
                            //Send videre til sykehusVeienNorth_2
                            else if (sykehusVeienNorth_2.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienNorth_2.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                c.setDistanceDriven(50);
                            }
                        }
                    }
                    //Fra SykehusveienNorth_2
                    if (pq.name == sykehusVeienNorth_2.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til sykehusveienNorth_3
                            if (sykehusVeienNorth_3.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienNorth_3.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                c.setDistanceDriven(100);
                            }
                        }
                    }
                    //Fra sykehusveienNord_3
                    if (pq.name == sykehusVeienNorth_3.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Inspiria bak
                            if (ps.name == inspiriaBak.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(100);
                            }
                            //Om inspiria bak er fullt
                            else if (ps.name == inspiriaBak.name && !ps.Free())
                            {
                                c.setDestination(k5);
                            }
                            //Til Caverion
                            else if (ps.name == caverion.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(100);
                            }
                            //Om Caverion er fullt
                            else if (ps.name == caverion.name && !ps.Free())
                            {
                                c.setDestination(adeccoAndIf);
                            }
                            //Til k5
                            else if (ps.name == k5.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(100);
                            }
                            //Om k5 er fullt
                            else if (ps.name == k5.name && !ps.Free())
                            {
                                c.setDestination(caverion);
                            }
                            //Send videre til sykehusveienNorth_4
                            else if (sykehusVeienNorth_4.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienNorth_4.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                c.setDistanceDriven(100);
                            }
                        }
                    }
                    //Fra sykehusveienNord_4
                    if (pq.name == sykehusVeienNorth_4.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            if (sykehusVeienSouth.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienSouth.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                c.setDistanceDriven(100);
                            }
                        }
                    }
                    //Fra sykehusveienSør
                    if (pq.name == sykehusVeienSouth.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Inspiria bak
                            if (ps.name == inspiriaBak.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(100);
                            }
                            //Om inspiria bak er fullt
                            else if (ps.name == inspiriaBak.name && !ps.Free())
                            {
                                c.setDestination(k5);
                            }
                            //Til Caverion
                            else if (ps.name == caverion.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(100);
                            }
                            //Om caverion er fullt
                            else if (ps.name == caverion.name && !ps.Free())
                            {
                                c.setDestination(adeccoAndIf);
                            }
                            //Til k5
                            else if (ps.name == k5.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(100);
                            }
                            //Om k5 er fullt
                            else if (ps.name == inspiriaBak.name && !ps.Free())
                            {
                                c.setDestination(caverion);
                            }
                            //Send videre til sykehusveienSouth_1
                            else if (sykehusVeienSouth_1.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienSouth_1.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                c.setDistanceDriven(100);
                            }
                        }
                    }
                    //Fra sykehusveienSør1
                    if (pq.name == sykehusVeienSouth_1.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            if (sykehusVeienSouth_2.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienSouth_2.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                c.setDistanceDriven(100);
                            }

                        }
                    }
                    //Fra sykehusveienSær_2
                    if (pq.name == sykehusVeienSouth_2.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Inspiria
                            if (ps.name == inspiria.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(100);
                            }
                            //Om inspiria er fullt
                            else if (ps.name == inspiria.name && !ps.Free())
                            {
                                c.setDestination(quality);
                            }
                            //Send videre til sykehusveienSouth_3
                            else if (sykehusVeienSouth_3.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienSouth_3.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                c.setDistanceDriven(100);
                            }
                        }
                    }
                    //Fra sykehusveienSouth_3
                    if (pq.name == sykehusVeienSouth_3.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Politihuset
                            if (ps.name == politi.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(100);
                            }
                            //Om politiet er fullt
                            else if (ps.name == politi.name && !ps.Free())
                            {
                                c.setDestination(tuneSenter);
                            }
                            //Til Quality
                            else if (ps.name == quality.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(100);
                            }
                            //Om Quality er fullt
                            else if (ps.name == quality.name && !ps.Free())
                            {
                                c.setDestination(superland);
                            }
                            //Til Superland
                            else if (ps.name == superland.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(100);
                            }
                            //Om Superland er fult
                            else if (ps.name == superland.name && !ps.Free())
                            {
                                c.setDestination(inspiria);
                            }
                            //Til If og Adecco
                            else if (ps.name == adeccoAndIf.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(100);
                            }
                            //Om if og Adecco er fullt
                            else if (ps.name == adeccoAndIf.name && !ps.Free())
                            {
                                c.setDestination(politi);
                            }
                            //Til Tunesenteret
                            else if (ps.name == tuneSenter.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(100);
                            }
                            //Om Tunesenteret er fullt
                            else if (ps.name == tuneSenter.name && !ps.Free())
                            {
                                c.setDestination(fagforbundet);
                            }
                            //Til Fagforbundet
                            else if (ps.name == fagforbundet.name && ps.Free())
                            {
                                pq.carsInQueue.Dequeue();
                                ps.listOfCars.Add(c);
                                c.setTimeOfQueuing(currentSimTime + 1);
                                c.setDistanceDriven(100);
                            }
                            //Om Fagforbundet er fullt
                            else if (ps.name == fagforbundet.name && !ps.Free())
                            {
                                c.setDestination(kiwi);
                            }
                            //Send videre til sykehusveienSouth_4
                            else if (sykehusVeienSouth_4.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                sykehusVeienNorth_4.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                c.setDistanceDriven(100);
                            }
                        }
                    }
                    //Fra sykehusveienSør_4
                    if (pq.name == sykehusVeienSouth_4.name && pq.carsInQueue.Count > 0)
                    {
                        Car c = (Car)pq.carsInQueue.Peek();
                        if (c.getTimeOfCreation() < currentSimTime && c.timeOfQueuing < currentSimTime)
                        {
                            c.setTimeofParking(currentSimTime);
                            Parkingspot ps = c.Destination;
                            //Til Kiwi/Tuneveien
                            if (ps.name == kiwi.name && tuneVeienSouth.checkIfFree() == true)
                            {
                                pq.carsInQueue.Dequeue();
                                tuneVeienSouth.carsInQueue.Enqueue(c);
                                c.setTimeOfQueuing(currentSimTime);
                                c.setDistanceDriven(130);
                            }
                        }
                    }

                }
                }
                //End of while simulation loop
                returnStringContext += "\r\n";
                currentSimTime++;
            }
            //Simulation ended
            printTotalParkingInfo(parkingspotArray);
            printTotalParkingInfoCarDetails(parkingspotArray);
            returnStringContext += "\r\n";
            printRemainingCarsInQueue(parkingQueueArrayCheck);
            //send back the simulation data to the MainPage frontend
            return returnStringContext;
        }
        /// <summary>
        /// Creates and give purpose to the cars.
        /// </summary>
        /// <param name="wantedAmountOfCars">The wanted amount of cars.</param>
        /// <param name="alreadyMadeCars">The amount of already made cars.</param>
        /// <param name="listOfParkingsQueues">The list of parkings queues.</param>
        public static void createAndGivePurposeToCars(int wantedAmountOfCars, int alreadyMadeCars, ParkingQueue[] listOfParkingsQueues)
        {
            while (wantedAmountOfCars > alreadyMadeCars)
            {
                makeCar(randomArray[randomPointer], getQueue(listOfParkingsQueues));
                alreadyMadeCars++;
                totalAmountOfCars++;
                totalAmountOfCarsCounter++;
            }
        }
        /// <summary>
        /// Generates random numbers.
        /// </summary>
        static void generateRandomNumbers()
        {
            Task.Delay(100).Wait();
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = (int)getRandomNumber("int", 0, 100);
            }
            Task.Delay(100).Wait();
            for (int i = 0; i < randomArray2.Length; i++)
            {
                randomArray2[i] = getRandomNumber("double", 0, 100);
            }
            Task.Delay(100).Wait();
            for (int i = 0; i < randomArray3.Length; i++)
            {
                randomArray3[i] = (int)getRandomNumber("int", 0, 3);
            }

        }
        /// <summary>
        /// Gets the random number.
        /// </summary>
        /// <param name="type">The type of random numbers you want int for int else you get a double.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        static double getRandomNumber(string type, int min, int max)
        {
            if (type == "int")
            {
                int newRandom = s_Random.Next(min, max);
                return newRandom;

            }
            else
            {
                double newRandom = s_Random.Next(min, max);
                return newRandom;
            }
        }
        /// <summary>
        /// Makes the car and places it in a starting queue .
        /// </summary>
        /// <param name="chance">The chance.</param>
        /// <param name="queuespot">The queuespot.</param>
        private static void makeCar(int chance, ParkingQueue queuespot)
        {
            int parkingChance = chance;

            if (parkingChance <= 9 && inspiria.Free())
            {
                Car car = new Car(randomPointer, inspiria, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                randomPointer++;
                Inspiria++;
            }
            else if (parkingChance <= 12 && inspiriaBak.Free())
            {
                Car car = new Car(randomPointer, inspiriaBak, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                randomPointer++;
                InspiriaBak++;
            }
            else if (parkingChance <= 27 && superland.Free())
            {
                Car car = new Car(randomPointer, superland, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                randomPointer++;
                Superland++;
            }
            else if (parkingChance <= 42 && quality.Free())
            {
                Car car = new Car(randomPointer, quality, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                randomPointer++;
                Quality++;
            }
            else if (parkingChance <= 57 && kiwi.Free())
            {
                Car car = new Car(randomPointer, kiwi, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                randomPointer++;
                Kiwi++;
            }
            else if (parkingChance <= 69 && politi.Free())
            {
                Car car = new Car(randomPointer, politi, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                randomPointer++;
                Politi++;
            }
            else if (parkingChance <= 73 && caverion.Free())
            {
                Car car = new Car(randomPointer, caverion, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                randomPointer++;
                Caverion++;
            }
            else if (parkingChance <= 76 && k5.Free())
            {
                Car car = new Car(randomPointer, k5, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                randomPointer++;
                K5++;
            }
            else if (parkingChance <= 84 && tuneSenter.Free())
            {
                Car car = new Car(randomPointer, tuneSenter, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                randomPointer++;
                TuneSenter++;
            }
            else if (parkingChance <= 92 && adeccoAndIf.Free())
            {
                Car car = new Car(randomPointer, adeccoAndIf, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                randomPointer++;
                AdeccoAndIf++;
            }
            else if (parkingChance <= 100 && fagforbundet.Free())
            {
                Car car = new Car(randomPointer, fagforbundet, queuespot, currentSimTime);
                placeInQueue(queuespot, car);
                randomPointer++;
                Fagforbundet++;
            }
            else
            {
                if (inspiria.Free())
                {
                    Car car = new Car(randomPointer, inspiria, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    randomPointer++;
                    Inspiria++;
                }
                else if (inspiriaBak.Free())
                {
                    Car car = new Car(randomPointer, inspiriaBak, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    randomPointer++;
                    InspiriaBak++;
                }
                else if (superland.Free())
                {
                    Car car = new Car(randomPointer, superland, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    randomPointer++;
                    Superland++;
                }
                else if (quality.Free())
                {
                    Car car = new Car(randomPointer, quality, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    randomPointer++;
                    Quality++;
                }
                else if (kiwi.Free())
                {
                    Car car = new Car(randomPointer, kiwi, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    randomPointer++;
                    Kiwi++;
                }
                else if (politi.Free())
                {
                    Car car = new Car(randomPointer, politi, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    randomPointer++;
                    Politi++;
                }
                else if (caverion.Free())
                {
                    Car car = new Car(randomPointer, caverion, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    randomPointer++;
                    Caverion++;
                }
                else if (k5.Free())
                {
                    Car car = new Car(randomPointer, k5, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    randomPointer++;
                    K5++;
                }
                else if (tuneSenter.Free())
                {
                    Car car = new Car(randomPointer, tuneSenter, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    randomPointer++;
                    TuneSenter++;
                }
                else if (adeccoAndIf.Free())
                {
                    Car car = new Car(randomPointer, adeccoAndIf, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    randomPointer++;
                    AdeccoAndIf++;
                }
                else if (fagforbundet.Free())
                {
                    Car car = new Car(randomPointer, fagforbundet, queuespot, currentSimTime);
                    placeInQueue(queuespot, car);
                    randomPointer++;
                    Fagforbundet++;
                }
                else
                {
                    counldtFindParking++;
                    randomPointer++;
                }
            }
        }
        /// <summary>
        /// Places the in queue.
        /// </summary>
        /// <param name="queuespot">The queuespot.</param>
        /// <param name="car">The car.</param>
        private static void placeInQueue(ParkingQueue queuespot, Car car)
        {
            queuespot.carsInQueue.Enqueue(car);
            returnStringContext += ("Car: " + car.id + ", Skal til: " + car.Destination.name + ", kommer fra " + queuespot.name);
            returnStringContext += "\r\n";
        }
        /// <summary>
        /// Gets the queue.
        /// </summary>
        /// <param name="parkingQueueArray">The parking queue array.</param>
        /// <returns></returns>
        private static ParkingQueue getQueue(ParkingQueue[] parkingQueueArray)
        {
            int chance = randomArray3[randomPointer3];
            ParkingQueue queuespot = parkingQueueArray[chance];
            randomPointer3++;
            return queuespot;

        }
        /// <summary>
        /// Gets the arriving cars random.
        /// </summary>
        /// <param name="chance">The chance for their to be more than one car arriving at any set interval.</param>
        /// <returns></returns>
        private static int getArrivingCarsRandom(double chance)
        {
            arrivingCars = 0;
            double c;
            bool hit = true;
            double luckyShot = 1f;
            while (hit)
            {
                c = (randomArray2[randomPointer2] / 100);
                if (chance > 1.0f)
                {
                    arrivingCars++;
                    chance = (chance - luckyShot);
                    randomPointer2++;
                }
                else if (c < chance && chance <= 1.0f)
                {
                    arrivingCars++;
                    randomPointer2++;
                    chance = chance * 0.5f;
                }
                else
                {
                    hit = false;
                    randomPointer2++;
                }
                randomPointer2++;
            }
            return arrivingCars;
        }
        /// <summary>
        /// Calculates the time from intervals.
        /// </summary>
        /// <param name="currentSimTime">The current sim time.</param>
        /// <returns></returns>
        private static string calculateTimeFromIntervals(int currentSimTime)
        {
            string timeString = "";
            int tmpTime = currentSimTime;
            if (currentSimTime < 360)
            {
                timeString += "07:";
                tmpTime = tmpTime / 6;
                if (tmpTime < 10)
                {
                    timeString += "0" + tmpTime;
                }
                else
                {
                    timeString += tmpTime;
                }
            }
            if (currentSimTime < 720 && currentSimTime >= 360)
            {
                timeString += "08:";
                tmpTime = (tmpTime - 360) / 6;
                if (tmpTime < 10)
                {
                    timeString += "0" + tmpTime;
                }
                else
                {
                    timeString += tmpTime;
                }

            }
            if (currentSimTime < 1080 && currentSimTime >= 720)
            {
                timeString += "09:";
                tmpTime = (tmpTime - 720) / 6;
                if (tmpTime < 10)
                {
                    timeString += "0" + tmpTime;
                }
                else
                {
                    timeString += tmpTime;
                }

            }
            if (currentSimTime == 1080)
            {
                timeString += "10:00";
            }
            return timeString;
        }
        /// <summary>
        /// Translates the intervals to time.
        /// </summary>
        /// <param name="intervals">The intervals.</param>
        /// <returns></returns>
        private static string translateIntervalsToTime(int intervals)
        {
            string timeString = "";
            int tmpTime = intervals;
            int[] timeIntervals = { 0,360,720,1080,1440,1800,2160,2520,2880,3240,3600,3960,4320,4680,5040,5400,5760,6120,6480,6840,7200,8560,7920,8280,8640};
            for(int i = 1; i < timeIntervals.Length; i++)
            {
                if (intervals < timeIntervals[i] && intervals >= timeIntervals[i-1])
                {
                    if (i < 10)
                    {
                        timeString += "0" + (i-1) + ":";
                        tmpTime = (tmpTime - (timeIntervals[i - 1])) / 6;
                    }
                    else
                    {
                        timeString += (i-1) + ":";
                        tmpTime = (tmpTime - (timeIntervals[i - 1])) / 6;

                    }
                    if(tmpTime < 10)
                    {
                        timeString += "0" + tmpTime;
                    }
                    else
                    {
                        timeString += tmpTime;
                    }
                }
            }
            return timeString;
        }
        /// <summary>
        /// Prints information about all the parkingspots you feed the method.
        /// </summary>
        /// <param name="array">The array of parkingspot you want stats printed from.</param>
        static void printTotalParkingInfo(Parkingspot[] array)
        {
            //Clearing the varaible before every print
            maxParkingspots = 0;
            takenSpaces = 0;
            freeSpaces = 0;
            //\r\n means spacing or line split
            returnStringContext += "\r\n";
            returnStringContext += "Parkeringsplass oversikt: ";
            returnStringContext += "\r\n";
            foreach (Parkingspot p in array)
            {
                if (p.listOfCars.Count > p.totalParkingSpaces)
                {
                    returnStringContext += (p.name + ": " + p.listOfCars.Count + "/" + p.totalParkingSpaces + " TO MANY CARS");
                    returnStringContext += "\r\n";
                }
                else
                {
                    returnStringContext += (p.name + ": " + p.listOfCars.Count + "/" + p.totalParkingSpaces);
                    returnStringContext += "\r\n";
                }
                maxParkingspots += p.getTotalParkingSpaces();
                takenSpaces += p.getTakenSpaces();
            }
            returnStringContext += "\r\n";
            returnStringContext += "Total oversikt: ";
            returnStringContext += "\r\n";
            returnStringContext += ("Totalt antall parkeringsplasser:          " + maxParkingspots);
            returnStringContext += "\r\n";
            returnStringContext += ("Totalt antall opptatte parkeringsplasser: " + takenSpaces);
            returnStringContext += "\r\n";
            returnStringContext += ("Totalt antall ledige parkeringsplasser:   " + (maxParkingspots - takenSpaces));
            returnStringContext += "\r\n";
            returnStringContext += ("Total cars made: " + totalAmountOfCarsCounter);
            returnStringContext += "\r\n";
            returnStringContext += ("Total cars returned home: " + (totalAmountOfCarsCounter - takenSpaces));
            returnStringContext += "\r\n";
        }
        /// <summary>
        /// Prints the total parking information car details.
        /// </summary>
        /// <param name="array">The array.</param>
        static void printTotalParkingInfoCarDetails(Parkingspot[] array)
        {
            int totalDistanceAllCars = 0;
            int totalWaitingTimeAllCars = 0;
            //\r\n means spacing or line split
            returnStringContext += "\r\n" + "Parkeringsplass oversikt: ";
            returnStringContext += "\r\n";
            foreach (Parkingspot p in array)
            {
                returnStringContext += p.name + "\r\n";
                int totalWaitingTime = 0;
                int totalDistanceDriven = 0;
                foreach (Car c in p.listOfCars)
                {
                    totalWaitingTime += (c.timeOfParking - c.timeOfCreation);
                    totalDistanceDriven += c.distanceDriven;
                }
                returnStringContext += "Biler parkert her: " + p.listOfCars.Count + "/" + p.totalParkingSpaces + "\r\n";
                returnStringContext += "Gjennomsnittlig tid i kø: " + translateIntervalsToTime((totalWaitingTime / p.listOfCars.Count)) + "\r\n";
                returnStringContext += "Total tid i kø: " + translateIntervalsToTime(totalWaitingTime) + "\r\n";
                returnStringContext += "Gjennomsnittlig distanse kjørt: " + (totalDistanceDriven / p.listOfCars.Count) + " meter" + "\r\n";
                returnStringContext += "Total distance kjørt: " + totalDistanceDriven + " meter" + "\r\n";
                returnStringContext += "\r\n";

                totalDistanceAllCars += totalDistanceDriven;
                totalWaitingTimeAllCars += totalWaitingTime;
            }
            returnStringContext += "Total distance kjørt for alle biler: " + (totalDistanceAllCars / 1000) + " Km";
            returnStringContext += "\r\n";
            returnStringContext += "Total tid brukt på alle biler: " + translateIntervalsToTime(totalWaitingTimeAllCars);
        }
        /// <summary>
        /// Prints the remaining cars in queue.
        /// </summary>
        /// <param name="pq">The Parkingqueues to print info about.</param>
        static void printRemainingCarsInQueue(ParkingQueue[] pq)
        {
            foreach (ParkingQueue queue in pq)
            {
                returnStringContext += (queue.name + "  Biler i min kø: " + queue.carsInQueue.Count);
                returnStringContext += "\r\n";
                if (queue.carsInQueue.Count > 0)
                {
                    foreach (Car c in queue.carsInQueue)
                    {
                        Debug.WriteLine("Bil: " + c.id + " destinasjon: " + c.Destination.name);
                        returnStringContext += ("Bil: " + c.id + " destinasjon: " + c.Destination.name);
                        returnStringContext += "\r\n";
                    }
                }
            }

        }
    }
}