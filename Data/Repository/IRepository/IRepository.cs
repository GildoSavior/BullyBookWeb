using System.Linq.Expressions;

namespace BullyBookWeb.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProtperties = null);
        IEnumerable<T> GetAll(string? includeProtperties = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}