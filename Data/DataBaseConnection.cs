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

                string query = @"
                    INSERT INTO users (username, password, role) 
                        VALUES (@username, @password)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, __Connection))
                {
                    cmd.Parameters.AddWithValue("@username", user.UserName);
                    cmd.Parameters.AddWithValue("@password", user.Password);

                    cmd.ExecuteNonQuery();
                }
            } 
        }

        public void RegisterProduct(Product product)
        {
            using (__Connection)
            {
                __Connection.Open();

                string query = @"
                    INSERT INTO products (category_id, product_name, price, created_at, updated_at, created_by, updated_by, is_active) 
                        VALUES (@category_id, @product_name, @price, @created_at, @updated_at, @created_by, @updated_by, @is_active)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, __Connection))
                {
                    cmd.Parameters.AddWithValue("@category_id", product.CategoryId);
                    cmd.Parameters.AddWithValue("@product_name", product.ProductName);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@created_at", DateTime.Now); // o usa product.CreatedAt si se pasa desde la instancia
                    cmd.Parameters.AddWithValue("@updated_at", DateTime.Now); // o usa product.UpdatedAt
                    cmd.Parameters.AddWithValue("@created_by", product.CreatedBy);
                    cmd.Parameters.AddWithValue("@updated_by", product.UpdatedBy);
                    cmd.Parameters.AddWithValue("@is_active", product.IsActive ? 1 : 0);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
