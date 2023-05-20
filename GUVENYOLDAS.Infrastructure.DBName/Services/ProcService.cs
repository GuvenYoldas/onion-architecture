using GUVENYOLDAS.Core.DBName.Entities.Procedures;
using GUVENYOLDAS.Infrastructure.DBName.Interfaces;
using GUVENYOLDAS.Infrastructure.DBName.Interfaces.Base;
using GUVENYOLDAS.Infrastructure.DBName.Services.Base;


namespace GUVENYOLDAS.Infrastructure.DBName.Services
{
    public class ProcService : EntityService<ProcEntity, int>
    {
        IUnitOfWork _unitOfWork;
        IProc _procService;
        public ProcService(IUnitOfWork unitOfWork, IProc procRepository) : base(unitOfWork, procRepository)
        {
            _unitOfWork = unitOfWork;
            _procService = procRepository;
        }


        public IEnumerable<ProcEntity> procEntityList(string param1, int param2, byte param3)
        {
            return _procService.procEntityList(param1, param2, param3);
        }
    }
}
