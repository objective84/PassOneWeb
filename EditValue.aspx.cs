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
    public partial class EditValue : System.Web.UI.Page
    {
        private PassOneCredentials creds;
        
        private CredentialsManager _credentialsManager = new CredentialsManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            creds = (PassOneCredentials)Session["Credentials"];
            //NewValueTextBox.Text = GetEditValue();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SetEditValue(NewValueTextBox.Text);
            _credentialsManager.UpdateCredentials((PassOneUser)Session["User"], creds);
            Server.Transfer("CredentialsList.aspx");
        }

        private string GetEditValue()
        {
            switch ((string)Session["Edit"])
            {
                case "WebsiteEdit":
                    return creds.Website;
                case "UrlEdit":
                    return creds.Url;
                case "PasswordEdit":
                    return creds.Password;
                case "EmailEdit":
                    return creds.EmailAddress;
                case "UsernameEdit":
                    return creds.Username;
                default:
                    return string.Empty;
            }
        }

        private void SetEditValue(string newValue)
        {
            switch ((string)Session["Edit"])
            {
                case "WebsiteEdit":
                    creds.Website = newValue;
                    break;
                case "UrlEdit":
                    creds.Url = newValue;
                    break;
                case "PasswordEdit":
                    creds.Url = newValue;
                    break;
                case "EmailEdit":
                    creds.EmailAddress = newValue;
                    break;
                case "UsernameEdit":
                    creds.Username = newValue;
                    break;
            }
        }
    }
}