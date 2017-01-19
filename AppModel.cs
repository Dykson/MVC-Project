using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MVCProject.Model
{
    class AppModel
    {
        static string response;
        public static string getConnectionString()
        {
            return "data source=C:/my_app_db.db";
        }

        public static string DBrequest(string query)
        {
            using (SQLiteConnection connection = new SQLiteConnection(AppModel.getConnectionString()))
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                connection.Open();                           // Open the connection to the database
                command.CommandText = query; // Select all users from database table
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AppModel.response = string.Format(reader["firstname"] + " | "
                        + reader["lastname"] + " | " + reader["position"]); // Display the user
                } 
                connection.Close();
            }

            return response;
        }
    }
}
