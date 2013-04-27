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
    public partial class Login : System.Web.UI.Page
    {
        public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\PassOneWeb\\";
        UserManager _userManager = new UserManager();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                Session["User"] = _userManager.Authenticate(UsernameTextBox.Text, PasswordTextBox.Text, Path);
                Response.Redirect("CredentialsList.aspx");
            }
            catch (InvalidLoginException)
            {
                throw new InvalidLoginException();
            }
        }
    }
}