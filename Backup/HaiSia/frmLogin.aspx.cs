using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;
using System.Text;
using System.Web.UI.HtmlControls;
namespace HaiSia
{
    public partial class frmLogin : System.Web.UI.Page
    {
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["HAISIA"].ConnectionString);
        public int index1 = 0;
        public string[] arr4 = new string[7];
        public String wp = "";
        public String orddt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //if (String.IsNullOrEmpty(Session["UserID"].ToString()) == false)
                //{
                //    StringBuilder builder = new StringBuilder();
                //    builder.Append("Welcome, ");
                //    builder.Append("<span style=\"color:Red;\">");
                //    builder.Append(Session["UserName"].ToString().Trim());
                //    builder.Append("</span>");
                //    lblCustomer.Text = builder.ToString();
                //}
                //else
                //{
                //    Session["UserID"] = "";
                //    Response.Redirect("frmLogin.aspx");
                //}
                StringBuilder builder = new StringBuilder();
                builder.Append("Welcome, ");
                builder.Append("<span style=\"color:Red;\">");
                builder.Append("Guest");
                builder.Append("</span>");
                lblCustomer.Text = builder.ToString();
            }
        }

        protected void lnkMyOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmMyOrder.aspx");
        }
        protected void lnkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmHome.aspx");
        }
        protected void lnkContactUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactUs.aspx");
        }

        protected void lnkMyCart_Click(object sender, EventArgs e)
        {

            Response.Redirect("frmMyCart.aspx");
        }

        protected void lnkOurProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmOurProducts.aspx");
        }
        protected void lnkLogout_Click(object sender, EventArgs e)
        {

            Session["varTempCartID"] = "";
            Session["PricingCode"] = "";
            Session["UserID"] = "";
            Session["UserName"] = "";
            Response.Redirect("frmLogin.aspx");

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
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
            catch (Exception ex)
            {
                a = ex.Message;
                
            }
            // strMsg = Replace(strMsg, "'", "\'")
            // strMsg = Replace(strMsg, ".", "")
        }

          protected void btnLogin_Click(object sender, EventArgs e)
          {
              String q = "Select GMCUST,GMCNME from [HAISIA].[dbo].[ARM01] where GMCUST='" + txtUserID.Text.ToString().Trim() + "' And ZMCOMP='01'";
              SqlCommand cmd = new SqlCommand(q, conn);
              DataTable dt = new DThelper().getSQLDT(cmd);

              if (dt.Rows.Count>0 && txtPassword.Text == "password")
              {
                  Session["UserID"] = dt.Rows[0]["GMCUST"].ToString().Trim();
                  Session["UserName"] = dt.Rows[0]["GMCNME"].ToString().Trim();
                  if(Session["LoginForm"].ToString().Trim()=="") Response.Redirect("frmHome.aspx");
                  else Response.Redirect(Session["LoginForm"].ToString().Trim());
                  
              }
              else
              {
                  if (txtUserID.Text.ToString().Trim() == "Admin" && txtPassword.Text == "password")
                  {
                      Session["UserID"] = "Admin";
                      Session["UserName"] = "Admin";
                      Response.Redirect("frmHomeAdmin.aspx");
                  }
                      
                  else
                  {
                    
                          String txt = "Incorrect Username & Password...";
                          InformatinBox_new(txt);
                      
                  }
              }
          }
            
    }
}
