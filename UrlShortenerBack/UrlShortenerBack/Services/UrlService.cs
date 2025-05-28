using AutoMapper;
using UrlShortenerBack.Dtos;
using UrlShortenerBack.Interfaces;
using UrlShortenerBack.Models;

namespace UrlShortenerBack.Services
{
    public class UrlService(ILogger<UrlService> logger, IUrlRepository urlRepository, IMapper mapper) : IUrlService
    {
        private static string base62 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static int[] counters = [0, 0, 0, 0, 0, 0, 0, 0];

        public CreatedUrl CreateUrl(string longUrl)
        {
            var newUrl = urlRepository.GetUrlByLong(longUrl);
            if (newUrl == null)
            {
                newUrl = new Url
                {
                    ShortUrl = GenerateShortUrl(longUrl),
                    LongUrl = longUrl,
                    CreatedAt = DateTime.Now,
                    UsedCount = 0
                };
                urlRepository.AddUrl(newUrl);
            }

            return mapper.Map<CreatedUrl>(newUrl);
        }

        public Url? GetUrl(string shortUrl)
        {
            return urlRepository.GetUrlByShort(shortUrl);
        }

        public IEnumerable<Url?> GetAllUrls()
        {
            return urlRepository.GetAllUrls();
        }

        public void UpdateUrlCount(string shortUrl)
        {
            urlRepository.UpdateUrlCount(shortUrl);
        }

        private static string GenerateShortUrl(string longUrl)
        {
            for (ushort i = 0; i < 7; i++)
            {
                counters[i] = (counters[i + 1] / base62.Length) % base62.Length;
            }

            counters[7]++;

            return base62[counters[0]].ToString() + base62[counters[1]] +
                   base62[counters[2]] + base62[counters[3]] + base62[counters[4]] +
                   base62[counters[5]] + base62[counters[6]] + base62[counters[7]];
        }
    }
}