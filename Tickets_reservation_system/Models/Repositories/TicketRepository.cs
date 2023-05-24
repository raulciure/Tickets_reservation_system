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
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Tickets " +
                    "VALUES($flightNumber, $passangerIdSerialNumber, " +
                    "$ticketId, $seatNr)";
                command.Parameters.AddWithValue("$flightNumber", obj.Flight.FlightNumber);
                command.Parameters.AddWithValue("$passangerIdSerialNumber", obj.Passanger.IdSerialNumber);
                command.Parameters.AddWithValue("$ticketId", obj.TicketId);
                command.Parameters.AddWithValue("$seatNr", obj.SeatNr);

                command.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(Ticket currentObj, Ticket updateObj)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Tickets " +
                    "SET $flightNumber, $passangerIdSerialNr, $ticketId, $seatNr " +
                    "WHERE ticketId = $currentTicketId";
                command.Parameters.AddWithValue("$flightNumber", updateObj.Flight.FlightNumber);
                command.Parameters.AddWithValue("$passangerIdSerialNumber", updateObj.Passanger.IdSerialNumber);
                command.Parameters.AddWithValue("$ticketId", updateObj.TicketId);
                command.Parameters.AddWithValue("$seatNr", updateObj.SeatNr);

                command.Parameters.AddWithValue("$currentFlightNumber", currentObj.TicketId);

                command.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Ticket obj)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Tickets WHERE ticketId = $ticketId";
                command.Parameters.AddWithValue("$ticketId", obj.TicketId);

                command.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
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

        public void DeleteTicketByPassangerIdSerialNumber(string idSerialNumber)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Tickets WHERE passangerIdSerialNr = $passangerIdSerialNr";
                command.Parameters.AddWithValue("$passangerIdSerialNr", idSerialNumber);

                command.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
