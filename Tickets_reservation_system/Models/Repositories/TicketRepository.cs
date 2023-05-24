using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models.Repositories
{
    internal class TicketRepository : ITicketRepository
    {
        private static readonly SqliteConnection connection = DBConnection.getDBConnection("TicketsReservationDB.db");

        public void Add(Ticket obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Ticket currentObj, Ticket updateObj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Ticket obj)
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicket(int ticketId)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Tickets WHERE ticketId = $id";
                command.Parameters.AddWithValue("$id", ticketId);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Ticket ticket = new Ticket();

                    // construct flight object from flightNumber
                    FlightRepository flightRepository = new FlightRepository();
                    ticket.Flight = flightRepository.GetFlight(reader.GetString(0));

                    // construct passanger object from passangerIdSerialNr
                    PassangerRepository passangerRepository = new PassangerRepository();
                    ticket.Passanger = passangerRepository.GetPassanger(reader.GetString(1));

                    // inherent ticket attributes
                    ticket.TicketId = reader.GetInt32(2);
                    ticket.SeatNr = reader.GetString(3);

                    return ticket;
                }
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
