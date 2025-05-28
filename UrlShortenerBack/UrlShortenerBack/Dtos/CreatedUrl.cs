using System.ComponentModel.DataAnnotations;

namespace UrlShortenerBack.Dtos
{
    public record CreatedUrl
    {
        [Key]
        [Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "ShortUrl must be exactly 8 characters.")]
        public required string ShortUrl { set; get; }

        [Required]
        [RegularExpression(@"^https?://", ErrorMessage = "URL must start with http:// or https://")]
        public required string LongUrl { set; get; }

        [Required] public required DateTime CreatedAt { set; get; }
    }
}