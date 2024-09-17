using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models.Repositories.Interfaces
{
    internal interface IPassengerRepository : IRepository<Passanger>
    {
        Passanger GetPassenger(string id);
    }
}
