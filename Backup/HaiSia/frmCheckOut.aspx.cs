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
    public partial class frmCheckOut : System.Web.UI.Page
    {
        public SqlConnection myconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["HAISIA"].ConnectionString);
        public int index1 = 0;
        public String wp = "";
        public string[] arr4 = new string[7];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (String.IsNullOrEmpty(Session["UserID"].ToString()) == false)
                {
                    LoadImage();
                    ViewState["ClosingDay"] = "";
                    ViewState["CollectionDate"] = "";
                    ViewState["ClosingTime"] = "";
                    ViewState["DisplayDayTime"] = "";
                    lnkLogout.Text = "Logout";
                    imgConfirmOrder.Enabled = true;
                    //imgCancelOrder.Enabled = true;
                    lnkMyCart.Enabled = true;
                    imgConfirmOrder.Visible = true;
                    imgConfirmOrder.ToolTip = "CLICK HERE TO ORDER NOW!";
                    grdvwMyCart.Columns[7].Visible = true;
                    Session["CartOrderID"] = Request.QueryString["OrderID"];
                    Session["varTempCartID"] = Request.QueryString["OrderRef"];
                    String strFS = getUserFontSize("frmCart.aspx");
                    dpdItemList.Items.FindByValue(strFS.Trim()).Selected = true;
                    setFontSize();
                    if (String.IsNullOrEmpty(Session["CartOrderID"].ToString()) == false)
                    {
                        if (Session["CartOrderID"].ToString().Trim() != "")
                        {

                            getReference();
                        }
                        else
                        {
                            lblOrderID.Visible = false;
                        }
                    }
                    else
                    {
                        lblOrderID.Visible = false;
                    }



                    //if (string.IsNullOrEmpty(lnkConfirmOrder.Attributes["OnClick"]))
                    //{
                    //    lnkConfirmOrder.Attributes["OnClick"] = "return false;";
                    //    lnkConfirmOrder.BackColor = System.Drawing.Color.Gray;
                    //}
                    //else
                    //{
                    //    lnkConfirmOrder.Attributes.Remove("OnClick");
                    //    lnkConfirmOrder.BackColor = System.Drawing.Color.Empty;
                    //}

                    //if (string.IsNullOrEmpty(lnkCancel.Attributes["OnClick"]))
                    //{
                    //    lnkCancel.Attributes["OnClick"] = "return false;";
                    //    lnkCancel.BackColor = System.Drawing.Color.Gray;
                    //}
                    //else
                    //{
                    //    lnkCancel.Attributes.Remove("OnClick");
                    //    lnkCancel.BackColor = System.Drawing.Color.Empty;
                    //}
                    //if (string.IsNullOrEmpty(lnkMyCart.Attributes["OnClick"]))
                    //{
                    //    lnkMyCart.Attributes["OnClick"] = "return false;";
                    //    lnkMyCart.BackColor = System.Drawing.Color.Gray;
                    //}
                    //else
                    //{
                    //    lnkMyCart.Attributes.Remove("OnClick");
                    //    lnkMyCart.BackColor = System.Drawing.Color.Empty;
                    //}

                    StringBuilder builder = new StringBuilder();
                    builder.Append("Welcome, ");
                    builder.Append("<span style=\"color:Red;\">");
                    builder.Append(Session["UserName"].ToString().Trim());
                    builder.Append("</span>");
                    lblCustomer.Text = builder.ToString();
                    builder = new StringBuilder();
                    builder.Append("Cart Ref No: ");
                    builder.Append("<span style=\"color:Red;\">");
                    builder.Append(Session["varTempCartID"].ToString().Trim());
                    builder.Append("</span>");
                    lblCartRefNo.Text = builder.ToString();
                    builder = new StringBuilder();
                    //String wp = Convert.ToChar(160).ToString() + Convert.ToChar(160).ToString() + Convert.ToChar(160).ToString() + 
                    //    Convert.ToChar(160).ToString() + Convert.ToChar(160).ToString();
                    wp = ":";
                    wp = wp.PadLeft(6, Convert.ToChar(160));
                    builder.Append("Order ID" + wp + " ");
                    builder.Append("<span style=\"color:Red;\">");
                    builder.Append(String.IsNullOrEmpty(Session["CartOrderID"].ToString()) == true ? "" : Session["CartOrderID"].ToString().Trim());
                    builder.Append("</span>");
                    lblOrderID.Text = builder.ToString();

                    builder = new StringBuilder();
                    builder.Append("Order Date : ");
                    builder.Append("<span style=\"color:Red;\">");
                    builder.Append(String.Format("{0:dd-MMM-yyyy}", DateTime.Now));
                    builder.Append("</span>");
                    lblOderDate.Text = builder.ToString();
                    //lblCartRefNo.Text =  "Order ID  : " + Session["varTempCartID"].ToString().Trim();
                    //lblOderDate.Text = "Order Date: " + String.Format("{0:dd MMM yyyy}", DateTime.Now);

                    LoadItems();
                    getCCDT();
                    setCCDT();
                }
                else
                {
                    Session["UserID"] = "";
                    lnkLogout.Text = "Login";
                    Response.Redirect("frmLogin.aspx");
                }
            }

        }

        private String getUserFontSize(String strFormName)
        {
            String strRetVal = "XX-Large";
            String q = "SELECT [varFontSize] FROM [HAISIA].[dbo].[tblUserFontSize] WHERE [GMCUST]=";
            q = q + "'" + Session["UserID"].ToString().Trim() + "' AND [varFormName]='" + strFormName.Trim() + "'";
            SqlCommand cmd = new SqlCommand(q, myconnection);
            DataTable dt = new DThelper().getSQLDT(cmd);
            if (dt.Rows.Count > 0) strRetVal = dt.Rows[0]["varFontSize"].ToString().Trim();
            return strRetVal;
        }
        private void LoadImage()
        {
            arr4 = new string[7];
            arr4[0] = "~/Images/NoImage.jpg";
            arr4[1] = "~/Images/blueSeaCrab1.jpeg";
            arr4[2] = "~/Images/rockCrab.jpeg";
            arr4[3] = "~/Images/CoralCrab.jpeg";
            arr4[4] = "~/Images/AsianShoreCrab.jpeg";
            arr4[5] = "~/Images/MangroveCrab.jpeg";
            arr4[6] = "~/Images/RiverCrab.jpeg";
        }
        private void getReference()
        {
            String q = "";
            SqlCommand cmd = null;
            try
            {

                q = "SELECT *  from [HAISIA].[dbo].[tblCartHeader] WHERE [varOrderID]='" + Session["CartOrderID"].ToString() + "'";

                cmd = new SqlCommand(q, myconnection);
                DataTable dt = new DThelper().getSQLDT(cmd);
                if (dt.Rows.Count > 0)
                {
                    Session["varTempCartID"] = dt.Rows[0]["varTempCartID"].ToString().Trim();
                }

                imgConfirmOrder.Enabled = false;
                //imgCancelOrder.Enabled = false;
                //lnkMyCart.Enabled = false;
                imgConfirmOrder.ForeColor = System.Drawing.Color.LightSlateGray;
                //imgCancelOrder.ForeColor = System.Drawing.Color.LightSlateGray;
                //lnkMyCart.ForeColor = System.Drawing.Color.LightSlateGray;
                imgConfirmOrder.Font.Underline = true;
                //imgCancelOrder.Font.Underline = true;
                imgConfirmOrder.ToolTip = "CONFIRMED ORDER CAN NOT BE DELETED!";
                imgConfirmOrder.Visible = false;
                grdvwMyCart.Columns[7].Visible = false;
                //lnkMyCart.Font.Underline = true;
                q = "Delete from [HAISIA].[dbo].[tblTempCart] Where varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "'";
                cmd = new SqlCommand(q, myconnection);
                new DThelper().executeSQLquery(cmd);
                q = "Delete from [HAISIA].[dbo].[tblTempCartHeader] Where varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "'";
                cmd = new SqlCommand(q, myconnection);
                new DThelper().executeSQLquery(cmd);
                q = " Insert into [HAISIA].[dbo].[tblTempCart] (varTempCartID,DMITNO,AMLIST,intQty,dblTotPrice) ";
                q = q + " SELECT '" + Session["varTempCartID"].ToString().Trim() + "' As varTempCartID,DMITNO,AMLIST,intQty,dblTotPrice";
                q = q + " FROM [HAISIA].[dbo].[tblCartDetail] ";
                q = q + " Where varOrderID='" + Session["CartOrderID"].ToString() + "'";
                cmd = new SqlCommand(q, myconnection);
                new DThelper().executeSQLquery(cmd);
                q = "INSERT INTO [HAISIA].[dbo].[tblTempCartHeader] ([varTempCartID],[ZMCOMP],[GMCUST],[GMCDIS],[dtCreated]) ";
                q = q + " SELECT [varTempCartID] ,[ZMCOMP] ,[GMCUST] ,[GMCDIS] ,[dtCreated] ";
                q = q + " FROM [HAISIA].[dbo].[tblCartHeader] WHERE [varOrderID]='" + Session["CartOrderID"].ToString() + "'";

            }

            catch (Exception ex)
            {
                InformatinBox_new(ex.Message);
            }

        }
        private void LoadItems()
        {
            //String q = "SELECT intQty FROM [HAISIA].[dbo].[tblTempCart] WHERE varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "' ";
            //q = q + " AND DMITNO='" + ItCd.Trim() + "'";
            String q = "";
            SqlCommand cmd = null;
            try
            {


                q = "SELECT A.varTempCartID,A.DMITNO,A.AMLIST,A.intQty,A.dblTotPrice,B.AMCURR,B.DMPUOM,C.DMITDS ";
                q = q + " FROM [HAISIA].[dbo].[tblTempCart] A, [HAISIA].[dbo].[OEM05] B , [HAISIA].[dbo].[INM01] C WHERE A.DMITNO=B.DMITNO AND B.GMCDIS='" + Session["PricingCode"].ToString().Trim() + "'";
                q = q + " AND A.DMITNO=C.DMITNO AND A.varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "'";
                cmd = new SqlCommand(q, myconnection);
                DataTable dt = new DThelper().getSQLDT(cmd);
                object sumQty;
                object sumTotP;
                if (dt.Rows.Count > 0)
                {
                    sumQty = dt.Compute("Sum(intQty)", "");
                    sumTotP = dt.Compute("Sum(dblTotPrice)", "");
                }
                else
                {
                    sumQty = 0;
                    sumTotP = 0;
                }



                StringBuilder builder = new StringBuilder();
                builder.Append("Total Items: ");
                builder.Append("<span style=\"color:Red;\">");
                builder.Append(String.Format("{0:0}", dt.Rows.Count.ToString().Trim()));
                builder.Append("</span>");
                lblTotItem.Text = builder.ToString();
                builder = new StringBuilder();

                wp = ":";
                wp = wp.PadLeft(4, Convert.ToChar(160));
                builder.Append("Total Qty" + wp + " ");
                //builder.Append("Total Qty: ");
                builder.Append("<span style=\"color:Red;\">");
                builder.Append(String.Format("{0:0}", sumQty));
                builder.Append("</span>");
                lblTotQty.Text = builder.ToString();
                lblTotPrice.Text = String.Format("{0:0.00}", sumTotP);
                lblTotPrice.Text = "$" + lblTotPrice.Text.Substring(0, lblTotPrice.Text.ToString().IndexOf(".") + 3);
                builder = new StringBuilder();

                builder.Append("Total Price : ");
                builder.Append("<span style=\"color:Red;\">");
                builder.Append(lblTotPrice.Text.Trim());
                builder.Append("</span>");
                lblTotPrice.Text = builder.ToString();
                //lblTotItem.Text = ": " + String.Format("{0:0}", dt.Rows.Count.ToString().Trim());
                //lblTotQty.Text = ": " + String.Format("{0:0}", sumQty);
                //lblTotPrice.Text = String.Format("{0:0.00}", sumTotP);
                //lblTotPrice.Text = "$" + lblTotPrice.Text.Substring(0, lblTotPrice.Text.ToString().IndexOf(".") + 3);

                DataRow dr = dt.NewRow();
                dr[0] = Session["varTempCartID"].ToString().Trim();
                dr[1] = DBNull.Value;
                dr[2] = DBNull.Value;
                dr[3] = int.Parse(String.Format("{0:0}", sumQty));
                dr[4] = double.Parse(String.Format("{0:0.00}", sumTotP));
                dr[5] = DBNull.Value;
                dr[6] = DBNull.Value;
                dr[7] = "TOTAL";
                dt.Rows.Add(dr);
                grdvwMyCart.DataSource = dt;
                grdvwMyCart.DataBind();
            }
            catch (Exception ex)
            {
                InformatinBox_new(ex.Message);
            }
        }
        protected void grdvwMyCart_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
        }
        protected void grdvwMyCart_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image Image1 = (Image)e.Row.FindControl("Image1");
                Label lblitemcode = (Label)e.Row.FindControl("lblitemcode");
                int Sno = e.Row.RowIndex + 1;
                int m = (Sno % 7);
                if (String.IsNullOrEmpty(lblitemcode.Text.ToString()) == false && lblitemcode.Text.Trim() != "")
                {
                    String q = "SELECT  [DMITNO],[DMITNOImageLocation] FROM [HAISIA].[dbo].[tblItmImgLocation] where DMITNO='" + lblitemcode.Text.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(q, myconnection);
                    DataTable dt = new DThelper().getSQLDT(cmd);
                    if (dt.Rows.Count > 0)
                    {
                        Image1.ImageUrl = dt.Rows[0]["DMITNOImageLocation"].ToString().Trim();

                    }
                    else
                    {
                        Image1.ImageUrl = "~/Images/NoImage.jpg";
                        //Image1.ImageUrl = arr4[m].ToString().Trim();

                    }
                }
                else
                {
                    Image1.ImageUrl = arr4[m].ToString().Trim();
                }

                e.Row.Cells[1].Attributes.Add("onmouseout", "javascript:this.style.color='blue';;");
                e.Row.Cells[1].Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';");
                lblitemcode.Attributes.Add("onmouseout", "javascript:this.style.color='blue';;");
                lblitemcode.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';");
                ////e.Row.Cells[1].Attributes.Add("onclick", "javascript:window.open('" + Image1.ImageUrl.ToString().Trim().Substring(2) + "','_newtab');");
                ////e.Row.Cells[1].Attributes.Add("onclick", "javascript:window.open('" + Image1.ImageUrl.ToString().Trim().Substring(2) + "');return false;");
                //e.Row.Cells[1].Attributes.Add("onclick", "javascript:Popup('" + Image1.ImageUrl.ToString().Trim().Substring(2) + "');return false;");
                e.Row.Cells[1].Attributes.Add("onclick", "javascript:Popup('" + Image1.ImageUrl.ToString().Trim() + "');return false;");
                if (e.Row.Cells[2].Text.Trim() == "TOTAL")
                {
                    e.Row.Cells[0].Text = "";
                    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Black;
                    e.Row.Font.Bold = true;
                    e.Row.ForeColor = System.Drawing.Color.Black;
                    CheckBox chb = (CheckBox)e.Row.FindControl("chb1");
                    chb.Visible = false;
                    Image1.Visible = false;
                    //e.Row.Cells[1].Visible = false; 
                    //e.Row.BackColor = System.Drawing.Color.DarkGoldenrod;
                }
                //String q = "SELECT [nvarNameSubmittedBy] ,[nvarStatusDescription]  FROM [SUPPLIERPORTALHOST].[dbo].[tblPpcProcessLog] WHERE Sno=" + e.Row.Cells[0].Text.Trim();
                //SqlCommand cmd = new SqlCommand(q, myconnection);
                //DataTable dt = new DBhelper().getSQLDT(cmd);
                //if (dt.Rows.Count > 0)
                //{
                //    e.Row.Cells[1].ToolTip = dt.Rows[0]["nvarNameSubmittedBy"].ToString().Trim();
                //    e.Row.Cells[5].ToolTip = dt.Rows[0]["nvarStatusDescription"].ToString().Trim();
                //}
            }
            else
            {
                LoadImage();
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

        protected void btnBackToOrder_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DisplayItems.aspx");
        }

        protected void BtnLogout_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnMyOrder_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgbtnCancelOrder_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgbtnConfirmOrder_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void lnkMyCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmMyCart.aspx");
        }


        protected void lnkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmHome.aspx");
        }
        protected void lnkContactUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactUs.aspx");
        }

        protected void lnkConfirmOrder_Click(object sender, EventArgs e)
        {
            ConfirmOrder();

        }

        private void ConfirmOrder()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HAISIA"].ConnectionString))
            {
                String strSql = "";
                String strSeqUpdate = "";
                if (String.IsNullOrEmpty(Session["CartOrderID"].ToString()) || Session["CartOrderID"].ToString().Trim() == "")
                {
                    getVendorSeqNo();

                }
                //String q = "Select * from [HAISIA].[dbo].[tblCartHeader] where varOrderID='" + Session["CartOrderID"].ToString().Trim() + "'";

                strSql = "SELECT TC.[varTempCartID],TC.[DMITNO],TC.[AMLIST],TC.[intQty],TC.[dblTotPrice], I.DMITDS ";
                strSql = strSql + " FROM [HAISIA].[dbo].[tblTempCart] TC, [HAISIA].[dbo].[INM01] I ";
                strSql = strSql + " WHERE TC.[varTempCartID]='" + Session["varTempCartID"].ToString().Trim() + "' AND TC.[DMITNO]=I.[DMITNO]";
                SqlCommand cmd = new SqlCommand(strSql, myconnection);
                DataTable Detdt = new DThelper().getSQLDT(cmd);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                // Start a local transaction.
                transaction = connection.BeginTransaction("OrderConfirm");

                // Must assign both transaction object and connection 
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;
                try
                {
                    if (checkHeaderOrder() == false)
                    {
                        strSql = "INSERT INTO [HAISIA].[dbo].[tblCartHeader] ([varOrderID],[varTempCartID],[ZMCOMP],[GMCUST]";
                        strSql = strSql + ",[GMCDIS],[dtCreated],[dtModified],[varCreatedBy],[varModifiedBy],[varStatus]";
                        strSql = strSql + ",[varCartHeaderRemarks]) VALUES (";
                        strSql = strSql + "'" + Session["CartOrderID"].ToString().Trim() + "',";
                        strSql = strSql + "'" + Session["varTempCartID"].ToString().Trim() + "','01',";
                        strSql = strSql + "'" + Session["UserID"].ToString().Trim() + "',";
                        strSql = strSql + "'" + Session["PricingCode"].ToString().Trim() + "',";
                        strSql = strSql + "GETDATE(),GETDATE(),";
                        strSql = strSql + "'" + Session["UserID"].ToString().Trim() + "',";
                        strSql = strSql + "'" + Session["UserID"].ToString().Trim() + "',";
                        strSql = strSql + "'03','Order confirmed')";

                        strSeqUpdate = "Update [HAISIA].[dbo].[CartSeqNo] SET [intSeqNo]= [intSeqNo] + 1  where GMCUST='" + Session["UserID"].ToString().Trim() + "'";
                    }
                    else
                    {
                        strSql = "UPDATE [HAISIA].[dbo].[tblCartHeader] SET[dtModified] = GETDATE(),";
                        strSql = strSql + " [varModifiedBy] = '" + Session["UserID"].ToString().Trim() + "',";
                        strSql = strSql + " [varStatus] = '02' WHERE [varOrderID]='" + Session["CartOrderID"].ToString().Trim() + "'";

                    }
                    command.CommandType = CommandType.Text;
                    command.CommandText = strSql;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    strSql = "Delete from [HAISIA].[dbo].[tblCartDetail] WHERE [varOrderID]='" + Session["CartOrderID"].ToString().Trim() + "'";
                    command.CommandType = CommandType.Text;
                    command.CommandText = strSql;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    foreach (DataRow dr in Detdt.Rows)
                    {
                        strSql = "INSERT INTO [HAISIA].[dbo].[tblCartDetail] ([varOrderID],[DMITNO],[DMITDS]";
                        strSql = strSql + ",[AMLIST],[intQty],[dblTotPrice]) VALUES (";
                        strSql = strSql + "'" + Session["CartOrderID"].ToString().Trim() + "',";
                        strSql = strSql + "'" + dr["DMITNO"].ToString().Trim() + "',";
                        strSql = strSql + "'" + dr["DMITDS"].ToString().Trim() + "',";
                        strSql = strSql + "" + dr["AMLIST"].ToString().Trim() + ",";
                        strSql = strSql + "" + dr["intQty"].ToString().Trim() + ",";
                        strSql = strSql + "" + dr["dblTotPrice"].ToString().Trim() + ")";
                        command.CommandType = CommandType.Text;
                        command.CommandText = strSql;
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }
                    if (String.IsNullOrEmpty(strSeqUpdate.ToString()) == false)
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = strSeqUpdate;
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();

                    }
                    strSql = "Delete From [HAISIA].[dbo].[tblTempCart] Where varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "'";
                    command.CommandType = CommandType.Text;
                    command.CommandText = strSql;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    strSql = "Delete From [HAISIA].[dbo].[tblTempCartHeader] Where varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "'";
                    command.CommandType = CommandType.Text;
                    command.CommandText = strSql;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    transaction.Commit();
                    InformatinBox_new("Order saved");
                    Session["varTempCartID"] = "";
                    Session["CartOrderID"] = "";

                }
                catch (Exception ex)
                {
                    InformatinBox_new("Commit Exception Type:  " + ex.GetType() + ",  Message: " + ex.Message);
                    transaction.Rollback();
                }
                Response.Redirect("frmMyOrder.aspx");
            }
        }
        private Boolean checkHeaderOrder()
        {
            Boolean retVal = false;

            String q = "Select * from [HAISIA].[dbo].[tblCartHeader] where varOrderID='" + Session["CartOrderID"].ToString().Trim() + "'";
            SqlCommand cmd = new SqlCommand(q, myconnection);
            DataTable dt = new DThelper().getSQLDT(cmd);
            if (dt.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;

        }
        protected void getVendorSeqNo()
        {
            try
            {


                String q = "Select * from [HAISIA].[dbo].[CartSeqNo] where GMCUST='" + Session["UserID"].ToString().Trim() + "'";
                SqlCommand cmd = new SqlCommand(q, myconnection);
                DataTable dt = new DThelper().getSQLDT(cmd);
                if (dt.Rows.Count > 0)
                {
                    Session["CartOrderID"] = Session["UserID"].ToString().Trim() + "-" + dt.Rows[0]["intSeqNo"].ToString().Trim();
                }
                else
                {

                    q = "Insert Into [HAISIA].[dbo].[CartSeqNo] Values ('" + Session["UserID"].ToString().Trim() + "',1)";
                    cmd = new SqlCommand(q, myconnection);
                    new DThelper().executeSQLquery(cmd);
                    Session["CartOrderID"] = Session["UserID"].ToString().Trim() + "-1";
                }
            }
            catch (Exception e)
            {
                InformatinBox_new(e.Message);
            }
        }

        protected void lnkMyOrder_Click(object sender, EventArgs e)
        {
            getMyOrder();
        }
        private void getMyOrder()
        {
            Response.Redirect("frmMyOrder.aspx");
        }


        protected void ClickButton(object sender, CommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Delete_Me_Items":
                    //InformatinBox_new("Test Delete Items");

                    CheckBox chbH = (CheckBox)grdvwMyCart.HeaderRow.FindControl("chbHead");
                    //InformatinBox_new(chbH.ClientID);
                    String q = "";

                    SqlCommand cmd = new SqlCommand(q, myconnection);
                    if (chbH.Checked == true)
                    {
                        q = "DELETE FROM [HAISIA].[dbo].[tblTempCart] WHERE [varTempCartID] ='" + Session["varTempCartID"].ToString().Trim() + "'";
                        //InformatinBox_new("All items selected");
                    }
                    else
                    {
                        for (int i = 0; i < grdvwMyCart.Rows.Count - 1; i++)
                        {
                            CheckBox chbD = (CheckBox)grdvwMyCart.Rows[i].FindControl("chb1");
                            Label lblitemcode = (Label)grdvwMyCart.Rows[i].FindControl("lblitemcode");
                            if (chbD.Checked == true)
                            {
                                //q = q + "'" + grdvwMyCart.Rows[i].Cells[1].Text.Trim() + "',";
                                q = q + "'" + lblitemcode.Text.Trim() + "',";
                            }

                        }
                        if (String.IsNullOrEmpty(q) == false && q.Trim() != "")
                        {
                            q = " AND [DMITNO] IN (" + q.Substring(0, q.Trim().Length - 1) + ")";
                            q = "DELETE FROM [HAISIA].[dbo].[tblTempCart] WHERE [varTempCartID] ='" + Session["varTempCartID"].ToString().Trim() + "'" + q;
                        }
                    }
                    if (String.IsNullOrEmpty(q) == false && q.Trim() != "")
                    {
                        cmd = new SqlCommand(q, myconnection);
                        new DThelper().executeSQLquery(cmd);
                        //InformatinBox_new(q);
                        LoadItems();
                        InformatinBox_new("Successfully Deleted");
                    }
                    else InformatinBox_new("No item(s) selected");



                    //index1 = Convert.ToInt32(e.CommandArgument);
                    ////grdvwMyOrder.Columns[7].Visible = true;
                    //GridViewRow row1 = grdvwMyCart.Rows[index1];
                    ////if (String.IsNullOrEmpty(row1.Cells[1].Text.ToString()) == false && row1.Cells[1].Text.ToString().Trim() != "" && row1.Cells[1].Text.ToString().Trim() != "&nbsp;")
                    ////{
                    ////    InformatinBox_new("Confirmed order can not be deleted!");
                    ////}

                    ////String st = grdvwMyOrder.Rows[index1].Cells[3].Text;
                    ////row1.Cells[7].Visible = true;
                    //if (row1.Cells[8].Text.ToString().Trim() != "Order not confirmed")
                    //{
                    //    //row1.Cells[7].Visible= false;
                    //    InformatinBox_new("Confirmed order can not be deleted!");

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
                    //    InformatinBox_new("Successfully deleted");
                    //    //row1.Cells[7].Visible = false;
                    //    LoadOrders();
                    //}
                    break;
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

        protected void imgConfirmOrder_Click(object sender, ImageClickEventArgs e)
        {
            ConfirmOrder();
        }

        protected void imgCancelOrder_Click(object sender, ImageClickEventArgs e)
        {
            // ConfirmOrder();
        }

        protected void dpdItemList_SelectedIndexChanged(object sender, EventArgs e)
        {

            setFontSize();
            addFontSizeToUser(dpdItemList.SelectedItem.Value.ToString().Trim());
        }
        private void setFontSize()
        {
            FontUnit fu = getFontUnit(dpdItemList.SelectedItem.Value.ToString().Trim());
            grdvwMyCart.HeaderStyle.Font.Size = fu;
            grdvwMyCart.RowStyle.Font.Size = fu;
            grdvwMyCart.AlternatingRowStyle.Font.Size = fu;
        }
        private void addFontSizeToUser(String strFontSize)
        {
            String q = "";
            SqlCommand cmd = new SqlCommand();
            try
            {
                q = "DELETE  FROM [HAISIA].[dbo].[tblUserFontSize] WHERE [GMCUST]='" + Session["UserID"].ToString().Trim() + "'";
                q = q + " AND [varFormName]='frmCart.aspx'";
                cmd = new SqlCommand(q, myconnection);
                new DThelper().executeSQLquery(cmd);
                q = "INSERT INTO [HAISIA].[dbo].[tblUserFontSize] VALUES ('" + Session["UserID"].ToString().Trim() + "',";
                q = q + "'frmCart.aspx','" + strFontSize.Trim() + "')";
                cmd = new SqlCommand(q, myconnection);
                new DThelper().executeSQLquery(cmd);

            }
            catch (Exception ex)
            {
                InformatinBox_new(ex.Message);
            }
        }
        private FontUnit getFontUnit(String strFontUnit)
        {

            FontUnit fu = FontUnit.XXLarge;
            switch (strFontUnit.Trim())
            {
                case "XX-Large":
                    fu = FontUnit.XXLarge;
                    break;
                case "X-Large":
                    fu = FontUnit.XLarge;
                    break;
                case "Large":
                    fu = FontUnit.Large;
                    break;
                case "Larger":
                    fu = FontUnit.Larger;
                    break;
                case "Medium":
                    fu = FontUnit.Medium;
                    break;
                case "XX-Small":
                    fu = FontUnit.XXSmall;
                    break;
                case "X-Small":
                    fu = FontUnit.XSmall;
                    break;
                case "Small":
                    fu = FontUnit.Small;
                    break;
                case "Smaller":
                    fu = FontUnit.Smaller;
                    break;
            }
            return fu;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            setCCDT();
        }
        private void setCCDT()
        {

            StringBuilder builder = new StringBuilder();


            //String strCLT = ViewState["ClosingTime"].ToString().Trim();
            //String strAMPM = strCLT.Substring(strCLT.Trim().Length - 2);
            //strCLT = strCLT.Substring(0, strCLT.Trim().Length - 3);
            //String[] a = strCLT.Split(':');
            String strCLD = ViewState["DisplayDayTime"].ToString().Trim();
            //strCLD = strCLD + " " + a[0].ToString().Trim().PadRight(2, '0');
            //strCLD = strCLD + ":" + a[1].ToString().Trim().PadRight(2, '0');
            //strCLD = strCLD + ":" + a[2].ToString().Trim().PadRight(2, '0');
            //strCLD = strCLD + " " + strAMPM;
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.ParseExact(strCLD.Trim(), "dd/MMM/yyyy h:mm:ss tt", null);
            TimeSpan span = endTime.Subtract(startTime);
            String strD = span.Days.ToString().Trim();
            String strH = span.Hours.ToString().Trim();
            String strM = span.Minutes.ToString().Trim();
            String strS = span.Seconds.ToString().Trim();
            //strCLD = strD.Trim() + " Days " + strH.Trim() + " Hours " + strM.Trim() + " Min " + strS.Trim() + " Sec";
            strCLD = strD.Trim() + " Days " + strH.Trim() + " Hours " + strM.Trim() + " Min";
            builder.Append("Time Left : ");
            builder.Append("<span style=\"color:Blue;\">");
            // builder.Append("4 Days " + a[0].ToString().Trim() + " Hours " + a[1].ToString().Trim() + " Min " + a[2].ToString().Trim() + " Sec");
            builder.Append(strCLD);
            builder.Append("</span>");
            lblItem.Text = builder.ToString();

        }
        private void getCCDT()
        {
            String q = "Select * from [HAISIA].[dbo].[tblCCDT]";
            SqlCommand cmd = new SqlCommand(q, myconnection);
            DataTable dt = new DThelper().getSQLDT(cmd);
            if (dt.Rows.Count > 0)
            {
                ViewState["ClosingDay"] = String.Format("{0:dd/MMM/yyyy}", dt.Rows[0]["dtClosingDay"]);
                ViewState["CollectionDate"] = String.Format("{0:dd/MMM/yyyy}", dt.Rows[0]["dtCollectionDate"]);
                ViewState["ClosingTime"] = dt.Rows[0]["varClosingTime"].ToString().Trim();
                String strCLT = ViewState["ClosingTime"].ToString().Trim();
                String strAMPM = strCLT.Substring(strCLT.Trim().Length - 2);
                strCLT = strCLT.Substring(0, strCLT.Trim().Length - 3);
                String[] a = strCLT.Split(':');
                String strCLD = ViewState["ClosingDay"].ToString().Trim();
                strCLD = strCLD + " " + a[0].ToString().Trim().PadRight(2, '0');
                strCLD = strCLD + ":" + a[1].ToString().Trim().PadRight(2, '0');
                strCLD = strCLD + ":" + a[2].ToString().Trim().PadRight(2, '0');
                strCLD = strCLD + " " + strAMPM;
                ViewState["DisplayDayTime"] = strCLD.ToString().Trim();
                StringBuilder builder = new StringBuilder();
                builder.Append("Collection Date : ");
                builder.Append("<span style=\"color:Blue;\">");
                builder.Append(ViewState["CollectionDate"].ToString().Trim());
                builder.Append("</span>");
                lblCollection.Text = builder.ToString();
                builder = new StringBuilder();
            }

        }

        protected void lnkOurProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmOurProducts.aspx");
        }
    }
}
