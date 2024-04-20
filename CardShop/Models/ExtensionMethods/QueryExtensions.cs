namespace CardShop.Models.ExtensionMethods
{
    public static class QueryExtensions
    {
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query,
            int pageSize, int pageNum)
        {
            return query.Skip((pageNum - 1) * pageSize)
                .Take(pageNum);
        }
    }
}
