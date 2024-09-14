using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models
{
    [Serializable]
    internal class Ticket
    {
        private string flightNumber;
        private Passanger passenger;
        private int ticketId;
        private string seatNr;

        public Ticket(string flightNumber, Passanger passenger, int ticketId, string seatNr)
        {
            this.flightNumber = flightNumber;
            this.passenger = passenger;
            this.ticketId = ticketId;
            this.seatNr = seatNr;
        }

        public Ticket() { }

        public string FlightNumber { get => this.flightNumber; set => this.flightNumber = value; }
        public Passanger Passenger { get => this.passenger; set => this.passenger = value; }
        public int TicketId { get => this.ticketId; set => this.ticketId = value; }
        public string SeatNr { get => this.seatNr; set => this.seatNr = value; }
    }
}
