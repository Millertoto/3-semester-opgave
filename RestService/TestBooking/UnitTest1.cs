using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var result = controller.GetAllFlights() as List<Flights>;

            Assert.AreEqual(6, result.Count);
        }
    }
}
