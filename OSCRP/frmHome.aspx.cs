using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OSCRP
{
    public partial class frmHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            {
                if (string.IsNullOrEmpty(Session["UserID"].ToString()) == true)
                    Response.Redirect("frmLogin.aspx", false);
            }
        }
    }
}