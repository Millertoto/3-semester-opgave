using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;

namespace Flybooking2.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private static List<Flight> flights = new List<Flight>()
        {
            new Flight("", "", "", 5.7, 10.3, 9, 50.59),
            new Flight("", "", "", 10.7, 20.3, 18, 60.69),
            new Flight("", "", "", 20.7, 30.3, 36, 70.79),
            new Flight("", "", "", 30.7, 40.3, 50, 50.50),
            new Flight("", "", "", 49.7, 50.3, 60, 70.70)
        };

        // GET: api/Flights
        [HttpGet]
        public IEnumerable<Flight> GetAllFlights()
        {
            return flights;
        }

        // GET: api/Flights/5
        [HttpGet("{id}", Name = "Get")]
        public Flight Get(string FlightNr)
        {
            return flights.Find(i => i.FlightNr == FlightNr);
        }

        // POST: api/Flights
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Flights/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
