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
using System.IO;

namespace HaiSia
{
    public partial class frmCCDT : System.Web.UI.Page
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
                    StringBuilder builder = new StringBuilder();
                    builder.Append("Welcome, ");
                    builder.Append("<span style=\"color:Red;\">");
                    builder.Append(Session["UserName"].ToString().Trim());
                    builder.Append("</span>");
                    lblCustomer.Text = builder.ToString();
                    lnkLogout.Text = "Logout";
                    getCCDT();
                }
                else
                {
                    Session["UserID"] = "";
                    Response.Redirect("frmLogin.aspx");
                }
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
        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            //command.Parameters.Add("@dtCmmCostStartDate", SqlDbType.DateTime).Value = DateTime.ParseExact(strDt.Trim(), "dd/MMM/yyyy", null);
            String q = "";
            SqlCommand cmd = new SqlCommand();
            String clTime = "";
            try
            {
                if (String.IsNullOrEmpty(txtClosingDay.Text.ToString()) == true || txtClosingDay.Text.Trim() == "")
                {
                    InformatinBox_new("Closing Day cannot be empty!");

                }
                else
                {
                    if (String.IsNullOrEmpty(txtNextColDate.Text.ToString()) == true || txtNextColDate.Text.Trim() == "")
                    {
                        InformatinBox_new("Collection Date cannot be empty!");

                    }
                    else
                    {
                        q = "DELETE FROM [HAISIA].[dbo].[tblCCDT]";
                        cmd = new SqlCommand(q, myconnection);
                        new DThelper().executeSQLquery(cmd);
                        q = "Insert Into [HAISIA].[dbo].[tblCCDT] VALUES (";
                        q = q + "@dtClosingDay,@varClosingTime,@dtCollectionDate)";
                        cmd = new SqlCommand(q, myconnection);
                        if (String.IsNullOrEmpty(txtHour.Text.ToString()) == false && txtHour.Text.Trim() != "")
                        {
                            clTime = clTime + txtHour.Text.Trim() + ":";
                        }
                        else
                        {
                            clTime = clTime + "0:";
                        }
                        if (String.IsNullOrEmpty(txtMin.Text.ToString()) == false && txtMin.Text.Trim() != "")
                        {
                            clTime = clTime + txtMin.Text.Trim() + ":";
                        }
                        else
                        {
                            clTime = clTime + "0:";
                        }
                        if (String.IsNullOrEmpty(txtSec.Text.ToString()) == false && txtSec.Text.Trim() != "")
                        {
                            clTime = clTime + txtSec.Text.Trim();
                        }
                        else
                        {
                            clTime = clTime + "0";
                        }
                        clTime = clTime + " " + rblst.SelectedItem.Value.ToString().Trim();


                        cmd.Parameters.Add("@dtClosingDay", SqlDbType.DateTime).Value = DateTime.ParseExact(txtClosingDay.Text.Trim(), "dd/MMM/yyyy", null);
                        cmd.Parameters.Add("@varClosingTime", SqlDbType.VarChar).Value = clTime.Trim();
                        cmd.Parameters.Add("@dtCollectionDate", SqlDbType.DateTime).Value = DateTime.ParseExact(txtNextColDate.Text.Trim(), "dd/MMM/yyyy", null);
                        new DThelper().executeSQLquery(cmd);
                        cmd.Parameters.Clear();
                        InformatinBox_new("Successfully submitted");
                    }
                }
            }
            catch (Exception ex)
            {
                InformatinBox_new(ex.Message);
            }
        }

        private void getCCDT()
        {
            String q = "Select * from [HAISIA].[dbo].[tblCCDT]";
            SqlCommand cmd = new SqlCommand(q, myconnection);
            DataTable dt = new DThelper().getSQLDT(cmd);
            if (dt.Rows.Count > 0)
            {
                txtClosingDay.Text = String.Format("{0:dd/MMM/yyyy}", dt.Rows[0]["dtClosingDay"]);
                txtNextColDate.Text = String.Format("{0:dd/MMM/yyyy}", dt.Rows[0]["dtCollectionDate"]);
                String strCLT = dt.Rows[0]["varClosingTime"].ToString().Trim();
                String strAMPM = strCLT.Substring(strCLT.Trim().Length - 2);
                strCLT = strCLT.Substring(0, strCLT.Trim().Length - 3);
                String[] a = strCLT.Split(':');
                txtHour.Text = a[0].ToString().Trim();
                txtMin.Text = a[1].ToString().Trim();
                txtSec.Text = a[2].ToString().Trim();
                if (strAMPM.Trim() == "AM") rblst.SelectedIndex = 0;
                else rblst.SelectedIndex = 1;
            }

        }


        protected void ImageUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmImageUpload.aspx");
        }
        protected void lnkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmHomeAdmin.aspx");
        }
        protected void lnkLogout_Click(object sender, EventArgs e)
        {

            Session["varTempCartID"] = "";
            Session["PricingCode"] = "";
            Session["UserID"] = "";
            Session["UserName"] = "";
            Response.Redirect("frmLogin.aspx");

        }
    }
}
