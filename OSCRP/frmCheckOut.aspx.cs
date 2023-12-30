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
    public partial class frmCheckOut : System.Web.UI.Page
    {
        public SqlConnection myconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OSCRP"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                if (string.IsNullOrEmpty(Session["UserID"].ToString()) == true)
                    Response.Redirect("frmLogin.aspx", false);
                string q = "SELECT M.[nvrCatrNo],M.[UserId],M.[intTotalitem],M.[intTotalQty],M.[monTotalPrice],M.[intIsOrdered]";
                q = q + ",D.[intLineNo],D.[nvrPrdNo],D.[intPrdQty],D.[decPrice],D.[monPrdTotPrice] ,[nvrPrdLocation],nvrPrdName,nvrCurr,P.[decPrice],nvrUOM,[intUnit],Description,TITLE";
                q = q + " FROM[dbo].[tblCart] M LEFT JOIN [dbo].[tblCartDetail] D ON M.[nvrCatrNo] = D.[nvrCartNo]";
                q = q + " LEFT JOIN[dbo].[ProductMaster] P ON D.nvrPrdNo = P.nvrPrdNo";
                
                q = q + " WHERE M.UserID = " + Session["UserID"].ToString() + " AND M.[nvrCatrNo]+D.[nvrPrdNo] IN (SELECT [nvrCatrNo]+[nvrPrdNo] FROM dbo.tblCheckOut)";
                    q = q + " AND D.[intIsOrdered]= 0  AND D.intIsDeleted=0 ORDER BY D.[intLineNo]";
                //    String q = "Select P.GMCDIS,P.DMITNO,P.AMCURR,P.DMFRDT,P.DMTODT,P.AMLIST,P.DMPUOM,I.DMITDS  From [OEM05] P INNER JOIN [INM01] I  ON P.DMITNO=I.DMITNO ";
                //q = q + " INNER JOIN [tblItmImgLocation] Q  ON P.DMITNO=Q.DMITNO   ORDER BY I.DMITDS";
                if (myconnection.State == ConnectionState.Closed)
                    myconnection.Open();
                SqlCommand cmd = new SqlCommand(q, myconnection);
                DataTable dt = new OSCRP.DThelper().getSQLDT(cmd);
                lstItemView.DataSource = dt;
                lstItemView.DataBind();
                lblcartNo.Text = dt.Rows[0]["nvrCatrNo"].ToString();
                q = "Select nvrCartNo,sum(intPrdQty) intTotalQty,sum(monPrdTotPrice) monTotalPrice,count(*)  intTotalitem From [dbo].[tblCartDetail] where nvrCartNo+nvrPrdNo IN (SELECT nvrCartNo+nvrPrdNo FROM dbo.tblCheckOut)  group by nvrCartNo";

                cmd = new SqlCommand(q, myconnection);
                 dt = new OSCRP.DThelper().getSQLDT(cmd);
                lblCartItems.Text = dt.Rows[0]["intTotalitem"].ToString();
                lblCartPrice.Text = dt.Rows[0]["monTotalPrice"].ToString();
                lblCartPrice.Text = lblCartPrice.Text.Substring(0, lblCartPrice.Text.Length - 2);
                lblCartQty.Text = dt.Rows[0]["intTotalQty"].ToString();
                

            }
        }

        protected void imgOrder_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("frmOrder.aspx");
        }
        protected void lstItemView_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                String q = "SELECT [nvrPrdNo],[nvrPrdLocation] FROM[OSCRP].[dbo].[ProductMaster] where [nvrPrdNo]='" + lblitemcode.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(q, myconnection);
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
                    String nvrPrdNo = e.CommandArgument.ToString();
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




            }
        }
    }
}