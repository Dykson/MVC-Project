using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using MVCProject.Entity;

namespace MVCProject.Service
{
    class SqliteDBService
    {
        private static SQLiteConnection connection;
        static string response;
        public static string getConnectionString()
        {
            return "data source=C:/my_app_db.db";
        }

        public static Hashtable UserTableRequest(string query)
        {
            using (SqliteDBService.connection = new SQLiteConnection(SqliteDBService.getConnectionString()))
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                connection.Open();                           // Open the connection to the database
                command.CommandText = query; // Select all users from database table
                SQLiteDataReader reader = command.ExecuteReader();

                Hashtable response = new Hashtable();
                
                while (reader.Read())
                {
                    response["id"] = reader.GetInt32(0);
                    response["login"] = reader.GetString(1);
                    response["password"] = reader.GetString(2);
                    response["firstname"] = reader.GetString(3);
                    response["lastname"] = reader.GetString(4);
                    response["position"] = reader.GetString(5);
                }

                SqliteDBService.connection.Close();

                return response;
            }
        }
    }
}
