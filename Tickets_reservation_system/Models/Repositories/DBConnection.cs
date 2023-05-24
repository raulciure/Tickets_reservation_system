using Microsoft.Data.Sqlite;
using System;

namespace Tickets_reservation_system.Models.Repositories
{
    public static class DBConnection
    {
        public static SqliteConnection getDBConnection(string filename)
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

        public static void closeDBConnection(SqliteConnection connection)
        {
            connection.Close();
        }
    }
}
