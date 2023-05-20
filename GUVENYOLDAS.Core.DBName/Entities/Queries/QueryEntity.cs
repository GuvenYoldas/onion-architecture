using GUVENYOLDAS.Core.DBName.Entities.Base;
using GUVENYOLDAS.Core.DBName.Interfaces.Queries;

namespace GUVENYOLDAS.Core.DBName.Entities.Queries
{
    public class QueryEntity : BaseEntity, IQuery
    {
        public QueryEntity()
        {
        }
        public string FullName { get; set; }
        public int Age { get; set; }
    }
}
