using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsPortal.Api.NewsArticles.Data
{
    public class NewsArticleSource
    {
        [Key]
        public int Uid { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<NewsArticle> NewsArticles { get; set; }
    }
}