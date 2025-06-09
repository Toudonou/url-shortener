using Microsoft.EntityFrameworkCore;
using UrlShortenerBack.Models;

namespace UrlShortenerBack.DbContexts
{
    public class UrlContext(DbContextOptions<UrlContext> options) : DbContext(options)
    {
        public DbSet<Url> Urls { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Url>(entity =>
            {
                entity.ToTable("Urls");
                entity.Property(e => e.Code).HasColumnName("Code").IsRequired().HasColumnType("VARCHAR(8)");
                entity.Property(e => e.ShortUrl).HasColumnName("ShortUrl").IsRequired().HasColumnType("VARCHAR(100)");
                entity.Property(e => e.LongUrl).HasColumnName("LongUrl").IsRequired().HasColumnType("VARCHAR(100)");
                entity.Property(e => e.UsedCount).HasColumnName("UsedCount").HasColumnType("INTEGER");
                entity.Property(e => e.CreatedAt).HasColumnName("CreatedAt").IsRequired().HasColumnType("DATE");
            });
        }
    }
}