using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLab1_CSharp_console
{
    class URIBuilder
    {
        public string URI_compile_string = null;
        private readonly string URI_start = "https://api.rasp.yandex.net/v3.0/search/?";
        private readonly string URI_api_key = "apikey=ddf82387-0ad5-481b-8263-5040c23d54f2";
        private readonly string URI_format_response = "&format=json";
        private readonly string URI_other = "&limit=1&lang=ru_RU&transport_types=plane";

        private readonly Dictionary<string, string> URI_city_codes = new Dictionary<string, string> { { "Волгоград", "c38" }, { "Симферополь", "c146" }, { "Москва", "c213" } };

        public URIBuilder()
        {
            //string city_from, string city_to, string date_arrival
            //string URI_id_from = "&from=" + URI_city_codes[city_from];
            //string URI_id_to = "&to=" + URI_city_codes[city_to];
            //string URI_date_arrival = "&date=" + date_arrival;

            //URI_compile_string = URI_start + URI_api_key + URI_format_response + URI_id_from + URI_id_to + URI_other + URI_date_arrival;
        }

        public string Bild(string city_from, string city_to, string date_arrival)
        {
            string URI_id_from = "&from=" + URI_city_codes[city_from];
            string URI_id_to = "&to=" + URI_city_codes[city_to];
            string URI_date_arrival = "&date=" + date_arrival;

            return URI_compile_string = URI_start + URI_api_key + URI_format_response + URI_id_from + URI_id_to + URI_other + URI_date_arrival;
        }
    }
}
