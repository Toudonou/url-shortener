using UrlShortenerBack.Dtos;
using UrlShortenerBack.Models;

namespace UrlShortenerBack.Interfaces
{
    public interface IUrlService
    {
        public CreatedUrl CreateUrl(string longUrl);
        public Url? GetUrl(string shortUrl);

        public void UpdateUrlCount(string shortUrl);
        public IEnumerable<Url?> GetAllUrls();
    }
}