using Microsoft.EntityFrameworkCore;
using UrlShortenerBack.DbContexts;
using UrlShortenerBack.Interfaces;
using UrlShortenerBack.Models;

namespace UrlShortenerBack.Repositories
{
    public class UrlRepository(UrlContext urlContext) : IUrlRepository
    {
        public async Task<IEnumerable<Url?>> GetAllUrls()
        {
            return await urlContext.Urls.ToListAsync();
        }

        public Task<Url?> GetUrlByShort(string shortUrl)
        {
            return urlContext.Urls.FirstOrDefaultAsync(x => x.Code == shortUrl);
        }

        public Task<Url?> GetUrlByLong(string longUrl)
        {
            return urlContext.Urls.FirstOrDefaultAsync(x => x.LongUrl == longUrl);
        }

        public void UpdateUrlCount(string shortUrl)
        {
            var url = GetUrlByShort(shortUrl).Result;
            if (url == null) return;
            url.UsedCount++;
            urlContext.SaveChangesAsync();
        }

        public void AddUrl(Url url)
        {
            urlContext.Urls.Add(url);
            urlContext.SaveChangesAsync();
        }
    }
}