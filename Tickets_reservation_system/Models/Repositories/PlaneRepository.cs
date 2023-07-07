using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models.Repositories
{
    internal class PlaneRepository : IPlaneRepository
    {
        private static readonly SqliteConnection connection = DBConnection.getDBConnection("TicketsReservationDB.db");

        public void Add(Plane obj)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Planes " +
                    "VALUES($companyName, $name, $tailNumber, $seatsNr, " +
                    "$seatsEconomy, $seatsBussiness, $seatsFirst, $range)";

                command.Parameters.AddWithValue("$companyName", obj.CompanyName);
                command.Parameters.AddWithValue("$name", obj.Name);
                command.Parameters.AddWithValue("$tailNumber", obj.TailNumber);
                command.Parameters.AddWithValue("$seatsNr", obj.SeatsNr);
                command.Parameters.AddWithValue("$seatsEconomy", obj.SeatingConfiguration.EconomySeats);
                command.Parameters.AddWithValue("$seatsBussiness", obj.SeatingConfiguration.BussinessSeats);
                command.Parameters.AddWithValue("$seatsFirst", obj.SeatingConfiguration.FirstSeats);
                command.Parameters.AddWithValue("$range", obj.Range);

                command.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(Plane currentObj, Plane updateObj)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Planes " +
                    "SET companyName = $companyName, name = $name, tailNumber = $tailNumber, " +
                    "seatsNr = $seatsNr, seatsEconomy = $seatsEconomy, seatsBussiness = $seatsBussiness, " +
                    "seatsFirst = $seatsFirst, range = $range " +
                    "WHERE tailNumber = $currentTailNumber";

                command.Parameters.AddWithValue("$companyName", updateObj.CompanyName);
                command.Parameters.AddWithValue("$name", updateObj.Name);
                command.Parameters.AddWithValue("$tailNumber", updateObj.TailNumber);
                command.Parameters.AddWithValue("$seatsNr", updateObj.SeatsNr);
                command.Parameters.AddWithValue("$seatsEconomy", updateObj.SeatingConfiguration.EconomySeats);
                command.Parameters.AddWithValue("$seatsBussiness", updateObj.SeatingConfiguration.BussinessSeats);
                command.Parameters.AddWithValue("$seatsFirst", updateObj.SeatingConfiguration.FirstSeats);
                command.Parameters.AddWithValue("$range", updateObj.Range);

                command.Parameters.AddWithValue("$currentTailNumber", currentObj.TailNumber);

                command.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Plane obj)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Planes WHERE tailNumber = $tailNumber";
                command.Parameters.AddWithValue("$tailNumber", obj.TailNumber);
                command.ExecuteNonQuery();
            }
            catch (SqliteException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Plane> GetAll()
        {
            try
            {
                List<Plane> list = new List<Plane>();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Planes";

                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Plane plane = new Plane();

                    plane.CompanyName = reader.GetString(0);
                    plane.Name = reader.GetString(1);
                    plane.TailNumber = reader.GetString(2);
                    plane.SeatsNr = reader.GetInt32(3);
                    plane.SeatingConfiguration.EconomySeats = reader.GetInt32(4);
                    plane.SeatingConfiguration.BussinessSeats = reader.GetInt32(5);
                    plane.SeatingConfiguration.FirstSeats = reader.GetInt32(6);
                    plane.Range = reader.GetInt32(7);

                    list.Add(plane);
                }
                return list;
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Plane GetPlane(string tailNumber)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Planes WHERE tailNumber = $tailNumber";
                command.Parameters.AddWithValue("$tailNumber", tailNumber);
                
                var reader = command.ExecuteReader();
                if(reader.Read())
                {
                    Plane plane = new Plane();

                    plane.CompanyName = reader.GetString(0);
                    plane.Name = reader.GetString(1);
                    plane.TailNumber = reader.GetString(2);
                    plane.SeatsNr = reader.GetInt32(3);
                    plane.SeatingConfiguration.EconomySeats = reader.GetInt32(4);
                    plane.SeatingConfiguration.BussinessSeats = reader.GetInt32(5);
                    plane.SeatingConfiguration.FirstSeats = reader.GetInt32(6);
                    plane.Range = reader.GetInt32(7);

                    return plane;
                }
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public List<Plane> GetPlanesByCompany(string companyName)
        {
            try
            {
                List<Plane> list = new List<Plane>();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Planes WHERE companyName = $companyName";
                command.Parameters.AddWithValue("$companyName", companyName);

                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Plane plane = new Plane();

                    plane.CompanyName = reader.GetString(0);
                    plane.Name = reader.GetString(1);
                    plane.TailNumber = reader.GetString(2);
                    plane.SeatsNr = reader.GetInt32(3);
                    plane.SeatingConfiguration.EconomySeats = reader.GetInt32(4);
                    plane.SeatingConfiguration.BussinessSeats = reader.GetInt32(5);
                    plane.SeatingConfiguration.FirstSeats = reader.GetInt32(6);
                    plane.Range = reader.GetInt32(7);

                    list.Add(plane);
                }

                return list;
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void DeletePlanesOfCompany(string companyName)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Planes WHERE companyName = $companyName";
                command.Parameters.AddWithValue("$companyName", companyName);
                command.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
