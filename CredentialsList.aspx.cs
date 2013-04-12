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
        private PassOneUser _passOneUser;
        private UserManager _userManager = new UserManager();
        private CredentialsManager _credentialsManager = new CredentialsManager();
        private PassOneCredentials _selectedCredentials;
     

        protected void Page_Load(object sender, EventArgs e)
        {
            _passOneUser = (PassOneUser)Session["User"];
            if (IsPostBack) return;

            CredentialsListBox.SelectedIndexChanged += CredentialsListBox_SelectedIndexChanged;
            //UpdateListBox();

            if (CredentialsListBox.Items.Count <= 0) return;

            CredentialsListBox.SelectedIndex = 0;
            CredentialsListBox_SelectedIndexChanged(CredentialsListBox, null);
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Session["Edit"] = ((WebControl)sender).ID;
            var id = _userManager.GetCredentialsList(_passOneUser)[CredentialsListBox.SelectedItem.Value];
            Session["Credentials"] = _credentialsManager.FindCredentials((PassOneUser)Session["User"],id);
            Server.Transfer("EditValue.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("NewCredentials.aspx");
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            var creds = _credentialsManager.FindCredentials(_passOneUser,
                                                            _userManager.GetCredentialsList(_passOneUser)[
                                                                CredentialsListBox.SelectedItem.Value]);
            _credentialsManager.DeleteCredentials(creds, _passOneUser);
            Session["User"] = _passOneUser;
            UpdateListBox();
            ClearDetails();
        }

        public void UpdateListBox()
        {
            var tempList = (from ListItem item in CredentialsListBox.Items select item.Text).ToList();

            var credentialsList = _userManager.GetCredentialsList(_passOneUser);

            foreach (var key in credentialsList.Keys.Where(key => !tempList.Contains(key)))
                CredentialsListBox.Items.Add(key);
            foreach (var item in tempList.Where(item => !credentialsList.ContainsKey(item)))
                CredentialsListBox.Items.Remove(item);
        }

        public void ClearDetails()
        {
            //WebsiteValue.Text = string.Empty;
            //UrlValue.Text = string.Empty;
            //UsernameValue.Text = string.Empty;
            //EmailValue.Text = string.Empty;
            //PasswordValue.Text = string.Empty;
        }

        protected void CredentialsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //if (PasswordValue.Visible)
            //{
            //    PasswordValue.Visible = false;
            //    ShowPasswordButton.Text = "Show Password";
            //}
            //_passOneUser = (PassOneUser)Session["User"];
            //var id = _userManager.GetCredentialsList(_passOneUser)[CredentialsListBox.SelectedItem.Value];
            //_selectedCredentials = _credentialsManager.FindCredentials(_passOneUser, id);
            //WebsiteValue.Text = _selectedCredentials.Website;
            //UrlValue.Text = _selectedCredentials.Url;
            //UsernameValue.Text = _selectedCredentials.Username;
            //EmailValue.Text = _selectedCredentials.EmailAddress;
            //PasswordValue.Text = _selectedCredentials.Password;
            //DetailsView1.DataItem = 
        }

        protected void ShowPassword_Click(object sender, EventArgs e)
        {
            //PasswordValue.Visible = !PasswordValue.Visible;
            //ShowPasswordButton.Text = PasswordValue.Visible ? "Hide Password" : "Show Password";
        }
    }
}