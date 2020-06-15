using System.Threading.Tasks;

namespace NewsPortal.Api.Search.Interfaces
{
    public interface ISearchService
    {
        Task<(bool IsSuccess, dynamic SearchResults)> SearchAsync(string queryString);
    }
}