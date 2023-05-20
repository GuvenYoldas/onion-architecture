using GUVENYOLDAS.Core.DBName.Entities.Tables;
using GUVENYOLDAS.Data.DBName;
using GUVENYOLDAS.Infrastructure.DBName.Interfaces;
using GUVENYOLDAS.Infrastructure.DBName.Repositories.Base;

namespace GUVENYOLDAS.Infrastructure.DBName.Repositories
{
    public class TableRepository : GenericRepository<TableEntity, int>, ITable
    {
        protected readonly DBNameDbContext _context;
        public TableRepository(DBNameDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
