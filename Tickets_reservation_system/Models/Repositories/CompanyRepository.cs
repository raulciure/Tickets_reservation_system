using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Tickets_reservation_system.Models.Repositories
{
    internal class CompanyRepository : ICompanyRepository
    {
        private static readonly SqliteConnection connection = DBConnection.getDBConnection("TicketsReservationDB.db");

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
                command.CommandText = "UPDATE Companies " +
                    "SET name = $field1, countryOfReg = $field2 " +
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
                // delete planes linked to/owned by this company
                PlaneRepository planeRepository = new PlaneRepository();
                planeRepository.DeletePlanesOfCompany(obj.Name);

                // delete company itself
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Companies WHERE name=$name";
                command.Parameters.AddWithValue("$name", obj.Name);
                command.ExecuteNonQuery();
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
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Companies WHERE name=$name";
                command.Parameters.AddWithValue("$name", name);
                var reader = command.ExecuteReader();

                Company company = new Company();
                if (reader.Read())
                {
                    company.Name = reader.GetString(0);
                    company.CountryOfRegistration = reader.GetString(1);

                    // get planes owned by this company
                    PlaneRepository planeRepository = new PlaneRepository();
                    company.Fleet = planeRepository.GetPlanesByCompany(company.Name);
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
            try
            {
                List<Company> list = new List<Company>();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Companies";

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Company company = new Company();

                    company.Name = reader.GetString(0);
                    company.CountryOfRegistration = reader.GetString(1);

                    // get planes owned by this company
                    PlaneRepository planeRepository = new PlaneRepository();
                    company.Fleet = planeRepository.GetPlanesByCompany(company.Name);

                    list.Add(company);
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
