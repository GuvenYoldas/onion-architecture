using GUVENYOLDAS.Core.DBName.Entities.Procedures;
using GUVENYOLDAS.Data.DBName;
using GUVENYOLDAS.Infrastructure.DBName.Interfaces;
using GUVENYOLDAS.Infrastructure.DBName.Repositories.Base;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GUVENYOLDAS.Infrastructure.DBName.Repositories
{
    public class ProcRepository : GenericRepository<ProcEntity, int>, IProc
    {
        protected readonly DBNameDbContext _context;
        public ProcRepository(DBNameDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ProcEntity> procEntityList(string param1, int param2, byte param3)
        {
            SqlParameter sqlPrmUserRole = new SqlParameter("@param1", param1);
            SqlParameter sqlPrmDepartment = new SqlParameter("@param2", param2);
            SqlParameter sqlPrmProccess = new SqlParameter("@param3", param3);

            return _context.Proc.FromSqlRaw<ProcEntity>("EXEC [dbo].[DBName].[procProcedure] @param1, @param2, @param3", sqlPrmUserRole, sqlPrmDepartment, sqlPrmProccess).ToList();
        }
    }
}
