using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models
{
    internal class Ticket
    {
        private Flight flight;
        private Passanger passanger;
        private string ticketId;
        private string seatNr;

        public Ticket(Flight flight, Passanger passanger, string ticketId, string seatNr)
        {
            this.flight = flight;
            this.passanger = passanger;
            this.ticketId = ticketId;
            this.seatNr = seatNr;
        }

        public Ticket() { }

        public Flight Flight { get => this.flight; set => this.flight = value; }
        public Passanger Passanger { get => this.passanger; set => this.passanger = value; }
        public string TicketId { get => this.ticketId; set => this.ticketId = value; }
        public string SeatNr { get => this.seatNr; set => this.seatNr = value; }
    }
}
