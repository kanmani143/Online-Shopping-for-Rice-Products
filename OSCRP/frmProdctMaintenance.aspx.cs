using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace OSCRP
{
    public partial class frmProdctMaintenance : System.Web.UI.Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack==false)
            {
                //ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(this.imgflUpload);
                if (myconnection.State == ConnectionState.Closed)
                    myconnection.Open();
                q = "SELECT  [nvrPrdNo],[nvrPrdName],[nvrPrdLocation],[decPrice],[nvrUOM],[dtMFdate],[dtExpDate]";
                q = q + ",[nvrCurr],[nvrPrdType],convert(varchar,[intUnit]) + ' Kg' as intUnit,[Company],[decWSprice],[Description],[Title]";
                q = q + " FROM[OSCRP].[dbo].[ProductMaster] where company = 'RMR' and intIsDeleted=0 order by nvrPrdName,decPrice";
                cmd = new SqlCommand(q, myconnection);
                DataTable dt = new OSCRP.DThelper().getSQLDT(cmd);
               
                grdProducts.DataSource = dt;
                grdProducts.DataBind();


                //ImgProdNameAdd.Attributes.Add("onclick", "javascript:Popup1('Product Name');return false;");
                //ImgProdTypeAdd.Attributes.Add("onclick", "javascript:Popup1('Product Type');return false;");
                //ImgTitleAdd.Attributes.Add("onclick", "javascript:Popup1('Product Title');return false;");
            }
        }

        protected void grdProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                 LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                lnkDelete.Attributes.Add("onmouseout ", "javascript:this.style.color='blue';");
                lnkDelete.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';");
                LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                lnkEdit.Attributes.Add("onmouseout ", "javascript:this.style.color='blue';");
                lnkEdit.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';");
 
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

                HiddenField hdnProdLocation = (HiddenField)e.Row.FindControl("hdnProdLocation");
                for (int i=0;i<e.Row.Cells.Count - 2;i++)
                {
                    e.Row.Cells[i].Attributes.Add("onclick", "javascript:Popup('" + hdnProdLocation.Value.ToString() + "');return false;");
                    e.Row.Cells[i].Attributes["style"] = "cursor:pointer";
                }

            }

        }

        protected void ClickButton(object sender, CommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Delete_Me_Product":
                    //index1 = Convert.ToInt32(e.CommandArgument);
                    //InformatinBox_new(index1.ToString());
                    strProdNo = e.CommandArgument.ToString();
                    if (myconnection.State == ConnectionState.Closed)
                        myconnection.Open();
                    q = "update [ProductMaster] set intIsDeleted=1 Where nvrPrdNo='" + strProdNo + "'";
                    cmd = new SqlCommand(q, myconnection);
                    cmd.ExecuteNonQuery();
                    q = "SELECT  [nvrPrdNo],[nvrPrdName],[nvrPrdLocation],[decPrice],[nvrUOM],[dtMFdate],[dtExpDate]";
                    q = q + ",[nvrCurr],[nvrPrdType],convert(varchar,[intUnit]) + ' Kg' as intUnit,[Company],[decWSprice],[Description],[Title]";
                    q = q + " FROM[OSCRP].[dbo].[ProductMaster] where company = 'RMR' and intIsDeleted=0 order by nvrPrdName,decPrice";
                    cmd = new SqlCommand(q, myconnection);
                    dt = new OSCRP.DThelper().getSQLDT(cmd);
                    grdProducts.DataSource = dt;
                    grdProducts.DataBind();
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
                    //index1 = Convert.ToInt32(e.CommandArgument);
                    //InformatinBox_new(index1.ToString());
                    dvDataEntry.Visible = true;
                    txtFile.Text = "";
                    strProdNo = e.CommandArgument.ToString();
                    Session["ProdNo"] = e.CommandArgument.ToString();
                    if (myconnection.State == ConnectionState.Closed)
                        myconnection.Open();
                   
                    updateDDLbox();
                    if (myconnection.State == ConnectionState.Closed)
                        myconnection.Open();
                    q = "Select * From ProductMaster where company = 'RMR' and intIsDeleted=0 and nvrPrdNo='" + strProdNo + "'";
                    cmd = new SqlCommand(q, myconnection);
                     dt = new OSCRP.DThelper().getSQLDT(cmd);
                    ddlProdName.Items.FindByValue(dt.Rows[0]["nvrPrdName"].ToString()).Selected = true;
                    //ddlProdName.Text = dt.Rows[0]["nvrPrdName"].ToString();
                    txtDescription.Text = dt.Rows[0]["Description"].ToString();
                    txtPrice.Text = dt.Rows[0]["decPrice"].ToString();
                    txtUOM.Text = dt.Rows[0]["nvrUOM"].ToString();
                    txtUnit.Text = dt.Rows[0]["intUnit"].ToString();
                    txtWSPrice.Text = dt.Rows[0]["decWSprice"].ToString();
                    ddlTitle.Items.FindByValue(dt.Rows[0]["Title"].ToString()).Selected = true;
                    ddlProdType.Items.FindByValue(dt.Rows[0]["nvrPrdType"].ToString()).Selected = true;
                    //ddlTitle.Text = dt.Rows[0]["Title"].ToString();
                    //ddlProdType.Text = dt.Rows[0]["nvrPrdType"].ToString();
                    txtFile.Text = dt.Rows[0]["nvrPrdLocation"].ToString();
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + strProdNo + "');", true);
                    break;
            }
        }

        protected void grdProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void InformatinBox_new(string strMsg)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string a;
            try
            {
                strMsg = strMsg.Replace( "'", @" \'");
                strMsg = strMsg.Replace( ".", "");
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(strMsg);
                sb.Append("')};");
                sb.Append("</script>");
                Response.Write(sb.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", sb.ToString(), true);
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
            catch (Exception ex)
            {
                a = ex.Message;
            }
        }
        protected void grdProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProducts.PageIndex = e.NewPageIndex;
            if (myconnection.State == ConnectionState.Closed)
                myconnection.Open();
            q = "SELECT  [nvrPrdNo],[nvrPrdName],[nvrPrdLocation],[decPrice],[nvrUOM],[dtMFdate],[dtExpDate]";
            q = q + ",[nvrCurr],[nvrPrdType],convert(varchar,[intUnit]) + ' Kg' as intUnit,[Company],[decWSprice],[Description],[Title]";
            q = q + " FROM[OSCRP].[dbo].[ProductMaster] where company = 'RMR' and intIsDeleted=0 order by nvrPrdName,decPrice";
            cmd = new SqlCommand(q, myconnection);
            DataTable dt = new OSCRP.DThelper().getSQLDT(cmd);
            grdProducts.DataSource = dt;
            grdProducts.DataBind();
           
        }

        protected void grdProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            Company = "RMR";
           
            try
            {
                strProdNo = Session["ProdNo"].ToString();
                if (myconnection.State == ConnectionState.Closed)
                    myconnection.Open();
                txtFile.Text = txtFile.Text.Replace("~/Images/", "");
                if (string.IsNullOrEmpty(strProdNo) == true)
                {
                    q = "select max(convert(numeric,replace(nvrPrdNo,'" + Company + "',''))) from ProductMaster where Company='" + Company + "'";
                    cmd = new SqlCommand(q, myconnection);
                    DataTable dt1 = new OSCRP.DThelper().getSQLDT(cmd);
                    if (dt1 != null && Convert.ToInt32(dt1.Rows[0][0].ToString()) > 0)
                        intPrdNo = Convert.ToInt32(dt1.Rows[0][0].ToString()) + 1;
                    else
                        intPrdNo = 1;
                    
                    q = "INSERT INTO [dbo].[ProductMaster] ";
                    q = q + " ([nvrPrdNo],[nvrPrdName],[nvrPrdLocation],[decPrice],[nvrUOM],[dtMFdate],[dtExpDate],[nvrCurr]";
                    q = q + " ,[nvrPrdType],[intUnit],[Company],[decWSprice],[Description],[Title],[intIsDeleted])";
                    q = q + " VALUES('" + Company.Trim() + intPrdNo.ToString().Trim() + "',@prdName,'~/Images/";
                    q = q + txtFile.Text + "'," + txtPrice.Text + ",'";
                    q = q + txtUOM.Text + "',GETDATE(),GETDATE()+365,'RS','" + ddlProdType.Text + "',";
                    q = q + txtUnit.Text + ",'" + Company.Trim() + "',";
                    q = q + txtWSPrice.Text + ",@Desc,'" + ddlTitle.Text + "',0)";
         
                   
                }
                else
                {
                    q = "UPDATE [dbo].[ProductMaster] ";
                    q = q + "SET [nvrPrdName] = @prdName";
                    q = q + ",[nvrPrdLocation] = '~/Images/" + txtFile.Text + "',[decPrice] = " + txtPrice.Text;
                    q = q + ",[nvrUOM] = '"+ txtUOM.Text + "',[nvrPrdType]='" + ddlProdType.Text + "'";
                    q = q + ",[intUnit] = " + txtUnit.Text + ",[decWSprice] = " + txtWSPrice.Text;
                    q = q + ",[Description] = @Desc,[Title] = '" + ddlTitle.Text + "'";
                    q = q + " WHERE [nvrPrdNo] = '" + strProdNo + "'";
                }
                if (myconnection.State == ConnectionState.Closed)
                    myconnection.Open();
                cmd = new SqlCommand(q, myconnection);
                cmd.Parameters.AddWithValue("@prdName", ddlProdName.Text);
                cmd.Parameters.AddWithValue("@Desc", txtDescription.Text);
                cmd.ExecuteNonQuery();
                string directoryPath = Server.MapPath(".") + "\\Images\\" + txtFile.Text;
                if (File.Exists(directoryPath)==false)
                imgflUpload.PostedFile.SaveAs(directoryPath);
                if (myconnection.State == ConnectionState.Closed)
                    myconnection.Open();
                q = "SELECT  [nvrPrdNo],[nvrPrdName],[nvrPrdLocation],[decPrice],[nvrUOM],[dtMFdate],[dtExpDate]";
                q = q + ",[nvrCurr],[nvrPrdType],convert(varchar,[intUnit]) + ' Kg' as intUnit,[Company],[decWSprice],[Description],[Title]";
                q = q + " FROM[OSCRP].[dbo].[ProductMaster] where company = 'RMR' and intIsDeleted=0 order by nvrPrdName,decPrice";
                cmd = new SqlCommand(q, myconnection);
                DataTable dt = new OSCRP.DThelper().getSQLDT(cmd);
                grdProducts.DataSource = dt;
                grdProducts.DataBind();
                //imgflUpload.
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ex.Message, true);
            }
            dvDataEntry.Visible = false;
        }
        protected void updateDDLbox ()
        {
            ddlTitle.Items.Clear();
            ddlTitle.Items.Add(new ListItem(" ", " "));
            q = "Select Distinct Title From ProductMaster where company = 'RMR' and intIsDeleted=0 Order by Title";
            cmd = new SqlCommand(q, myconnection);
            dt = new OSCRP.DThelper().getSQLDT(cmd);
            foreach (DataRow dr in dt.Rows)
            {
                ddlTitle.Items.Add(new ListItem(dr[0].ToString(), dr[0].ToString()));
            }
            if (myconnection.State == ConnectionState.Closed)
                myconnection.Open();
            ddlProdType.Items.Clear();
            ddlProdType.Items.Add(new ListItem(" ", " "));
            q = "Select Distinct nvrPrdType From ProductMaster where company = 'RMR' and intIsDeleted=0 Order by nvrPrdType ";
            cmd = new SqlCommand(q, myconnection);
            dt = new OSCRP.DThelper().getSQLDT(cmd);
            foreach (DataRow dr in dt.Rows)
            {
                ddlProdType.Items.Add(new ListItem(dr[0].ToString(), dr[0].ToString()));
            }
            if (myconnection.State == ConnectionState.Closed)
                myconnection.Open();
            ddlProdName.Items.Clear();
            ddlProdName.Items.Add(new ListItem(" ", " "));
            q = "select distinct nvrPrdName from ProductMaster where Company='" + Company + "' order by nvrPrdName";
            cmd = new SqlCommand(q, myconnection);
            dt = new OSCRP.DThelper().getSQLDT(cmd);
            foreach (DataRow dr in dt.Rows)
            {
                ddlProdName.Items.Add(new ListItem(dr[0].ToString(), dr[0].ToString()));
            }
            
        }
        protected void imgAdd_Click(object sender, ImageClickEventArgs e)
        {
            strProdNo = "";
            dvDataEntry.Visible = true;
            //txtProdName.Text = "";
            txtPrice.Text = "";
            txtUnit.Text = "";
            txtUOM.Text = "";
            txtWSPrice.Text = "";
            txtDescription.Text = "";
            updateDDLbox();
            Session["ProdNo"] = "";
            txtFile.Text = "";
        }

        protected void ImgProdNameAdd_Click(object sender, ImageClickEventArgs e)
        {
            //Session["PlaceHolder"] = "";
            //string strVal = addDdlValue("Product Name");
            ////while (string.IsNullOrEmpty(Session["PlaceHolder"].ToString()))
            ////{
            ////    // code block to be executed
            ////}
            ////strVal = Session["PlaceHolder"].ToString();
            //if (string.IsNullOrEmpty(strVal)==false)
            //ddlProdName.Items.Add(new ListItem(strVal, strVal));
            ImgProdNameAdd.Visible = false;
            ddlProdName.Visible = false;
            ImgProdNameSave.Visible = true;
            txtProdName.Visible = true;
            btnSave.Enabled = false;
            txtProdName.Focus();
        }

        protected void ImgProdTypeAdd_Click(object sender, ImageClickEventArgs e)
        {
            ImgProdTypeAdd.Visible = false;
            ddlProdType.Visible = false;
            ImgProdTypeSave.Visible = true;
            txtProdType.Visible = true;
            btnSave.Enabled = false;
            txtProdType.Focus();
        }

        protected void ImgTitleAdd_Click(object sender, ImageClickEventArgs e)
        {
            ImgTitleAdd.Visible = false;
            ddlTitle.Visible = false;
            ImgTitleSave.Visible = true;
            txtTitle.Visible = true;
            btnSave.Enabled = false;
            txtTitle.Focus();
        }

        protected string addDdlValue(String Desc)
        {
            
            Response.Redirect("frmAddDDLValue.aspx?lblname=" + Desc);

            //string url = "frmAddDDLValue.aspx?lblname=" + Desc;
            //string s = "window.open('" + url + "', 'popup_window', 'width=500,height=100,left=100,top=100,resizable=yes');";
            //ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
            while (string.IsNullOrEmpty(Session["PlaceHolder"].ToString()))
            {
                // code block to be executed
            }

            return Session["PlaceHolder"].ToString();
        }

        protected void ImgProdNameSave_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //ddlProdName.Visible = true;
                if (string.IsNullOrEmpty(txtProdName.Text) == false)
                {
                    ddlProdName.Items.Add(new ListItem(txtProdName.Text, txtProdName.Text));
                    //ddlProdName.Items.FindByValue(txtProdName.Text).Selected = true;
                }
                ddlProdName.Visible = true;
                ImgProdNameAdd.Visible = true;
                btnSave.Enabled = true;
                ImgProdNameSave.Visible = false;
                txtProdName.Text = "";
                txtProdName.Visible = false;
            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "script", ex.Message, true);
            }
        }

        protected void ImgProdTypeSave_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //ddlProdName.Visible = true;
                if (string.IsNullOrEmpty(txtProdType.Text) == false)
                {
                    ddlProdType.Items.Add(new ListItem(txtProdType.Text, txtProdType.Text));
                    //ddlProdName.Items.FindByValue(txtProdName.Text).Selected = true;
                }
                ddlProdType.Visible = true;
                ImgProdTypeAdd.Visible = true;
                btnSave.Enabled = true;
                ImgProdTypeSave.Visible = false;
                txtProdType.Text = "";
                txtProdType.Visible = false;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "script", ex.Message, true);
            }
        }

        protected void ImgTitleSave_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //ddlProdName.Visible = true;
                if (string.IsNullOrEmpty(txtTitle.Text) == false)
                {
                    ddlTitle.Items.Add(new ListItem(txtTitle.Text, txtTitle.Text));
                    //ddlProdName.Items.FindByValue(txtProdName.Text).Selected = true;
                }
                ddlTitle.Visible = true;
                ImgTitleAdd.Visible = true;
                btnSave.Enabled = true;
                ImgTitleSave.Visible = false;
                txtTitle.Text = "";
                txtTitle.Visible = false;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "script", ex.Message, true);
            }
        }

        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            strProdNo = "";
            dvDataEntry.Visible = false;
            //txtProdName.Text = "";
            txtPrice.Text = "";
            txtUnit.Text = "";
            txtUOM.Text = "";
            txtWSPrice.Text = "";
            txtDescription.Text = "";
            updateDDLbox();
            Session["ProdNo"] = "";
            txtFile.Text = "";
        }
    }
}