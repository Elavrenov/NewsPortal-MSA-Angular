using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using NewsPortal.Api.NewsArticles.Data;
using NewsPortal.Api.NewsArticles.Interfaces;
using NewsPortal.Api.NewsArticles.Models;

namespace NewsPortal.Api.NewsArticles.Services
{
    public class NewsArticlesProvider: INewsArticlesProvider
    {
        private readonly NewsArticlesDbContext _dbContext;
        private readonly ILogger<INewsArticlesProvider> _logger;
        private readonly IMapper _mapper;

        public NewsArticlesProvider(NewsArticlesDbContext dbContext, ILogger<INewsArticlesProvider> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!_dbContext.NewsArticles.Any())
            {
                _dbContext.AddRange(InMemoryDataProvider.GetInMemoryDataNewsArticles());
                _dbContext.SaveChanges();
            }
        }
        public async Task<(bool IsSuccess, IEnumerable<NewsArticleModel> NewsArticles, string ErrorMessage)> GetAllNewsArticlesAsync()
        {
            try
            {
                var newsArticles = await _dbContext.NewsArticles.Include(x=> x.Source).ToListAsync();

                if (newsArticles != null && newsArticles.Any())
                {
                    var result = _mapper.Map<IEnumerable<NewsArticle>, IEnumerable<NewsArticleModel>>(newsArticles);
                    
                    return (true, result, null);
                }

                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());

                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<NewsArticleModel> NewsArticles, string ErrorMessage)> GetNewsArticlesByPublisherIdAsync(string publisherId)
        {
            try
            {
                var allArticles = await _dbContext.NewsArticles.Include(x => x.Source).ToListAsync();

                var articlesByPublisherId = allArticles.Where(x => x.Source.Id == publisherId);


                if (articlesByPublisherId.Any())
                {
                    var result = _mapper.Map<IEnumerable<NewsArticle>, IEnumerable<NewsArticleModel>>(articlesByPublisherId);

                    return (true, result, null);
                }

                return (false, null, "Not Found By Id");

            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());

                return (false, null, ex.Message);
            }
        }
    }
}