using BullyBookWeb.Models;

namespace BullyBookWeb.Data.Repository.IRepository
{
    public interface ICoverTpeRepository : IRepository<CoverType>
    {
        void Update(CoverType obj);
    }
}