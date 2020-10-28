using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLab1_CSharp_console
{
    class Parser
    {
        public Flights flight;
        private JObject abr;
        private Dictionary<string,string> tmp;

        public Parser(string json_data)
        {
            abr = JObject.Parse(json_data);
            //int count_in = abr["segments"].Count();
            //tmp.Add("count_in", count_in.ToString());
            //for(int i = 0; i < count_in; i++)
            //{
            //    tmp.Add(i + "_arrival", (string)abr["segments"][0]["arrival"]);
            //    tmp.Add(i + "_from_title", (string)abr["segments"][0]["from"]["title"]);

            //}
        }

        public Flights GetFlights()
        {
            var abr_segments_0 = abr["segments"][0];
            var abr_segments_0_from = abr_segments_0["from"];
            var abr_segments_0_thread = abr_segments_0["thread"];
            var abr_segments_0_to = abr_segments_0["to"];

            flight.arrival = (DateTime)abr_segments_0["arrival"];

            flight.from_title = (string)abr_segments_0_from["title"];
            flight.from_station_type_name = (string)abr_segments_0_from["station_type_name"];

            flight.thread_title = (string)abr_segments_0_thread["title"];
            flight.thread_number_plane = (string)abr_segments_0_thread["number"];
            flight.thread_carrier_title = (string)abr_segments_0_thread["carrier"]["title"];
            flight.thread_transport_type = (string)abr_segments_0_thread["transport_type"];
            flight.thread_vehicle = (string)abr_segments_0_thread["vehicle"];

            flight.departure = (DateTime)abr_segments_0["departure"];

            flight.to_title = (string)abr_segments_0_to["title"];
            flight.to_station_type_name = (string)abr_segments_0_to["station_type_name"];

            flight.has_transfers = (bool)abr_segments_0["has_transfers"];
            flight.duration = (double)abr_segments_0["duration"];

            flight.search_data = (string)abr["search"]["date"];

            return flight;
        }
    }
}
