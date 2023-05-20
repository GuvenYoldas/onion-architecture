using GUVENYOLDAS.Core.DBName.Entities.Queries;
using GUVENYOLDAS.Data.DBName;
using GUVENYOLDAS.Infrastructure.DBName.Interfaces;
using GUVENYOLDAS.Infrastructure.DBName.Repositories.Base;

namespace GUVENYOLDAS.Infrastructure.DBName.Repositories
{
    public class QueryRepository : GenericRepository<QueryEntity, int>, IQuery
    {
        protected readonly DBNameDbContext _context;
        public QueryRepository(DBNameDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
