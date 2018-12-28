using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringConnection = "Data Source = DESKTOP-K8JOR69;Initial catalog=CRCMS_new;trusted_connection = true;";
            SqlConnection conn = new SqlConnection(stringConnection);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            da.SelectCommand = new SqlCommand("SELECT * FROM dic_Group");
            da.SelectCommand.Connection = conn;
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            DataRow dr = dt.NewRow();
            dr["Name"] = "Eshkerer";

            dt.Rows.Add(dr);
            Class1.AddGroup(dt);

            dt.Rows[8][1] = "lolo";
            Class1.UpdateGroup(dt);

            dt.Rows[7].Delete();
            Class1.DeleteGroup(dt);
        }
    }
}
