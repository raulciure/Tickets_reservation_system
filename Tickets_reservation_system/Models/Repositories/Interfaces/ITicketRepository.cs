using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models.Repositories.Interfaces
{
    internal interface ITicketRepository : IRepository<Ticket>
    {
        Ticket GetTicket(int ticketId);
        void DeleteTicketByPassangerId(string idSerialNumber);
    }
}
