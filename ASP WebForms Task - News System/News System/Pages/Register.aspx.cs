using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News_System.Pages
{
    public partial class LoginRegister : System.Web.UI.Page
    {
        private Repository repo;

        public LoginRegister()
        {
            this.repo = new Repository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string username = this.userName.Text;
                string password = this.password.Text;

                try
                {
                    User newUser = repo.RegisterUser(username, password);
                    FormsAuthentication.RedirectFromLoginPage(newUser.Username, true);
                }
                catch (ArgumentException ex)
                {
                    // Display user error msg;
                }
            }
        }
    }
}