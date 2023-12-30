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
    public partial class frmOurProducts : System.Web.UI.Page
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
                StringBuilder builder = new StringBuilder();
                if (String.IsNullOrEmpty(Session["UserID"].ToString()) == false)
                {
                    lnkLogout.Text = "Logout";
                    builder = new StringBuilder();
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
                    builder = new StringBuilder();
                    builder.Append("Welcome, ");
                    builder.Append("<span style=\"color:Red;\">");
                    builder.Append("Guest");
                    builder.Append("</span>");
                    lblCustomer.Text = builder.ToString();
                }
                Session["LoginForm"] = "";
                loadProd();
            }
        }
        private void loadProd() 
        {
            String q = "";
            SqlCommand cmd = new SqlCommand();
            try 
            {
                q = "SELECT [varProductName] FROM [HAISIA].[dbo].[tblOurProducts] order by [varProductName]";
                cmd = new SqlCommand(q, myconnection);
                DataTable dt = new DThelper().getSQLDT(cmd);
                q = "SELECT [varProductName] FROM [HAISIA].[dbo].[tblOurProducts] Where [varProductName]='XXXXX'";
                cmd = new SqlCommand(q, myconnection);
                DataTable dt1 = new DThelper().getSQLDT(cmd);
                //q = "SELECT [varProductName] FROM [HAISIA].[dbo].[tblOurProducts] Where [varProductName]='XXXXX'";
                //cmd = new SqlCommand(q, myconnection);
                //DataTable dt2 = new DThelper().getSQLDT(cmd);
                int i = 0;
                int j = (dt.Rows.Count / 2);
                foreach (DataRow dr in dt.Rows) 
                {
                    dt1.ImportRow(dr);
                    //if (i <= j) dt1.ImportRow(dr);
                    //else dt2.ImportRow(dr);
                    //i++;
                }

                gvLeft.DataSource = dt1;
                gvLeft.DataBind();
                //gvRight.DataSource = dt2;
                //gvRight.DataBind();
            }
            catch 
            { 
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

        protected void gvLeft_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String q="SELECT [varImageLocation] FROM [HAISIA].[dbo].[tblOurProducts] ";
                q= q+ "Where [varProductName]='" + e.Row.Cells[0].Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand (q,myconnection);
                DataTable dt = new DThelper().getSQLDT(cmd);
                e.Row.Cells[0].Attributes.Add("onmouseout", "javascript:this.style.color='blue';;");
                e.Row.Cells[0].Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';javascript:ShowImage('" + dt.Rows[0][0].ToString().Trim().Substring(2) + "');return false;");
                e.Row.Cells[0].Attributes.Add("onclick", "javascript:ShowImage('" + dt.Rows[0][0].ToString().Trim().Substring(2) + "');return false;");
                e.Row.Cells[0].Attributes.Add("touchend", "javascript:this.style.color='blue';;");
                e.Row.Cells[0].Attributes.Add("touchstart", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';javascript:ShowImage('" + dt.Rows[0][0].ToString().Trim().Substring(2) + "');return false;");
                e.Row.Cells[0].Attributes.Add("touchleave", "javascript:this.style.color='blue';;");
                e.Row.Cells[0].Attributes.Add("touchmove", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';javascript:ShowImage('" + dt.Rows[0][0].ToString().Trim().Substring(2) + "');return false;");
                
            }
        }

        protected void gvRight_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String q = "SELECT [varImageLocation] FROM [HAISIA].[dbo].[tblOurProducts] ";
                q = q + "Where [varProductName]='" + e.Row.Cells[0].Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(q, myconnection);
                DataTable dt = new DThelper().getSQLDT(cmd);
                e.Row.Cells[0].Attributes.Add("onmouseout ", "javascript:this.style.color='blue';;");
                e.Row.Cells[0].Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';javascript:ShowImage('" + dt.Rows[0][0].ToString().Trim().Substring(2) + "');return false;");
                e.Row.Cells[0].Attributes.Add("onclick", "javascript:ShowImage('" + dt.Rows[0][0].ToString().Trim().Substring(2) + "');return false;");
            }
        }
    }
}
