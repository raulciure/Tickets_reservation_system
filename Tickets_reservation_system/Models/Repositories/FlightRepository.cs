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
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Flights " +
                    "SET flightNumber = $flightNumber, departure = $departure, arrival = $arrival, " +
                    "departureTime = $departureTime, arrivalTime = $arrivalTime, flightTime = $flightTime, " +
                    "days = $days, planeTailNumber = $planeTailNumber, companyName = $companyName " +
                    "WHERE flightNumber = $currentFlightNumber";
                command.Parameters.AddWithValue("$flightNumber", updateObj.FlightNumber);
                command.Parameters.AddWithValue("$departure", updateObj.DepartureAirport);
                command.Parameters.AddWithValue("$arrival", updateObj.ArrivalAirport);
                command.Parameters.AddWithValue("$departureTime", updateObj.DepartureTime);
                command.Parameters.AddWithValue("$arrivalTime", updateObj.ArrivalTime);
                command.Parameters.AddWithValue("$flightTime", updateObj.FlightTime);

                string operatingDaysString = string.Join(",", updateObj.OperatingDays);
                command.Parameters.AddWithValue("$days", operatingDaysString);

                command.Parameters.AddWithValue("$planeTailNumber", updateObj.Plane.TailNumber);
                command.Parameters.AddWithValue("$companyName", updateObj.Company.Name);

                command.Parameters.AddWithValue("$currentFlightNumber", currentObj.FlightNumber);

                command.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
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
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Flights " +
                    "WHERE flightNumber = $flightNumber";
                command.Parameters.AddWithValue("$flightNumber", flightNumber);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Flight flight = new Flight();

                    // inherent flight attributes
                    flight.FlightNumber = reader.GetString(0);
                    flight.DepartureAirport = reader.GetString(1);
                    flight.ArrivalAirport = reader.GetString(2);
                    flight.DepartureTime = DateTime.Parse(reader.GetString(3));
                    flight.ArrivalTime = DateTime.Parse(reader.GetString(4));
                    flight.FlightTime = DateTime.Parse(reader.GetString(5));
                    
                    string operatingDaysString = reader.GetString(6);
                    var splitString = operatingDaysString.Split(',');
                    foreach (var entry in splitString)
                    {
                        flight.OperatingDays.Add((Flight.Days) Enum.Parse(typeof(Flight.Days), entry));
                    }
                    
                    // construct plane object from planeTailNumber
                    PlaneRepository planeRepository = new PlaneRepository();
                    flight.Plane = planeRepository.GetPlane(reader.GetString(7));

                    // construct company object from companyName
                    CompanyRepository companyRepository = new CompanyRepository();
                    flight.Company = companyRepository.GetCompany(reader.GetString(8));

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
            try
            {
                List<Flight> list = new List<Flight>();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Flights";

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Flight flight = new Flight();

                    // inherent flight attributes
                    flight.FlightNumber = reader.GetString(0);
                    flight.DepartureAirport = reader.GetString(1);
                    flight.ArrivalAirport = reader.GetString(2);
                    flight.DepartureTime = DateTime.Parse(reader.GetString(3));
                    flight.ArrivalTime = DateTime.Parse(reader.GetString(4));
                    flight.FlightTime = DateTime.Parse(reader.GetString(5));

                    string operatingDaysString = reader.GetString(6);
                    var splitString = operatingDaysString.Split(',');
                    foreach (var entry in splitString)
                    {
                        flight.OperatingDays.Add((Flight.Days)Enum.Parse(typeof(Flight.Days), entry));
                    }

                    // construct plane object from planeTailNumber
                    PlaneRepository planeRepository = new PlaneRepository();
                    flight.Plane = planeRepository.GetPlane(reader.GetString(7));

                    // construct company object from companyName
                    CompanyRepository companyRepository = new CompanyRepository();
                    flight.Company = companyRepository.GetCompany(reader.GetString(8));

                    list.Add(flight);
                }
                return list;
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
