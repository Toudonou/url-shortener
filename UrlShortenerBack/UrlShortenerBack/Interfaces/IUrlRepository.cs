using UrlShortenerBack.Models;

namespace UrlShortenerBack.Interfaces
{
    public interface IUrlRepository
    {
        public IEnumerable<Url?> GetAllUrls();
        public Url? GetUrlByShort(string shortUrl);
        public Url? GetUrlByLong(string longUrl);

        public void UpdateUrlCount(string shortUrl);
        public void AddUrl(Url url);
    }
}