using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PassOne.Business;
using PassOne.Domain;

namespace PassOne.Account
{
    public partial class Login : System.Web.UI.Page
    {
        UserManager _userManager = new UserManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Session["User"] = _userManager.Authenticate();
            //    Server.Transfer("CredentialsList.aspx");
            //}
            //catch (InvalidLoginException)
            //{
            //    throw new InvalidLoginException();
            //}
        }
    }
}
