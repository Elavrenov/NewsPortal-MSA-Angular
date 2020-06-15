using System.Collections.Generic;
using System.Threading.Tasks;
using NewsPortal.Api.Publishers.Models;

namespace NewsPortal.Api.Publishers.Interfaces
{
    public interface IPublishersProvider
    {
        Task<(bool IsSuccess, IEnumerable<PublisherModel> Publishers, string ErrorMessage)> GetPublishersAsync();
    }
}