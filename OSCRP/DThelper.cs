using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlTypes;

namespace OSCRP
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
        protected void InformatinBox_new(string strMsg)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string a;
            try
            {
                strMsg = strMsg.Replace("\'", " \\\'");
                strMsg = strMsg.Replace(".", "");
                sb.Append("<script type = \'text/javascript\'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert(\'");
                sb.Append(strMsg);
                sb.Append("\')};");
                sb.Append("</script>");
                
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
            catch (Exception ex)
            {
                a = ex.Message;

            }
            // strMsg = Replace(strMsg, "'", "\'")
            // strMsg = Replace(strMsg, ".", "")
        }
        public DataTable getSQLDT(SqlCommand cmd)
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable result = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
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

            return ds.Tables[0];
        }

        public DataSet getSQLDS(SqlCommand cmd)
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable result = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
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

            return ds;
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
