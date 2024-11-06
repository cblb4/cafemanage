using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CafeManagementSystem
{
    public class connection  
    {
        SqlConnection conn;
        public SqlConnection getConnect()
        {
            conn = new SqlConnection("Data Source=LAPTOP-MV98GJ7M;Initial Catalog=Cafe;Integrated Security=True;Encrypt=False");
            return conn;
        }
    }
}
