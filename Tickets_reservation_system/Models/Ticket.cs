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
        private int ticketId;
        private string seatNr;

        public Ticket(Flight flight, Passanger passanger, int ticketId, string seatNr)
        {
            this.flight = flight;
            this.passanger = passanger;
            this.ticketId = ticketId;
            this.seatNr = seatNr;
        }

        public Ticket() { }

        public Flight Flight { get => this.flight; set => this.flight = value; }
        public Passanger Passanger { get => this.passanger; set => this.passanger = value; }
        public int TicketId { get => this.ticketId; set => this.ticketId = value; }
        public string SeatNr { get => this.seatNr; set => this.seatNr = value; }
    }
}
