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
namespace HaiSia
{
    public partial class frmMyOrder : System.Web.UI.Page
    {
        public SqlConnection myconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["HAISIA"].ConnectionString);
        public int index1 = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["CartOrderID"] = "";
            Session["varTempCartID"] = "";
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
                    builder = new StringBuilder();
                    builder.Append("<span style=\"color:Red;\">");
                    builder.Append("Note: ");
                    builder.Append("</span>");
                    builder.Append("To view or confirm Orders, click on ");
                    builder.Append("<span style=\"background-color:Yellow;\">");
                    builder.Append("Order ID");
                    builder.Append("</span>");
                    builder.Append(" or ");
                    builder.Append("<span style=\"background-color:Yellow;\">");
                    builder.Append("Cart Ref No");
                    builder.Append("</span>");
                    lblNote.Text = builder.ToString();



                    LoadOrders();
                }
                else
                {
                    Session["UserID"] = "";
                    lnkLogout.Text = "Login";
                    Session["LoginForm"] = "frmMyOrder.aspx";
                    Response.Redirect("frmLogin.aspx");
                }
            }
        }
        private void LoadOrders()
        {
            try
            {


                //Session["varTempCartID"] = Session["UserID"].ToString().Trim() + Session["PricingCode"].ToString().Trim() + GetTimestamp(DateTime.Now).Trim();
                String q = "SELECT H.[varOrderID],LTRIM(RTRIM(H.[varTempCartID])) as varTempCartID,H.[dtCreated],H.[varStatus],H.[varCartHeaderRemarks],";
                q = q + " Count(*) as TotItems,sum(D.intQty) as TotQty, SUM(D.dblTotPrice) as TotPrice ";
                q = q + " FROM [HAISIA].[dbo].[tblCartHeader] H, [HAISIA].[dbo].[tblCartDetail] D WHERE H.varOrderID=D.varOrderID";
                q = q + " and H.GMCUST='" + Session["UserID"].ToString().Trim() + "' ";
                q = q + " GROUP BY H.[varOrderID],H.[varTempCartID],H.[dtCreated],H.[varStatus],H.[varCartHeaderRemarks] order by H.[dtCreated] Desc";
                SqlCommand cmd = new SqlCommand(q, myconnection);
                DataTable dt = new DThelper().getSQLDT(cmd);

                q = "SELECT null as varOrderID,H.[varTempCartID],H.[dtCreated],'01' as varStatus,'Order not confirmed' as varCartHeaderRemarks,";
                q = q + " Count(*) as TotItems,sum(D.intQty) as TotQty, SUM(D.dblTotPrice) as TotPrice ";
                q = q + " FROM [HAISIA].[dbo].[tblTempCartHeader] H, [HAISIA].[dbo].[tblTempCart] D WHERE H.varTempCartID=D.varTempCartID ";
                q = q + " and H.GMCUST='" + Session["UserID"].ToString().Trim() + "' GROUP BY H.[varTempCartID],H.[dtCreated] order by H.[dtCreated] Desc";
                cmd = new SqlCommand(q, myconnection);
                DataTable dt1 = new DThelper().getSQLDT(cmd);
                foreach (DataRow dr in dt1.Rows)
                {
                    dt.ImportRow(dr);
                }
                grdvwMyOrder.DataSource = dt;
                grdvwMyOrder.DataBind();
            }
            catch (Exception ex)
            {
                InformatinBox_new(ex.Message);
            }
        }
        protected void grdvwMyOrder_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
        }
        protected void grdvwMyOrder_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Attributes.Add("onmouseout ", "javascript:this.style.color='blue';;");
                e.Row.Cells[1].Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';");
                e.Row.Cells[2].Attributes.Add("onmouseout ", "javascript:this.style.color='blue';;");
                e.Row.Cells[2].Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';");
                String strID = String.IsNullOrEmpty(e.Row.Cells[1].Text.ToString()) ? "" : e.Row.Cells[1].Text.ToString().Trim();
                String strRef = String.IsNullOrEmpty(e.Row.Cells[2].Text.ToString()) ? "" : e.Row.Cells[2].Text.ToString().Trim();
                e.Row.Cells[1].Attributes.Add("onclick", "javascript:window.location.href='frmCheckOut.aspx?OrderID=" + strID.Trim() + "&OrderRef=" + strRef + "';;");
                e.Row.Cells[2].Attributes.Add("onclick", "javascript:window.location.href='frmCheckOut.aspx?OrderID=" + strID.Trim() + "&OrderRef=" + strRef + "';;");

                if (e.Row.Cells[8].Text.ToString().Trim() != "Order not confirmed")
                {
                    e.Row.Cells[8].BackColor = System.Drawing.Color.LightGreen;
                    ImageButton btndelete = (ImageButton)e.Row.FindControl("btndelete");
                    btndelete.Visible = false;
                    btndelete.ImageUrl = "";

                }
                else
                {
                    e.Row.Cells[1].Font.Underline = false;
                }


            }
        }
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            //String q = "Delete From [HAISIA].[dbo].[tblTempCart] Where varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "'";
            //SqlCommand cmd = new SqlCommand(q, myconnection);
            //new DThelper().executeSQLquery(cmd);
            //q = "Delete From [HAISIA].[dbo].[tblTempCartHeader] Where varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "'";
            //cmd = new SqlCommand(q, myconnection);
            //new DThelper().executeSQLquery(cmd);
            Session["varTempCartID"] = "";
            Session["PricingCode"] = "";
            Session["UserID"] = "";
            Session["UserName"] = "";
            Response.Redirect("frmLogin.aspx");
        }
        protected void ClickButton(object sender, CommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Delete_Me_Order":
                    index1 = Convert.ToInt32(e.CommandArgument);
                    //grdvwMyOrder.Columns[7].Visible = true;
                    GridViewRow row1 = grdvwMyOrder.Rows[index1];
                    //if (String.IsNullOrEmpty(row1.Cells[1].Text.ToString()) == false && row1.Cells[1].Text.ToString().Trim() != "" && row1.Cells[1].Text.ToString().Trim() != "&nbsp;")
                    //{
                    //    InformatinBox_new("Confirmed order can not be deleted!");
                    //}

                    //String st = grdvwMyOrder.Rows[index1].Cells[3].Text;
                    //row1.Cells[7].Visible = true;
                    if (row1.Cells[8].Text.ToString().Trim() != "Order not confirmed")
                    {
                        //row1.Cells[7].Visible= false;
                        InformatinBox_new("Confirmed order can not be deleted!");

                    }
                    else
                    {
                        //row1.Cells[7].Visible= false;
                        String q = "DELETE FROM [HAISIA].[dbo].[tblTempCart] WHERE [varTempCartID]='" + row1.Cells[2].Text.ToString().Trim() + "'";
                        SqlCommand cmd = new SqlCommand(q, myconnection);
                        new DThelper().executeSQLquery(cmd);
                        q = "DELETE FROM [HAISIA].[dbo].[tblTempCartHeader] WHERE [varTempCartID]='" + row1.Cells[2].Text.ToString().Trim() + "'";
                        cmd = new SqlCommand(q, myconnection);
                        new DThelper().executeSQLquery(cmd);
                        InformatinBox_new("Successfully deleted");
                        //row1.Cells[7].Visible = false;
                        LoadOrders();
                    }
                    break;
            }
        }

        protected void lnkBackToItems_Click(object sender, EventArgs e)
        {
            Response.Redirect("DisplayItems.aspx");
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
