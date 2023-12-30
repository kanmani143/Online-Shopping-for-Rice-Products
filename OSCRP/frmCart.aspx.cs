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
    public partial class frmCart : System.Web.UI.Page
    {
        public SqlConnection myconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OSCRP"].ConnectionString);
        public SqlConnection myconnection1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OSCRP"].ConnectionString);
        SqlCommand cmd,cmd1;
        DataSet ds;
        DataTable dt;
        string q = "";
        string nvrPrdNo = "";
        int intIsCommitted=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                if (string.IsNullOrEmpty(Session["UserID"].ToString()) == true)
                    Response.Redirect("frmLogin.aspx");
                //string q = "SELECT M.[nvrCatrNo],M.[UserId],M.[intTotalitem],M.[intTotalQty],M.[monTotalPrice],M.[intIsOrdered]";
                LoadItems();
                

            }
        }
        protected void getConnection()
        {
            if (myconnection.State == ConnectionState.Closed)
                myconnection.Open();
        }
        protected void getConnection1()
        {
            if (myconnection1.State == ConnectionState.Closed)
                myconnection1.Open();
        }
        protected void LoadItems()
        {
            q = "SELECT M.[nvrCatrNo],M.[UserId]";
            q = q + ",D.[intLineNo],D.[nvrPrdNo],D.[intPrdQty],D.[decPrice],D.[monPrdTotPrice] ,[nvrPrdLocation],nvrPrdName,nvrCurr,P.[decPrice],nvrUOM,[intUnit],Description,TITLE";
            q = q + " FROM [dbo].[tblCart] M LEFT JOIN[dbo].[tblCartDetail] D ON M.[nvrCatrNo] = D.[nvrCartNo]";
            q = q + " LEFT JOIN[dbo].[ProductMaster] P ON D.nvrPrdNo = P.nvrPrdNo";
            q = q + " WHERE M.UserID = " + Session["UserID"].ToString() + " AND D.[intIsOrdered]= 0  AND D.intIsDeleted=0 ORDER BY D.[intLineNo];";
            q = q + "   Select SUM(D.[intPrdQty]),SUM(D.[monPrdTotPrice]),Count(*) From [tblCartDetail] D Left Join [tblCart] M on D.nvrCartNo = M.nvrCatrNo";
            q = q + "  WHERE d.intIsOrdered = 0 and M.UserId = " + Session["UserID"].ToString() + " GROUP BY D.nvrCartNo";
            //    String q = "Select P.GMCDIS,P.DMITNO,P.AMCURR,P.DMFRDT,P.DMTODT,P.AMLIST,P.DMPUOM,I.DMITDS  From [OEM05] P INNER JOIN [INM01] I  ON P.DMITNO=I.DMITNO ";
            //q = q + " INNER JOIN [tblItmImgLocation] Q  ON P.DMITNO=Q.DMITNO   ORDER BY I.DMITDS";
            
                getConnection();
                cmd = new SqlCommand(q, myconnection);
                //DataTable dt = new OSCRP.DThelper().getSQLDT(cmd);
                ds = new OSCRP.DThelper().getSQLDS(cmd);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                lstItemView.Items.Clear();
                lstItemView.DataSource = null;
                lstItemView.DataBind();
                lstItemView.DataSource = ds.Tables[0];
                lstItemView.DataBind();
                lblcartNo.Text = ds.Tables[0].Rows[0]["nvrCatrNo"].ToString();
                lblCartItems.Text = ds.Tables[1].Rows[0][2].ToString();
                lblCartPrice.Text = ds.Tables[1].Rows[0][1].ToString();
                lblCartPrice.Text = lblCartPrice.Text.Substring(0, lblCartPrice.Text.Length - 2);
                lblCartQty.Text = ds.Tables[1].Rows[0][0].ToString();
            }

           else
            {
                Label1.Visible = true;
                Label1.Text = "There is no item in the cart";
            }
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
                //String q = "SELECT  [DMITNO],[DMITNOImageLocation] FROM [tblItmImgLocation] where DMITNO='" + lblitemcode.Text.Trim() + "'";
                getConnection();
                q = "SELECT [nvrPrdNo],[nvrPrdLocation] FROM[OSCRP].[dbo].[ProductMaster] where [nvrPrdNo]='" + lblitemcode.Text.Trim() + "'";
                cmd = new SqlCommand(q, myconnection);
                DataTable dt = new DThelper().getSQLDT(cmd);
                if (dt.Rows.Count > 0)
                {
                    imgBtnList.ImageUrl = dt.Rows[0]["nvrPrdLocation"].ToString().Trim();

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
                //imgBtnList.Attributes.Add("onclick", "javascript:Popup('" + imgBtnList.ImageUrl.ToString().Trim() + "');return false;");


            }
            else
            {
                //LoadImage();
            }

        }
        protected void ClickButton(object sender, CommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Add_to_cart":
                    nvrPrdNo = e.CommandArgument.ToString();
                    Response.Redirect("AddToCart.aspx?nvrPrdNo=" + nvrPrdNo);
                    break;
                ////Get the button that raised the event
                //Button btn = (Button)sender;

                ////Get the row that contains this button
                //ListView gvr = (ListView)btn.NamingContainer;

                ////Get rowindex
                //int rowindex = gvr.



                //index1 = Convert.ToInt32(e.CommandArgument);
                //index1 = lstItemView.SelectedIndex;

                case "AddToCart_Me":

                    break;
                case "SelectCheck":
                    bool check = true;
                    ImageButton Imgbtn = sender as ImageButton;
                    if (Imgbtn.ImageUrl == "~/Images/CheckBoxUnChecked.jpg")
                    {
                        Imgbtn.ImageUrl = "~/Images/CheckBoxChecked.jpg";
                        for (int i = 0; i < lstItemView.Items.Count; i++)
                        {


                            ImageButton ImgchbCheckOut = (ImageButton)lstItemView.Items[i].FindControl("ImgchbCheckOut");
                            if (ImgchbCheckOut.ImageUrl == "~/Images/CheckBoxUnChecked.jpg")
                            {
                                check = false;
                                break;
                            }


                        }
                        if (check == false)
                            ImageSelectALL.ImageUrl = "~/Images/CheckBoxUnChecked.jpg";
                        else
                            ImageSelectALL.ImageUrl = "~/Images/CheckBoxChecked.jpg";
                    }
                    else
                    {
                        Imgbtn.ImageUrl = "~/Images/CheckBoxUnChecked.jpg";
                        ImageSelectALL.ImageUrl = "~/Images/CheckBoxUnChecked.jpg";

                    }

                    break;
                case "RemoveItem":
                    nvrPrdNo = e.CommandArgument.ToString();
                    getConnection();
                    //getConnection1();
                    //SqlTransaction tran = myconnection.BeginTransaction(IsolationLevel.ReadCommitted);
                    //intIsCommitted = 0;
                    
                    try
                    {
                        //cmd = myconnection.CreateCommand();
                        //cmd.Connection = myconnection;
                        //cmd.Transaction = tran;
                        q = "Delete from tblCartDetail Where nvrCartNo='" + lblcartNo.Text + "' and nvrPrdNo='" + nvrPrdNo + "'";
                        //cmd.CommandType = CommandType.Text;
                        //cmd.CommandText = q;
                        cmd = new SqlCommand(q, myconnection);
                        cmd.ExecuteNonQuery();

                        q = "Select SUM(D.[intPrdQty]),SUM(D.[monPrdTotPrice]),Count(*) From [tblCartDetail] D";
                        q = q + " Where d.intIsOrdered = 0 and d.nvrCartNo='" + lblcartNo.Text + "' group by d.nvrCartNo";
                        getConnection();
                        cmd = new SqlCommand(q, myconnection);
                        dt = new OSCRP.DThelper().getSQLDT(cmd);
                        if(dt !=null && dt.Rows.Count>0 && dt.Rows[0][2].ToString()!="0")
                        {
                            getConnection();
                            q = "Update tblCart Set intTotalitem=" + dt.Rows[0][2].ToString() + ",intTotalQty=" + dt.Rows[0][0].ToString() + ",monTotalPrice=" + dt.Rows[0][1].ToString() + " where [nvrCatrNo] ='" + lblcartNo.Text + "'";
                            cmd = new SqlCommand(q, myconnection);
                            cmd.CommandType = CommandType.Text;
                            
                            cmd.ExecuteNonQuery();
                        }
                        //tran.Commit();
                        intIsCommitted = 1;
                    }
                    catch(Exception ex)
                    {
                        //if (intIsCommitted == 0)
                        //    tran.Rollback();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + ex.Message + "');", true);
                    }

                    Response.Redirect("frmCart.aspx", false);
                    break;


            }
        }
        protected void lstItemView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void imgCheckOut_Click(object sender, ImageClickEventArgs e)
        {
            int IsItemSelected = 0;
            for (int i = 0; i < lstItemView.Items.Count; i++)
            {
                ImageButton ImgchbCheckOut = (ImageButton)lstItemView.Items[i].FindControl("ImgchbCheckOut");
                
                    //CheckBox CheckOut = (CheckBox)lstItemView.Items[i].FindControl("chbCheckOut");
                if (ImgchbCheckOut.ImageUrl == "~/Images/CheckBoxChecked.jpg")
                {
                    IsItemSelected = 1;
                    break;
                }
            }
            if (IsItemSelected == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No item(s) selected');", true);
                //InformatinBox_new("No item(s) selected");
            }
            else
            {
                getConnection();
                string q = "delete from  tblCheckOut where nvrCatrNo='" + lblcartNo.Text + "'";
                cmd = new SqlCommand(q, myconnection);
                cmd.ExecuteNonQuery();
                for (int i = 0; i < lstItemView.Items.Count; i++)
                {

                    //CheckBox CheckOut = (CheckBox)lstItemView.Items[i].FindControl("chbCheckOut");
                    //if (CheckOut.Checked == true)
                    //{
                    ImageButton ImgchbCheckOut = (ImageButton)lstItemView.Items[i].FindControl("ImgchbCheckOut");

                    
                    if (ImgchbCheckOut.ImageUrl == "~/Images/CheckBoxChecked.jpg")
                    {
                        Label lblNvrprod = (Label)lstItemView.Items[i].FindControl("lblItemCode");
                        

                         q = "Insert into tblCheckOut (nvrCatrNo,nvrPrdNo,UserID)";
                        q = q + " values ('" + lblcartNo.Text + "','" + lblNvrprod.Text + "'," + Session["UserID"].ToString() + ")";
                        cmd = new SqlCommand(q, myconnection);
                        cmd.ExecuteNonQuery();


                    }
                }
                Response.Redirect("frmCheckOut.aspx",false);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('item(s) selected');", true);
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
                Response.Write(sb.ToString());
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", sb.ToString(), true);
                //ScriptManager.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString(),true);
                //ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('"+ strMsg + "');", true);
            }
            catch (Exception ex)
            {
                a = ex.Message;

            }
            // strMsg = Replace(strMsg, "'", "\'")
            // strMsg = Replace(strMsg, ".", "")
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            //bool check = false;
            //if (chkSelectAll.Checked == true)
            //    check = true;
            //for (int i = 0; i < lstItemView.Items.Count; i++)
            //{

            //    CheckBox CheckOut = (CheckBox)lstItemView.Items[i].FindControl("chbCheckOut");
            //    CheckOut.Checked = check;

            //}
        }

        protected void ImageSelectALL_Click(object sender, ImageClickEventArgs e)
        {
            bool check = false;
            if (ImageSelectALL.ImageUrl == "~/Images/CheckBoxUnChecked.jpg")
            {
                ImageSelectALL.ImageUrl = "~/Images/CheckBoxChecked.jpg";
                check = true;
            }
            else
            {
                ImageSelectALL.ImageUrl = "~/Images/CheckBoxUnChecked.jpg";
                check = false;
            }

            for (int i = 0; i < lstItemView.Items.Count; i++)
            {

                //CheckBox CheckOut = (CheckBox)lstItemView.Items[i].FindControl("chbCheckOut");
                //ImgchbCheckOut;
                    ImageButton ImgchbCheckOut = (ImageButton)lstItemView.Items[i].FindControl("ImgchbCheckOut");
                if (check == false)
                    ImgchbCheckOut.ImageUrl = "~/Images/CheckBoxUnChecked.jpg"; 
                else
                    ImgchbCheckOut.ImageUrl = "~/Images/CheckBoxChecked.jpg";
                //CheckOut.Checked = check;

            }

        }
    }
}