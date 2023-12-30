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
    public partial class frmUsers : System.Web.UI.Page
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
                LoadUsers();

            }

        }
        protected void LoadUsers()
        {
            getConnection();
            q = "SELECT  *   FROM [tblUser]";
            q= "SELECT[UserId],[varFirstName],[nvrLastName],[nvrEmail],[txtAddress],";
            q = q + "[nvrPinCode],[nvrPhone],[nvrWhatsAPP],[nvrPassword],[Role]";
            q = q + ",convert(bit,intActive) AS intActive";
            q = q + ",convert(bit,intIsDeleted) AS intIsDeleted";
            q = q + " FROM [tblUser] where Role!='Admin'";
            cmd = new SqlCommand(q, myconnection);
            DataTable dt = new OSCRP.DThelper().getSQLDT(cmd);
            grdUsers.DataSource = dt;
            grdUsers.DataBind();
        }
        protected void getConnection()
        {
            if (myconnection.State == ConnectionState.Closed)
                myconnection.Open();
        }
        protected void grdUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                HiddenField hdnUserId = (HiddenField)e.Row.FindControl("hdnUserId");
    
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
                    e.Row.Cells[i].Attributes["onclick"] = "location.href='frmOrderMaintenance.aspx?UserId=" + DataBinder.Eval(e.Row.DataItem, "UserId") + "'";
                    e.Row.Cells[i].Attributes["style"] = "cursor:pointer";
                }
                e.Row.Cells[5].Attributes.Add("style", "word-break:break-all;word-wrap:break-word;width:100px");

            }
        }
        protected void imgUpdate_Click(object sender, ImageClickEventArgs e)
        {
            int act = 0;
            int del = 0;
            foreach(GridViewRow gr in grdUsers.Rows)
            {
                if (gr.RowType == DataControlRowType.DataRow)
                {
                    act = 0;
                    del = 0;
                    CheckBox cbxActive = (CheckBox)gr.FindControl("cbxActive");
                    CheckBox cbxDelete = (CheckBox)gr.FindControl("cbxDelete");
                    HiddenField hdnUserId = (HiddenField)gr.FindControl("hdnUserId");
                    if (cbxActive.Checked == true)
                        act = 1;
                    if (cbxDelete.Checked == true)
                        del = 1;
                    q = "update [tblUser] set intActive=" + act .ToString() + ",intIsDeleted=" + del.ToString() + " Where UserId = " + gr.Cells[1].Text;

                    getConnection();
                    cmd = new SqlCommand(q, myconnection);
                    cmd.ExecuteNonQuery();
                }
                
            }
            LoadUsers();
        }
            protected void grdUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void grdUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUsers.PageIndex = e.NewPageIndex;
            LoadUsers();
        }
        protected void grdUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}