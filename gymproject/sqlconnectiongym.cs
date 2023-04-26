using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymproject
{
    class sqlconnectiongym
    {
        public SqlConnection connection()
        {
            SqlConnection connect = new SqlConnection("Server=iamahmetkoca\\SQLEXPRESS;Database=gym-project;User ID=ahmetkoca;Password=01020312;");
            connect.Open();
            return connect;
        }
    }
}
