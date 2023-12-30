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
    public partial class AddToCart : System.Web.UI.Page
    {
        
        public SqlConnection myconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OSCRP"].ConnectionString);
        public SqlConnection myconnection1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OSCRP"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Session["UserID"].ToString()) == true)
                    Response.Redirect("frmLogin.aspx", false);
                String nvrPrdNo = Request.QueryString["nvrPrdNo"];

                String q = "SELECT [nvrPrdLocation],nvrPrdNo,nvrPrdName,nvrCurr,decPrice,nvrUOM,[intUnit],Description,TITLE  FROM[OSCRP].[dbo].[ProductMaster] where [nvrPrdNo]='" + nvrPrdNo.Trim() + "'";
                SqlCommand cmd = new SqlCommand(q, myconnection);
                DataTable dt = new DThelper().getSQLDT(cmd);
                if (dt.Rows.Count > 0)
                {
                    ItemImage.ImageUrl = dt.Rows[0]["nvrPrdLocation"].ToString().Trim();
                    ItemImage.Attributes.Add("onmouseout", "javascript:this.style.cursor=;");
                    ItemImage.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';");
                    ItemImage.Attributes.Add("onclick", "javascript:Popup('" + dt.Rows[0]["nvrPrdLocation"].ToString().Trim() + "');return false;");
                    lblItemCode.Text = dt.Rows[0]["nvrPrdNo"].ToString().Trim(); ;
                    lblItemName.Text = dt.Rows[0]["nvrPrdName"].ToString().Trim(); ;
                    lblCurr.Text = dt.Rows[0]["nvrCurr"].ToString().Trim(); ;
                    lblPrice.Text = dt.Rows[0]["decPrice"].ToString().Trim(); ;
                    //lblSlash.Text = "";
                    lblUom.Text = dt.Rows[0]["nvrUOM"].ToString().Trim(); ;
                    lblUnit.Text = dt.Rows[0]["intUnit"].ToString().Trim();
                    imgBtnMinus.CommandArgument= lblItemCode.Text = dt.Rows[0]["nvrPrdNo"].ToString().Trim();
                    imgBtnAdd.CommandArgument = lblItemCode.Text = dt.Rows[0]["nvrPrdNo"].ToString().Trim();
                    ImgbtnAddtoCart.CommandArgument = lblItemCode.Text = dt.Rows[0]["nvrPrdNo"].ToString().Trim();
                    lblDesc.Text= dt.Rows[0]["Description"].ToString().Trim(); ;
                    lblTitle.Text = dt.Rows[0]["TITLE"].ToString().Trim(); ;
                    lblItemPrice.Text = dt.Rows[0]["nvrCurr"].ToString().Trim() + " "
                        + dt.Rows[0]["decPrice"].ToString().Trim() + " / " + dt.Rows[0]["nvrUOM"].ToString().Trim()
                        + " (" + dt.Rows[0]["intUnit"].ToString().Trim() + " KG)";
                    
                        
                        q = "SELECT M.[nvrCatrNo],M.[UserId],M.[intTotalitem],M.[intTotalQty],M.[monTotalPrice],M.[intIsOrdered] ";
                        q = q + ",D.[intLineNo],D.[nvrPrdNo],D.[intPrdQty],D.[decPrice],D.[monPrdTotPrice] ";

                        q = q + "FROM [dbo].[tblCart] M LEFT JOIN[dbo].[tblCartDetail] D ON M.[nvrCatrNo] = D.[nvrCartNo] ";
                        q = q + "WHERE D.nvrPrdNo = '" + nvrPrdNo + "' AND M.UserID = " + Session["UserID"].ToString() + " AND D.[intIsOrdered]= 0  AND D.intIsDeleted=0 ORDER BY D.[intLineNo]";
                        cmd = new SqlCommand(q, myconnection);
                        dt = new DThelper().getSQLDT(cmd);
                        if (dt.Rows.Count > 0)
                        {
                            lblTotalQty.Text = dt.Rows[0]["intPrdQty"].ToString().Trim();
                            lblTotalPrice.Text = dt.Rows[0]["monPrdTotPrice"].ToString().Trim();
                            txtQty.Text = dt.Rows[0]["intPrdQty"].ToString().Trim();
                            lblcartNo.Text = dt.Rows[0]["nvrCatrNo"].ToString().Trim();
                            lblLineNo.Text= dt.Rows[0]["intLineNo"].ToString().Trim();
                        }
                        else
                        {
                            q = "SELECT M.[nvrCatrNo],D.[intLineNo] From  [dbo].[tblCart] M LEFT JOIN [dbo].[tblCartDetail] D ON M.[nvrCatrNo] = D.[nvrCartNo] where D.[intIsOrdered]= 0  AND D.intIsDeleted=0 and UserID = " + Session["UserID"].ToString() + " Order by D.[intLineNo] Desc";
                        cmd = new SqlCommand(q, myconnection);
                        dt = new DThelper().getSQLDT(cmd);
                        if (dt.Rows.Count > 0)
                        {
                            lblcartNo.Text = dt.Rows[0]["nvrCatrNo"].ToString().Trim();
                            lblLastLineNo.Text = dt.Rows[0]["intLineNo"].ToString().Trim();
                        }
                        }
                }
                else
                {
                    ItemImage.ImageUrl = "~/Images/NoImage.jpg";
                    //imgBtnList.ImageUrl = arr4[m].ToString().Trim();

                }
 


            }
        }

        protected void ClickButton(object sender, CommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Add_to_cart":
                    int intadd = 1;
                    if (string.IsNullOrEmpty(txtQty.Text)==true || txtQty.Text=="0")
                    {
                        intadd = 0;
                    }

                    if (string.IsNullOrEmpty(lblTotalQty.Text)==true || lblTotalQty.Text=="0")
                    {
                        intadd = 0;
                    }
 
                    lblError.Visible = false;
                    if (myconnection.State == ConnectionState.Closed)
                        myconnection.Open();
                    if (myconnection1.State == ConnectionState.Closed)
                        myconnection1.Open();
                    SqlTransaction tran = myconnection.BeginTransaction(IsolationLevel.ReadCommitted);
                    int intIsCommitted = 0;
                        try
                        {
                            String q = "";
                            SqlCommand cmd = myconnection.CreateCommand();
                            cmd.Connection = myconnection;
                            SqlCommand cmd1;
                            cmd.Transaction = tran;
                            DataTable dt;
                            String nvrPrdNo = e.CommandArgument.ToString();
                            int IsLineupdate = 0;
                            int IsCartUpdate = 0;
                        if (intadd == 1)
                        {

                            if (string.IsNullOrEmpty(lblcartNo.Text) == false)
                            {
                                if (string.IsNullOrEmpty(lblLineNo.Text) == false)
                                {
                                    IsLineupdate = 1;
                                    IsCartUpdate = 1;
                                }
                                else
                                {
                                    q = "SELECT max([intLineNo]) FROM[OSCRP].[dbo].[tblCartDetail] where nvrCartNo = '" + lblcartNo.Text + "'";
                                    if (myconnection1.State == ConnectionState.Closed)
                                        myconnection1.Open();
                                    cmd1 = new SqlCommand(q, myconnection1);
                                    dt = new DThelper().getSQLDT(cmd1);
                                    if (dt != null & dt.Rows.Count > 0)

                                        lblLineNo.Text = (Convert.ToInt32(dt.Rows[0][0].ToString()) + 1).ToString();
                                    IsCartUpdate = 1;
                                }

                            }
                            else
                            {
                                q = "SELECT max(nvrCatrNo) From  tblCart";
                                if (myconnection1.State == ConnectionState.Closed)
                                    myconnection1.Open();
                                cmd1 = new SqlCommand(q, myconnection1);
                                dt = new DThelper().getSQLDT(cmd1);
                                if (dt.Rows.Count > 0)
                                {
                                    string cartNo = dt.Rows[0][0].ToString().Trim();

                                    if (cartNo.Substring(7, 8) == DateTime.Now.ToString("ddMMyyyy"))
                                    {
                                        string strseqno = cartNo.Substring(15, 4);
                                        int intseqno = Convert.ToInt32(strseqno) + 1;
                                        lblcartNo.Text = "RMRCart" + DateTime.Now.ToString("ddMMyyyy") + intseqno.ToString("D4");


                                    }
                                    else
                                    {
                                        lblcartNo.Text = "RMRCart" + DateTime.Now.ToString("ddMMyyyy") + "0001";
                                    }
                                }
                                else
                                {
                                    lblcartNo.Text = "RMRCart" + DateTime.Now.ToString("ddMMyyyy") + "0001";
                                }
                                lblLineNo.Text = "1";
                            }


                            if (IsLineupdate == 0)
                            {
                                if (IsCartUpdate == 0)
                                {
                                    q = " Insert Into [dbo].[tblCart] ([nvrCatrNo],[UserId],[intTotalitem],[intTotalQty],[monTotalPrice],[intIsOrdered])";
                                    q = q + " values ('" + lblcartNo.Text + "'," + Session["UserID"];
                                    q = q + ",1," + txtQty.Text + "," + lblTotalPrice.Text + ",0)";

                                    cmd.CommandType = CommandType.Text;
                                    cmd.CommandText = q;
                                    cmd.ExecuteNonQuery();
                                }
                                q = "Insert into [dbo].[tblCartDetail] ([nvrCartNo],[intLineNo],[nvrPrdNo],[intPrdQty],[decPrice],[monPrdTotPrice])";
                                q = q + " values ('" + lblcartNo.Text + "'," + lblLineNo.Text;
                                q = q + ",'" + nvrPrdNo + "'," + txtQty.Text;
                                q = q + "," + lblPrice.Text + "," + lblTotalPrice.Text + ")";

                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = q;
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                q = "Update [dbo].[tblCartDetail] set [intPrdQty] = " + txtQty.Text + ",[monPrdTotPrice]=" + lblTotalPrice.Text;
                                q = q + " Where [nvrCartNo]='" + lblcartNo.Text + "' and [intLineNo]=" + lblLineNo.Text;
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = q;
                                cmd.ExecuteNonQuery();
                            }
                            tran.Commit();
                            intIsCommitted = 1;
                            q = "SELECT SUM(intPrdQty),SUM(monPrdTotPrice),COUNT(*) From  [dbo].[tblCartDetail] where nvrCartNo  ='" + lblcartNo.Text;
                            q = q + "' Group by nvrCartNo";
                            cmd1 = new SqlCommand(q, myconnection1);
                            dt = new DThelper().getSQLDT(cmd1);
                            if (dt.Rows.Count > 0)
                            {
                                q = "UPDATE [dbo].[tblCart] SET intTotalitem = " + dt.Rows[0][2].ToString();
                                q = q + ",intTotalQty = " + dt.Rows[0][0].ToString() + ",monTotalPrice = " + dt.Rows[0][1].ToString();
                                q = q + " Where nvrCatrNo ='" + lblcartNo.Text + "'";
                                if (myconnection.State == ConnectionState.Closed)
                                    myconnection.Open();
                                cmd.Connection = myconnection;
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = q;
                                cmd.ExecuteNonQuery();
                            }
                            //tran.Commit();
                            Response.Redirect("frmCart.aspx");
                            //Response.Redirect("frmCart.aspx?nvrPrdNo=" + nvrPrdNo + "&intPrdQty=" + lblTotalQty.Text
                            //    + "&monPrdTotPrice=" + lblTotalPrice.Text + "&decPrice=" + lblPrice.Text);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "PopupError('frmOurProducts.aspx', 'Quantity should not be zero!'); ", true);
                            //Response.Redirect("frmOurProducts.aspx", false);
                        }
                        }
                    catch (Exception ex)
                    {
                        if (intIsCommitted==0)
                            tran.Rollback();
                        lblError.Visible = true;
                        lblError.Text = ex.Message;
                        
                    }
                    finally
                    {
                        if (myconnection.State == ConnectionState.Open)
                            myconnection.Close();
                        if (myconnection1.State == ConnectionState.Open)
                            myconnection1.Close();
                    }
                    break;

                case "AddQty":
                    if (string.IsNullOrEmpty(txtQty.Text) == true)
                        txtQty.Text = "0";
                    txtQty.Text = (Convert.ToInt32(txtQty.Text) + 1).ToString();
                    lblTotalQty.Text = txtQty.Text;
                    lblTotalPrice.Text = ((Convert.ToDouble(txtQty.Text)) * Convert.ToDouble(lblPrice.Text)).ToString()+ ".00";
                    break;

                case "ReduceQty":
                    if (string.IsNullOrEmpty(txtQty.Text) == true)
                        txtQty.Text = "0";
                    if (Convert.ToInt32(txtQty.Text) > 0)
                    {
                        txtQty.Text = (Convert.ToInt32(txtQty.Text) - 1).ToString();
                        lblTotalQty.Text = txtQty.Text;
                        lblTotalPrice.Text = ((Convert.ToDouble(txtQty.Text)) * Convert.ToDouble(lblPrice.Text)).ToString() + ".00";
                    }
                    else
                    {
                        lblTotalQty.Text = "0";
                        lblTotalPrice.Text = "0.00";
                    }
                    
                    
                    break;


            }
        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQty.Text) == false)
                lblTotalQty.Text = txtQty.Text;
        }


    }
}