using BullyBookWeb.Models;

namespace BullyBookWeb.Data.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}