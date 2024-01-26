using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models
{
    public enum Days
    {
        MONDAY,
        TUESDAY,
        WEDNESDAY,
        THURSDAY,
        FRIDAY,
        SATURDAY,
        SUNDAY
    }

    [Serializable]
    internal class Flight
    {
        private string departureAirport;
        private string arrivalAirport;
        private DateTime departureTime;
        private DateTime arrivalTime;
        private TimeSpan flightTime;
        private List<Days> operatingDays;
        private string flightNumber;
        private int price;
        private string planeTailNumber;
        private string companyName;

        public Flight(string departureAirport, string arrivalAirport, DateTime departureTime, DateTime arrivalTime, 
            TimeSpan flightTime, string flightNumber, int price, string planeTailNumber, string companyName)
        {
            this.departureAirport = departureAirport;
            this.arrivalAirport = arrivalAirport;
            this.departureTime = departureTime;
            this.arrivalTime = arrivalTime;
            this.flightTime = flightTime;
            this.flightNumber = flightNumber;
            this.price = price;
            this.planeTailNumber = planeTailNumber;
            this.companyName = companyName;
        }

        public Flight() { }

        public string DepartureAirport { get => this.departureAirport; set => this.departureAirport = value; }
        public string ArrivalAirport { get => this.arrivalAirport; set => this.arrivalAirport = value; }
        public DateTime DepartureTime { get => this.departureTime; set => this.departureTime = value; }
        public DateTime ArrivalTime { get => this.arrivalTime; set => this.arrivalTime = value; }
        public TimeSpan FlightTime { get => this.flightTime; set => this.flightTime = value; }
        public List<Days> OperatingDays { get => this.operatingDays; set => this.operatingDays = value; }
        public string FlightNumber { get => this.flightNumber; set => this.flightNumber = value; }
        public int Price { get => this.price; set => this.price = value; }
        public string PlaneTailNumber { get => this.planeTailNumber; set => this.planeTailNumber = value; }
        public string CompanyName { get => this.companyName; set => this.companyName = value; }
    }
}
