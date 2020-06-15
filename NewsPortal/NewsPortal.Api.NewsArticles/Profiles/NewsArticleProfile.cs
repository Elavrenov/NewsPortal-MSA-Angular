using NewsPortal.Api.NewsArticles.Data;
using NewsPortal.Api.NewsArticles.Models;

namespace NewsPortal.Api.NewsArticles.Profiles
{
    public class NewsArticleProfile: AutoMapper.Profile
    {
        public NewsArticleProfile()
        {
            CreateMap<NewsArticleSource, NewsArticleSourceModel>();
            CreateMap<NewsArticle, NewsArticleModel>();
        }
    }
}