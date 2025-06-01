using UrlShortenerBack.Dtos;
using UrlShortenerBack.Models;

namespace UrlShortenerBack.Interfaces
{
    public interface IUrlService
    {
        public CreatedUrl CreateUrl(string longUrl);
        public Task<Url?> GetUrl(string shortUrl);

        public void UpdateUrlCount(string shortUrl);
        public Task<IEnumerable<Url?>> GetAllUrls();
    }
}