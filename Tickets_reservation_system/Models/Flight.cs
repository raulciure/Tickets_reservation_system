using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models
{
    internal class Flight
    {
        public enum Days
        {
            MONDAY,
            TUESDAY,
            WEDNESDAY,
            THURSDAT,
            FRIDAY,
            SATURDAY,
            SUNDAY
        }

        private string departureAirport;
        private string arrivalAirport;
        private DateTime departureTime;
        private DateTime arrivalTime;
        private DateTime flightTime;
        private List<Days> operatingDays;
        private string flightNumber;
        private Plane plane;
        private Company company;

        public Flight(string departureAirport, string arrivalAirport, DateTime departureTime, DateTime arrivalTime, 
            DateTime flightTime, string flightNumber, Plane plane, Company company)
        {
            this.departureAirport = departureAirport;
            this.arrivalAirport = arrivalAirport;
            this.departureTime = departureTime;
            this.arrivalTime = arrivalTime;
            this.flightTime = flightTime;
            this.flightNumber = flightNumber;
            this.plane = plane;
            this.company = company;
        }

        public Flight() { }

        public string DepartureAirport { get => this.departureAirport; set => this.departureAirport = value; }
        public string ArrivalAirport { get => this.arrivalAirport; set => this.arrivalAirport = value; }
        public DateTime DepartureTime { get => this.departureTime; set => this.departureTime = value; }
        public DateTime ArrivalTime { get => this.arrivalTime; set => this.arrivalTime = value; }
        public DateTime FlightTime { get => this.flightTime; set => this.flightTime = value; }
        public List<Days> OperatingDays { get => this.operatingDays; set => this.operatingDays = value; }
        public string FlightNumber { get => this.flightNumber; set => this.flightNumber = value; }
        public Plane Plane { get => this.plane; set => this.plane = value; }
        public Company Company { get => this.company; set => this.company = value; }
    }
}
