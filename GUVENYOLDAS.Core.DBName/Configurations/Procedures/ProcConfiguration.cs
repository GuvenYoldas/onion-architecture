using GUVENYOLDAS.Core.DBName.Entities.Procedures;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GUVENYOLDAS.Core.DBName.Configurations.Procedures
{
    public class ProcConfiguration : IEntityTypeConfiguration<ProcEntity>
    {
        public void Configure(EntityTypeBuilder<ProcEntity> builder)
        {
            builder.HasNoKey();
        }
    }
}
