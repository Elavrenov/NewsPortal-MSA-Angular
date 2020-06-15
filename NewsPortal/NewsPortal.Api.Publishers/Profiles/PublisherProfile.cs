using NewsPortal.Api.Publishers.Data;
using NewsPortal.Api.Publishers.Models;

namespace NewsPortal.Api.Publishers.Profiles
{
    public class PublisherProfile: AutoMapper.Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherModel>();
        }
    }
}