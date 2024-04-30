using System.ComponentModel.DataAnnotations;

namespace CardShop.Models.Domain
{
    public class Quality
    {
        public int QualityId { get; set; }
        [Required]
        public string? Type { get; set; }
    }
}
