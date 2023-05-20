using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GUVENYOLDAS.Core.DBName.Interfaces.Base;

namespace GUVENYOLDAS.Core.DBName.Entities.Base
{
    public abstract class BaseEntity : BaseAuditableEntity, IBase
    {
        [Key]
        [Column(name: "ID", Order = 0)]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ID { get; set; }
    }

    public abstract class BaseEntity<TKey> : BaseAuditableEntity, IBase<TKey>
    {
        [Key]
        [Column(name: "ID", Order = 0)]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TKey ID { get; set; }
    }
}
