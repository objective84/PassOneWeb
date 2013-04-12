using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PassOne.Business;
using PassOne.Domain;

namespace PassOne
{
    public partial class NewCredentials : System.Web.UI.Page
    {
        public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\PassOneWeb\\";
        UserManager _userManager = new UserManager();
        CredentialsManager _credentialsManager = new CredentialsManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var user = (PassOneUser) Session["User"];
            _credentialsManager.CreateCredentials(user,
                                                  new PassOneCredentials(WebsiteTextbox.Text, UrlTextbox.Text,
                                                                  UsernameTextbox.Text, PasswordTextbox.Text,
                                                                  EmailTextbox.Text));
            Session["User"] = user;
            Server.Transfer("CredentialsList.aspx");
        }
    }
}