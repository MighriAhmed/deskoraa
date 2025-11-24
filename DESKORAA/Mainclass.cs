using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKORAA
{
    internal class Mainclass
    {
        public static readonly string con_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=deskoraa;Integrated Security=True";

        public static SqlConnection con = new SqlConnection(con_string);

        public static bool IsValidAdmins(string username, string MotPasse)
        {
            bool IsValid = false;

            string qry = @"SELECT * FROM Admins WHERE Username='" + username + "' AND MotPasse='" + MotPasse + "'";
            SqlCommand cmd=new SqlCommand (qry,con);
            DataTable dt=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill (dt);
            if (dt.Rows.Count > 0)
            {
                IsValid = true;
            }

            return IsValid;
        }
    }
}
