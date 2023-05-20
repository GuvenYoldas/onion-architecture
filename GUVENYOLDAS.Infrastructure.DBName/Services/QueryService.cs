using GUVENYOLDAS.Core.DBName.Entities.Queries;
using GUVENYOLDAS.Infrastructure.DBName.Interfaces;
using GUVENYOLDAS.Infrastructure.DBName.Interfaces.Base;
using GUVENYOLDAS.Infrastructure.DBName.Services.Base;

namespace GUVENYOLDAS.Infrastructure.DBName.Services
{
    public class QueryService : EntityService<QueryEntity, int>
    {
        IUnitOfWork _unitOfWork;
        IQuery _iQuery;
        public QueryService(IUnitOfWork unitOfWork, IQuery queryRepository) : base(unitOfWork, queryRepository)
        {
            _unitOfWork = unitOfWork;
            _iQuery = queryRepository;
        }
    }
}
