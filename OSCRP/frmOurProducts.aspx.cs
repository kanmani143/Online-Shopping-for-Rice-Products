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
    public partial class frmOurProducts : System.Web.UI.Page
    {
        public SqlConnection myconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OSCRP"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false) 
            {

                if (IsPostBack == false)
                {
                    if (string.IsNullOrEmpty(Session["UserID"].ToString()) == true)
                        Response.Redirect("frmLogin.aspx", false);
                }

                //    String q = "Select P.GMCDIS,P.DMITNO,P.AMCURR,P.DMFRDT,P.DMTODT,P.AMLIST,P.DMPUOM,I.DMITDS  From [OEM05] P INNER JOIN [INM01] I  ON P.DMITNO=I.DMITNO ";
                //q = q + " INNER JOIN [tblItmImgLocation] Q  ON P.DMITNO=Q.DMITNO   ORDER BY I.DMITDS";
                String q = "SELECT [nvrPrdNo],[nvrPrdName],[nvrPrdLocation],[decPrice],[nvrUOM]";
                q = q + " ,[dtMFdate],[dtExpDate],[nvrCurr],[nvrPrdType],[intUnit]";
                q = q + " FROM[OSCRP].[dbo].[ProductMaster] WHERE Company ='RMR' ORDER BY [nvrPrdName],[intUnit]";
            SqlCommand cmd = new SqlCommand(q, myconnection);
            DataTable dt = new OSCRP.DThelper().getSQLDT(cmd);
            lstItemView.DataSource = dt;
            lstItemView.DataBind();
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

        protected void lstItemView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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