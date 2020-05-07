using Flybooking2.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib.Model;
using System.Collections.Generic;
namespace TestBooking
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllFlightsTest()
        {
            // Vi skaber en instans af vores flighs controller,
            // for at kunne bruge metoderne den indeholder
            // til at finde ud af, om metoden henter vores liste med flights.
            FlightsController controller = new FlightsController();
            var result = controller.GetAllFlights() as List<Flight>;

            Assert.AreEqual(5, result.Count);
        }

        [TestMethod]
        public void GetSpecificFlightTest()
        {
            FlightsController controller = new FlightsController();

            var result = controller.GetSpecificFlight("Zf9-2tk");

            Assert.AreEqual(9, result.Capacity);
        }
    }
}
