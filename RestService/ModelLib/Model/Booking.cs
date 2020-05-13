using System;
using System.Collections.Generic;
using System.Text; 
namespace ModelLib.Model
{ 
    public class Booking 
    { 
        private string _flightNr;
        private int _seatNr;
        private string _travelClass;
        private bool _allReadyBooked;
        public Booking(string flightNr, int seatNr, string travelClass, bool allReadyBooked) 
        {
            FlightNr = flightNr;
            SeatNr = seatNr;
            TravelClass = travelClass;
            AllReadyBooked = allReadyBooked;
        }
        public string FlightNr { get; set; }
        public int SeatNr { get; set; }
        public string TravelClass { get; set; }
        public bool AllReadyBooked { get; set; }
    }
}
