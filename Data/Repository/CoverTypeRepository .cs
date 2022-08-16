using System.Linq.Expressions;
using BullyBookWeb.Data.Repository.IRepository;
using BullyBookWeb.Models;

namespace BullyBookWeb.Data.Repository
{
    public class CoverTpeRepository : Repository<CoverType>, ICoverTpeRepository
    {
        private readonly ApplicationDbContext _db;
        public CoverTpeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(CoverType obj)
        {
            _db.CoverTypes.Update(obj);
        }
    }
}