using BullyBookWeb.Data.Repository.IRepository;

namespace BullyBookWeb.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category { get; private set; }
        public ICoverTpeRepository Cover { get; private set; }

        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Cover = new CoverTpeRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}