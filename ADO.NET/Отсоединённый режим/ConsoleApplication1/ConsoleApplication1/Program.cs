using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static SqlConnection con = null;
        static DataSet ds = null;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            con = new SqlConnection();
            con.ConnectionString = @"Data Source=205_TEACHER\SQLEXPRESS; Initial Catalog=Statistic; Trusted_Connection=Yes;";

            SqlDataAdapter da =
                new SqlDataAdapter("select * from StatisticEvents;", con);
           ds = new DataSet();
            da.Fill(ds);
            
            
            AddStat();
            EditStat();
            DeleteStat();

            PrintData();

            if (ds.HasChanges())
            {
                Console.WriteLine("\nBefore changes: \n");
                foreach (DataTable table in
                    ds.GetChanges(DataRowState.Modified)
                    .Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        for (int i = 0; i < row.ItemArray.Length; i++)
                        {
                            Console.WriteLine("\t BEFORE - {0}: AFTER - {1}",
                           row[i, DataRowVersion.Original],
                           row[i, DataRowVersion.Current]);
                        }                       
                    }
                }
            }
        }

        static void PrintData()
        {
           
            if(!ds.HasErrors)
            {
                var relations = ds.Relations;
                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if(row.RowState == 
                            DataRowState.Modified)
                            Console.ForegroundColor = 
                                ConsoleColor.Yellow;
                        else if (row.RowState == 
                            DataRowState.Added )
                            Console.ForegroundColor =
                                ConsoleColor.Green;
                        else if (row.RowState ==
                            DataRowState.Deleted)
                            Console.ForegroundColor =
                                ConsoleColor.Red;

                        Console.WriteLine(row["StatisticEventsId"]);
                        foreach (object cell in row.ItemArray)
                        {
                            Console.WriteLine("\t{0}", cell);
                        }
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
        }

        static void AddStat()
        {
            DataRow dr = ds.Tables[0].NewRow();
            dr["AccidentDate"] = DateTime.Now;
            dr["Time"] = "Time";
            dr["DayOfWeek"] = "DayOfWeek";
            dr["County"] = "County";
            dr["Age"] = 30;
            dr["Gender"] = "Gender";
            dr["Race"] = "Race";

            ds.Tables[0].Rows.Add(dr);

        }

        static void EditStat()
        {
            DataRow dr = ds.Tables[0].Rows[0];
            dr["AccidentDate"] = DateTime.Now;
            dr["Time"] = DateTime.Now.Ticks;
            dr["DayOfWeek"] = DateTime.Now.DayOfWeek;
        }

        static void DeleteStat()
        {
            DataRow dr = ds.Tables[0].Rows[2];
            //ds.Tables[0].Rows.Remove(dr);

            ds.Tables[0].Rows.RemoveAt(5);

            ds.AcceptChanges();
        }
    }
}
