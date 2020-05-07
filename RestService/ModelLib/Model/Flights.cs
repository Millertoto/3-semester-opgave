using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Model
{
    public class Flights
    {
        // instance fields
        private string _flightNr;
        private string _departure;
        private string _destination;
        private double _distance;
        private double _trivelTime;
        private int _capacity;
        private double _fuelConsumption;

        public Flights()
        {

        }

        public Flights(string flightNr, string departure, string destination, double distance,
            double trivelTime, int capacity, double fuelConsumption)

        {
            _flightNr = flightNr;
            _departure = departure;
            _destination = destination;
            _distance = distance;
            _trivelTime = trivelTime;
            _capacity = capacity;
            _fuelConsumption = fuelConsumption;
        }
    }
}
    

