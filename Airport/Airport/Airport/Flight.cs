using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public abstract class Flight
    {
        private string flightCode;
        private DateTime date;
        private int availableSeats;
        private int soldTickets;
        public string FlightCode 
        {
            get { return flightCode; }
            set { this.flightCode = value; }
        }
        public DateTime Date
        { 
            get { return date; } 
            set {  this.date = value; }
        }    
        public int AvailableSeats
        {
            get { return availableSeats; }
            set { this.availableSeats = value;}
        }
        public int SoldTickets
        {
            get { return soldTickets; }
            set { this.soldTickets = value;}
        }
        public Flight(string flightCode, DateTime date, int availableSeats, int soldTickets)
        {
            FlightCode = flightCode;
            Date = date;
            AvailableSeats = availableSeats;
            SoldTickets = soldTickets;
        }
        public virtual void DisplayFlightInfo()
        {
            Console.WriteLine("Код на полет: " + FlightCode);
            Console.WriteLine("Дата: " + Date);
            Console.WriteLine("Свободни места: " + AvailableSeats);
            Console.WriteLine("Продадени билети: " + SoldTickets);
        }
        public abstract double CalculateAverageSoldTickets();
    }
}
