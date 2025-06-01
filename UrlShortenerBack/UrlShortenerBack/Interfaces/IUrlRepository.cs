using UrlShortenerBack.Models;

namespace UrlShortenerBack.Interfaces
{
    public interface IUrlRepository
    {
        public Task<IEnumerable<Url?>> GetAllUrls();
        public Task<Url?> GetUrlByShort(string shortUrl);
        public Task<Url?> GetUrlByLong(string longUrl);

        public void UpdateUrlCount(string shortUrl);
        public void AddUrl(Url url);
    }
}