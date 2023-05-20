using GUVENYOLDAS.Core.DBName.Interfaces.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GUVENYOLDAS.Core.DBName.Entities.Base
{
    public abstract class BaseAuditableEntity : IBaseAuditable
    {
        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column("UPDATED_DATE")]
        public DateTime UpdatedDate { get; set; }
    }
}
