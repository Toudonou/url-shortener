using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using UrlShortenerBack.Dtos;
using UrlShortenerBack.Interfaces;
using UrlShortenerBack.Models;

namespace UrlShortenerBack.Controllers
{
    public class UrlController(ILogger<UrlController> logger, IUrlService urlService) : ControllerBase
    {
        public class UrlRequest
        {
            public string LongUrl { get; set; }
        }
        
        [HttpPost]
        [Route("shorten/")]
        public ActionResult<CreatedUrl> Shorten([FromBody] UrlRequest request)
        {
            if (!request.LongUrl.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase) &&
                !request.LongUrl.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase))
            {
                logger.LogError("Error: The long URL must start with https:// or http://");
                return BadRequest("The long URL must start with https:// or http://");
            }

            return Ok(urlService.CreateUrl(request.LongUrl));
        }

        [HttpGet]
        [Route("r/{shortUrl}")]
        public IActionResult RedirectUrl(string shortUrl)
        {
            if (shortUrl.Length != 8)
            {
                logger.LogError("The short url code must be 8 characters long");
                return BadRequest("The short url code must be 8 characters long");
            }

            var url = urlService.GetUrl(shortUrl);
            if (url.Result == null)
            {
                logger.LogError("The short url is not found");
                return NotFound("The short url is not found");
            }

            urlService.UpdateUrlCount(shortUrl);
            return Redirect(url.Result.LongUrl);
        }

        [HttpGet]
        [Route("urls/")]
        public Task<IEnumerable<Url?>> GetAllUrls()
        {
            return urlService.GetAllUrls();
        }

        [HttpGet]
        [Route("health/")]
        public IActionResult Health()
        {
            return Ok("Controller UP!!!");
        }
    }
}