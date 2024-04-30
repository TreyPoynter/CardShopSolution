using System.ComponentModel.DataAnnotations;

namespace CardShop.Models.Domain
{
    public class Sport
    {
        public int SportId { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
