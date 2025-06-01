using AutoMapper;
using UrlShortenerBack.Dtos;
using UrlShortenerBack.Interfaces;
using UrlShortenerBack.Models;

namespace UrlShortenerBack.Services
{
    public class UrlService(ILogger<UrlService> logger, IUrlRepository urlRepository, IMapper mapper)
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
                    ShortUrl = GenerateShortUrl(),
                    LongUrl = longUrl,
                    CreatedAt = DateTime.Now,
                    UsedCount = 0
                };
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

        private string GenerateShortUrl()
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