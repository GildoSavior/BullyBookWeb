using System.Linq.Expressions;
using BullyBookWeb.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BullyBookWeb.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal DbSet<T> dbSet;
        private readonly ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(string? includeProtperties = null)
        {
            IQueryable<T> query = dbSet;
            if (includeProtperties != null)
            {
                foreach (var includeProps in includeProtperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProps);
                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProtperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            if (includeProtperties != null)
            {
                foreach (var includeProps in includeProtperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProps);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}