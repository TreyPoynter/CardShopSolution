using System.ComponentModel.DataAnnotations;

namespace CardShop.Models.Domain
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
