using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SQLite;
using System.Configuration;

using Entity;

namespace Data
{
    public class DataBaseConnection
    {

        SQLiteConnection __Connection;

        DataBaseConnection()
        {
            __Connection = new SQLiteConnection(
                ConfigurationManager.ConnectionStrings["sqliteconex"].ConnectionString
            );
        }

        public void RegisterUser(User user)
        {
            using (__Connection)
            {
                __Connection.Open();

                string query = "INSERT INTO users (username, password, role) VALUES (@username, @password)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, __Connection))
                {
                    cmd.Parameters.AddWithValue("@username", user.UserName);
                    cmd.Parameters.AddWithValue("@password", user.Password);

                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
