using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets_reservation_system.Models.Repositories;
using Xunit;

namespace Tickets_reservation_system.Testing
{
    public class DBConnectionTest
    {
        [Fact]
        public void ConnectionTest()
        {
            var connection = DBConnection.getDBConnection("TicketsReservationDB.db");

            Assert.NotNull(connection);
        }
    }
}
