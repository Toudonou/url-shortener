using System.ComponentModel.DataAnnotations;

namespace UrlShortenerBack.Dtos
{
    public record CreatedUrl
    {
        [Required]
        [RegularExpression(@"^https?://", ErrorMessage = "The ShortUrl must start with http:// or https://")]
        public required string ShortUrl { set; get; }

        [Required]
        [RegularExpression(@"^https?://", ErrorMessage = "The LongUrl must start with http:// or https://")]
        public required string LongUrl { set; get; }

        [Required] public required DateTime CreatedAt { set; get; }
    }
}