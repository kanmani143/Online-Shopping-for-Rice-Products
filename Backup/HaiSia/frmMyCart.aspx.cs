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
    public partial class frmMyCart : System.Web.UI.Page
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
                    
                    LoadImage();
                    ViewState["ClosingDay"] = "";
                    ViewState["CollectionDate"] = "";
                    ViewState["ClosingTime"] = "";
                    ViewState["DisplayDayTime"] = "";
                    Session["LoginForm"] = "";
                    //builder.Append("<span style=\"color:Green;\">");
                    //builder.Append(Session["UserID"].ToString().Trim());
                    //builder.Append("</span>");
                    //builder.Append("  Name: ");
                    StringBuilder builder = new StringBuilder();
                    builder.Append("Welcome, ");
                    builder.Append("<span style=\"color:Red;\">");
                    builder.Append(Session["UserName"].ToString().Trim());
                    builder.Append("</span>");
                    lblCustomer.Text = builder.ToString();
                    builder = new StringBuilder();
                    builder.Append("Cart Ref No: ");
                    builder.Append("<span style=\"color:Red;\">");
                    builder.Append("");
                    builder.Append("</span>");
                    lblCartRefNo.Text = builder.ToString();
                    builder = new StringBuilder();
                    builder.Append("Order Date : ");
                    builder.Append("<span style=\"color:Red;\">");

                    builder.Append("");
                    builder.Append("</span>");
                    lblOderDate.Text = builder.ToString();
                    builder = new StringBuilder();
                    //lblCustomer.Text = "ID: " + Session["UserID"].ToString().Trim() + "  Name: " + Session["UserName"].ToString().Trim();
                    if (String.IsNullOrEmpty(Session["CartOrderID"].ToString()) == false)
                    {
                        if (Session["CartOrderID"].ToString().Trim() != "")
                        {
                            Session["varTempCartID"] = "";
                        }
                    }
                    String q = "Select GMCDIS from [HAISIA].[dbo].[ARM01] where GMCUST='" + Session["UserID"].ToString().Trim() + "' And ZMCOMP='01'";
                    SqlCommand cmd = new SqlCommand(q, myconnection);
                    DataTable dt = new DThelper().getSQLDT(cmd);

                    if (dt.Rows.Count > 0)
                    {
                        Session["PricingCode"] = dt.Rows[0]["GMCDIS"].ToString().Trim();
                        LoadItem();
                    }
                    getCCDT();
                    setCCDT();
                }
                else
                {
                    Session["UserID"] = "";
                    lnkLogout.Text = "Login";
                    Session["LoginForm"] = "frmMyCart.aspx";
                    Response.Redirect("frmLogin.aspx");
                }
            }

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
        protected void dpdItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //for (int i = 0; i < lstItemView.Items.Count; i++)
            //{
            //    ImageButton imgb = (ImageButton)lstItemView.Items[i].FindControl("imgBtnList");
            //    imgb.ImageUrl = dpdItemList.SelectedItem.Value.ToString().Trim();
            //    Label lbl1 = (Label)lstItemView.Items[i].FindControl("lblItemName");
            //    lbl1.Text = dpdItemList.SelectedItem.Text.ToString().Trim();
            //}
        }
        private void LoadItem()
        {
            String q = "Select P.GMCDIS,P.DMITNO,P.AMCURR,P.DMFRDT,P.DMTODT,P.AMLIST,P.DMPUOM,I.DMITDS  From [HAISIA].[dbo].[OEM05] P,[HAISIA].[dbo].[INM01] I WHERE  P.DMITNO=I.DMITNO ";
            q = q + " And P.GMCDIS='" + Session["PricingCode"].ToString().Trim() + "' ORDER BY I.DMITDS";
            SqlCommand cmd = new SqlCommand(q, myconnection);
            DataTable dt = new DThelper().getSQLDT(cmd);
            lstItemView.DataSource = dt;
            lstItemView.DataBind();
            StringBuilder builder = new StringBuilder();
            //int m = 0;
            //LoadImage();
            //for (int i = 0; i < lstItemView.Items.Count; i++)
            //{

            //    m = ((i + 1) % 7);
            //    ImageButton imgBtnList = (ImageButton)lstItemView.Items[i].FindControl("imgBtnList");
            //    imgBtnList.ImageUrl = arr4[m].ToString().Trim();
            //}
            if (String.IsNullOrEmpty(Session["varTempCartID"].ToString()) == true)
            {
                q = "SELECT [varTempCartID],[dtCreated] FROM [HAISIA].[dbo].[tblTempCartHeader] ";
                q = q + " WHERE [GMCUST]='" + Session["UserID"].ToString().Trim() + "' ORDER BY [dtCreated] DESC";
                cmd = new SqlCommand(q, myconnection);
                DataTable dt2 = new DThelper().getSQLDT(cmd);
                if (dt2.Rows.Count > 0)
                {
                    Session["varTempCartID"] = dt2.Rows[0]["varTempCartID"].ToString().Trim();
                    orddt = String.Format("{0:dd-MMM-yyyy}", dt2.Rows[0]["dtCreated"]);
                }
            }
            if (String.IsNullOrEmpty(Session["varTempCartID"].ToString()) == false)
            {
                q = "SELECT DMITNO,intQty,dblTotPrice FROM [HAISIA].[dbo].[tblTempCart] WHERE varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "'";
                cmd = new SqlCommand(q, myconnection);
                DataTable dt1 = new DThelper().getSQLDT(cmd);
                builder = new StringBuilder();
                builder.Append("Cart Ref No: ");
                builder.Append("<span style=\"color:Red;\">");
                builder.Append(Session["varTempCartID"].ToString().Trim());
                builder.Append("</span>");
                lblCartRefNo.Text = builder.ToString();
                builder = new StringBuilder();
                builder.Append("Order Date : ");
                builder.Append("<span style=\"color:Red;\">");
                builder.Append(String.Format("{0:dd-MMM-yyyy}", DateTime.Now));
                builder.Append("</span>");
                lblOderDate.Text = builder.ToString();

                lblCartRefNo.Visible = true;
                lblOderDate.Visible = true;
                if (dt1.Rows.Count > 0)
                {
                    object sumQty;
                    sumQty = dt1.Compute("Sum(intQty)", "");
                    object sumTotP;
                    sumTotP = dt1.Compute("Sum(dblTotPrice)", "");

                    //TotItem.Text = ": " + String.Format("{0:0}", dt1.Rows.Count.ToString().Trim());
                    //TotQty.Text = ": " + String.Format("{0:0}", sumQty);
                    //TotPrice.Text = String.Format("{0:0.00}", sumTotP);
                    //TotPrice.Text = "$" + TotPrice.Text.Substring(0, TotPrice.Text.ToString().IndexOf(".") + 3);
                    builder = new StringBuilder();
                    builder.Append("Total Items: ");
                    builder.Append("<span style=\"color:Red;\">");
                    builder.Append(String.Format("{0:0}", dt1.Rows.Count.ToString().Trim()));
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
                    for (int i = 0; i < lstItemView.Items.Count; i++)
                    {

                        Label ItemCode = (Label)lstItemView.Items[i].FindControl("lblItemCode");
                        TextBox Qty = (TextBox)lstItemView.Items[i].FindControl("txtQty");
                        Label lblItemName = (Label)lstItemView.Items[i].FindControl("lblItemName");
                        Label lblCurr = (Label)lstItemView.Items[i].FindControl("lblCurr");
                        Label lblPrice = (Label)lstItemView.Items[i].FindControl("lblPrice");
                        Label lblSlash = (Label)lstItemView.Items[i].FindControl("lblSlash");
                        Label lblUom = (Label)lstItemView.Items[i].FindControl("lblUom");
                        //m = ((i +1) % 7);
                        ImageButton imgBtnList = (ImageButton)lstItemView.Items[i].FindControl("imgBtnList");
                        //imgBtnList.ImageUrl = arr4[m].ToString().Trim();
                        DataRow[] dr = dt1.Select("DMITNO='" + ItemCode.Text.Trim() + "'");
                        if (dr.Length > 0)
                        {
                            Qty.Text = dr[0][1].ToString();
                            //lblItemName.ForeColor = System.Drawing.Color.Green;
                            //lblItemName.Attributes.Add("style", "text-decoration:blink");
                            //Qty.BackColor = System.Drawing.Color.Green;
                            imgBtnList.BorderColor = System.Drawing.Color.Magenta;
                            imgBtnList.BorderStyle = BorderStyle.Solid;
                            imgBtnList.BorderWidth = 10;
                            //lblItemName.Font.Strikeout = true;
                            //ItemCode.Font.Strikeout = true;
                            //ItemCode.Font.Strikeout = true;
                            //lblCurr.Font.Strikeout = true;
                            //lblPrice.Font.Strikeout = true;
                            //lblSlash.Font.Strikeout = true;
                            //lblUom.Font.Strikeout = true;
                            ////Qty.BackColor = System.Drawing.Color.Magenta;
                            ////Qty.ForeColor = System.Drawing.Color.White;

                        }
                        else
                        {
                            Qty.Text = "0";
                            //lblItemName.Font.Strikeout = false;
                            //ItemCode.Font.Strikeout = false;
                            //lblCurr.Font.Strikeout = false;
                            //lblPrice.Font.Strikeout = false;
                            //lblSlash.Font.Strikeout = false;
                            //lblUom.Font.Strikeout = false;
                            imgBtnList.BorderColor = System.Drawing.Color.Transparent;
                            imgBtnList.BorderStyle = BorderStyle.Solid;
                            imgBtnList.BorderWidth = 10;
                            //Qty.BackColor = System.Drawing.Color.White;
                            //Qty.ForeColor = System.Drawing.Color.Black;
                            //lblItemName.Attributes.Remove("style");
                            //lblItemName.ForeColor = System.Drawing.Color.DarkGoldenrod;
                            //Qty.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
                else
                {
                    builder = new StringBuilder();
                    builder.Append("Total Items: ");
                    builder.Append("<span style=\"color:Red;\">");
                    builder.Append(String.Format("{0:0}", "0"));
                    builder.Append("</span>");
                    lblTotItem.Text = builder.ToString();
                    builder = new StringBuilder();
                    wp = ":";
                    wp = wp.PadLeft(4, Convert.ToChar(160));
                    builder.Append("Total Qty" + wp + " ");
                    //builder.Append("Total Qty: ");
                    builder.Append("<span style=\"color:Red;\">");
                    builder.Append(String.Format("{0:0}", "0"));
                    builder.Append("</span>");
                    lblTotQty.Text = builder.ToString();
                    lblTotPrice.Text = String.Format("{0:0.00}", "0.00");
                    lblTotPrice.Text = "$" + lblTotPrice.Text.Substring(0, lblTotPrice.Text.ToString().IndexOf(".") + 3);
                    builder = new StringBuilder();
                    builder.Append("Total Price : ");
                    builder.Append("<span style=\"color:Red;\">");
                    builder.Append(lblTotPrice.Text.Trim());
                    builder.Append("</span>");
                    lblTotPrice.Text = builder.ToString();
                }
            }
            else
            {
                builder = new StringBuilder();
                builder.Append("Total Items: ");
                builder.Append("<span style=\"color:Red;\">");
                builder.Append(String.Format("{0:0}", "0"));
                builder.Append("</span>");
                lblTotItem.Text = builder.ToString();
                builder = new StringBuilder();
                wp = ":";
                wp = wp.PadLeft(4, Convert.ToChar(160));
                builder.Append("Total Qty" + wp + " ");
                //builder.Append("Total Qty: ");
                builder.Append("<span style=\"color:Red;\">");
                builder.Append(String.Format("{0:0}", "0"));
                builder.Append("</span>");
                lblTotQty.Text = builder.ToString();
                lblTotPrice.Text = String.Format("{0:0.00}", "0.00");
                lblTotPrice.Text = "$" + lblTotPrice.Text.Substring(0, lblTotPrice.Text.ToString().IndexOf(".") + 3);
                builder = new StringBuilder();
                builder.Append("Total Price : ");
                builder.Append("<span style=\"color:Red;\">");
                builder.Append(lblTotPrice.Text.Trim());
                builder.Append("</span>");
                lblTotPrice.Text = builder.ToString();

            }
        }
        private String GetTimestamp(DateTime value)
        {
            return value.ToString("HHmmssffff");
        }
        private Boolean checkTempCartID(String TempID)
        {
            Boolean retVal = false;
            String q = "SELECT varTempCartID FROM [HAISIA].[dbo].[tblTempCartHeader] WHERE varTempCartID='" + TempID.ToString().Trim() + "' AND ZMCOMP='01'";
            SqlCommand cmd = new SqlCommand(q, myconnection);
            DataTable dt = new DThelper().getSQLDT(cmd);
            if (dt.Rows.Count > 0) retVal = true;
            return retVal;
        }
        private Boolean checkCartItems(String strItemCode)
        {
            Boolean retVal = false;
            String q = "SELECT varTempCartID FROM [HAISIA].[dbo].[tblTempCart] WHERE varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "' ";
            q = q + " AND DMITNO='" + strItemCode.Trim() + "'";
            SqlCommand cmd = new SqlCommand(q, myconnection);
            DataTable dt = new DThelper().getSQLDT(cmd);
            if (dt.Rows.Count > 0) retVal = true;
            return retVal;

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

        protected void ClickButton(object sender, CommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "ReduceToCart_Me":
                    String DIMITNO = e.CommandArgument.ToString();
                    ////Get the button that raised the event
                    //Button btn = (Button)sender;

                    ////Get the row that contains this button
                    //ListView gvr = (ListView)btn.NamingContainer;

                    ////Get rowindex
                    //int rowindex = gvr.



                    //index1 = Convert.ToInt32(e.CommandArgument);
                    //index1 = lstItemView.SelectedIndex;
                    index1 = getIndex(DIMITNO);
                    AddtoCart(index1, -1);
                    break;
                case "AddToCart_Me":

                    String DIMITNO1 = e.CommandArgument.ToString();
                    //index1 = Convert.ToInt32(e.CommandArgument);
                    //AddtoCart(index1, 1);

                    index1 = getIndex(DIMITNO1);
                    AddtoCart(index1, 1);
                    break;


            }
        }

        private Int32 getIndex(String DIMITNO)
        {
            Int32 retVal = -1;

            for (int i = 0; i < lstItemView.Items.Count; i++)
            {

                Label lbl1 = (Label)lstItemView.Items[i].FindControl("lblItemCode");
                if (lbl1.Text.Trim() == DIMITNO.Trim())
                {
                    retVal = i;
                    break;
                }


            }

            return retVal;
        }
        private Boolean checkCartQty(String ItCd, int Qt)
        {
            Boolean retVal = false;
            String q = "SELECT intQty FROM [HAISIA].[dbo].[tblTempCart] WHERE varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "' ";
            q = q + " AND DMITNO='" + ItCd.Trim() + "'";
            SqlCommand cmd = new SqlCommand(q, myconnection);
            DataTable dt = new DThelper().getSQLDT(cmd);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString().Trim() == Qt.ToString().Trim()) retVal = true;

            }
            return retVal;
        }
        private void AddtoCart(int idx, int intQty)
        {
            String q = "";
            StringBuilder builder = new StringBuilder();
            SqlCommand cmd = new SqlCommand(q, myconnection);
            try
            {

                if (String.IsNullOrEmpty(Session["varTempCartID"].ToString()) == true)
                {

                    Boolean blnCheck = true;
                    while (blnCheck)
                    {
                        //Session["varTempCartID"] = Session["UserID"].ToString().Trim() + Session["PricingCode"].ToString().Trim() + GetTimestamp(DateTime.Now).Trim();
                        Session["varTempCartID"] = GetTimestamp(DateTime.Now).Trim();
                        blnCheck = checkTempCartID(Session["varTempCartID"].ToString().Trim());
                    }
                    q = "INSERT INTO [HAISIA].[dbo].[tblTempCartHeader] ([varTempCartID],[ZMCOMP],[GMCUST]";
                    q = q + ",[GMCDIS],[dtCreated]) VALUES ('" + Session["varTempCartID"].ToString().Trim() + "',";
                    q = q + "'01','" + Session["UserID"].ToString().Trim() + "',";
                    q = q + "'" + Session["PricingCode"].ToString().Trim() + "',GETDATE())";
                    cmd = new SqlCommand(q, myconnection);
                    new DThelper().executeSQLquery(cmd);
                    cmd.Parameters.Clear();
                    orddt = String.Format("{0:dd-MMM-yyyy}", DateTime.Now);
                    builder = new StringBuilder();
                    builder.Append("Cart Ref No: ");
                    builder.Append("<span style=\"color:Red;\">");
                    builder.Append(Session["varTempCartID"].ToString().Trim());
                    builder.Append("</span>");
                    lblCartRefNo.Text = builder.ToString();
                    builder = new StringBuilder();
                    builder.Append("Order Date : ");
                    builder.Append("<span style=\"color:Red;\">");

                    builder.Append(orddt);
                    builder.Append("</span>");
                    lblOderDate.Text = builder.ToString();
                    lblCartRefNo.Visible = true;
                    lblOderDate.Visible = true;
                }

                TextBox txtQty = (TextBox)lstItemView.Items[idx].FindControl("txtQty");
                Label lblPrice = (Label)lstItemView.Items[idx].FindControl("lblPrice");
                Label lblItemCode = (Label)lstItemView.Items[idx].FindControl("lblItemCode");
                Boolean blnChkCrtItems = checkCartItems(lblItemCode.Text.Trim());

                if ((String.IsNullOrEmpty(txtQty.Text) == true || txtQty.Text.Trim() == "0") && intQty < 0)
                {
                }
                else
                {

                    if (blnChkCrtItems == true)
                    {

                        //if (String.IsNullOrEmpty(txtQty.Text) == true || txtQty.Text.Trim() == "0")
                        //{
                        //    q = "DELETE FROM [HAISIA].[dbo].[tblTempCart] ";
                        //    q = q + " WHERE varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "' ";
                        //    q = q + " AND DMITNO='" + lblItemCode.Text.Trim() + "'";
                        //}


                        //else
                        //{
                        if (checkCartQty(lblItemCode.Text.Trim(), int.Parse(txtQty.Text)) == true)
                        {
                            int qt = int.Parse(txtQty.Text) + intQty;
                            txtQty.Text = qt.ToString().Trim();
                        }
                        q = "UPDATE [HAISIA].[dbo].[tblTempCart] SET AMLIST=@AMLIST,intQty=@intQty,dblTotPrice=@dblTotPrice";
                        q = q + " WHERE varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "' ";
                        q = q + " AND DMITNO='" + lblItemCode.Text.Trim() + "'";
                        //}


                    }
                    else
                    {
                        if (String.IsNullOrEmpty(txtQty.Text) == true || txtQty.Text.Trim() == "0") txtQty.Text = "1";
                        q = "INSERT INTO [HAISIA].[dbo].[tblTempCart] ([varTempCartID]";
                        q = q + ",[DMITNO],[AMLIST],[intQty],[dblTotPrice]) VALUES (";
                        q = q + "'" + Session["varTempCartID"] + "'";
                        q = q + ",'" + lblItemCode.Text.Trim() + "',";
                        q = q + "@AMLIST,@intQty,@dblTotPrice)";

                    }
                    cmd = new SqlCommand(q, myconnection);
                    //if (blnChkCrtItems == true && (String.IsNullOrEmpty(txtQty.Text) == true || txtQty.Text.Trim() == "0"))
                    //{
                    //}
                    //else
                    //{
                    cmd.Parameters.Add("@AMLIST", SqlDbType.Decimal).Value = double.Parse(lblPrice.Text.Trim());
                    cmd.Parameters.Add("@intQty", SqlDbType.Int).Value = int.Parse(txtQty.Text.Trim());
                    cmd.Parameters.Add("@dblTotPrice", SqlDbType.Decimal).Value = double.Parse(lblPrice.Text.Trim()) * double.Parse(txtQty.Text.Trim());
                    //}
                    //String.Format("{0:0.00}", double.Parse(txtCMMPP.Text.ToString().Trim()));
                    new DThelper().executeSQLquery(cmd);
                    cmd.Parameters.Clear();
                    q = "DELETE FROM [HAISIA].[dbo].[tblTempCart] ";
                    q = q + " WHERE varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "' ";
                    q = q + " AND DMITNO='" + lblItemCode.Text.Trim() + "' and intQty=0";
                    cmd = new SqlCommand(q, myconnection);
                    new DThelper().executeSQLquery(cmd);
                    cmd.Parameters.Clear();

                    //q = "SELECT count(*) FROM [HAISIA].[dbo].[tblTempCart] WHERE varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "'";
                    q = "SELECT DMITNO,intQty,dblTotPrice FROM [HAISIA].[dbo].[tblTempCart] WHERE varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "'";
                    cmd = new SqlCommand(q, myconnection);
                    DataTable dt = new DThelper().getSQLDT(cmd);


                    //builder = new StringBuilder();
                    //builder.Append("Total Qty: ");
                    //builder.Append("<span style=\"color:Red;\">");
                    //builder.Append(String.Format("{0:0}", sumQty));
                    //builder.Append("</span>");
                    //lblTotQty.Text = builder.ToString();
                    //lblTotPrice.Text = String.Format("{0:0.00}", sumTotP);
                    //lblTotPrice.Text = "$" + lblTotPrice.Text.Substring(0, lblTotPrice.Text.ToString().IndexOf(".") + 3);
                    //builder = new StringBuilder();
                    //builder.Append("Total Price: ");
                    //builder.Append("<span style=\"color:Red;\">");
                    //builder.Append(lblTotPrice.Text.Trim());
                    //builder.Append("</span>");
                    //lblTotPrice.Text = builder.ToString();
                    if (dt.Rows.Count > 0)
                    {
                        builder = new StringBuilder();
                        builder.Append("Total Items: ");
                        builder.Append("<span style=\"color:Red;\">");
                        builder.Append(String.Format("{0:0}", dt.Rows.Count.ToString().Trim()));
                        builder.Append("</span>");
                        lblTotItem.Text = builder.ToString();
                        object sumQty;
                        sumQty = dt.Compute("Sum(intQty)", "");
                        object sumTotP;
                        sumTotP = dt.Compute("Sum(dblTotPrice)", "");

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

                    }
                    else
                    {
                        builder = new StringBuilder();
                        builder.Append("Total Items: ");
                        builder.Append("<span style=\"color:Red;\">");
                        builder.Append(String.Format("{0:0}", "0"));
                        builder.Append("</span>");
                        lblTotItem.Text = builder.ToString();
                        builder = new StringBuilder();
                        wp = ":";
                        wp = wp.PadLeft(4, Convert.ToChar(160));
                        builder.Append("Total Qty" + wp + " ");
                        //builder.Append("Total Qty: ");
                        builder.Append("<span style=\"color:Red;\">");
                        builder.Append(String.Format("{0:0}", "0"));
                        builder.Append("</span>");
                        lblTotQty.Text = builder.ToString();
                        lblTotPrice.Text = String.Format("{0:0.00}", "0.00");
                        lblTotPrice.Text = "$" + lblTotPrice.Text.Substring(0, lblTotPrice.Text.ToString().IndexOf(".") + 3);
                        builder = new StringBuilder();
                        builder.Append("Total Price : ");
                        builder.Append("<span style=\"color:Red;\">");
                        builder.Append(lblTotPrice.Text.Trim());
                        builder.Append("</span>");
                        lblTotPrice.Text = builder.ToString();
                    }
                    //if (lblTotItem.Text.Trim() == "Total Items: <span style=\"color:Red;\">0</span>")
                    //{
                    //    builder = new StringBuilder();
                    //    builder.Append("Total Qty: ");
                    //    builder.Append("<span style=\"color:Red;\">");
                    //    builder.Append(String.Format("{0:0}", "0"));
                    //    builder.Append("</span>");
                    //    lblTotQty.Text = builder.ToString();
                    //    lblTotPrice.Text = String.Format("{0:0.00}", "0.00");
                    //    lblTotPrice.Text = "$" + lblTotPrice.Text.Substring(0, lblTotPrice.Text.ToString().IndexOf(".") + 3);
                    //    builder = new StringBuilder();
                    //    builder.Append("Total Price: ");
                    //    builder.Append("<span style=\"color:Red;\">");
                    //    builder.Append(lblTotPrice.Text.Trim());
                    //    builder.Append("</span>");
                    //    lblTotPrice.Text = builder.ToString();
                    //}
                    //else
                    //{
                    //    q = "SELECT Sum(intQty),Sum(dblTotPrice) FROM [HAISIA].[dbo].[tblTempCart] WHERE varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "'";
                    //    q = q + "GROUP BY varTempCartID";
                    //    cmd = new SqlCommand(q, myconnection);
                    //    dt = new DThelper().getSQLDT(cmd);
                    //    if (dt.Rows.Count > 0)
                    //    {

                    //        //TotQty.Text = ": " + String.Format("{0:0}", dt.Rows[0][0].ToString().Trim());
                    //        //TotPrice.Text = String.Format("{0:0.00}", dt.Rows[0][1].ToString().Trim());
                    //        //TotPrice.Text = "$" + TotPrice.Text.Substring(0, TotPrice.Text.ToString().IndexOf(".") + 3);

                    //        builder = new StringBuilder();
                    //        builder.Append("Total Qty: ");
                    //        builder.Append("<span style=\"color:Red;\">");
                    //        builder.Append(String.Format("{0:0}", dt.Rows[0][0].ToString().Trim()));
                    //        builder.Append("</span>");
                    //        lblTotQty.Text = builder.ToString();
                    //        lblTotPrice.Text = String.Format("{0:0.00}", dt.Rows[0][1].ToString().Trim());
                    //        lblTotPrice.Text = "$" + lblTotPrice.Text.Substring(0, lblTotPrice.Text.ToString().IndexOf(".") + 3);
                    //        builder = new StringBuilder();
                    //        builder.Append("Total Price: ");
                    //        builder.Append("<span style=\"color:Red;\">");
                    //        builder.Append(lblTotPrice.Text.Trim());
                    //        builder.Append("</span>");
                    //        lblTotPrice.Text = builder.ToString();


                    //    }
                    //}


                }

                q = "SELECT DMITNO,intQty FROM [HAISIA].[dbo].[tblTempCart] WHERE varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "'";
                cmd = new SqlCommand(q, myconnection);
                DataTable dt1 = new DThelper().getSQLDT(cmd);
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < lstItemView.Items.Count; i++)
                    {

                        Label ItemCode = (Label)lstItemView.Items[i].FindControl("lblItemCode");
                        Label lblItemName = (Label)lstItemView.Items[i].FindControl("lblItemName");
                        TextBox Qty = (TextBox)lstItemView.Items[i].FindControl("txtQty");
                        HtmlTableCell tdItems = (HtmlTableCell)lstItemView.Items[i].FindControl("tdItems");
                        Label lblCurr = (Label)lstItemView.Items[i].FindControl("lblCurr");
                        Label lblPrice1 = (Label)lstItemView.Items[i].FindControl("lblPrice");
                        Label lblSlash = (Label)lstItemView.Items[i].FindControl("lblSlash");
                        Label lblUom = (Label)lstItemView.Items[i].FindControl("lblUom");
                        String bc = tdItems.BgColor.ToString();
                        ImageButton imgBtnList = (ImageButton)lstItemView.Items[i].FindControl("imgBtnList");

                        DataRow[] dr = dt1.Select("DMITNO='" + ItemCode.Text.Trim() + "'");
                        if (dr.Length > 0)
                        {
                            Qty.Text = dr[0][1].ToString();
                            //ItemCode.Font.Strikeout = true;
                            //lblItemName.Font.Strikeout = true;
                            ////Qty.BackColor = System.Drawing.Color.Magenta;
                            ////Qty.ForeColor  = System.Drawing.Color.White;
                            //lblCurr.Font.Strikeout = true;
                            //lblPrice1.Font.Strikeout = true;
                            //lblSlash.Font.Strikeout = true;
                            //lblUom.Font.Strikeout = true;
                            imgBtnList.BorderColor = System.Drawing.Color.Magenta;
                            imgBtnList.BorderStyle = BorderStyle.Solid;
                            imgBtnList.BorderWidth = 10;
                        }
                        else
                        {
                            Qty.Text = "0";
                            //lblItemName.Font.Strikeout = false;
                            //ItemCode.Font.Strikeout = false;
                            ////Qty.BackColor = System.Drawing.Color.White;
                            ////Qty.ForeColor = System.Drawing.Color.Black;
                            //lblCurr.Font.Strikeout = false;
                            //lblPrice1.Font.Strikeout = false;
                            //lblSlash.Font.Strikeout = false;
                            //lblUom.Font.Strikeout = false;
                            imgBtnList.BorderColor = System.Drawing.Color.Transparent;
                            imgBtnList.BorderStyle = BorderStyle.Solid;
                            imgBtnList.BorderWidth = 10;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < lstItemView.Items.Count; i++)
                    {

                        TextBox Qty = (TextBox)lstItemView.Items[i].FindControl("txtQty");
                        Label lblItemName = (Label)lstItemView.Items[i].FindControl("lblItemName");
                        HtmlTableCell tdItems = (HtmlTableCell)lstItemView.Items[i].FindControl("tdItems");
                        Label ItemCode = (Label)lstItemView.Items[i].FindControl("lblItemCode");
                        Label lblCurr = (Label)lstItemView.Items[i].FindControl("lblCurr");
                        Label lblPrice1 = (Label)lstItemView.Items[i].FindControl("lblPrice");
                        Label lblSlash = (Label)lstItemView.Items[i].FindControl("lblSlash");
                        Label lblUom = (Label)lstItemView.Items[i].FindControl("lblUom");
                        ImageButton imgBtnList = (ImageButton)lstItemView.Items[i].FindControl("imgBtnList");
                        Qty.Text = "0";
                        //lblItemName.Font.Strikeout = false;
                        //ItemCode.Font.Strikeout = false;
                        ////                Qty.BackColor = System.Drawing.Color.White;
                        ////Qty.ForeColor = System.Drawing.Color.Black;
                        //lblCurr.Font.Strikeout = false;
                        //lblPrice1.Font.Strikeout = false;
                        //lblSlash.Font.Strikeout = false;
                        //lblUom.Font.Strikeout = false;
                        imgBtnList.BorderColor = System.Drawing.Color.Transparent;
                        imgBtnList.BorderStyle = BorderStyle.Solid;
                        imgBtnList.BorderWidth = 10;
                    }
                }

            }
            catch (Exception ex)
            {
                InformatinBox_new(ex.Message);
            }

        }
        private void AddtoCart_old(int idx, int intQty)
        {
            String q = "";
            SqlCommand cmd = new SqlCommand(q, myconnection);
            try
            {

                if (String.IsNullOrEmpty(Session["varTempCartID"].ToString()) == true)
                {

                    Boolean blnCheck = true;
                    while (blnCheck)
                    {
                        Session["varTempCartID"] = Session["UserID"].ToString().Trim() + Session["PricingCode"].ToString().Trim() + GetTimestamp(DateTime.Now).Trim();
                        blnCheck = checkTempCartID(Session["varTempCartID"].ToString().Trim());
                    }
                    q = "INSERT INTO [HAISIA].[dbo].[tblTempCartHeader] ([varTempCartID],[ZMCOMP],[GMCUST]";
                    q = q + ",[GMCDIS],[dtCreated]) VALUES ('" + Session["varTempCartID"].ToString().Trim() + "',";
                    q = q + "'01','" + Session["UserID"].ToString().Trim() + "',";
                    q = q + "'" + Session["PricingCode"].ToString().Trim() + "',GETDATE())";
                    cmd = new SqlCommand(q, myconnection);
                    new DThelper().executeSQLquery(cmd);
                    cmd.Parameters.Clear();
                }

                TextBox txtQty = (TextBox)lstItemView.Items[idx].FindControl("txtQty");
                Label lblPrice = (Label)lstItemView.Items[idx].FindControl("lblPrice");
                Label lblItemCode = (Label)lstItemView.Items[idx].FindControl("lblItemCode");
                Boolean blnChkCrtItems = checkCartItems(lblItemCode.Text.Trim());
                if (blnChkCrtItems == true)
                {
                    if (String.IsNullOrEmpty(txtQty.Text) == true || txtQty.Text.Trim() == "0")
                    {
                        q = "DELETE FROM [HAISIA].[dbo].[tblTempCart] ";
                        q = q + " WHERE varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "' ";
                        q = q + " AND DMITNO='" + lblItemCode.Text.Trim() + "'";
                    }
                    else
                    {
                        q = "UPDATE [HAISIA].[dbo].[tblTempCart] SET AMLIST=@AMLIST,intQty=@intQty,dblTotPrice=@dblTotPrice";
                        q = q + " WHERE varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "' ";
                        q = q + " AND DMITNO='" + lblItemCode.Text.Trim() + "'";
                    }


                }
                else
                {
                    q = "INSERT INTO [HAISIA].[dbo].[tblTempCart] ([varTempCartID]";
                    q = q + ",[DMITNO],[AMLIST],[intQty],[dblTotPrice]) VALUES (";
                    q = q + "'" + Session["varTempCartID"] + "'";
                    q = q + ",'" + lblItemCode.Text.Trim() + "',";
                    q = q + "@AMLIST,@intQty,@dblTotPrice)";

                }
                cmd = new SqlCommand(q, myconnection);
                if (blnChkCrtItems == true && (String.IsNullOrEmpty(txtQty.Text) == true || txtQty.Text.Trim() == "0"))
                {
                }
                else
                {
                    cmd.Parameters.Add("@AMLIST", SqlDbType.Decimal).Value = double.Parse(lblPrice.Text.Trim());
                    cmd.Parameters.Add("@intQty", SqlDbType.Int).Value = int.Parse(txtQty.Text.Trim());
                    cmd.Parameters.Add("@dblTotPrice", SqlDbType.Decimal).Value = double.Parse(lblPrice.Text.Trim()) * double.Parse(txtQty.Text.Trim());
                }
                //String.Format("{0:0.00}", double.Parse(txtCMMPP.Text.ToString().Trim()));
                new DThelper().executeSQLquery(cmd);
                cmd.Parameters.Clear();
                q = "SELECT count(*) FROM [HAISIA].[dbo].[tblTempCart] WHERE varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "'";
                cmd = new SqlCommand(q, myconnection);
                DataTable dt = new DThelper().getSQLDT(cmd);
                if (dt.Rows.Count > 0)
                {
                    //TotItem.Text = ": " + String.Format("{0:0}", dt.Rows[0][0].ToString().Trim());
                }

                q = "SELECT Sum(intQty),Sum(dblTotPrice) FROM [HAISIA].[dbo].[tblTempCart] WHERE varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "'";
                q = q + "GROUP BY varTempCartID";
                cmd = new SqlCommand(q, myconnection);
                dt = new DThelper().getSQLDT(cmd);
                if (dt.Rows.Count > 0)
                {
                    //TotQty.Text = ": " + String.Format("{0:0}", dt.Rows[0][0].ToString().Trim());
                    //TotPrice.Text = String.Format("{0:0.00}", dt.Rows[0][1].ToString().Trim());
                    //TotPrice.Text = "$" + TotPrice.Text.Substring(0, TotPrice.Text.ToString().IndexOf(".") + 3);
                }

            }
            catch (Exception ex)
            {
                InformatinBox_new(ex.Message);
            }

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
                Response.Redirect("frmCheckOut.aspx?OrderID= &OrderRef=" + Session["varTempCartID"].ToString().Trim());

            }
            else
            {
                InformatinBox_new("No item(s) selected");
            }
        }
        protected void BtnLogout_Click(object sender, EventArgs e)
        {

            String q = "Delete From [HAISIA].[dbo].[tblTempCart] Where varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "'";
            SqlCommand cmd = new SqlCommand(q, myconnection);
            new DThelper().executeSQLquery(cmd);
            q = "Delete From [HAISIA].[dbo].[tblTempCartHeader] Where varTempCartID='" + Session["varTempCartID"].ToString().Trim() + "'";
            cmd = new SqlCommand(q, myconnection);
            new DThelper().executeSQLquery(cmd);
            Session["varTempCartID"] = "";
            Session["PricingCode"] = "";
            Session["UserID"] = "";
            Session["UserName"] = "";
            Response.Redirect("frmLogin.aspx");
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
            //if (String.IsNullOrEmpty(Session["varTempCartID"].ToString()) == false)
            //{
            //    callCartForm();
            //}
            //else
            //{
            //    InformatinBox_new("No Order created");
            //}
        }
        protected void btnCart_Click(object sender, ImageClickEventArgs e)
        {
            if (String.IsNullOrEmpty(Session["varTempCartID"].ToString()) == false)
            {
                callCartForm();
            }
            else
            {
                InformatinBox_new("No Order created");
            }
        }
        protected void lnkCheckOut_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Session["varTempCartID"].ToString()) == false)
            {
                callCartForm();
            }
            else
            {
                InformatinBox_new("No Order created");
            }
        }

        protected void lnkMyOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmMyOrder.aspx");
        }

        protected void lstItemView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ImageButton imgBtnList = (ImageButton)e.Item.FindControl("imgBtnList");
                Label lblitemcode = (Label)e.Item.FindControl("lblItemCode");
                //        int m = 0;
                ////         Dim di As ListViewDataItem = DirectCast((e.Item), System.Web.UI.WebControls.ListViewDataItem)
                ////Dim itemIdex As Integer = di.DataItemIndex
                //        ListViewDataItem di= (ListViewDataItem) e.Item;
                //        int i = di.DataItemIndex;
                //        m = ((i + 1) % 7);

                //        imgBtnList.ImageUrl = arr4[m].ToString().Trim();
                String q = "SELECT  [DMITNO],[DMITNOImageLocation] FROM [HAISIA].[dbo].[tblItmImgLocation] where DMITNO='" + lblitemcode.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(q, myconnection);
                DataTable dt = new DThelper().getSQLDT(cmd);
                if (dt.Rows.Count > 0)
                {
                    imgBtnList.ImageUrl = dt.Rows[0]["DMITNOImageLocation"].ToString().Trim();

                }
                else
                {
                    imgBtnList.ImageUrl = "~/Images/NoImage.jpg";
                    //imgBtnList.ImageUrl = arr4[m].ToString().Trim();

                }
                imgBtnList.Attributes.Add("onmouseout", "javascript:this.style.cursor=;");
                imgBtnList.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';");
                ////e.Row.Cells[1].Attributes.Add("onclick", "javascript:window.open('" + Image1.ImageUrl.ToString().Trim().Substring(2) + "','_newtab');");
                ////e.Row.Cells[1].Attributes.Add("onclick", "javascript:window.open('" + Image1.ImageUrl.ToString().Trim().Substring(2) + "');return false;");
                //e.Row.Cells[1].Attributes.Add("onclick", "javascript:Popup('" + Image1.ImageUrl.ToString().Trim().Substring(2) + "');return false;");
                imgBtnList.Attributes.Add("onclick", "javascript:Popup('" + imgBtnList.ImageUrl.ToString().Trim() + "');return false;");


            }
            else
            {
                LoadImage();
            }
        }
        protected void lnkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmHome.aspx");
        }
        protected void lnkContactUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactUs.aspx");
        }

        protected void lnkOurProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmOurProducts.aspx");
        }
    }
}
