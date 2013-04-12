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

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            SetEditValue(NewValueTextBox.Text);
            _credentialsManager.UpdateCredentials((PassOneUser)Session["User"], creds);
            Server.Transfer("CredentialsList.aspx");
        }

        private string GetEditValue()
        {
            switch ((string)Session["Edit"])
            {
                case "WebsiteValue":
                    return creds.Website;
                case "UrlValue":
                    return creds.Url;
                case "PasswordValue":
                    return creds.Password;
                case "EmailEdit":
                    return creds.EmailAddress;
                case "UsernameValue":
                    return creds.Username;
                default:
                    return string.Empty;
            }
        }

        private void SetEditValue(string newValue)
        {
            switch ((string)Session["Edit"])
            {
                case "WebsiteValue":
                    creds.Website = newValue;
                    break;
                case "UrlValue":
                    creds.Url = newValue;
                    break;
                case "PasswordValue":
                    creds.Password = newValue;
                    break;
                case "EmailValue":
                    creds.EmailAddress = newValue;
                    break;
                case "UsernameValue":
                    creds.Username = newValue;
                    break;
            }
        }
    }
}