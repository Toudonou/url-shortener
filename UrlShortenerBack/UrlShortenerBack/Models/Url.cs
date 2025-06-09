using System.ComponentModel.DataAnnotations;

namespace UrlShortenerBack.Models
{
    public record Url
    {
        [Key]
        [Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "The code must be exactly 8 characters.")]
        public required string Code { set; get; }
        
        [Required]
        [RegularExpression(@"^https?://", ErrorMessage = "The ShortUrl must start with http:// or https://")]
        public required string ShortUrl { set; get; }

        [Required]
        [RegularExpression(@"^https?://", ErrorMessage = "The LongUrl must start with http:// or https://")]
        public required string LongUrl { set; get; }

        [Required] public required DateTime CreatedAt { set; get; }
        public uint UsedCount { set; get; } = 1;
    }
}