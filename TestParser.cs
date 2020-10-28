using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TPLab1_CSharp_console
{
    [TestFixture]
    class TestParser
    {
        static StreamReader sr = new StreamReader("DEBUG_output.txt", System.Text.Encoding.Default);

        static string json = sr.ReadLine();

        Parser pars = new Parser(json);
        Flights flight = new Flights();

        [Test]
        public void Test_My_Parser_Data()
        {
            flight = pars.GetFlights();
            Assert.AreEqual("2019-04-08", flight.search_data);
        }

        [Test]
        public void Test_My_Parser_Transport_Type()
        {
            flight = pars.GetFlights();
            Assert.AreEqual("plane", flight.thread_transport_type);
        }
    }
}
