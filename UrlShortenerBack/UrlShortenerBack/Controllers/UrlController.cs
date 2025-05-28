using Microsoft.AspNetCore.Mvc;
using UrlShortenerBack.Dtos;
using UrlShortenerBack.Interfaces;
using UrlShortenerBack.Models;

namespace UrlShortenerBack.Controllers
{
    [Route("api/")]
    public class UrlController(ILogger<UrlController> logger, IUrlService urlService) : ControllerBase
    {
        [HttpPost]
        [Route("shorten/")]
        public ActionResult<CreatedUrl> Shorten([FromBody] string longUrl)
        {
            if (!longUrl.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase) &&
                !longUrl.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase))
            {
                logger.LogError("Error: The long URL must start with https:// or http://");
                return BadRequest("The long URL must start with https:// or http://");
            }

            return Ok(urlService.CreateUrl(longUrl));
        }

        [HttpGet]
        [Route("{shortUrl}")]
        public IActionResult RedirectUrl(string shortUrl)
        {
            if (shortUrl.Length != 8)
            {
                logger.LogError("The short url must be 8 characters long");
                return BadRequest("The short url must be 8 characters long");
            }

            var url = urlService.GetUrl(shortUrl);
            if (url == null)
            {
                logger.LogError("The short url is not found");
                return BadRequest("The short url is not found");
            }
            urlService.UpdateUrlCount(shortUrl);
            return Redirect(url.LongUrl);
        }

        [HttpGet]
        [Route("urls/")]
        public ActionResult<IEnumerable<Url>> GetAllUrls()
        {
            return new ActionResult<IEnumerable<Url>>(urlService.GetAllUrls()!);
        }

        [HttpGet]
        [Route("health/")]
        public IActionResult Health()
        {
            return Ok("Controller UP!!!");
        }
    }
}