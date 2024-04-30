using System.ComponentModel.DataAnnotations;

namespace CardShop.Models.Domain
{
    public class Team
    {
        public int TeamId { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
