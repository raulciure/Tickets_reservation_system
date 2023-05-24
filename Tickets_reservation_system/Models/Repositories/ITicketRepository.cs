using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models.Repositories
{
    internal interface ITicketRepository : IRepository<Ticket>
    {
        Ticket GetTicket(int ticketId);
    }
}
