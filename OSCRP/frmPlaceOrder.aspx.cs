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
    public partial class frmPlaceOrder : System.Web.UI.Page
    {
        public SqlConnection myconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OSCRP"].ConnectionString);
        string strOrderNo;
        string strUserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                 strOrderNo = Request.QueryString["OrderId"].ToString();
                if (string.IsNullOrEmpty(Session["UserID"].ToString()) == true)
                    Response.Redirect("frmLogin.aspx");
                string q = "SELECT M.[nvrCatrNo],M.[UserId],M.[intTotalitem],M.[intTotalQty],M.[monTotalPrice],M.[intIsOrdered]";
                q = q + ",D.[intLineNo],D.[nvrPrdNo],D.[intPrdQty],D.[decPrice],D.[monPrdTotPrice] ,[nvrPrdLocation],P.[nvrPrdName],nvrCurr,P.[decPrice],nvrUOM,[intUnit],Description,TITLE";
                q = q + " ,  nvrCurr + ' ' + CONVERT (NVARCHAR,P.[decPrice]) + ' / ' + nvrUOM + ' (' + CONVERT (NVARCHAR,[intUnit])+ ' Kg)' as 'Price', D.nvrInvoiceNo FROM [dbo].[tblCart] M LEFT JOIN [dbo].[tblCartDetail] D ON M.[nvrCatrNo] = D.[nvrCartNo]";
                q = q + " LEFT JOIN[dbo].[ProductMaster] P ON D.nvrPrdNo = P.nvrPrdNo";

                //q = q + " WHERE M.UserID = " + Session["UserID"].ToString();
                    //+ " AND M.[nvrCatrNo]+D.[nvrPrdNo] IN (SELECT [nvrCatrNo]+[nvrPrdNo] FROM dbo.tblCheckOut)";
                q = q + " WHERE D.[intIsOrdered]= 1  AND D.intIsDeleted=0  and D.nvrOrderID ='" + strOrderNo + "' ORDER BY D.[intLineNo];";
                //q = q + "Select nvrCartNo,sum(intPrdQty) intTotalQty,sum(monPrdTotPrice) monTotalPrice,count(*)  intTotalitem From [dbo].[tblCartDetail] where nvrCartNo+nvrPrdNo IN (SELECT nvrCartNo+nvrPrdNo FROM dbo.tblCheckOut) and nvrOrderID ='" + strOrderNo + "' group by nvrCartNo;";
                q = q + "Select nvrCartNo,sum(intPrdQty) intTotalQty,sum(monPrdTotPrice) monTotalPrice,count(*)  intTotalitem From [dbo].[tblCartDetail] where  nvrOrderID ='" + strOrderNo + "' group by nvrCartNo;";
                //    String q = "Select P.GMCDIS,P.DMITNO,P.AMCURR,P.DMFRDT,P.DMTODT,P.AMLIST,P.DMPUOM,I.DMITDS  From [OEM05] P INNER JOIN [INM01] I  ON P.DMITNO=I.DMITNO ";
                //q = q + " INNER JOIN [tblItmImgLocation] Q  ON P.DMITNO=Q.DMITNO   ORDER BY I.DMITDS";
                if (myconnection.State == ConnectionState.Closed)
                    myconnection.Open();
                SqlCommand cmd = new SqlCommand(q, myconnection);
                //DataTable dt = new OSCRP.DThelper().getSQLDT(cmd);
                DataSet ds = new OSCRP.DThelper().getSQLDS(cmd);
                grdOrder.DataSource = ds.Tables[0];
                var strInv = ds.Tables[0].Rows[0]["nvrInvoiceNo"].ToString();
                strUserID= ds.Tables[0].Rows[0]["UserId"].ToString();
                //grdOrder.Columns[5].FooterText = dt.AsEnumerable().Select(x => x.Field<double>("intPrdQty")).Sum().ToString();
                //grdOrder.Columns[6].FooterText = dt.AsEnumerable().Select(x => x.Field<double>("monPrdTotPrice")).Sum().ToString();


                int strfooter = Convert.ToInt32(ds.Tables[1].Rows[0][1]);

                grdOrder.Columns[4].FooterText = strfooter.ToString("0.00");
                strfooter = Convert.ToInt32(ds.Tables[1].Rows[0][2]);
                grdOrder.Columns[4].FooterStyle.Font.Bold = true;
                grdOrder.Columns[5].FooterText = strfooter.ToString("0.00");
                grdOrder.Columns[5].FooterStyle.Font.Bold = true;
                grdOrder.DataBind();
                getConnection();
                q = "SELECT [nvrInvoiceNo],[dtInvoiceDate],[monInvoiceAmount],[intInvoiceQty],[intInvoiceItems]";
                q = q + " FROM tblInvoice Where [nvrInvoiceNo] = '" + strInv + "'";
                 cmd = new SqlCommand(q, myconnection);
                DataTable dt = new OSCRP.DThelper().getSQLDT(cmd);
                lblInvoiceNo.Text = strInv;
                DateTime DtInv= Convert.ToDateTime(dt.Rows[0]["dtInvoiceDate"].ToString());
                lblInvoiceAmount.Text= strfooter.ToString("0.00");
                lblInvoiceDate.Text = DtInv.ToString("dd/MM/yyyy");

                getConnection();
                q = "SELECT * ";
                q = q + " FROM [tblOrder] Where [nvrOrderID] = '" + strOrderNo + "'";
                cmd = new SqlCommand(q, myconnection);
                 dt = new OSCRP.DThelper().getSQLDT(cmd);
                lblOrderID.Text = strOrderNo;
                DtInv = Convert.ToDateTime(dt.Rows[0]["dtOrderDate"].ToString());
                lblOrderDate.Text= DtInv.ToString("dd/MM/yyyy");
                lblStatus.Text = dt.Rows[0]["varStatus"].ToString();
                if (string.IsNullOrEmpty(dt.Rows[0]["dtDepartDate"].ToString())==false)
                {
                    DtInv = Convert.ToDateTime(dt.Rows[0]["dtDepartDate"].ToString());
                    lblDepartureDate.Text = DtInv.ToString("dd/MM/yyyy");
                }
                if (string.IsNullOrEmpty(dt.Rows[0]["dtDeliveredDate"].ToString()) == false)
                {
                    DtInv = Convert.ToDateTime(dt.Rows[0]["dtDeliveredDate"].ToString());
                    lblDeliveredDate.Text = DtInv.ToString("dd/MM/yyyy");
                }




                getConnection();
                q = "select * from tblUser where UserId=" + strUserID;
                cmd = new SqlCommand(q, myconnection);
                 dt = new OSCRP.DThelper().getSQLDT(cmd);
                lblAddress.Text = dt.Rows[0]["txtAddress"].ToString();
                lblName.Text = dt.Rows[0]["varFirstName"].ToString() + " " + dt.Rows[0]["nvrLastName"].ToString();
                lblPinCode.Text = dt.Rows[0]["nvrPinCode"].ToString();
                lblPhone.Text = dt.Rows[0]["nvrPhone"].ToString();
                lblWhatsApp.Text = dt.Rows[0]["nvrWhatsAPP"].ToString();



            }
        }

        protected void imgPlaceOrder_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Write(Invoice.InnerHtml.ToString());
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Order Confirmed');", true);
        }
        protected void getConnection()
        {
            if (myconnection.State == ConnectionState.Closed)
                myconnection.Open();
        }
    }
}