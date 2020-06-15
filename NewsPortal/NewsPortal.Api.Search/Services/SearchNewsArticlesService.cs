using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using NewsPortal.Api.Search.Interfaces;
using NewsPortal.Api.Search.Models;

namespace NewsPortal.Api.Search.Services
{
    public class SearchNewsArticlesService: ISearchService
    {
        private readonly INewsArticlesService _newsArticles;

        public SearchNewsArticlesService(INewsArticlesService newsArticles)
        {
            _newsArticles = newsArticles;
        }
        public async Task<(bool IsSuccess, dynamic SearchResults)> SearchAsync(string queryString)
        {
            var (isSuccess, newsArticles, _) = await _newsArticles.SearchNewsArticlesByContentAsync(queryString);

            newsArticles = isSuccess ? newsArticles : new List<NewsArticleModel>(){new NewsArticleModel()
            {
                Title = "Not found or this service is currently not available", 
                UrlToImage = "https://www.publicdomainpictures.net/pictures/280000/velka/not-found-image-15383864787lu.jpg"
            }};

            return (true, newsArticles);
        }
    }
}