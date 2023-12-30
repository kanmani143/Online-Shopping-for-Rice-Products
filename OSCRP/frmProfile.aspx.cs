using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Diagnostics;
namespace OSCRP
{
    public partial class frmProfile : System.Web.UI.Page
    {
        public SqlConnection myconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OSCRP"].ConnectionString);
        string q = "";
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (myconnection.State == ConnectionState.Closed)
                    myconnection.Open();
                //txtlLoginID.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                txtAddress.Text = "";
                txtPinCode.Text = "";
                txtPhoneNo.Text = "";
                txtWhatsApp.Text = "";
                LoadValue();
            }
        }
        protected void LoadValue()
        {
            getConnection();
            q = "Select * From tblUser Where UserId=" + Session["UserID"].ToString();
            cmd = new SqlCommand(q, myconnection);
            dt = dt = new OSCRP.DThelper().getSQLDT(cmd);
            if (dt !=null && dt.Rows.Count>0)
            {
                txtFirstName.Text = dt.Rows[0]["varFirstName"].ToString();
                txtLastName.Text = dt.Rows[0]["nvrLastName"].ToString(); 
                txtEmail.Text = dt.Rows[0]["nvrEmail"].ToString();
                txtAddress.Text = dt.Rows[0]["txtAddress"].ToString();
                txtPinCode.Text = dt.Rows[0]["nvrPinCode"].ToString();
                txtPhoneNo.Text = dt.Rows[0]["nvrPhone"].ToString();
                txtWhatsApp.Text = dt.Rows[0]["nvrWhatsAPP"].ToString();

            }
        }
        protected void getConnection()
        {
            if (myconnection.State == ConnectionState.Closed)
                myconnection.Open();
        }
        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                getConnection();
                cmd = new SqlCommand("dbo.SPRegister", myconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("varLoginID", SqlDbType.NVarChar, 100).Value = Session["UserName"].ToString();

                cmd.Parameters.Add("@varFirstName", SqlDbType.NVarChar, 100).Value = txtFirstName.Text;
                cmd.Parameters.Add("@nvrLastName", SqlDbType.NVarChar, 100).Value = txtLastName.Text;
                cmd.Parameters.Add("@nvrEmail", SqlDbType.NVarChar, 100).Value = txtEmail.Text;
                cmd.Parameters.Add("@txtAddress", SqlDbType.NVarChar, 4000).Value = txtAddress.Text;
                cmd.Parameters.Add("@nvrPinCode", SqlDbType.NVarChar, 10).Value = txtPinCode.Text;
                cmd.Parameters.Add("@nvrPhone", SqlDbType.NVarChar, 50).Value = txtPhoneNo.Text;
                cmd.Parameters.Add("@nvrWhatsAPP", SqlDbType.NVarChar, 50).Value = txtWhatsApp.Text;
                cmd.Parameters.Add("@nvrPassword", SqlDbType.NVarChar, 30).Value = "No need";
                cmd.Parameters.Add("@nvrCommand", SqlDbType.NVarChar, 100).Value = "UPDATE";
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@Result";
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Size = 500;
                parameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parameter);
                cmd.ExecuteNonQuery();
                lblError.Visible = true;

                if (cmd.Parameters["@Result"].Value.ToString() == "Success")
                {


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Profile successfully updated');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + cmd.Parameters["@Result"].Value.ToString() + "');", true);

                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        protected void btnClose_Click(object sender, ImageClickEventArgs e)
        {
            lblError.Visible = false;
            Response.Redirect("frmHome.aspx", false);
        }


    }
}