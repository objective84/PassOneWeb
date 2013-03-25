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
    public partial class CredentialsList : System.Web.UI.Page
    {
        public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\PassOneWeb\\";
        private User _user;
        private UserManager _userManager = new UserManager();
        private CredentialsManager _credentialsManager = new CredentialsManager();
     

        protected void Page_Load(object sender, EventArgs e)
        {
            _user = (User)Session["User"];
            if (IsPostBack) return;

            CredentialsListBox.SelectedIndexChanged += CredentialsListBox_SelectedIndexChanged;
            UpdateListBox();

            if (CredentialsListBox.Items.Count <= 0) return;

            CredentialsListBox.SelectedIndex = 0;
            CredentialsListBox_SelectedIndexChanged(CredentialsListBox, null);
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Server.Transfer("EditValue.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("NewCredentials.aspx");
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            var creds = _credentialsManager.FindCredentials(_user,
                                                            _userManager.GetCredentialsList(_user, Path)[
                                                                CredentialsListBox.SelectedItem.Value], Path);
            _credentialsManager.DeleteCredentials(creds, _user, Path);
            Session["User"] = _user;
            UpdateListBox();
            
        }

        public void UpdateListBox()
        {
            var tempList = (from ListItem item in CredentialsListBox.Items select item.Text).ToList();

            var credentialsList = _userManager.GetCredentialsList(_user, Path);

            foreach (var key in credentialsList.Keys.Where(key => !tempList.Contains(key)))
                CredentialsListBox.Items.Add(key);
            foreach (var item in tempList.Where(item => !credentialsList.ContainsKey(item)))
                CredentialsListBox.Items.Remove(item);
        }

        protected void CredentialsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PasswordValue.Visible)
            {
                PasswordValue.Visible = false;
                ShowPasswordButton.Text = "Show Password";
            }
            _user = (User)Session["User"];
            var id = _userManager.GetCredentialsList(_user, Path)[CredentialsListBox.SelectedItem.Value];
            var creds = _credentialsManager.FindCredentials(_user, id, Path);
            WebsiteValue.Text = creds.Website;
            UrlValue.Text = creds.Url;
            UsernameValue.Text = creds.Username;
            EmailValue.Text = creds.EmailAddress;
            PasswordValue.Text = creds.Password;
        }

        protected void ShowPassword_Click(object sender, EventArgs e)
        {
            PasswordValue.Visible = !PasswordValue.Visible;
            ShowPasswordButton.Text = PasswordValue.Visible ? "Hide Password" : "Show Password";
        }
    }
}