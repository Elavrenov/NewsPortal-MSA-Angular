using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Api.Search.Interfaces;

namespace NewsPortal.Api.Search.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("{queryString}")]
        public async Task<IActionResult> SearchNewsArticlesAsync(string queryString)
        {
            var result = await _searchService.SearchAsync(queryString);

            if (result.SearchResults != null)
            {
                return Ok(result.SearchResults);
            }

            return NotFound();
        }
    }
}