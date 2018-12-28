using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        public static string stringConnection = "Data Source = DESKTOP-K8JOR69;Initial catalog=CRCMS_new;Trusted_connection = true;";
        public static SqlConnection conn = new SqlConnection(stringConnection);
        public static SqlDataAdapter da = new SqlDataAdapter(new SqlCommand("SELECT * FROM dic_Group"));
        public static SqlCommandBuilder b = new SqlCommandBuilder(da);
        public static SqlDataAdapter da2 = new SqlDataAdapter(new SqlCommand("SELECT * FROM dic_Model"));
        public static SqlCommandBuilder b2 = new SqlCommandBuilder(da2);
        public static SqlDataAdapter da3 = new SqlDataAdapter(new SqlCommand("SELECT * FROM dic_Pavilion"));
        public static SqlCommandBuilder b3 = new SqlCommandBuilder(da3);
        public static SqlDataAdapter da4 = new SqlDataAdapter(new SqlCommand("SELECT * FROM dic_Status"));
        public static SqlCommandBuilder b4 = new SqlCommandBuilder(da4);

        #region Group

        public static void AddGroup(DataTable dataTable)
        {
            da.SelectCommand.Connection = conn;
            da.Update(dataTable.GetChanges(DataRowState.Added));
        }
        public static void UpdateGroup(DataTable dataTable)
        {
            da.SelectCommand.Connection = conn;
            da.Update(dataTable.GetChanges(DataRowState.Modified));
        }
        public static void DeleteGroup(DataTable dataTable)
        {
            da.SelectCommand.Connection = conn;
            da.Update(dataTable.GetChanges(DataRowState.Deleted));
        }

        #endregion

        #region Model

        public static void AddModel(DataTable dataTable)
        {
            da2.SelectCommand.Connection = conn;
            da2.Update(dataTable.GetChanges(DataRowState.Added));
        }
        public static void UpdateModel(DataTable dataTable)
        {
            da2.SelectCommand.Connection = conn;
            da2.Update(dataTable.GetChanges(DataRowState.Modified));
        }
        public static void DeleteModel(DataTable dataTable)
        {
            da2.SelectCommand.Connection = conn;
            da2.Update(dataTable.GetChanges(DataRowState.Deleted));
        }

        #endregion

        #region Pavilion

        public static void AddPavilion(DataTable dataTable)
        {
            da3.SelectCommand.Connection = conn;
            da3.Update(dataTable.GetChanges(DataRowState.Added));
        }
        public static void UpdatePavilionl(DataTable dataTable)
        {
            da3.SelectCommand.Connection = conn;
            da3.Update(dataTable.GetChanges(DataRowState.Modified));
        }
        public static void DeletePavilion(DataTable dataTable)
        {
            da3.SelectCommand.Connection = conn;
            da3.Update(dataTable.GetChanges(DataRowState.Deleted));
        }

        #endregion

        #region Status

        public static void AddStatus(DataTable dataTable)
        {
            da4.SelectCommand.Connection = conn;
            da4.Update(dataTable.GetChanges(DataRowState.Added));
        }
        public static void UpdateStatus(DataTable dataTable)
        {
            da4.SelectCommand.Connection = conn;
            da4.Update(dataTable.GetChanges(DataRowState.Modified));
        }
        public static void DeleteStatus(DataTable dataTable)
        {
            da4.SelectCommand.Connection = conn;
            da4.Update(dataTable.GetChanges(DataRowState.Deleted));
        }

        #endregion
    }
}
