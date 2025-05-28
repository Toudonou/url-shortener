using UrlShortenerBack.Interfaces;
using UrlShortenerBack.Models;

namespace UrlShortenerBack.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private static readonly List<Url?> Urls = [];

        public IEnumerable<Url?> GetAllUrls()
        {
            return Urls;
        }

        public Url? GetUrlByShort(string shortUrl)
        {
            return Urls.FirstOrDefault(url => url?.ShortUrl == shortUrl);
        }

        public Url? GetUrlByLong(string longUrl)
        {
            return Urls.FirstOrDefault(url => url?.LongUrl == longUrl);
        }

        public void UpdateUrlCount(string shortUrl)
        {
            GetUrlByShort(shortUrl)!.UsedCount++;
        }

        public void AddUrl(Url url)
        {
            Urls.Add(url);
        }
    }
}