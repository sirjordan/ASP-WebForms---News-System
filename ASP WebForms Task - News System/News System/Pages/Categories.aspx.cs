using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News_System.Pages
{
    public partial class Categories : System.Web.UI.Page
    {
        private Repository repo;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public Categories()
        {
            this.repo = new Repository();
        }

        public IQueryable<Category> GetCategories()
        {
            IEnumerable<Category> categories = this.repo.GetCategories().Where(c => c.Name != null).Distinct();
            return categories.AsQueryable();
        }

        public void InsertCategory()
        {
            Category newCategory = new Category();
            bool success = TryUpdateModel(newCategory, new FormValueProvider(ModelBindingExecutionContext));
            if (success)
            {
                try
                {
                    this.repo.AddNewCategory(newCategory);
                }
                catch (InvalidOperationException ex)
                {
                }
            }
        }

        public void DeleteCategory(int? categoryID)
        {
            this.repo.DeleteCategory(categoryID);
        }

        public void UpdateCategory(int categoryID)
        {
            Category category = new Category();
            bool success = TryUpdateModel(category, new FormValueProvider(ModelBindingExecutionContext));
            if (success)
            {
                category.CategoryID = categoryID;
                this.repo.UpdateCategory(category);
            }
        }
    }
}