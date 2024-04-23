using CardShop.Data;
using Microsoft.EntityFrameworkCore;

namespace CardShop.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _context { get; set; }
        private DbSet<T> _dbSet { get; set; }

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> List(QueryOptions<T> options)
        {
            IQueryable<T> query = _dbSet;

            foreach (string include in options.GetIncludes())
            {
                query = query.Include(include);
            }
            if (options.HasWhere)
                query = query.Where(options.Where);
            if (options.HasOrderBy)
                query = query.OrderBy(options.OrderBy);
            if (options.HasPaging)
                query = query.Where(options.Where);

            return query.ToList();
        }

        public T? Get(int id) => _dbSet.Find(id);

        public void Add(T entity) => _dbSet.Add(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public void Save() => _context.SaveChanges();

        public IEnumerable<T> Search(params Func<T, bool>[] predicates)
        {
            IEnumerable<T> query = _dbSet;

            foreach (var predicate in predicates)
            {
                query = query.Where(predicate);
            }

            return query;
        }
    }
}
