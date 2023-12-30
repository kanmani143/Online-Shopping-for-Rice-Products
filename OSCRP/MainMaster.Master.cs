using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace OSCRP
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        public SqlConnection myconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OSCRP"].ConnectionString);
        string q = "";
        DataTable dt;
        DataSet ds;
        SqlCommand cmd;
        public string LoginText
        {
            get
            {
                // Get value of control on master page  
                return Login.Text;
            }
            set
            {
                // Set new value for control on master page  
                Login.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
             if (IsPostBack == false)
            {
                

                if (string.IsNullOrEmpty(Session["UserID"].ToString()) == false)
                {
                    dvUserMenu.Visible = true;
                    foreach (Control X in form1.Controls.OfType<LinkButton>())
                    {
                        string s = X.GetType().ToString().Trim();
                        if (X.GetType().ToString().Trim() == "System.Web.UI.WebControls.LinkButton")
                        {
                            string strID = (X as LinkButton).ID.ToString().Trim();
                            if (strID == "Login" || strID == "Pipeline" || strID == "Signup" || strID == "Logout" || strID == "lnkProfile" || strID == "lnkChangePassword")
                            {
                                (X as LinkButton).Attributes.Add("onmouseout", "Javascript:this.style.color='#cc6699';");
                                (X as LinkButton).Attributes.Add("onmouseover", "Javascript:this.style.color='red';Javascript: this.style.cursor = 'pointer'");
                            }

                            else
                            {
                                (X as LinkButton).Attributes.Add("onmouseout", "Javascript:this.style.color='Black';");
                                (X as LinkButton).Attributes.Add("onmouseover", "Javascript:this.style.color='red';Javascript: this.style.cursor = 'pointer'");
                            }
                        }

                    }
                    lnkHome.Attributes.Add("onmouseout", "Javascript:this.style.color='Black';");
                    lnkHome.Attributes.Add("onmouseover", "Javascript:this.style.color='red';Javascript: this.style.cursor = 'pointer'");
                    lnkFeedback.Attributes.Add("onmouseout", "Javascript:this.style.color='Black';");
                    lnkFeedback.Attributes.Add("onmouseover", "Javascript:this.style.color='red';Javascript: this.style.cursor = 'pointer'");

                    lnkMyCart.Attributes.Add("onmouseout", "Javascript:this.style.color='Black';");
                    lnkMyCart.Attributes.Add("onmouseover", "Javascript:this.style.color='red';Javascript: this.style.cursor = 'pointer'");
                    lnkOurProducts.Attributes.Add("onmouseout", "Javascript:this.style.color='Black';");
                    lnkOurProducts.Attributes.Add("onmouseover", "Javascript:this.style.color='red';Javascript: this.style.cursor = 'pointer'");

                    lnkMyOrder.Attributes.Add("onmouseout", "Javascript:this.style.color='Black';");
                    lnkMyOrder.Attributes.Add("onmouseover", "Javascript:this.style.color='red';Javascript: this.style.cursor = 'pointer'");
                    lnkStatus.Attributes.Add("onmouseout", "Javascript:this.style.color='Black';");
                    lnkStatus.Attributes.Add("onmouseover", "Javascript:this.style.color='red';Javascript: this.style.cursor = 'pointer'");

                    lnkOrders.Attributes.Add("onmouseout", "Javascript:this.style.color='Black';");
                    lnkOrders.Attributes.Add("onmouseover", "Javascript:this.style.color='red';Javascript: this.style.cursor = 'pointer'");
                    lnkUsers.Attributes.Add("onmouseout", "Javascript:this.style.color='Black';");
                    lnkUsers.Attributes.Add("onmouseover", "Javascript:this.style.color='red';Javascript: this.style.cursor = 'pointer'");

                    lnkProduct.Attributes.Add("onmouseout", "Javascript:this.style.color='Black';");
                    lnkProduct.Attributes.Add("onmouseover", "Javascript:this.style.color='red';Javascript: this.style.cursor = 'pointer'");
                    lnkInvoices.Attributes.Add("onmouseout", "Javascript:this.style.color='Black';");
                    lnkInvoices.Attributes.Add("onmouseover", "Javascript:this.style.color='red';Javascript: this.style.cursor = 'pointer'");
                    //Login.Text = "Logout";
                    //Signup.Text = "Profile";
                    Login.Visible = false;
                    Logout.Visible = true;
                    Signup.Visible = false;
                    lnkProfile.Visible = true;

                    string Role ="";
                    if (myconnection.State == ConnectionState.Open)
                        myconnection.Open();
                    
                    q = "Select * From tblUser Where UserID=" + Session["UserID"].ToString();
                    cmd = new SqlCommand(q, myconnection);
                    
                    dt = new OSCRP.DThelper().getSQLDT(cmd);
                    if (dt != null)
                    {
                        lblUserName.Text = "Welcome ! " + dt.Rows[0]["varFirstName"].ToString() + " ";
                        lblUserName.Text = lblUserName.Text + dt.Rows[0]["nvrLastName"].ToString() + ", ";
                        lblUserName.Text = lblUserName.Text + dt.Rows[0]["nvrEmail"].ToString();
                        Role = dt.Rows[0]["Role"].ToString();
                        Session["Role"] = Role;
                    }
                    if (Role == "Admin")
                    {
                        lnkInvoices.Visible = false;
                        lnkOrders.Visible = true;
                        lnkUsers.Visible = true;
                        lnkProduct.Visible = true;
                        lnkOurProducts.Visible = false;
                        lnkStatus.Visible = false;
                        lnkFeedback.Visible = true;
                        lnkMyCart.Visible = false;
                        lnkMyOrder.Visible = false;
                    }
                    else
                    {
                        lnkOurProducts.Visible = true;
                        lnkStatus.Visible = false;
                        lnkFeedback.Visible = true;
                        lnkMyCart.Visible = true;
                        lnkMyOrder.Visible = true;
                        lnkInvoices.Visible = false;
                        lnkOrders.Visible = false;
                        lnkUsers.Visible = false;
                        lnkProduct.Visible = false;

                    }
                   
                    //if (string.IsNullOrEmpty(Session["FirstName"].ToString()) == false)
                    //    lblUserName.Text = "Welcome : " + Session["FirstName"].ToString() + "   " + Session["UserName"].ToString();
                }
                else
                {
                    dvUserMenu.Visible = false;
                    Login.Visible = true;
                    Logout.Visible = false;
                    Signup.Visible = true;
                    lnkProfile.Visible = false;

                    //Login.Text = "Login";
                    //Signup.Text = "Signup";
                }

                }


        }

        //private void Common_Click(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmLogin.aspx",false);
        }

        protected void lnkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmHome.aspx",false);
        }

        protected void lnkMyCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCart.aspx",false);
        }

        protected void lnkOurProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmOurProducts.aspx",false);
        }

        protected void lnkFeedback_Click(object sender, EventArgs e)
        {
            if (Session["Role"].ToString()=="Admin")
                Response.Redirect("frmfeedBackMaintenance.aspx", false);
            else
                Response.Redirect("frmFeedback.aspx",false);
        }

        protected void Signup_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmSignUp.aspx",false);
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Login.Visible = true;
            Logout.Visible = false;
            Session["UserID"] = "";
            Response.Redirect("frmLogin.aspx", false);
        }

        protected void Profile_Click(object sender, EventArgs e)
        {
            
        }
        
             protected void lnkProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmProdctMaintenance.aspx", false);
        }
        
         protected void lnkOrders_Click(object sender, EventArgs e)
        {
            string userid = "";
            Response.Redirect("frmOrderMaintenance.aspx?UserId="+ userid, false);
        }
        protected void lnkProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmProfile.aspx", false);
        }

        protected void lnkStatus_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmStatus.aspx", false);
        }

        protected void lnkMyOrder_Click(object sender, EventArgs e)
        {
            
                Response.Redirect("frmMyOrder.aspx", false);
        }

        protected void lnkUsers_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Calendar.aspx", false);
            Response.Redirect("frmUsers.aspx", false);
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            //Session["UserID"] = "";
        }
    }
}