using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OSCRP
{
    public partial class ucCalendar : System.Web.UI.UserControl
    {
        protected System.Web.UI.WebControls.TextBox txtDate;
        protected System.Web.UI.HtmlControls.HtmlGenericControl ImgPane;
        protected string dateSelected;
        protected string _ObjectName;
        protected bool _Disabled;
        protected System.Web.UI.HtmlControls.HtmlInputText childfld;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}