﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Model
{
    public class Flight
    {
        // instance fields
        private string _flightNr;
        private string _departure;
        private string _destination;
        private double _distance;
        private double _travelTime;
        private int _capacity;
        private double _fuelConsumption;

        public Flight()
        {

        }

        public Flight(string flightNr, string departure, string destination, double distance,
            double travelTime, int capacity, double fuelConsumption)

        {
            _flightNr = flightNr;
            _departure = departure;
            _destination = destination;
            _distance = distance;
            _travelTime = travelTime;
            _capacity = capacity;
            _fuelConsumption = fuelConsumption;
        }

        public string FlightNr
        {
            get;
            set;
        }
        public string Departure
        {
            get;
            set;
        }
        public string Destination
        {
            get;
            set;
        }
        public double Distance
        {
            get;
            set;
        }

        public double TravelTime
        {
            get;
            set;
        }

        public int Capacity
        {
            get;
            set;
        }

        public double FuelConsumption
        {
            get;
            set;
        }

        public string ToString()
        {
            return FlightNr + " " + Departure + " " + Destination + " " + Capacity + " " + TravelTime + " " + FuelConsumption + " " + Distance;
        }
    }
}
    

