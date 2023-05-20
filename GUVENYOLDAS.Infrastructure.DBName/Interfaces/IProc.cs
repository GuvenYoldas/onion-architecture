using GUVENYOLDAS.Core.DBName.Entities.Procedures;
using GUVENYOLDAS.Infrastructure.DBName.Interfaces.Base;

namespace GUVENYOLDAS.Infrastructure.DBName.Interfaces
{
    public interface IProc : IGeneric<ProcEntity, int>
    {
        IEnumerable<ProcEntity> procEntityList(string param1, int param2, byte param3);
    }
}
