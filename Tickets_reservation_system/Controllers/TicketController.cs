using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets_reservation_system.Models;
using Tickets_reservation_system.Models.Repositories;

namespace Tickets_reservation_system.Controllers
{
    internal class TicketController
    {
        private readonly TicketRepository ticketRepository = new TicketRepository();

        public int GetTicketCountByFlight(string flightNumber)
        {
            List<Ticket> allTickets = ticketRepository.GetAll();
            return allTickets.FindAll(x => x.FlightNumber.Equals(flightNumber)).Count();
        }
    }
}
