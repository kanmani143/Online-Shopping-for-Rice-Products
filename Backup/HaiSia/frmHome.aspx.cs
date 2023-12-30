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
    public partial class frmHome : System.Web.UI.Page
    {
        public SqlConnection myconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["HAISIA"].ConnectionString);
        public int index1 = 0;
        public string[] arr4 = new string[7];
        public String wp = "";
        public String orddt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                if (String.IsNullOrEmpty(Session["UserID"].ToString()) == false)
                {
                    lnkLogout.Text = "Logout";
                    StringBuilder builder = new StringBuilder();
                    builder.Append("Welcome, ");
                    builder.Append("<span style=\"color:Red;\">");
                    builder.Append(Session["UserName"].ToString().Trim());
                    builder.Append("</span>");
                    lblCustomer.Text = builder.ToString();
                }
                else
                {
                    Session["UserID"] = "";
                    //Response.Redirect("frmLogin.aspx");
                    lnkLogout.Text = "Login";
                    StringBuilder builder = new StringBuilder();
                    builder.Append("Welcome, ");
                    builder.Append("<span style=\"color:Red;\">");
                    builder.Append("Guest");
                    builder.Append("</span>");
                    lblCustomer.Text = builder.ToString();
                }
                Session["LoginForm"] = "";
            }
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
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            
                Session["varTempCartID"] = "";
                Session["PricingCode"] = "";
                Session["UserID"] = "";
                Session["UserName"] = "";
                Response.Redirect("frmLogin.aspx");
            
     
        }
        private Boolean blnChkDetItems()
        {
            Boolean retVal = false;
            String q = "Select *  From [HAISIA].[dbo].[tblTempCart] Where varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "'";
            SqlCommand cmd = new SqlCommand(q, myconnection);
            DataTable dt = new DThelper().getSQLDT(cmd);
            if (dt.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        private void callCartForm()
        {
            if (blnChkDetItems() == true)
            {

                //Response.Redirect("frmMyCartNew.aspx");
                Response.Redirect("frmCart.aspx?OrderID= &OrderRef=" + Session["varTempCartID"].ToString().Trim());

            }
            else
            {
                InformatinBox_new("No item(s) selected");
            }
        }
        //protected void lnkMyCart_Click(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(Session["varTempCartID"].ToString()) == false)
        //    {
        //        callCartForm();
        //    }
        //    else
        //    {
        //        InformatinBox_new("No Order created");
        //    }
        //}

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
        
    }
}
