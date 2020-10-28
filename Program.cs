using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.IO;

namespace TPLab1_CSharp_console
{
    class Program
    {
        static void Main()
        {
            bool finish_paste = false;
            string city_from = null;
            string city_to = null;
            string date_arrival = null;

            //условие использование Яндекс API
            Console.WriteLine("Данные предоставлены сервисом Яндекс.Расписания http://rasp.yandex.ru/");

            do
            {
                Console.Write("Введите город отправления (Москва, Волгоград, Симферополь): ");
                city_from = Console.ReadLine();
                Console.Write("Введите город прибытия (Москва, Волгоград, Симферополь): ");
                city_to = Console.ReadLine();
                Console.Write("Введите дату отправления в формате ГГГГ-ММ-ДД: ");
                date_arrival = Console.ReadLine();
                Console.Write($"Вам нужны билеты на самолёт из {city_from} в {city_to} на следующую дату {date_arrival}? Д/н(Y/n):");
                string check_string = Console.ReadLine();
                if (check_string == "д" || check_string == "Д" || check_string == "Y" || check_string == "y")
                    finish_paste = true;
            } while (finish_paste != true);
            
            //Собираем строку для запроса
            URIBuilder URI_my = new URIBuilder();
            URI_my.Bild(city_from, city_to, date_arrival);
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI_my.URI_compile_string);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (var stream = response.GetResponseStream())
            using (var streamReader = new StreamReader(stream, Encoding.UTF8))
            {
                string json_response = streamReader.ReadToEnd();

                Parser pars = new Parser(json_response);
                Flights flight = pars.GetFlights();

                Console.WriteLine("\nНу-с.. Имеем следующее:");

                Console.WriteLine($"\tДата и время отправления: {flight.departure}.");
                Console.WriteLine($"\tДата и время прибытия: {flight.arrival}.");

                Console.WriteLine($"\tОтправление из {flight.from_station_type_name} {flight.from_title}.");
                Console.WriteLine($"\tПрибытие в {flight.to_station_type_name} {flight.to_title}.");

                if(flight.has_transfers == true)
                    Console.WriteLine("\tПересадки: да.");
                else
                    Console.WriteLine("\tПересадки: нет.");
                Console.WriteLine($"\tРасстояние: {flight.duration} км.");

                Console.WriteLine($"\tПуть следования: {flight.thread_title}.");
                Console.WriteLine($"\tНомер самолёта: {flight.thread_number_plane}.");
                Console.WriteLine($"\tАвиакомпания: {flight.thread_carrier_title}.");
                if (flight.thread_transport_type == "plane")
                    Console.WriteLine($"\tТранспорт: самолёт. Модель транспорта: {flight.thread_vehicle}.");
                else
                    Console.WriteLine($"\tТранспорт: неизвестно. Модель транспорта: {flight.thread_vehicle}.");

                try
                {
                    StreamWriter sw = new StreamWriter("DEBUG_output.txt");
                    sw.WriteLine(json_response);
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }

                Console.WriteLine("Well done");
                Console.ReadKey();

            }
        }
    }
}
