using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;
using UrlShortenerBack.Dtos;
using UrlShortenerBack.Interfaces;
using UrlShortenerBack.Models;

namespace UrlShortenerBack.Services
{
    public class UrlService(
        ILogger<UrlService> logger,
        IHttpContextAccessor httpContextAccessor,
        IUrlRepository urlRepository,
        IMapper mapper)
        : IUrlService
    {
        private static readonly char[] Base62 =
            "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

        private static readonly Random Random = new();

        public CreatedUrl CreateUrl(string longUrl)
        {
            var newUrl = urlRepository.GetUrlByLong(longUrl).Result;
            if (newUrl == null)
            {
                newUrl = new Url
                {
                    Code = GenerateShortUrlCode(),
                    ShortUrl = "",
                    LongUrl = longUrl,
                    CreatedAt = DateTime.Now,
                    UsedCount = 0
                };

                var request = httpContextAccessor.HttpContext?.Request!;
                newUrl.ShortUrl = $"{request.Scheme}://{request.Host}/r/" + newUrl.Code; 

                urlRepository.AddUrl(newUrl);
            }

            return mapper.Map<CreatedUrl>(newUrl);
        }

        public Task<Url?> GetUrl(string shortUrl)
        {
            return urlRepository.GetUrlByShort(shortUrl);
        }

        public Task<IEnumerable<Url?>> GetAllUrls()
        {
            return urlRepository.GetAllUrls();
        }

        public void UpdateUrlCount(string shortUrl)
        {
            urlRepository.UpdateUrlCount(shortUrl);
        }

        private string GenerateShortUrlCode()
        {
            var shortUrl = string.Empty;

            Random.Shared.Shuffle(Base62);
            while (true)
            {
                while (shortUrl.Length < 8)
                {
                    var index = Random.Next(Base62.Length);
                    shortUrl += Base62[index];
                }

                if (GetUrl(shortUrl).Result == null) break;
            }

            return shortUrl;
        }
    }
}