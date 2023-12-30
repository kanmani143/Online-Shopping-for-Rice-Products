using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace OSCRP
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Add("UserID", String.Empty);
            Session.Add("UserName", String.Empty);
            Session.Add("FirstName", String.Empty);
            Session.Add("CartNo", String.Empty);
            Session.Add ("varTempCartID",String.Empty);
            Session.Add("PricingCode", String.Empty);
            Session.Add("CartOrderID", String.Empty);
            Session.Add("LoginForm", String.Empty);
            //Session.Add("PlaceHolder", String.Empty);
            Session.Add("ProdNo", String.Empty);
            Session.Add("Calendar", String.Empty);
            Session.Add("OrderID", String.Empty);
            Session.Add("FeedBackId", String.Empty);
            Session.Add("Role", String.Empty);
            Session.Add("Password", String.Empty);
            Session.Add("Url", String.Empty);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session["UserID"] = "";
            Session["UserName"] = "";
            Session["FirstName"] = "";
            Session["CartNo"] = "";
            Session["varTempCartID"] = "";
            Session["PricingCode"] = "";
            Session["CartOrderID"] = "";
            Session["LoginForm"] = "";
            //Session["PlaceHolder"]="";
            Session["ProdNo"] = "";
            Session["Calendar"] = "";
            Session["OrderID"] = "";
            Session["FeedBackId"] = "";
            Session["Role"] = "";
            Session["Password"] = "";
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Session["UserID"] = "";
            Session["UserName"] = "";
            Session["FirstName"] = "";
            Session["CartNo"] = "";
            Session["varTempCartID"] = "";
            Session["PricingCode"] = "";
            Session["CartOrderID"] = "";
            Session["LoginForm"] = "";
            //Session["PlaceHolder"]="";
            Session["ProdNo"] = "";
            Session["Calendar"] = "";
            Session["OrderID"] = "";
            Session["FeedBackId"] = "";
            Session["Role"] = "";
            Session["Password"] = "";
        }
    }
}