using CardShop.Models.Domain;

namespace CardShop.Areas.Admin.Models.ViewModels
{
    public class SearchVM<T> where T : class
    {
        public IEnumerable<T> Items { get; set; } = null!;
        public string? Search { get; set; }
    }
}
