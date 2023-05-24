using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace Tickets_reservation_system.Models.Repositories
{
    public static class DBConnection
    {
        public static SqliteConnection getDBConnection(string filename)
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirecory = Directory.GetParent(workingDirectory).Parent.FullName;

            var connection = new SqliteConnection(@"Data Source = " + Path.Combine(projectDirecory, filename));

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
