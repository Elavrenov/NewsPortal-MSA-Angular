using System.Collections.Generic;
using System.Threading.Tasks;
using NewsPortal.Api.Search.Models;

namespace NewsPortal.Api.Search.Interfaces
{
    public interface INewsArticlesService
    {
        Task<(bool IsSuccess, IEnumerable<NewsArticleModel> NewsArticles, string ErrorMessage)> SearchNewsArticlesByContentAsync(string queryString);
    }
}