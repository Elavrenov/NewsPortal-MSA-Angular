using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Api.Publishers.Interfaces;

namespace NewsPortal.Api.Publishers.Controllers
{
    [Route("api/publishers")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublishersProvider _publishersProvider;

        public PublishersController(IPublishersProvider publishersProvider)
        {
            _publishersProvider = publishersProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetPublishersAsync()
        {
            var result = await _publishersProvider.GetPublishersAsync();

            if (result.IsSuccess)
            {
                return Ok(result.Publishers);
            }

            return NotFound();
        }
    }
}