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

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Session["User"] = _userManager.Authenticate(UsernameTextBox.Text, PasswordTextBox.Text, Path);
                Server.Transfer("CredentialsList.aspx");
            }
            catch (InvalidLoginException)
            {
                throw new InvalidLoginException();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("Register.aspx");
        }
    }
}