using BullyBookWeb.Models;

namespace BullyBookWeb.Data.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
    }
}