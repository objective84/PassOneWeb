using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PassOne.Business;

namespace PassOne.Forms
{
    public partial class CredentialsList : System.Web.UI.Page
    {
        public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\PassOne\\";
        private UserManager _userManager = new UserManager();
        private CredentialsManager _credentialsManager = new CredentialsManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            var tempList = CredentialsListBox.Items.Cast<string>().ToList();

            var credentialsList =
                _userManager.GetCredentialsList(_userManager.Authenticate("phowland", "otack0206", Path), Path);

            foreach (var key in credentialsList.Keys.Where(key => !tempList.Contains(key)))
                AddItemToCredentialsListBox(key);
            foreach (var item in tempList.Where(item => !credentialsList.ContainsKey(item)))
                RemoveItemFromCredentialsListBox(item);
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Server.Transfer("EditValue.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("NewCredentials.aspx");
        }

        protected void CredentialsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Method to add a new entry to the view's credentials listbox
        /// </summary>
        /// <param name="item">The credentials title to be added</param>
        public void AddItemToCredentialsListBox(string item)
        {
            CredentialsListBox.Items.Add(item);
        }

        /// <summary>
        /// Method to remove a credentials entry from the view's list box
        /// </summary>
        /// <param name="item">The credentials title to be removed</param>
        public void RemoveItemFromCredentialsListBox(string item)
        {
            CredentialsListBox.Items.Remove(item);
        }
    }
}