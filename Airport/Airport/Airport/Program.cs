using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Flight> flights = new List<Flight>();

            try
            {
                Console.WriteLine("Въведи брой полети: ");
                int numberOfFlights = int.Parse(Console.ReadLine());

                for (int i = 0; i < numberOfFlights; i++)
                {
                    Console.WriteLine("Въведи детайли за полета {0}:", i + 1);
                    Console.WriteLine("Код на полет: ");
                    string flightCode = Console.ReadLine();

                    Console.WriteLine("Дата (dd/MM/yyyy): ");
                    DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                    Console.WriteLine("Свободни места: ");
                    int availableSeats = int.Parse(Console.ReadLine());

                    Console.WriteLine("Продадени билети: ");
                    int soldTickets = int.Parse(Console.ReadLine());

                    TicketReservation flight = new TicketReservation(flightCode, date, availableSeats, soldTickets);
                    flights.Add(flight);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Грешка");
                return;
            }

            Console.WriteLine("Информация за полета:");
            Console.WriteLine("                     ");
            foreach (Flight flight in flights)
            {
                flight.DisplayFlightInfo();
                Console.WriteLine();
            }

            Console.WriteLine("Полети със свободни места:");
            Console.WriteLine("                     ");

            var flightsWithAvailableSeats = flights.Where(f => f.AvailableSeats > 0);

            foreach (Flight flight in flightsWithAvailableSeats)
            {
                flight.DisplayFlightInfo();
                Console.WriteLine();
            }

            double averageSoldTickets = flights.Average(f => f.SoldTickets);
            Console.WriteLine("Среден брой заклупени билети: " + averageSoldTickets);

            Flight flightWithMinSoldTickets = flights.OrderBy(f => f.SoldTickets).FirstOrDefault();
            if (flightWithMinSoldTickets != null)
            {
                Console.WriteLine("Полет с най малко закупени билети:");
                flightWithMinSoldTickets.DisplayFlightInfo();
                Console.WriteLine();
            }

            Console.WriteLine("Полети по дата:");
            Console.WriteLine("                     ");

            var sortedFlights = flights.OrderBy(f => f.Date);

            foreach (Flight flight in sortedFlights)
            {
                flight.DisplayFlightInfo();
                Console.WriteLine();
            }
        }

    }
    
}
