namespace CardShop.Areas.Admin.Models.ViewModels
{
    public class ManageVM<T> where T : class
    {
        public string Action { get; set; } = String.Empty;
        public T? Item { get; set; }
    }
}
