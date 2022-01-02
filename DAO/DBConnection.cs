using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DBConnection
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=QLBN;User ID=sa;Password=123");
    }
}
