using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullyBookWeb.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ICoverTpeRepository Cover { get; }
        void Save();
    }
}