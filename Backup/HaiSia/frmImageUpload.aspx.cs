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
    public partial class frmImageUpload : System.Web.UI.Page
    {
        public SqlConnection myconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["HAISIA"].ConnectionString);
        public int index1 = 0;
        public string[] arr4 = new string[7];
        public int intControl = 0;
        public Boolean blnLike = false;
        public string strFileUploadMsg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (String.IsNullOrEmpty(Session["UserID"].ToString()) == false)
                {
                    arr4[0] = "~/Images/NoImage.jpg";  
                    arr4[1] ="~/Images/blueSeaCrab1.jpeg";
                    arr4[2] ="~/Images/rockCrab.jpeg";
                    arr4[3]  ="~/Images/CoralCrab.jpeg";
                    arr4[4]  ="~/Images/AsianShoreCrab.jpeg";
                    arr4[5]  ="~/Images/MangroveCrab.jpeg";
                    arr4[6] = "~/Images/RiverCrab.jpeg";
                    StringBuilder builder = new StringBuilder();
                    builder.Append("Welcome, ");
                    builder.Append("<span style=\"color:Green;\">");
                    builder.Append(Session["UserName"].ToString().Trim());
                    builder.Append("</span>");
                    lblCustomer.Text = builder.ToString();
                    ViewState["blnLike"] = "F";
                    dpdImgIndex.SelectedIndex = 1;
                    LoadImage();
                }
                else
                {
                    Session["UserID"] = "";
                    Response.Redirect("frmLogin.aspx");
                }
            }
         
        }
        private void LoadImage() 
        {
            String q = "";
            if (ViewState["blnLike"].ToString().Trim() == "T")
            {
                if (String.IsNullOrEmpty(txtLike.Text.ToString()) == false && txtLike.Text.ToString().Trim() != "")
                {
                    q = "SELECT  DISTINCT P.DMITNO,I.[DMITDS], 'No Image Available' as STATUS, '' as DMITNOImageLocation ";
                    q = q + " FROM [HAISIA].[dbo].[OEM05] P, [HAISIA].[dbo].[INM01] I WHERE P.DMITNO = I.DMITNO ";
                    q = q + " AND upper(I.[DMITDS]) LIKE '%" + txtLike.Text.Trim().ToUpper() + "%' ORDER BY  I.[DMITDS]";
                }
                else 
                {
                    InformatinBox_new("Like cannot be empty!");
                }
            }
            else
            {
                if (dpdImgIndex.SelectedItem.Text.Trim().ToUpper() == "ALL")
                {
                    q = "SELECT  DISTINCT P.DMITNO,I.[DMITDS], 'No Image Available' as STATUS, '' as DMITNOImageLocation ";
                    q = q + " FROM [HAISIA].[dbo].[OEM05] P, [HAISIA].[dbo].[INM01] I WHERE P.DMITNO = I.DMITNO ORDER BY  I.[DMITDS]";
                }
                else
                {
                    q = "SELECT  DISTINCT P.DMITNO,I.[DMITDS], 'No Image Available' as STATUS, '' as DMITNOImageLocation ";
                    q = q + " FROM [HAISIA].[dbo].[OEM05] P, [HAISIA].[dbo].[INM01] I WHERE P.DMITNO = I.DMITNO ";
                    q = q + " AND upper(I.[DMITDS]) LIKE '" + dpdImgIndex.SelectedItem.Text.Trim().ToUpper() + "%' ORDER BY  I.[DMITDS]";
                }
            }
            SqlCommand cmd = new SqlCommand(q, myconnection);
            DataTable dt = new DThelper().getSQLDT(cmd);
          
            if (dt.Rows.Count <= 0)
            {
                dt.Rows.Add(dt.NewRow());
                grdvwImage.DataSource = dt;
                grdvwImage.DataBind();
                grdvwImage.Rows[0].Visible = false;
            }
            else
            {
                grdvwImage.DataSource = dt;
                grdvwImage.DataBind();
            }
          
        }
        protected void grdvwImage_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdvwImage.EditIndex = e.NewEditIndex;
            intControl = 1;
            LoadImage();
            intControl = 0;
            grdvwImage.Rows[e.NewEditIndex].Cells[3].Focus();
            FileUpload FileUpload1 = (FileUpload)grdvwImage.Rows[e.NewEditIndex].FindControl("FileUpload1");
            OpenDialogueBox(FileUpload1);
        
        }

        private void OpenDialogueBox(FileUpload FileUpload1) 
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<script type = \'text/javascript\'>");
            sb.Append("window.onload=function(){");
            sb.Append("OpenDialogueBox(\'");
            sb.Append(FileUpload1.ClientID);
            sb.Append("\')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        public string GetFileName(string strFileName)
        {
            string strRetVal;
            strRetVal = "";
            try
            {
                int intLen;
                int i;
                intLen = strFileName.Trim().Length;
                i = intLen;
                while ((i != 0))
                {
                    if (((strFileName.Trim().Substring((i - 1), 1) == "\\")
                                || (strFileName.Trim().Substring((i - 1), 1) == "/")))
                    {
                        break; //Warning!!! Review that break works as 'Exit Do' as it could be in a nested instruction like switch
                    }
                    i = (i - 1);
                }
                strRetVal = strFileName.Trim().Substring(i);
            }
            catch (Exception ex)
            {
                InformatinBox_new(ex.Message);
            }
            return strRetVal;
        }
        private string getFileExist(String FileName) 
        {
            string pathToCheck = Server.MapPath("~/Images/" + FileName);
            string tempfileName = FileName;
                      // Check to see if a file already exists with the
            // same name as the file to upload.
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    // if a file with this name already exists,
                    // prefix the filename with a number.
                    tempfileName =  Path.GetFileNameWithoutExtension(FileName).Trim();
                    tempfileName = tempfileName + "_" + counter.ToString() ;
                    tempfileName = tempfileName + Path.GetExtension(FileName);
                    pathToCheck = Server.MapPath("~/Images/" + tempfileName);
                    counter++;
                }

                strFileUploadMsg = "A file with the same name already exists!!! " +
                     "\\n Your file was saved as " + tempfileName;
                

               
            }
            else
            {
                // Notify the user that the file was saved successfully.
                strFileUploadMsg = "Your file was uploaded successfully.";
            }


            // Append the name of the file to upload to the path.

            return tempfileName;
        }
        protected void grdvwImage_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;
            GridViewRow row1 = grdvwImage.Rows[index];
            FileUpload fuploadFile = (FileUpload)row1.FindControl("FileUpload1");
            //FileUpload fuploadFile = (FileUpload)grdvwImage.Rows[e.RowIndex].FindControl("FileUpload1");
            Label lblitemcode = (Label)row1.FindControl("lblitemcode");
            String fileName="";
            String strDoc = fuploadFile.FileName.ToString().Trim();
            
            try
            {
             if (strDoc.ToString().Trim()!="")
            {
                //fileName = GetFileName(strDoc.ToString().Trim());
                fileName = strDoc.ToString().Trim();
                string exten = Path.GetExtension(fileName); 
                //here we have to restrict file type            
                exten = exten.ToLower();
                string[] acceptedFileTypes = new string[4];            
                acceptedFileTypes[0] = ".jpg";
                acceptedFileTypes[1] = ".jpeg";
                acceptedFileTypes[2] = ".gif";
                acceptedFileTypes[3] = ".png";                               
                bool acceptFile = false;              
                for (int i = 0; i <= 3; i++)
                {
                    if (exten == acceptedFileTypes[i])
                    {                     
                        acceptFile = true;
                        break;
                    }
                } 
                if (!acceptFile)
                {
                    InformatinBox_new ( "The file you are trying to upload is not a permitted file type!");
                }
            
            else
            {
                int length = fuploadFile.PostedFile.ContentLength;

                if (length <= (3072 * 1024))
                {
                    fileName = getFileExist(fileName);
                    String SavePath = Server.MapPath("~/Images/" + fileName);
                    //SavePath = SavePath.Replace("/", "\\");
                    //InformatinBox_new(SavePath);
                    fuploadFile.SaveAs(SavePath);
                    //fuploadFile.SaveAs(Server.MapPath("~/Images/" + FileExist));
                    lblitemcode = (Label)row1.FindControl("lblitemcode");
                    String q = "Select [DMITNO] from [HAISIA].[dbo].[tblItmImgLocation] WHERE [DMITNO]='" + lblitemcode.Text.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(q, myconnection);
                    DataTable dt = new DThelper().getSQLDT(cmd);
                    if (dt.Rows.Count > 0)
                    {
                        q = "Update [HAISIA].[dbo].[tblItmImgLocation] SET [DMITNOImageLocation]='" + "~/Images/" + fileName + "' WHERE [DMITNO]='" + lblitemcode.Text.Trim() + "'";
                    }
                    else
                    {
                        q = "Insert Into  [HAISIA].[dbo].[tblItmImgLocation] Values (";
                        q = q + "'" + lblitemcode.Text.Trim() + "','" + "~/Images/" + fileName + "')";
                    }
                    cmd = new SqlCommand(q, myconnection);
                    new DThelper().executeSQLquery(cmd);
                    InformatinBox_new(strFileUploadMsg);
                }
                else 
                {
                    InformatinBox_new("File Size should no be more than 3MB");
                }
            }
            grdvwImage.EditIndex = -1;
            intControl = 0;
            LoadImage();
            intControl = 0;
            }
            }
            catch(Exception ex) 
            {
                InformatinBox_new(ex.Message);
            }
            //Label lblitemcode = (Label)row1.FindControl("lblitemcode");
        }
        protected void grdvwImage_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void grdvwImage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
  
            grdvwImage.EditIndex = -1;
            intControl = 1;
            LoadImage();
            intControl = 0;
            //LoadImage();
            //gvDetails.Width = 1274; 
        }
        protected void grdvwImage_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //FileUpload flUpload = new FileUpload();
                //flUpload = (FileUpload)e.Row.FindControl("fUpload");
                //ScriptManager.GetCurrent(this).RegisterPostBackControl(flUpload);  
                Label lblitemcode = (Label)e.Row.FindControl("lblitemcode");
                Image Image1 = (Image)e.Row.FindControl("Image1");
                Label lblimgLoc = (Label)e.Row.FindControl("lblimgLoc");
                //String check = e.Row.FindControl("lblimgLoc").ClientID.ToString();
                //if (String.IsNullOrEmpty(lblimgLoc.Text.ToString()) == true) lblimgLoc.Text = " ";
                int Sno = e.Row.RowIndex + 1;
                int m = (Sno % 7);
                String q = "SELECT  [DMITNO],[DMITNOImageLocation] FROM [HAISIA].[dbo].[tblItmImgLocation] where DMITNO='" + lblitemcode.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(q, myconnection);
                DataTable  dt = new DThelper().getSQLDT(cmd);
                if (dt.Rows.Count > 0)
                {
                    Image1.ImageUrl = dt.Rows[0]["DMITNOImageLocation"].ToString().Trim();
                    //lblimgLoc.Text = Image1.ImageUrl.ToString();
                    if (e.Row.FindControl("lblimgLoc") != null)
                    {
                        if (String.IsNullOrEmpty(dt.Rows[0]["DMITNOImageLocation"].ToString()) == false) lblimgLoc.Text = dt.Rows[0]["DMITNOImageLocation"].ToString();
                    }
                     
                    //e.Row.Cells[3].Text = "Image Available";
                }
                else 
                {
                    Image1.ImageUrl = "~/Images/NoImage.jpg";
                    if (e.Row.FindControl("lblimgLoc") != null) lblimgLoc.Text = "";
                    //Image1.ImageUrl = arr4[m].ToString().Trim();
                    //if (m==0)  e.Row.Cells[3].Text = "No Image Available";
                    //else e.Row.Cells[3].Text = "Image Available";
                }
                e.Row.Cells[1].Attributes.Add("onmouseout ", "javascript:this.style.color='black';;");
                e.Row.Cells[1].Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';;javascript:this.style.color='red';");
                //e.Row.Cells[1].Attributes.Add("onclick", "javascript:window.open('" + Image1.ImageUrl.ToString().Trim().Substring(2) + "','_newtab');");
                //e.Row.Cells[1].Attributes.Add("onclick", "javascript:window.open('" + Image1.ImageUrl.ToString().Trim().Substring(2) + "');return false;");
                e.Row.Cells[1].Attributes.Add("onclick", "javascript:Popup('" + Image1.ImageUrl.ToString().Trim() + "');return false;");
                //Popup(url)

                //("onclick", "javascript:window.open('www.microsoft.com'); return false;");
            }
        }
        protected void grdvwImage_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
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
        
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session["varTempCartID"] = "";
            Session["PricingCode"] = "";
            Session["UserID"] = "";
            Session["UserName"] = "";
            Response.Redirect("frmLogin.aspx");
        }
        protected void dpdImgIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["blnLike"] = "F";
            LoadImage();
           
        }

        protected void imgbLike_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["blnLike"] = "T";
            LoadImage();
          

        }
        protected void lnkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmHomeAdmin.aspx");
        }

        protected void CCDT_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCCDT.aspx");
        }
    }
}
