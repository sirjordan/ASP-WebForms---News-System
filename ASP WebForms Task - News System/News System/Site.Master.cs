using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News_System
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private Repository repository;

        protected void Page_Load(object sender, EventArgs e)
        {
            bool logged = HttpContext.Current.User.Identity.Name != null && HttpContext.Current.User.Identity.Name != string.Empty;
            if (logged)
            {
                this.literalCurrentUser.Text = HttpContext.Current.User.Identity.Name;
                this.articles.Visible = true;
                this.literalLogOut.Visible = true;
                this.categories.Visible = true;
                this.loginRegisterPanel.Visible = false;
            }
            else
            {
                this.literalCurrentUser.Text = "Unregistered";
                this.literalLogOut.Visible = false;
                this.articles.Visible = false;
                this.categories.Visible = false;
                this.loginRegisterPanel.Visible = true;
            }
        }

        public Site()
        {
            this.repository = new Repository();
        }

        protected void linkbuttonRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void articles_Click(object sender, EventArgs e)
        {
            Response.Redirect("Articles.aspx");
        }

        protected void categories_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categories.aspx");
        }

        protected void literalLogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx");
        }

        protected void linkbuttonLogin_Click(object sender, EventArgs e)
        {
            string username = this.textboxUserName.Text;
            string password = this.textboxPassword.Text;
            bool rememberUser = this.rememberMe.Checked;

            try
            {
                User user = repository.GetUser(username, password);
                if (user != null)
                {
                    FormsAuthentication.RedirectFromLoginPage(user.Username, rememberUser);
                }
                else
                {
                    this.labelMgs.Text = "Invalid username/password";
                }
            }
            catch (ArgumentException ex)
            {
                this.labelMgs.Text = ex.Message;
            }
        }
    }
}