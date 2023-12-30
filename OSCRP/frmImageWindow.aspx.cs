using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OSCRP
{
    public partial class frmImageWindow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                String ImageUrl = Request.QueryString["ImageUrl"];
                if (String.IsNullOrEmpty(ImageUrl.ToString()) == false && ImageUrl.Trim() != "")
                {
                    Image1.ImageUrl = ImageUrl.ToString().Trim();
                }
            }
        }
    }
}