using CardShop.Models.Attributes;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardShop.Models.Domain
{
    public class Card
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A Player is required")]
        public string? Player {  get; set; }
        [ValidateNever]
        public string Description { get; set; } = String.Empty;
        [Required(ErrorMessage = "A Price is required")]
        [Range(1.0d, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal? Price { get; set; }
        public bool IsForSale { get; set; } = true;
        [Required(ErrorMessage = "A Card Type is required")]
        public int? TypeId { get; set; }
        [ForeignKey(nameof(TypeId))]
        [ValidateNever]
        public CardType Type { get; set; }
        [Required(ErrorMessage = "A Card Number is required")]
        public uint? Number { get; set; }
        [ValidateNever]
        public string? ImageName { get; set; }
        [Required(ErrorMessage = "A Year is required")]
        [YearRange(1900)]
        public short? Year { get; set; }
        [Required(ErrorMessage = "Card Quality is required")]
        public int? QualityId { get; set; }
        [ForeignKey(nameof(QualityId))]
        [ValidateNever]
        public Quality Quality { get; set; }
        [Required(ErrorMessage = "Card Manufacturer is required")]
        public int? ManufactuererId { get; set; }
        [ForeignKey(nameof(ManufactuererId))]
        [ValidateNever]
        public Manufacturer Manufacturer { get; set; }
        [Required(ErrorMessage = "Card Sport is required")]
        public int? SportId { get; set; }
        [ForeignKey(nameof(SportId))]
        [ValidateNever]
        public Sport Sport { get; set; }
        public IEnumerable<Purchase> Purchases { get; set; }

        public Card()
        {
            Description = String.Empty;
            Purchases = new List<Purchase>();
        }
    }
}
