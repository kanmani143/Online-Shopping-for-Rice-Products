using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace OSCRP
{
    public partial class frmSignUp : System.Web.UI.Page
    {
        public SqlConnection myconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OSCRP"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack==false)
            {
                txtlLoginID.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                txtAddress.Text = "";
                txtPinCode.Text = "";
                txtPhoneNo.Text = "";
                txtWhatsApp.Text = "";
                txtPassword.Text = "";
                txtConfirmPassWord.Text = "";
            }
        }

        protected void btnSignUp_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (myconnection.State == ConnectionState.Closed)
                    myconnection.Open();
                SqlCommand cmd = new SqlCommand("dbo.SPRegister", myconnection);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("varLoginID", SqlDbType.NVarChar, 100).Value = txtlLoginID.Text;
                cmd.Parameters.Add("@varFirstName", SqlDbType.NVarChar, 100).Value = txtFirstName.Text;
                cmd.Parameters.Add("@nvrLastName", SqlDbType.NVarChar, 100).Value = txtLastName.Text;
                cmd.Parameters.Add("@nvrEmail", SqlDbType.NVarChar, 100).Value = txtEmail.Text;
                cmd.Parameters.Add("@txtAddress", SqlDbType.NVarChar, 4000).Value = txtAddress.Text;
                cmd.Parameters.Add("@nvrPinCode", SqlDbType.NVarChar, 10).Value = txtPinCode.Text;
                cmd.Parameters.Add("@nvrPhone", SqlDbType.NVarChar, 50).Value = txtPhoneNo.Text;
                cmd.Parameters.Add("@nvrWhatsAPP", SqlDbType.NVarChar, 50).Value = txtWhatsApp.Text;
                cmd.Parameters.Add("@nvrPassword", SqlDbType.NVarChar, 30).Value = txtPassword.Text;
                cmd.Parameters.Add("@Role", SqlDbType.NVarChar, 50).Value = "User";
                cmd.Parameters.Add("@intActive", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@intIsDeleted", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@nvrCommand", SqlDbType.NVarChar, 100).Value = "INSERT";
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully registered');", true);
                    //Response.Redirect("frmLogin.aspx", false);
                }
                else
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully registered');", true);
                lblError.Text = cmd.Parameters["@Result"].Value.ToString();
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        protected void btnClose_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("frmLogin.aspx", false);
        }
    }
}