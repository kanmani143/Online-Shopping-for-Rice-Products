using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace HaiSia
{
    public class DThelper
    {
        private String connstring;
        public SqlConnection conn;
        public SqlConnection connSSPOS;
        public DThelper()
        {
            setup();
        }

        private void setup()
        {

        }

        public DataTable getSQLDT(SqlCommand cmd)
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable result = new DataTable();
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                sda = new SqlDataAdapter(cmd);
                sda.Fill(result);
                if (cmd.Connection.State != ConnectionState.Closed)
                {
                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                String errmsg = ex.ToString();
            }
            finally
            {
                //if (cn != null) { cn.Close(); cn.Dispose(); }
                if (cmd != null) { cmd.Dispose(); }
                if (sda != null) { sda.Dispose(); }
            }

            return result;
        }

        //private static void executeSQLquery(SqlCommand cmd)
        //{
        //    try
        //    {
        //        if (cmd.Connection.State != ConnectionState.Open)
        //        {
        //            cmd.Connection.Open();
        //        }
        //        cmd.ExecuteNonQuery();
        //        if (cmd.Connection.State != ConnectionState.Closed)
        //        {
        //            cmd.Connection.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        String errmsg = ex.ToString();
        //    }
        //    finally
        //    {
        //        //if (cn != null) { cn.Close(); cn.Dispose(); }
        //        if (cmd != null) { cmd.Dispose(); }
        //    }
        //}

        public void bulkinsert(DataTable mainDT, String tablename, SqlConnection sqlconn)
        {
            SqlConnection connection = sqlconn;
            connection.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.DestinationTableName = tablename;

                try
                {
                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(mainDT);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            connection.Close();
        }
        public void executeSQLquery(SqlCommand cmd)
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable result = new DataTable();
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();
                if (cmd.Connection.State != ConnectionState.Closed)
                {
                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                String errmsg = ex.ToString();
                throw;
            }
            finally
            {
                //if (cn != null) { cn.Close(); cn.Dispose(); }
                if (cmd != null) { cmd.Dispose(); }
                if (sda != null) { sda.Dispose(); }
                if (cmd.Connection.State != ConnectionState.Closed)
                { cmd.Connection.Close(); cmd.Connection.Dispose(); }
            }
        }

    }
}
