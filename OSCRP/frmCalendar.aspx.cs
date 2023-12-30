using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OSCRP
{
    public partial class frmCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack==false)
            {
                calDeparture.Visible = true;
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            Session["Calendar"] = calDeparture.SelectedDate.ToString();
            calDeparture.Dispose();
            calDeparture.Visible = false;
        }
    }
}