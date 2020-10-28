using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLab1_CSharp_console
{
    [TestFixture]
    class TestURI
    {
        URIBuilder uri = new URIBuilder();
        [Test]
        public void Test_My_URI_Builder()
        {
            var check_URI = uri.Bild("Волгоград", "Москва", "2019-04-08");
            Assert.AreEqual("https://api.rasp.yandex.net/v3.0/search/?apikey=ddf82387-0ad5-481b-8263-5040c23d54f2&format=json&from=c38&to=c213&limit=1&lang=ru_RU&transport_types=plane&date=2019-04-08", check_URI);
        }
    }
}
