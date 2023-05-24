using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models.Repositories
{
    internal class FlightRepository : IFlightRepository
    {
        private static readonly SqliteConnection connection = DBConnection.getDBConnection("TicketsReservationDB.db");

        public void Add(Flight obj)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Flights " +
                    "VALUES($flightNumber, $departure, $arrival, $departureTime, $arrivalTime, $flightTime, $days, $planeTailNumber, $companyName)";
                command.Parameters.AddWithValue("$flightNumber", obj.FlightNumber);
                command.Parameters.AddWithValue("$departure", obj.DepartureAirport);
                command.Parameters.AddWithValue("$arrival", obj.ArrivalAirport);
                command.Parameters.AddWithValue("$departureTime", obj.DepartureTime.ToString("HH:mm"));
                command.Parameters.AddWithValue("$arrivalTime", obj.ArrivalTime.ToString("HH:mm"));
                command.Parameters.AddWithValue("$flightTime", obj.FlightTime.ToString("HH:mm"));

                string operatingDaysString = string.Join(",", obj.OperatingDays);
                command.Parameters.AddWithValue("$days", operatingDaysString);

                command.Parameters.AddWithValue("$planeTailNumber", obj.Plane.TailNumber);
                command.Parameters.AddWithValue("$companyName", obj.Company.Name);

                command.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(Flight currentObj, Flight updateObj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Flight obj)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Flights WHERE flightNumber = $flightNumber";
                command.Parameters.AddWithValue("$flightNumber", obj.FlightNumber);
                command.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Flight GetFlight(string flightNumber)
        {
            try
            {
                // Inherent flight attributes
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Flights " +
                    "WHERE flightNumber = $flightNumber";
                command.Parameters.AddWithValue("$flightNumber", flightNumber);

                var reader = command.ExecuteReader();
                if(reader.Read())
                {
                    Flight flight = new Flight();

                    flight.FlightNumber = reader.GetString(0);
                    flight.DepartureAirport = reader.GetString(1);
                    flight.ArrivalAirport = reader.GetString(2);
                    flight.DepartureTime = DateTime.Parse(reader.GetString(3));
                    flight.ArrivalTime = DateTime.Parse(reader.GetString(4));
                    flight.FlightTime = DateTime.Parse(reader.GetString(5));
                    
                    string operatingDaysString = reader.GetString(6);
                    var splitString = operatingDaysString.Split(',');
                    foreach(var entry in splitString)
                    {
                        flight.OperatingDays.Add((Flight.Days) Enum.Parse(typeof(Flight.Days), entry));
                    }
                    
                    // Construct plane object from tailNumber
                    var planeCommand = connection.CreateCommand();
                    planeCommand.CommandText = "SELECT * FROM Planes WHERE planeTailNumber = $planeTailNumber";
                    planeCommand.Parameters.AddWithValue("$planeTailNumber", reader.GetString(7));
                    var planeReader = planeCommand.ExecuteReader();

                    Plane plane = new Plane();
                    if (planeReader.Read())
                    {
                        plane.Name = planeReader.GetString(1);
                        plane.TailNumber = planeReader.GetString(2);
                        plane.SeatsNr = planeReader.GetInt32(3);
                        plane.SeatingConfiguration.EconomySeats = planeReader.GetInt32(4);
                        plane.SeatingConfiguration.BussinessSeats = planeReader.GetInt32(5);
                        plane.SeatingConfiguration.FirstSeats = planeReader.GetInt32(6);
                        plane.Range = planeReader.GetInt32(7);
                    }
                    flight.Plane = plane;
                    
                    // Construct company object from companyName
                    var companyCommand = connection.CreateCommand();
                    companyCommand.CommandText = "SELECT * FROM Companies WHERE companyName = $companyName";
                    companyCommand.Parameters.AddWithValue("$companyName", reader.GetString(8));
                    var companyReader = companyCommand.ExecuteReader();

                    Company company = new Company();
                    if(companyReader.Read())
                    {
                        company.Name = companyReader.GetString(0);
                        company.CountryOfRegistration = companyReader.GetString(1);
                    }
                    flight.Company = company;

                    // return constructed object
                    return flight;
                }

            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public List<Flight> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
