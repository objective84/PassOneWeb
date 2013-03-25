using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PassOne
{
    public partial class EditValue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("CredentialsList.aspx");
        }

        protected void NewValueTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}