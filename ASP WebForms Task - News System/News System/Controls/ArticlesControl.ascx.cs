using News_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News_System.Controls
{
    public partial class ArticlesControl : System.Web.UI.UserControl
    {
        public int Count { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<ArticleModel> GetArticles()
        {
            if (Count != 0)
            {
                return new Repository().GetAllArticles();
            }
            else
            {
                return new Repository().GetAllArticles().Take(Count);
            }
        }
    }
}