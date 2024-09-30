using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SQLite;
using System.Configuration;

namespace Data
{
    internal class DataBaseConnection
    {

        SQLiteConnection cn = new SQLiteConnection(
            ConfigurationManager.ConnectionStrings["sqliteconex"].ConnectionString
        );
    }
}
