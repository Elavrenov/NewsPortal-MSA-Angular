using System.Collections.Generic;
using System.Threading.Tasks;
using NewsPortal.Api.NewsArticles.Models;

namespace NewsPortal.Api.NewsArticles.Interfaces
{
    public interface INewsArticlesProvider
    {
        Task<(bool IsSuccess, IEnumerable<NewsArticleModel> NewsArticles, string ErrorMessage)> GetAllNewsArticlesAsync();
        Task<(bool IsSuccess, IEnumerable<NewsArticleModel> NewsArticles, string ErrorMessage)> GetNewsArticlesByPublisherIdAsync(string publisherId);
    }
}