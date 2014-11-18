using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using News_System.Models;

namespace News_System
{
    public class Repository
    {
        private NewsSystemDataContext ctx;

        public Repository()
        {
            this.ctx = new NewsSystemDataContext();
        }
        public NewsSystemDataContext GetRepository
        {
            get
            {
                return this.ctx;
            }
        }

        public IQueryable<ArticleModel> GetPopularArticles
        {
            get
            {
                IQueryable<ArticleModel> Users_Article =
                    from a in ctx.Articles.OrderByDescending(ar => ar.Like.Value).Take(3)
                    join u in ctx.Users
                    on a.AuthorID equals u.UserID
                    select new ArticleModel()
                    {
                        Title = a.Title,
                        Author = u.Username,
                        Content = a.Content,
                        ID = a.ArticleID,
                        Category = a.Category.Name,
                        Likes = a.Like.Value,
                        PostDate = a.PostDate
                    };

                return Users_Article;
            }
        }

        public IQueryable<ArticleModel> GetAllArticles()
        {
            IQueryable<ArticleModel> Users_Article =
                    from a in ctx.Articles
                    join u in ctx.Users
                    on a.AuthorID equals u.UserID
                    select new ArticleModel()
                    {
                        Title = a.Title,
                        Author = u.Username,
                        Content = a.Content,
                        ID = a.ArticleID,
                        Category = a.Category.Name,
                        Likes = a.Like.Value,
                        PostDate = a.PostDate
                    };

            return Users_Article;
        }

        public void DeleteArticle(int? articleId)
        {
            Article articleToDelete = this.ctx.Articles.Where(a => a.ArticleID == articleId).FirstOrDefault();
            ctx.Articles.DeleteOnSubmit(articleToDelete);
            ctx.SubmitChanges();
        }

        public void AddNewArticle(Article article)
        {
            ctx.Articles.InsertOnSubmit(article);
            ctx.SubmitChanges();
        }

        public void UpdateArticle(Article article)
        {
            Article articleToUpdate = this.ctx.Articles.Where(a => a.ArticleID == article.ArticleID).FirstOrDefault();
            articleToUpdate.AuthorID = article.AuthorID;
            articleToUpdate.Category = article.Category;
            articleToUpdate.Content = article.Content;
            articleToUpdate.Title = article.Title;
            this.ctx.SubmitChanges();
        }

        public User RegisterUser(string username, string password)
        {
            if (username != null && password != null)
            {
                if (!UserExist(username))
                {
                    User newUser = new User() { Username = username, Password = password };
                    ctx.Users.InsertOnSubmit(newUser);
                    ctx.SubmitChanges();
                    return newUser;
                }
                else
                {
                    throw new ArgumentException("Username already exist");
                }
            }
            else
            {
                throw new ArgumentException("Invalid username/password");
            }
        }

        private bool UserExist(string username)
        {
            int foundedUser = this.ctx.Users.Where(u => u.Username == username).Count();
            if (foundedUser >=  1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User GetUser(string userName, string password)
        {
            List<User> users = this.ctx.Users.ToList();
            User user = users.Where(u => u.Username == userName && u.Password == password).FirstOrDefault();
            return user;
        }

        public int GetUserId(string userName)
        {
            List<User> users = this.ctx.Users.ToList();
            User user = users.Where(u => u.Username == userName).FirstOrDefault();
            return user.UserID;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = ctx.Categories.ToList();
            return categories;
        }

        public void LikeArticle(int id)
        {
            ctx.Articles.Where(a => a.ArticleID == id).First().Like.Value += 1;
            ctx.SubmitChanges();
        }

        public void AddNewCategory(Category category)
        {
            if (!(ctx.Categories.Contains(category)))
            {
                this.ctx.Categories.InsertOnSubmit(category);
                this.ctx.SubmitChanges();
            }
            else
            {
                throw new InvalidOperationException("Category already exist!");
            }
        }

        public void DeleteCategory(int? id)
        {
            Category categoryToDelete = this.ctx.Categories.Where(c => c.CategoryID == id).FirstOrDefault();
            this.ctx.Categories.DeleteOnSubmit(categoryToDelete);
            this.ctx.SubmitChanges();
        }

        public void UpdateCategory(Category category)
        {
            Category categoryToUpdate = this.ctx.Categories.Where(c => c.CategoryID == category.CategoryID).FirstOrDefault();
            categoryToUpdate.Name = category.Name;
            this.ctx.SubmitChanges();
        }
    }
}