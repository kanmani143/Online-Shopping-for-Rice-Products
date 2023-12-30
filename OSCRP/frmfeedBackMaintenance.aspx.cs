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
    public partial class frmfeedBackMaintenance : System.Web.UI.Page
    {
        public SqlConnection myconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OSCRP"].ConnectionString);
        public int index1 = 0;
        SqlCommand cmd;
        string q = "";
        DataTable dt;
        DataSet ds;

        string strUserID = "";
        string strFeedBackId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                LoadFeedBacks();

            }
        }
        protected void LoadFeedBacks()
        {
            getConnection();
           
            q = "SELECT  F.[FeedBackID],F.[UserID],F.[nvrSubject],F.[txtDescription],F.[nvrActionTaken]";
            q = q + ",F.[nvrStatus],F.[dtFeedBackDate],F.[dtActionDate],U.varFirstName + ' ' + U.nvrLastName UserName";
            q = q + " FROM [tblFeedBack] F Left outer join tblUser U on F.UserID = U.UserId";
            q = q + " Where F.intIsDeleted is null or F.intIsDeleted=0";
            cmd = new SqlCommand(q, myconnection);
            DataTable dt = new OSCRP.DThelper().getSQLDT(cmd);
            grdFeedbacks.DataSource = dt;
            grdFeedbacks.DataBind();
        }
        protected void getConnection()
        {
            if (myconnection.State == ConnectionState.Closed)
                myconnection.Open();
        }


        protected void grdFeedbacks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
     
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
                //for (int i = 0; i < e.Row.Cells.Count - 3; i++)
                //{
                //    e.Row.Cells[i].Attributes["onclick"] = "location.href='frmPlaceOrder.aspx?OrderId=" + DataBinder.Eval(e.Row.DataItem, "nvrOrderID") + "'";
                //    e.Row.Cells[i].Attributes["style"] = "cursor:pointer";
                //}
                //LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                //lnkDelete.Attributes.Add("onmouseout", "javascript:this.style.color='blue';");
                //lnkDelete.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';");
                LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                lnkEdit.Attributes.Add("onmouseout", "javascript:this.style.color='blue';");
                lnkEdit.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';");

            }
        }
        protected void ClickButton(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete_Me_Feedback":

                    strFeedBackId = e.CommandArgument.ToString();


                    getConnection();
                    q = "update [tblFeedBack]  set intIsDeleted=1, dtCancelledDate=GETDATE() Where FeedBackID=" + strFeedBackId;
                    cmd = new SqlCommand(q, myconnection);
                    cmd.ExecuteNonQuery();
                    //q = "SELECT  *   FROM [tblOrder] where intIsdeleted=0";
                    LoadFeedBacks();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Deleted successfully');", true);

                    break;
                case "Edit_Me_Feedback":
                    lblError.Text = "";
                    dvDataEntry.Visible = true;
                    strFeedBackId = e.CommandArgument.ToString();
                    Session["FeedBackId"] = strFeedBackId;

                    q = "Select nvrActionTaken,dtActionDate From [tblFeedBack]  Where FeedBackID=" + strFeedBackId;
                    cmd = new SqlCommand(q, myconnection);
                    DataTable dt = new OSCRP.DThelper().getSQLDT(cmd);
                    
                    if (string.IsNullOrEmpty(dt.Rows[0]["nvrActionTaken"].ToString()) == false)
                    {
                        txtActionTaken.Text = dt.Rows[0]["nvrActionTaken"].ToString();
                        
                    }
                    else
                        txtActionTaken.Text = "";
                    break;
            }
        }
        protected void grdFeedbacks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void grdFeedbacks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdFeedbacks.PageIndex = e.NewPageIndex;
            LoadFeedBacks();
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {

            DateTime d;
            getConnection();
            strFeedBackId = Session["FeedBackId"].ToString();
            if (string.IsNullOrEmpty(txtActionTaken.Text) == false)
            {
                
                q = "update [tblFeedBack] set dtActionDate= GETDATE(),nvrActionTaken=@Action,nvrStatus='Action Taken' Where FeedBackID=" + strFeedBackId;
                cmd = new SqlCommand(q, myconnection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@Action", SqlDbType.NVarChar,4000).Value = txtActionTaken.Text;

                cmd.ExecuteNonQuery();
            }

            LoadFeedBacks();
            
            txtActionTaken.Text = "";
            dvDataEntry.Visible = false;
        }

        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            txtActionTaken.Text = "";
            dvDataEntry.Visible = false;
        }
    }
}