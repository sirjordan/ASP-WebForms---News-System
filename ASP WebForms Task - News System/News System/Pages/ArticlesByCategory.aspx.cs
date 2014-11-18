using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News_System.Pages
{
    public partial class ArticlesByCategory : System.Web.UI.Page
    {
        protected string categoryString;
        protected Repository repo;

        protected void Page_Load(object sender, EventArgs e)
        {
            categoryString = Request.QueryString["Category"];
        }

        public ArticlesByCategory()
        {
            repo = new Repository();
        }
    }
}