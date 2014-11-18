using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Web.Security;
using News_System.Models;

namespace News_System.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        private Repository repository;
        private SessionHelper sessionHelper;

        protected void Page_Init(object sender, EventArgs ev)
        {
            this.categoryRepeater.ItemDataBound += (s, e) =>
            {
                Repeater innerRepeater = e.Item.FindControl("categoryLeatestPostTitles") as Repeater;
                string currentCat = ((Category)e.Item.DataItem).Name;
                IEnumerable<ArticleModel> articleByCategory = this.repository
                    .GetAllArticles()
                    .Where(c => c.Category == currentCat)
                    .OrderBy(ca => ca.PostDate)
                    .Take(3)
                    .ToList();
                innerRepeater.DataSource = articleByCategory;
                innerRepeater.DataBind();
            };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public Default()
        {
            this.repository = new Repository();
            this.sessionHelper = new SessionHelper();
        }

        public IEnumerable<ArticleModel> GetArticles()
        {
            return this.repository.GetPopularArticles;
        }

        public IEnumerable<Category> GetCategories()
        {
            return this.repository.GetCategories().Where(c => c.Name != null).Distinct();
        }
    }
}