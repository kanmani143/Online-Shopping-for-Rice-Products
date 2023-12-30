using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OSCRP
{
    public partial class frmError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                String Url = Request.QueryString["Url"];
                String msg = Request.QueryString["msg"];
                Session["Url"] = Url;
                lblError.Text = msg;
            }
        }

        protected void btnClose_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "window.close(); ", true);
            //Response.Redirect(Session["Url"].ToString(), false);
        }
    }
}