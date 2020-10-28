using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLab1_CSharp_console
{
    struct Flights
    {
        //данные берутся из ответа json в поле segments
        public DateTime arrival;

        public string from_title;
        public string from_station_type_name;

        public string thread_title;
        public string thread_number_plane;
        public string thread_carrier_title;
        public string thread_transport_type;
        public string thread_vehicle;

        public DateTime departure;

        public string to_title;
        public string to_station_type_name;

        public bool has_transfers;
        public double duration;

        public string search_data;

    }
}
