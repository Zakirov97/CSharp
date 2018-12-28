using _14._11._2018_WorkWithDataContext.Model;
using _14._11._2018_WorkWithDataContext.Model2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Entity;

namespace _14._11._2018_WorkWithDataContext
{
    class Program
    {
        static ModelEntity db = new ModelEntity();
        static ModelEntity2 db2 = new ModelEntity2();
        static void Main(string[] args)
        {
            var newEquip = db.NewEquipments.ToList();
            var EquipHis = db.EquipmentHistories.ToList();

            #region Zadanie 3-e
            //Zadanie 3-e scazali ne delat
            //DataContext context = new DataContext(ConfigurationManager.ConnectionStrings["NewConnection"].ConnectionString);
            //context.CreateDatabase();
            //context.ExecuteCommand("CREATE TABLE TESTTable(TESTTableId INT NOT NULL PRIMARY KEY IDENTITY," +
            //                       "intGarageRoom nvarchar(50) null," +
            //                       "strSerialNo nvarchar(20) null," +
            //                       "intTypeHistory int null," +
            //                       "dStartDate date null," +
            //                       "dEndDate date null," +
            //                       "intDaysCount int null," +
            //                       "intStatys int null)");
            //context.SubmitChanges();
            #endregion

            
        }

        //V skobki peredat nado vse elementi newequipment 
        static public void Task4_1()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    //a suda peredat vse argumenti
                    cmd.CommandText = string.Format("INSERT INTO newEquipment VALUES({0})", 0);
                }
            }
        }
        static public void Task4_2()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO TablesManufacturer(strName) VALUES('Audi')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO TablesManufacturer(strName) VALUES('BMW')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO TablesManufacturer(strName) VALUES('KIA')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO TablesManufacturer(strName) VALUES('JEEP')";
                    cmd.ExecuteNonQuery();
                }
            }
        }


        //5-oe zadanie 
        //Tablici je uje svyazani
        //otlojennaya zagruzka dannih
        //var newEquip = db.NewEquipments.ToList();
        //var EquipHis = db.EquipmentHistories.ToList();

        static public void Task6()
        {
            List<NewEquipment> eq = new List<NewEquipment>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                con.Open();
                SqlDataReader reader;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select * from newEquipment " +
                        "where eq.intModelID = ( " +
                        "select m.intModelID from TablesModel as m " + 
                        "inner join[MCS].[dbo].[newEquipment] as e on m.intModelID = e.intModelID " +
                        "group by m.intModelID " +
                        "having count(*) > 10 and m.intModelID = eq.intModelID)";
                    reader = cmd.ExecuteReader();
                }
            }
        }

        //Ne znayu kak udalit bez cikla
        static public void Task7()
        {
        }
    }
}
