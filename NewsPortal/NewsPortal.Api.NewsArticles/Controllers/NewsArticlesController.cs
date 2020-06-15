using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Api.NewsArticles.Interfaces;

namespace NewsPortal.Api.NewsArticles.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class NewsArticlesController : ControllerBase
    {
        private readonly INewsArticlesProvider _articlesProvider;

        public NewsArticlesController(INewsArticlesProvider articlesProvider)
        {
            _articlesProvider = articlesProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNewsArticlesAsync()
        {
            var result = await _articlesProvider.GetAllNewsArticlesAsync();

            if (result.IsSuccess)
            {
                return Ok(result.NewsArticles);
            }

            return NotFound();
        }

        [HttpGet("{publisherId}")]
        public async Task<IActionResult> GetNewsArticlesByPublisherIdAsync(string publisherId)
        {
            var result = await _articlesProvider.GetNewsArticlesByPublisherIdAsync(publisherId);

            if (result.IsSuccess)
            {
                return Ok(result.NewsArticles);
            }

            return NotFound();
        }
    }
}