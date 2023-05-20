using GUVENYOLDAS.Core.DBName.Entities.Base;
using GUVENYOLDAS.Core.DBName.Interfaces.Procedures;

namespace GUVENYOLDAS.Core.DBName.Entities.Procedures
{
    public class ProcEntity : BaseEntity, IProc
    {
        public ProcEntity()
        {
        }
        public string FullName { get; set; }
        public int Age { get; set; }
    }
}
