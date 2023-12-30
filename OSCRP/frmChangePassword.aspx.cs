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
    public partial class frmChangePassword : System.Web.UI.Page
    {
        public SqlConnection myconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OSCRP"].ConnectionString);
        string q = "";
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtOldPassword.Text.Trim() != Session["Password"].ToString().Trim())
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Old Password is not correct');", true);
                    return;
                }
                if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('New Password and Confirm Password are not match');", true);
                    return;
                }
                if (myconnection.State == ConnectionState.Closed)
                    myconnection.Open();
                SqlCommand cmd = new SqlCommand("dbo.spChangePassword", myconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@varLoginID", SqlDbType.NVarChar, 100).Value = Session["UserName"].ToString();
                cmd.Parameters.Add("@nvrPassword", SqlDbType.NVarChar, 30).Value = txtNewPassword.Text;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@Result";
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Size = 500;
                parameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parameter);
                
                cmd.ExecuteNonQuery();
                lblError.Visible = true;

                if (cmd.Parameters["@Result"].Value.ToString().Trim() == "Success")
                {
                    Session["Password"] = txtNewPassword.Text;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Password changed successfully');", true);
                    //Response.Redirect("frmHome.aspx", false);
                }
                else
                    lblError.Text = cmd.Parameters["@Result"].Value.ToString();
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + ex.Message + "');", true);
            }
        }

        protected void btnClose_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("frmHome.aspx", false);
        }
    }
}