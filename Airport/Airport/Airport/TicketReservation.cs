using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Airport
{
    public class TicketReservation: Flight, IReservation
    {
        public TicketReservation(string flightCode, DateTime date, int availableSeats, int soldTickets)
        : base(flightCode, date, availableSeats, soldTickets)
        { 

        }
        public void ReserveTicket()
        {
            if (AvailableSeats > 0)
            {
                Console.WriteLine("Резервиран билет за полета: " + FlightCode);
                SoldTickets++;
                AvailableSeats--;
            }
            else
            {
                Console.WriteLine("Няма свободни места за полета: " + FlightCode);
            }
        }
        public override double CalculateAverageSoldTickets()
        {
            return SoldTickets / AvailableSeats;
        }
        public class FlightDateComparer : IComparer<Flight>
        {
            public int Compare(Flight x, Flight y)
            {
                return DateTime.Compare(x.Date, y.Date);
            }
        }
    }
}
