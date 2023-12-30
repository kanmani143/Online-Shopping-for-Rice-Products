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
    public partial class frmOrderMaintenance : System.Web.UI.Page
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
        string strUserID = "";
        protected System.Web.UI.HtmlControls.HtmlGenericControl ImgPane;
        protected string dateSelected;
        protected string _ObjectName;
        protected bool _Disabled;
        protected System.Web.UI.HtmlControls.HtmlInputText childfld;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack==false)
            {   if (string.IsNullOrEmpty(Request.QueryString["UserId"].ToString()) == false)
                {
                    strUserID = Request.QueryString["UserId"].ToString();
                }
                else
                    strUserID = "";
                LoadOrders(strUserID);

            }
            
            
        }
        protected void grdOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //    e.Row.Attributes.Add("onmouseout ", "javascript:this.style.color='black';;")
                //e.Row.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';")
                
                HiddenField hdnOrderID = (HiddenField)e.Row.FindControl("hdnOrderID");
                //e.Row.Cells[0].Attributes.Add("onclick", "javascript:Popup('" + hdnProdLocation.Value.ToString() + "');return false;");
                //e.Row.Cells[1].Attributes.Add("onclick", "javascript:Popup('" + hdnProdLocation.Value.ToString() + "');return false;");
                //e.Row.Cells[2].Attributes.Add("onclick", "javascript:Popup('" + hdnProdLocation.Value.ToString() + "');return false;");
                //e.Row.Cells[3].Attributes.Add("onclick", "javascript:Popup('" + hdnProdLocation.Value.ToString() + "');return false;");
                //e.Row.Cells[4].Attributes.Add("onclick", "javascript:Popup('" + hdnProdLocation.Value.ToString() + "');return false;");
                //e.Row.Cells[5].Attributes.Add("onclick", "javascript:Popup('" + hdnProdLocation.Value.ToString() + "');return false;");
                //e.Row.Cells[6].Attributes.Add("onclick", "javascript:Popup('" + hdnProdLocation.Value.ToString() + "');return false;");
                //e.Row.Attributes.Add("onmouseout", "javascript:this.style.cursor='';;javascript:this.style.color='black';");
                //e.Row.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';");

                e.Row.Attributes.Add("style", "cursor:hand;");
                if (e.Row.RowState == DataControlRowState.Alternate)
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='Lime';this.style.color='#FFFFFF';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;this.style.color='#000000';");
                }
                else
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='Lime';this.style.color='#FFFFFF';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;this.style.color='#000000';");
                }
                for (int i = 0; i < e.Row.Cells.Count - 3; i++)
                {
                    e.Row.Cells[i].Attributes["onclick"] = "location.href='frmPlaceOrder.aspx?OrderId=" + DataBinder.Eval(e.Row.DataItem, "nvrOrderID") + "'";
                    e.Row.Cells[i].Attributes["style"] = "cursor:pointer";
                }
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                lnkDelete.Attributes.Add("onmouseout", "javascript:this.style.color='blue';");
                lnkDelete.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';");
                LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                lnkEdit.Attributes.Add("onmouseout", "javascript:this.style.color='blue';");
                lnkEdit.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';");

                //lnkEdit.Attributes.Remove("onclick");
                //lnkDelete.Attributes["onclick"].Remove();
                //e.Row.Cells[3].Visible = false;
            }
        }
        protected void ClickButton(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete_Me_Order":
                    //index1 = Convert.ToInt32(e.CommandArgument);
                    //InformatinBox_new(index1.ToString());
                    strOrderId = e.CommandArgument.ToString();
                    //if (myconnection.State == ConnectionState.Closed)
                    //    myconnection.Open();
                    //q = "SELECT  *   FROM[tblOrder]  intIsDeleted = 1 and nvrOrderID='" + strOrderId + "'";
                    //cmd = new SqlCommand(q, myconnection);
                    //dt = new OSCRP.DThelper().getSQLDT(cmd);
                    //if (dt != null && dt.Rows.Count>0)
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Already Deleted');", true);
                    //    return;
                    //}
  
                    getConnection();
                    q = "update [tblOrder] set intIsDeleted=1, dtCancelledDate=GETDATE() Where nvrOrderID='" + strOrderId + "'";
                    cmd = new SqlCommand(q, myconnection);
                    cmd.ExecuteNonQuery();
                    //q = "SELECT  *   FROM [tblOrder] where intIsdeleted=0";
                    LoadOrders(strUserID);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Deleted successfully');", true);
                    ////grdvwMyOrder.Columns[7].Visible = true;
                    //GridViewRow row1 = grdProducts.Rows[index1];
                    ////if (String.IsNullOrEmpty(row1.Cells[1].Text.ToString()) == false && row1.Cells[1].Text.ToString().Trim() != "" && row1.Cells[1].Text.ToString().Trim() != "&nbsp;")
                    ////{
                    ////    InformatinBox_new("Confirmed order can not be deleted!");
                    ////}

                    ////String st = grdvwMyOrder.Rows[index1].Cells[3].Text;
                    ////row1.Cells[7].Visible = true;
                    //if (row1.Cells[8].Text.ToString().Trim() != "Order not confirmed")
                    //{
                    //    //row1.Cells[7].Visible= false;
                    //    //InformatinBox_new("Confirmed order can not be deleted!");

                    //}
                    //else
                    //{
                    //    //row1.Cells[7].Visible= false;
                    //    String q = "DELETE FROM [HAISIA].[dbo].[tblTempCart] WHERE [varTempCartID]='" + row1.Cells[2].Text.ToString().Trim() + "'";
                    //    SqlCommand cmd = new SqlCommand(q, myconnection);
                    //    new DThelper().executeSQLquery(cmd);
                    //    q = "DELETE FROM [HAISIA].[dbo].[tblTempCartHeader] WHERE [varTempCartID]='" + row1.Cells[2].Text.ToString().Trim() + "'";
                    //    cmd = new SqlCommand(q, myconnection);
                    //    new DThelper().executeSQLquery(cmd);
                    //    //InformatinBox_new("Successfully deleted");
                    //    //row1.Cells[7].Visible = false;
                    //    //LoadOrders();
                    //}
                    break;
                case "Edit_Me_Product":
                    dvDataEntry.Visible = true;
                    Session["OrderID"]=e.CommandArgument.ToString();
                    q = "Select * From [tblOrder]  Where nvrOrderID='" + Session["OrderID"].ToString() + "'";
                    cmd = new SqlCommand(q, myconnection);
                    DataTable dt = new OSCRP.DThelper().getSQLDT(cmd);
                    if (string.IsNullOrEmpty(dt.Rows[0]["dtDepartDate"].ToString()) == false)
                    {
                        DateTime d = Convert.ToDateTime(dt.Rows[0]["dtDepartDate"].ToString());
                        txtDepartureDate.Text = d.ToString("dd/MM/yyyy");
                    }
                    else
                        txtDepartureDate.Text = "";
                    if (string.IsNullOrEmpty(dt.Rows[0]["dtDeliveredDate"].ToString()) == false)
                    {
                        DateTime d = Convert.ToDateTime(dt.Rows[0]["dtDeliveredDate"].ToString());
                        txtDeliveredDate.Text = d.ToString("dd/MM/yyyy");
                    }
                    else
                        txtDeliveredDate.Text = "";
                    ////index1 = Convert.ToInt32(e.CommandArgument);
                    ////InformatinBox_new(index1.ToString());
                    //dvDataEntry.Visible = true;
                    //strProdNo = e.CommandArgument.ToString();
                    //Session["ProdNo"] = e.CommandArgument.ToString();
                    //if (myconnection.State == ConnectionState.Closed)
                    //    myconnection.Open();

                        //updateDDLbox();
                        //if (myconnection.State == ConnectionState.Closed)
                        //    myconnection.Open();
                        //q = "Select * From ProductMaster where company = 'RMR' and intIsDeleted=0 and nvrPrdNo='" + strProdNo + "'";
                        //cmd = new SqlCommand(q, myconnection);
                        //dt = new OSCRP.DThelper().getSQLDT(cmd);
                        //ddlProdName.Items.FindByValue(dt.Rows[0]["nvrPrdName"].ToString()).Selected = true;
                        ////ddlProdName.Text = dt.Rows[0]["nvrPrdName"].ToString();
                        //txtDescription.Text = dt.Rows[0]["Description"].ToString();
                        //txtPrice.Text = dt.Rows[0]["decPrice"].ToString();
                        //txtUOM.Text = dt.Rows[0]["nvrUOM"].ToString();
                        //txtUnit.Text = dt.Rows[0]["intUnit"].ToString();
                        //txtWSPrice.Text = dt.Rows[0]["decWSprice"].ToString();
                        //ddlTitle.Items.FindByValue(dt.Rows[0]["Title"].ToString()).Selected = true;
                        //ddlProdType.Items.FindByValue(dt.Rows[0]["nvrPrdType"].ToString()).Selected = true;
                        ////ddlTitle.Text = dt.Rows[0]["Title"].ToString();
                        ////ddlProdType.Text = dt.Rows[0]["nvrPrdType"].ToString();
                        //txtFile.Text = dt.Rows[0]["nvrPrdLocation"].ToString();
                        ////ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + strProdNo + "');", true);
                    break;
            }
        }
        protected void grdOrders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void grdOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdOrders.PageIndex = e.NewPageIndex;
            LoadOrders(strUserID);
        }
        protected void LoadOrders(string UserID)
        {
            getConnection();
            if (string.IsNullOrEmpty(UserID)==true)
            q = "SELECT  *   FROM [tblOrder] where  nvrOrderID in (select nvrOrderID from tblCartDetail)";
            else
                q = "SELECT  *   FROM [tblOrder] Where nvrOrderID in (select nvrOrderID from tblCartDetail) and UserID=" + UserID;
            cmd = new SqlCommand(q, myconnection);
            DataTable dt = new OSCRP.DThelper().getSQLDT(cmd);
            grdOrders.DataSource = dt;
            grdOrders.DataBind();
        }
        protected void grdOrders_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            //int rowIndex = grdOrders.EditIndex;
            //HiddenField hdnorder =(HiddenField)grdOrders.Rows[rowIndex].FindControl("hdnOrderID");
            DateTime d;
            getConnection();
            strOrderId = Session["OrderID"].ToString();
            if (string.IsNullOrEmpty(txtDepartureDate.Text)==false)
            {
                d = Convert.ToDateTime(txtDepartureDate.Text);
                q = "update [tblOrder] set dtDepartDate= convert(datetime,'" + d.ToString("MM/dd/yyyy") + "'),varStatus='Departed' Where nvrOrderID='" + strOrderId + "'";
                cmd = new SqlCommand(q, myconnection);
                cmd.ExecuteNonQuery();
            }
            if (string.IsNullOrEmpty(txtDeliveredDate.Text) == false)
            {
                d = Convert.ToDateTime(txtDeliveredDate.Text);
                q = "update [tblOrder] set dtDeliveredDate= convert(datetime,'" + d.ToString("MM/dd/yyyy") + "'),varStatus='Delivered'  Where nvrOrderID='" + strOrderId + "'";
                cmd = new SqlCommand(q, myconnection);
                cmd.ExecuteNonQuery();
            }
            LoadOrders(strUserID);
            txtDeliveredDate.Text = "";
            txtDepartureDate.Text = "";
            dvDataEntry.Visible = false;
        }
        protected void getConnection()
        {
            if (myconnection.State == ConnectionState.Closed)
                myconnection.Open();
        }
        protected void ImgCalender_Click(object sender, ImageClickEventArgs e)
        {
            //if (calDeparture.Visible == false)
            //    calDeparture.Visible = true;
            //else
            //    calDeparture.Visible = false;
        }

        protected void ImageCalendarDel_Click(object sender, ImageClickEventArgs e)
        {
            //if (DeliveredCalendar.Visible == false)
            //    DeliveredCalendar.Visible = true;
            //else
            //    DeliveredCalendar.Visible = false;
        }

        protected void ImgCalender_Click1(object sender, ImageClickEventArgs e)
        {

        }
        
        protected void DeliveredCalendar_SelectionChanged(object sender, EventArgs e)
        {
            string s = "";
            //s = DeliveredCalendar.SelectedDate.ToString();
            //txtDeliveredDate.Text = Convert.ToDateTime(s).ToString("d");
            //DeliveredCalendar.Visible = false;
        }
        protected void calDeparture_SelectionChanged(object sender, EventArgs e)
        {
            string s = "";
            //s = calDeparture.SelectedDate.ToString();
            //txtDepartureDate.Text = Convert.ToDateTime(s).ToString("d");
            //calDeparture.Visible = false;
        }

        protected void btnClose_Click(object sender, ImageClickEventArgs e)
        {
            txtDeliveredDate.Text = "";
            txtDepartureDate.Text = "";
            dvDataEntry.Visible = false;
        }
    }

}