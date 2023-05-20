using GUVENYOLDAS.Core.DBName.Entities.Tables;
using GUVENYOLDAS.Infrastructure.DBName.Interfaces;
using GUVENYOLDAS.Infrastructure.DBName.Interfaces.Base;
using GUVENYOLDAS.Infrastructure.DBName.Services.Base;


namespace GUVENYOLDAS.Infrastructure.DBName.Services
{
    public class TableService : EntityService<TableEntity, int>//, ITable -> I dont want to use Interface here
    {
        IUnitOfWork _unitOfWork;
        ITable _iTable;
        public TableService(IUnitOfWork unitOfWork, ITable tableRepository) : base(unitOfWork, tableRepository)
        {
            _unitOfWork = unitOfWork;
            _iTable = tableRepository;
        }
    }
}
