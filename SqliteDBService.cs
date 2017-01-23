using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using MvcProject.Entity;

namespace MvcProject.Service
{
    class SqliteDBService
    {
        private static SQLiteConnection connection;

        public static string getConnectionString()
        {
            return "data source=C:/my_app_db.db";
        }
        public static void CompleteConnection()
        {
            SqliteDBService.connection.Close();
            SqliteDBService.connection.Dispose();
        }

        public static SQLiteDataReader UserTableRequest(string query)
        {
            try
            {
                SqliteDBService.connection = new SQLiteConnection(SqliteDBService.getConnectionString());
                SQLiteCommand command = new SQLiteCommand(connection);
                connection.Open();
                command.CommandText = query;
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return reader;
                }
                return null;  
            }
            catch (Exception exception)
            {
                SqliteDBService.CompleteConnection();
                Console.WriteLine(exception.Message);

                return null;
            }
       
        }
    }
}
