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
    public partial class frmMyOrder : System.Web.UI.Page
    {
        public SqlConnection myconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OSCRP"].ConnectionString);
        public int index1 = 0;
        SqlCommand cmd;
        string q = "";
        DataTable dt;
        DataSet ds;
        string strProdNo = "";
        string Company = "RMR";
        int intPrdNo = 0;
        string strOrderId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (string.IsNullOrEmpty(Session["UserID"].ToString()) == true)
                    Response.Redirect("frmLogin.aspx");
                LoadOrders();
                //ImgCalender.Attributes.Add("onclick", "javascript:CalendarPopup();return false;");
                //if (string.IsNullOrEmpty(Session["Calendar"].ToString())==false)
                //if (Session["Calendar"] != null)
                //    txtDepartureDate.Text = Session["Calendar"].ToString();
            }
        }

        protected void ClickButton(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "ViewDetails":

                    strOrderId = e.CommandArgument.ToString();
                    Response.Redirect("frmPlaceOrder.aspx?OrderId=" + strOrderId);

                    break;
                case "Delete_Me_Order":
                    Label1.Visible = false;
                    Label1.Text = "";
                    strOrderId = e.CommandArgument.ToString();
                    getConnection();
                    q= "select * from [tblOrder]  Where nvrOrderID='" + strOrderId + "'";
                    cmd = new SqlCommand(q, myconnection);
                    dt = new OSCRP.DThelper().getSQLDT(cmd);
                    if (string.IsNullOrEmpty(dt.Rows[0]["dtDeliveredDate"].ToString())==false)
                    {
                        Label1.Visible = true;
                        Label1.Text = "Already delivered";
                        return;
                    }
                    getConnection();
                    q = "update [tblOrder] set intIsDeleted=1, dtCancelledDate=GETDATE(),varStatus='Cancelled' Where nvrOrderID='" + strOrderId + "'";
                    cmd = new SqlCommand(q, myconnection);
                    cmd.ExecuteNonQuery();
                    //q = "SELECT  *   FROM [tblOrder] where intIsdeleted=0";
                    LoadOrders();
                    break;
            }
        }

        protected void grdOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //    e.Row.Attributes.Add("onmouseout ", "javascript:this.style.color='black';;")
                //e.Row.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';")
                //LinkButton lnkViewDetails = (LinkButton)e.Row.FindControl("lnkViewDetails");
                //lnkViewDetails.Attributes.Add("onmouseout ", "javascript:this.style.color='blue';");
                //lnkViewDetails.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';");
             
                HiddenField hdnOrderID = (HiddenField)e.Row.FindControl("hdnOrderID");

                e.Row.Attributes.Add("style", "cursor:hand;");
                if (e.Row.RowState == DataControlRowState.Alternate)
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='Lime';this.style.color='#FFFFFF';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;this.style.color='#000000';");
                    //e.Row.Attributes.Add("önclick", "getPKWhales(" + hdnOrderID + ");");
                }
                else
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='Lime';this.style.color='#FFFFFF';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;this.style.color='#000000';");
                    //e.Row.Attributes.Add("önclick", "getPKWhales(" + hdnOrderID + ");");
                }
                for (int i = 0; i < e.Row.Cells.Count - 2; i++)
                {
                    e.Row.Cells[i].Attributes["onclick"] = "location.href='frmPlaceOrder.aspx?OrderId=" + DataBinder.Eval(e.Row.DataItem, "nvrOrderID") + "'";
                    e.Row.Cells[i].Attributes["style"] = "cursor:pointer";
                }
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                lnkDelete.Attributes.Add("onmouseout ", "javascript:this.style.color='blue';");
                lnkDelete.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';");

                //e.Row.Attributes["onclick"] = "location.href='frmPlaceOrder.aspx?OrderId=" + DataBinder.Eval(e.Row.DataItem, "nvrOrderID") + "'";
                //e.Row.Attributes["style"] = "cursor:pointer";
                //e.Row.Cells[3].Visible = false;
            }
        }
        protected void getPKWhales(string hdnOrderID)
        {
            Response.Redirect("frmPlaceOrder.aspx?OrderId=" + hdnOrderID);
        }
        protected void grdOrders_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void grdOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = "";
            s = "anbu";
        }
        protected void grdOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdOrders.PageIndex = e.NewPageIndex;
            LoadOrders();
        }
        protected void LoadOrders()
        {
            Label1.Visible = false;
            Label1.Text = "";
            getConnection();
            q = "SELECT  *   FROM [tblOrder] where (intIsDeleted is null or intIsDeleted=0) and [UserID]=" + Session["UserID"].ToString() + " and nvrOrderID in (select nvrOrderID from tblCartDetail) order by dtOrderDate Desc";
            cmd = new SqlCommand(q, myconnection);
            DataTable dt = new OSCRP.DThelper().getSQLDT(cmd);
            if (dt != null && dt.Rows.Count > 0)
            {
                grdOrders.DataSource = dt;
                grdOrders.DataBind();
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "There is no order";
            }
        }
        protected void getConnection()
        {
            if (myconnection.State == ConnectionState.Closed)
                myconnection.Open();
        }
    }
}