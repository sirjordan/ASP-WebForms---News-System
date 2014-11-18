using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_System.Models
{
    [Serializable]
    [JsonObject]
    public class ArticleModel
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int ID { get; set; }
        public int? Likes { get; set; }
        public DateTime? PostDate { get; set; }
    }
}