using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Xml;

namespace OSCRP
{
    public partial class frmOrder : System.Web.UI.Page
    {
        public SqlConnection myconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OSCRP"].ConnectionString);
        public SqlConnection myconnection1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OSCRP"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                if (IsPostBack == false)
                {
                    if (string.IsNullOrEmpty(Session["UserID"].ToString()) == true)
                        Response.Redirect("frmLogin.aspx", false);
                }
                string q = "SELECT M.[nvrCatrNo],M.[UserId],M.[intTotalitem],M.[intTotalQty],M.[monTotalPrice],M.[intIsOrdered]";
                q = q + ",D.[intLineNo],D.[nvrPrdNo],D.[intPrdQty],D.[decPrice],D.[monPrdTotPrice] ,[nvrPrdLocation],P.[nvrPrdName],nvrCurr,P.[decPrice],nvrUOM,[intUnit],Description,TITLE";
                q = q + " ,  nvrCurr + ' ' + CONVERT (NVARCHAR,P.[decPrice]) + ' / ' + nvrUOM + ' (' + CONVERT (NVARCHAR,[intUnit])+ ' Kg)' as 'Price' FROM [dbo].[tblCart] M LEFT JOIN [dbo].[tblCartDetail] D ON M.[nvrCatrNo] = D.[nvrCartNo]";
                q = q + " LEFT JOIN[dbo].[ProductMaster] P ON D.nvrPrdNo = P.nvrPrdNo";

                q = q + " WHERE M.UserID = " + Session["UserID"].ToString() + " AND M.[nvrCatrNo]+D.[nvrPrdNo] IN (SELECT [nvrCatrNo]+[nvrPrdNo] FROM dbo.tblCheckOut)";
                q = q + " AND D.[intIsOrdered]= 0  AND D.intIsDeleted=0 ORDER BY D.[intLineNo];";
                q = q + "Select nvrCartNo,sum(intPrdQty) intTotalQty,sum(monPrdTotPrice) monTotalPrice,count(*)  intTotalitem From [dbo].[tblCartDetail] where nvrCartNo +nvrPrdNo IN (SELECT nvrCatrNo+nvrPrdNo FROM dbo.tblCheckOut where UserID = " + Session["UserID"].ToString() + ")  group by nvrCartNo;";
                //    String q = "Select P.GMCDIS,P.DMITNO,P.AMCURR,P.DMFRDT,P.DMTODT,P.AMLIST,P.DMPUOM,I.DMITDS  From [OEM05] P INNER JOIN [INM01] I  ON P.DMITNO=I.DMITNO ";
                //q = q + " INNER JOIN [tblItmImgLocation] Q  ON P.DMITNO=Q.DMITNO   ORDER BY I.DMITDS";
                if (myconnection.State == ConnectionState.Closed)
                    myconnection.Open();
                SqlCommand cmd = new SqlCommand(q, myconnection);
                //DataTable dt = new OSCRP.DThelper().getSQLDT(cmd);
                DataSet ds = new OSCRP.DThelper().getSQLDS(cmd);
                grdOrder.DataSource = ds.Tables[0];
                //grdOrder.Columns[5].FooterText = dt.AsEnumerable().Select(x => x.Field<double>("intPrdQty")).Sum().ToString();
                //grdOrder.Columns[6].FooterText = dt.AsEnumerable().Select(x => x.Field<double>("monPrdTotPrice")).Sum().ToString();
                IFormatProvider ip;
                lblcartNo.Text = ds.Tables[1].Rows[0][0].ToString();
                lblTotalItems.Text = ds.Tables[1].Rows[0][3].ToString();
                int strfooter = Convert.ToInt32(ds.Tables[1].Rows[0][1]);

                grdOrder.Columns[4].FooterText = strfooter.ToString("0.00");
                lblTotalQty.Text = strfooter.ToString("0.00");
                strfooter = Convert.ToInt32(ds.Tables[1].Rows[0][2]);
                grdOrder.Columns[4].FooterStyle.Font.Bold = true;
                grdOrder.Columns[5].FooterText = strfooter.ToString("0.00");
                grdOrder.Columns[5].FooterStyle.Font.Bold = true;
                lblTotalPrice.Text= strfooter.ToString("0.00");
                grdOrder.DataBind();
                q = "select * from tblUser where UserId=" + Session["UserID"].ToString();
                cmd = new SqlCommand(q, myconnection);
                DataTable dt = new OSCRP.DThelper().getSQLDT(cmd);
                lblAddress.Text = dt.Rows[0]["txtAddress"].ToString();
                lblName.Text = dt.Rows[0]["varFirstName"].ToString() + " " + dt.Rows[0]["nvrLastName"].ToString();
                lblPinCode.Text = dt.Rows[0]["nvrPinCode"].ToString();
                lblPhone.Text = dt.Rows[0]["nvrPhone"].ToString();
                lblWhatsApp.Text = dt.Rows[0]["nvrWhatsAPP"].ToString();
                //lstItemView.DataSource = dt;
                //lstItemView.DataBind();
                //lblcartNo.Text = dt.Rows[0]["nvrCatrNo"].ToString();
                //q = "Select nvrCartNo,sum(intPrdQty) intTotalQty,sum(monPrdTotPrice) monTotalPrice,count(*)  intTotalitem From [dbo].[tblCartDetail] where nvrCartNo+nvrPrdNo IN (SELECT nvrCartNo+nvrPrdNo FROM dbo.tblCheckOut)  group by nvrCartNo";

                //cmd = new SqlCommand(q, myconnection);
                //dt = new OSCRP.DThelper().getSQLDT(cmd);
                ////lblCartItems.Text = dt.Rows[0]["intTotalitem"].ToString();
                ////lblCartPrice.Text = dt.Rows[0]["monTotalPrice"].ToString();
                ////lblCartPrice.Text = lblCartPrice.Text.Substring(0, lblCartPrice.Text.Length - 2);
                ////lblCartQty.Text = dt.Rows[0]["intTotalQty"].ToString();


            }
        }

        protected void imgPlaceOrder_Click(object sender, ImageClickEventArgs e)
        {
            string q = "";
            SqlCommand cmd,cmd1;
            string strOrderNo = "";
            string strInvNo = "";
            q = "Select  top 1 [nvrOrderID],RIGHT([nvrOrderID],12) from tblOrder order by dtOrderDate desc";
            if (myconnection.State == ConnectionState.Closed)
                myconnection.Open();
            if (myconnection1.State == ConnectionState.Closed)
                myconnection1.Open();
            DataTable dt;
            SqlTransaction tran = myconnection.BeginTransaction(IsolationLevel.ReadCommitted);
            int intIsCommitted = 0;
            try
            {


                cmd1 = new SqlCommand(q, myconnection1);
                dt = new OSCRP.DThelper().getSQLDT(cmd1);
                if ( dt.Rows[0][0].ToString()==null || dt.Rows[0][0].ToString() == "")
                {
                    strOrderNo = "RMROrder" + DateTime.Now.ToString("ddMMyyyy") + "0001";
                    //strOrderNo = "RMROrder" + DateTime.Now.ToString("ddMMyyyy") + "0001";
                }
                else
                {
                    strOrderNo = dt.Rows[0][0].ToString().Trim();

                    if (strOrderNo.Substring(8, 8) == DateTime.Now.ToString("ddMMyyyy"))
                    {
                        string strseqno = strOrderNo.Substring(16, 4);
                        int intseqno = Convert.ToInt32(strseqno) + 1;
                        strOrderNo = "RMROrder" + DateTime.Now.ToString("ddMMyyyy") + intseqno.ToString("D4");


                    }
                    else
                    {
                        strOrderNo = "RMROrder" + DateTime.Now.ToString("ddMMyyyy") + "0001";
                    }
                }
                strInvNo = strOrderNo.Replace("Order", "Inv");

                cmd = myconnection.CreateCommand();
                cmd.Connection = myconnection;
                
                cmd.Transaction = tran;

                q = "SELECT  [nvrCatrNo],[nvrPrdNo],[UserId]  FROM [tblCheckOut] WHERE [nvrCatrNo] = '" + lblcartNo.Text + "' and [UserId]=" + Session["UserID"].ToString();
                cmd1 = new SqlCommand(q, myconnection1);
                dt = new OSCRP.DThelper().getSQLDT(cmd1);
                foreach (DataRow dr in dt.Rows)
                {
                    q= "Update tblCartDetail set intIsOrdered=1 , nvrOrderID='" + strOrderNo + "',nvrInvoiceNo='" + strInvNo + "' ";
                    q = q + " Where [nvrCartNo] ='" + dr["nvrCatrNo"].ToString() + "' And nvrPrdNo='" + dr["nvrPrdNo"].ToString() + "'";
                    cmd.Connection = myconnection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = q;
                    cmd.ExecuteNonQuery();
                }
                q = "INSERT INTO[dbo].[tblOrder] ";
                q = q + "([nvrOrderID],[UserID],[dtOrderDate],[nvrCatrNo],[varStatus],[dtDepartDate],[dtDeliveredDate]";
                q = q + ",[dtCancelledDate],[intIsDeleted],[intTotalItems],[intTotalQty],[monTotalPrice])";
                q = q + " VALUES ('" + strOrderNo + "' ," + Session["UserID"].ToString() + ",GETDATE(),'" + lblcartNo.Text +"',";
                q = q + "'Ordered',null,null,null,";
                q = q + "0," + lblTotalItems.Text + ", " + lblTotalQty.Text + "," + lblTotalPrice.Text + ")";
                cmd.Connection = myconnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = q;
                cmd.ExecuteNonQuery();
                q = "Insert into [tblInvoice]   ([nvrInvoiceNo],[dtInvoiceDate],[monInvoiceAmount],[intInvoiceQty],[intInvoiceItems])";
                q = q + " Values ('" + strInvNo + "',GetDate()," + lblTotalPrice.Text + "," + lblTotalQty.Text + "," + lblTotalItems.Text + ")";
                cmd.Connection = myconnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = q;
                cmd.ExecuteNonQuery();
                tran.Commit();
                intIsCommitted = 1;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Order Confirmed');", true);

                Response.Redirect("frmPlaceOrder.aspx?OrderId=" + strOrderNo,false);
                //Response.Write(Invoice.InnerHtml.ToString());
            }
            catch (Exception ex)
            {   
                if (intIsCommitted == 0)
                    tran.Rollback();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('"+ ex.Message + "');", true);
            }
            //finally
            //{
            //    if (myconnection.State == ConnectionState.Open)
            //        myconnection.Close();
            //    if (myconnection1.State == ConnectionState.Open)
            //        myconnection1.Close();
            //}

        }

        //protected void btnExportToPDF_Click(object sender, EventArgs e)
        //{
        //    using (System.IO.StringWriter sw = new StringWriter())
        //    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
        //    {
        //        grdOrder.RenderControl(hw);
        //        StringReader sr = new StringReader(sw.ToString());
        //        Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10, 0f);
        //        PdfWriter wrt = PdfWriter.GetInstance(pdfdoc, Response.OutputStream);
        //        pdfdoc.Open();
                
        //        XMLWorkerHelper.GetInstance().ParseXHtml(wrt, pdfdoc, sr);
        //        pdfdoc.Close();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=Category.pdf");
        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        Response.Write(pdfdoc);
        //        Response.End();
        //    }
        //}
    }
}