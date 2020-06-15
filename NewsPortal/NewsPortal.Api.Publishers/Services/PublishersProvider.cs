using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewsPortal.Api.Publishers.Data;
using NewsPortal.Api.Publishers.Interfaces;
using NewsPortal.Api.Publishers.Models;

namespace NewsPortal.Api.Publishers.Services
{
    public class PublishersProvider: IPublishersProvider
    {
        private readonly PublishersDbContext _dbContext;
        private readonly ILogger<IPublishersProvider> _logger;
        private readonly IMapper _mapper;

        public PublishersProvider(PublishersDbContext dbContext, ILogger<IPublishersProvider> logger, IMapper mapper )
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!_dbContext.Publishers.Any())
            {
                _dbContext.Publishers.AddRange(InMemoryDataProvider.GetInMemoryDataPublishers());
                _dbContext.SaveChanges();
            }
        }
        public async Task<(bool IsSuccess, IEnumerable<PublisherModel> Publishers, string ErrorMessage)> GetPublishersAsync()
        {
            try
            {
                var publishers = await _dbContext.Publishers.ToListAsync();

                if (publishers != null && publishers.Any())
                {
                    var result= _mapper.Map<IEnumerable<Publisher>, IEnumerable<PublisherModel>>(publishers);

                    return (true, result, null);
                }

                return (false, null, "NotFound");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());

                return (false, null, ex.Message);
            }
        }
    }
}