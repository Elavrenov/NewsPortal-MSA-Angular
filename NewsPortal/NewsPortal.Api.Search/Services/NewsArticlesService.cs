using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NewsPortal.Api.Search.Interfaces;
using NewsPortal.Api.Search.Models;

namespace NewsPortal.Api.Search.Services
{
    public class NewsArticlesService: INewsArticlesService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<NewsArticlesService> _logger;

        public NewsArticlesService(IHttpClientFactory clientFactory, ILogger<NewsArticlesService> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }
        public async Task<(bool IsSuccess, IEnumerable<NewsArticleModel> NewsArticles, string ErrorMessage)> SearchNewsArticlesByContentAsync(string queryString)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("NewsArticlesService");
                var response = await httpClient.GetAsync($"api/articles");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<NewsArticleModel>>(content, options).ToList();

                    queryString = queryString.ToLower();

                    var searchResult = result.Where(x => x.Content != null && x.Content.ToLower().Contains(queryString));
                    searchResult = searchResult.Any() ? searchResult : result.Where(x => x.Description != null && x.Description.ToLower().Contains(queryString));

                    return searchResult.Any()
                        ?  (true, searchResult, (string) null): (false, null, "Not Found");
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}