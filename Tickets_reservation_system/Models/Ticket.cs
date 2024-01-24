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
        private string passangerId;
        private int ticketId;
        private string seatNr;

        public Ticket(string flightNumber, string passangerId, int ticketId, string seatNr)
        {
            this.flightNumber = flightNumber;
            this.passangerId = passangerId;
            this.ticketId = ticketId;
            this.seatNr = seatNr;
        }

        public Ticket() { }

        public string FlightNumber { get => this.flightNumber; set => this.flightNumber = value; }
        public string PassangerId { get => this.passangerId; set => this.passangerId = value; }
        public int TicketId { get => this.ticketId; set => this.ticketId = value; }
        public string SeatNr { get => this.seatNr; set => this.seatNr = value; }
    }
}
