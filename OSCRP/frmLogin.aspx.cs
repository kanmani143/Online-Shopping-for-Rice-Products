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
    public partial class frmLogin : System.Web.UI.Page
    {
        public SqlConnection myconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OSCRP"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
            lblUserError.Text = "";
            lblPasswordError.Text ="";
            lblPasswordError.Visible = true;
            lblUserError.Visible = true;

            if (string.IsNullOrEmpty(txtUserID.Text) == true && string.IsNullOrEmpty(txtPassword.Text) == true)
            {
                lblUserError.Text = "Please Enter User";
                lblPasswordError.Text = "Please Enter Password";
                return;
            }
            else
                if (string.IsNullOrEmpty(txtUserID.Text) == true)
            {
                lblUserError.Text = "Please Enter User";
                return;
            }
            else
                if (string.IsNullOrEmpty(txtPassword.Text) == true)
            {
                lblPasswordError.Text = "Please Enter Password";
                return;
            }

            try
            {
                if (myconnection.State == ConnectionState.Closed)
                    myconnection.Open();
                SqlCommand cmd = new SqlCommand("dbo.spLogin", myconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@varLoginID", SqlDbType.NVarChar, 100).Value = txtUserID.Text;
                cmd.Parameters.Add("@nvrPassword", SqlDbType.NVarChar, 30).Value = txtPassword.Text;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@Result";
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Size = 500;
                parameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parameter);
                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@UserID";
                parameter1.SqlDbType = SqlDbType.NVarChar;
                parameter1.Size = 30;
                parameter1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parameter1);
                cmd.ExecuteNonQuery();
                lblError.Visible = true;

                if (cmd.Parameters["@Result"].Value.ToString().Trim() == "Success")
                {
                    if (myconnection.State == ConnectionState.Closed)
                        myconnection.Open();
                    
                    string q = "Select * from [tblUser] where [UserId]=" + cmd.Parameters["@UserID"].Value.ToString().Trim();
                    cmd = new SqlCommand(q, myconnection);
                    DataTable dt = new DThelper().getSQLDT(cmd);
                    if(string.IsNullOrEmpty(dt.Rows[0]["intActive"].ToString()) || dt.Rows[0]["intActive"].ToString()=="0")
                    {
                        lblError.Text = "User is inactive";

                    }
                    else
                    {
                        if ( dt.Rows[0]["intIsDeleted"].ToString() == "1")
                        {
                            lblError.Text = "User does not exist or removed";

                        }
                        else
                        {
                            Session["UserID"] = dt.Rows[0]["UserId"].ToString();
                            Session["UserName"] = txtUserID.Text;
                            Session["Password"] = txtPassword.Text;
                            Response.Redirect("frmHome.aspx", false);
                        }
                    }


                }
                else
                    lblError.Text = cmd.Parameters["@Result"].Value.ToString();
                

            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }
    }
}