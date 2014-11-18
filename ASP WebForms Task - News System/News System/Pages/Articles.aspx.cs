using News_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News_System.Pages
{
    public partial class Articles : System.Web.UI.Page
    {
        private Repository repository;
        protected bool IsInsertItem;

        public Articles()
        {
            this.repository = new Repository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<ArticleModel> GetArticles()
        {
            return this.repository.GetAllArticles().OrderBy(a => a.PostDate);
        }

        public void DeleteArticle(int? id)
        {
            this.repository.DeleteArticle(id);
        }

        public void UpdateArticle(int id)
        {
            Article myArticle = new Article();
            //this.repository.GetRepository.Articles.Where(p => p.ArticleID == id).FirstOrDefault();
            bool success = TryUpdateModel(myArticle, new FormValueProvider(ModelBindingExecutionContext));
            if (success)
            {
                this.repository.UpdateArticle(myArticle);
            }
        }

        public void InsertArticle()
        {
            Article newArticle = new Article();
            bool success = TryUpdateModel(newArticle, new FormValueProvider(ModelBindingExecutionContext));
            if (success)
            {
                newArticle.PostDate = DateTime.Now;
                int userId = repository.GetUserId(HttpContext.Current.User.Identity.Name);
                newArticle.AuthorID = userId;
                //var selectedCategory = Request["category"];
                newArticle.CategoryID = 1;
                
                this.repository.AddNewArticle(newArticle);
            }
        }

        protected List<Category> GetCategories()
        {
            List<Category> categories = this.repository.GetCategories().Where(c => c.Name != null).Distinct().ToList();
            return categories;
        }

        protected void articlesListView_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.InsertItem)
            {
                DropDownList ddl = (DropDownList)e.Item.FindControl("categoryList");
                if (ddl != null)
                {
                    ddl.DataSource = GetCategories();
                    ddl.DataTextField = "Name";
                    ddl.DataValueField = "CategoryID";
                    ddl.DataBind();

                }
            }
        }

    }
}