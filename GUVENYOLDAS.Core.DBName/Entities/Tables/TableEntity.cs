using GUVENYOLDAS.Core.DBName.Entities.Base;
using GUVENYOLDAS.Core.DBName.Interfaces.Tables;

namespace GUVENYOLDAS.Core.DBName.Entities.Tables
{
    public class TableEntity : BaseEntity, ITable
    {
        public TableEntity()
        {
        }
        public string FullName { get; set; }
        public int Age { get; set; }
    }
}
