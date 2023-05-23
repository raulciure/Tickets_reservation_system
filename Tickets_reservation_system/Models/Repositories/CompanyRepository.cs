using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models.Repositories
{
    internal class CompanyRepository : ICompanyRepository
    {
        private static SqliteConnection connection = getDBConnection("TicketsReservationDB.db");

        static SqliteConnection getDBConnection(string filename)
        {
            var connection = new SqliteConnection("Data Source = " + filename);
            try
            {
                connection.Open();
                return connection;
            }
            catch (SqliteException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public void Add(Company obj)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Companies VALUES($name, $countryOfReg)";
                command.Parameters.AddWithValue("$name", obj.Name);
                command.Parameters.AddWithValue("$countryOfReg", obj.CountryOfRegistration);
                command.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(Company currentObj, Company updateObj)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Companies" +
                    "SET name = $field1, countryOfReg = $field2" +
                    "WHERE name = $currentName";
                command.Parameters.AddWithValue("field1", updateObj.Name);
                command.Parameters.AddWithValue("field2", updateObj.CountryOfRegistration);
                command.Parameters.AddWithValue("currentName", currentObj.Name);
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Company obj)
        {
            try
            {
                var command1 = connection.CreateCommand();
                command1.CommandText = "DELETE FROM Planes WHERE companyName = $companyName";
                command1.Parameters.AddWithValue("companyName", obj.Name);
                command1.ExecuteNonQuery();

                var command2 = connection.CreateCommand();
                command2.CommandText = "DELETE FROM Companies WHERE name=$name";
                command2.Parameters.AddWithValue("$name", obj.Name);
                command2.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Company GetCompany(string name)
        {
            try
            {
                var command1 = connection.CreateCommand();
                command1.CommandText = "SELECT * FROM Companies WHERE name=$name";
                command1.Parameters.AddWithValue("$name", name);
                var reader1 = command1.ExecuteReader();

                var command2 = connection.CreateCommand();
                command2.CommandText = "SELECT * FROM Planes WHERE companyName = $companyName";
                command2.Parameters.AddWithValue("companyName", name);
                var reader2 = command2.ExecuteReader();
                
                reader1.Read();
                Company company = new Company();
                company.Name = reader1.GetString(0);
                company.CountryOfRegistration = reader1.GetString(1);

                while(reader2.Read())
                {
                    Plane plane = new Plane();
                    plane.Name = reader2.GetString(1);
                    plane.TailNumber = reader2.GetString(2);
                    plane.SeatsNr = reader2.GetInt32(3);
                    plane.SeatingConfiguration.EconomySeats = reader2.GetInt32(4);
                    plane.SeatingConfiguration.BussinessSeats = reader2.GetInt32(5);
                    plane.SeatingConfiguration.FirstSeats = reader2.GetInt32(6);
                    plane.Range = reader2.GetInt32(7);

                    company.Fleet.Add(plane);
                }

                return company;

            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public List<Company> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
