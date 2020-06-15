using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace NewsPortal.Api.NewsArticles.Data
{
    public static class InMemoryDataProvider
    {
        private static int _i;
        private const string Path = @".\Data\NewsArticles.json";

        public static IEnumerable<NewsArticle> GetInMemoryDataNewsArticles()
        {
            var jsonString = File.ReadAllText(Path);

            var jArray = JArray.Parse(jsonString);

            IList<NewsArticle> articles = jArray.Select(j => new NewsArticle
            {
                Id = ++_i,
                Source = new NewsArticleSource()
                {
                    Uid = _i,
                    Id = (string)j["source"]?["id"],
                    Name =(string)j["source"]?["name"] 
                },
                Description = (string)j["description"],
                Author = (string)j["author"],
                Content = (string)j["content"],
                PublishedAt = (string)j["publishedAt"],
                Title = (string)j["title"],
                Url = (string)j["url"],
                UrlToImage = (string)j["urlToImage"]
            }).ToList();


            return articles;
        }
    }
}