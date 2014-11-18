using News_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace News_System.Controlers
{
    public class ArticlesController : ApiController
    {
        private Repository repository;

        public ArticlesController()
        {
            this.repository = new Repository();
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public ArticleModel Get(int id)
        {
            bool logged = HttpContext.Current.User.Identity.Name != null && HttpContext.Current.User.Identity.Name != string.Empty;
            if (logged)
            {
                return this.repository.GetPopularArticles.Where(am => am.ID == id).FirstOrDefault();
            }
            else
            {
                return null; 
            }
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            try
            {
                this.repository.LikeArticle(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict);
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }


    }
}