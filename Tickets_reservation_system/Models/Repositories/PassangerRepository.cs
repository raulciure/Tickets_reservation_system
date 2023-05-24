using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models.Repositories
{
    internal class PassangerRepository : IPassangerRepository
    {
        private static readonly SqliteConnection connection = DBConnection.getDBConnection("TicketsReservationDB.db");

        public void Add(Passanger obj)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Passangers " +
                    "VALUES($idSerialNumber, $firstName, $lastName, $email, $phoneNumber, $age)";
                command.Parameters.AddWithValue("$idSerialNumber", obj.IdSerialNumber);
                command.Parameters.AddWithValue("$firstName", obj.FirstName);
                command.Parameters.AddWithValue("$lastName", obj.LastName);
                command.Parameters.AddWithValue("$email", obj.Email);
                command.Parameters.AddWithValue("$phoneNumber", obj.PhoneNumber);
                command.Parameters.AddWithValue("$age", obj.Age);
                
                command.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            { 
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(Passanger currentObj, Passanger updateObj)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Passangers " +
                    "SET idSerialNr = $id, firstName = $firstName, lastName = $lastName, " +
                    "email = $email, phoneNumber = $phoneNumber, age = $age " +
                    "WHERE idSerialNr = $currentId";

                command.Parameters.AddWithValue("$id", updateObj.IdSerialNumber);
                command.Parameters.AddWithValue("$firstName", updateObj.FirstName);
                command.Parameters.AddWithValue("$lastName", updateObj.LastName);
                command.Parameters.AddWithValue("$email", updateObj.Email);
                command.Parameters.AddWithValue("$phoneNumber", updateObj.PhoneNumber);
                command.Parameters.AddWithValue("$age", updateObj.Age);

                command.Parameters.AddWithValue("currentId", currentObj.IdSerialNumber);

                command.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Passanger obj)
        {
            try
            {
                var command1 = connection.CreateCommand();
                command1.CommandText = "DELETE FROM Tickets WHERE passangerIdSerialNr = $id";
                command1.Parameters.AddWithValue("$id", obj.IdSerialNumber);
                command1.ExecuteNonQuery();

                var command2 = connection.CreateCommand();
                command2.CommandText = "DELETE FROM Passangers WHERE idSerialNumber = $id";
                command2.Parameters.AddWithValue("$id", obj.IdSerialNumber);
                command2.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Passanger GetPassanger(string idSerialNumber)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Passangers WHERE idSerialNumber = $id";
                command.Parameters.AddWithValue("$id", idSerialNumber);

                var reader = command.ExecuteReader();
                if(reader.Read())
                {
                    Passanger passanger = new Passanger();

                    passanger.IdSerialNumber = reader.GetString(0);
                    passanger.FirstName = reader.GetString(1);
                    passanger.LastName = reader.GetString(2);
                    passanger.Email = reader.GetString(3);
                    passanger.PhoneNumber = reader.GetString(4);
                    passanger.Age = reader.GetInt32(5);

                    return passanger;
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
