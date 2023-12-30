using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OSCRP
{
    public partial class frmAddDDLValue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                String strLblName = Request.QueryString["lblname"];
                if (String.IsNullOrEmpty(strLblName.ToString()) == false && strLblName.Trim() != "")
                {
                    lblId.Text = "Enter " + strLblName.ToString() + " : ";
                }
            }
        }
        
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            //Session["PlaceHolder"] = txtValue.Text;
            
        }
    }
}