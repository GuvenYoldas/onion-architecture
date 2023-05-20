using GUVENYOLDAS.Core.DBName.Entities.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GUVENYOLDAS.Core.DBName.Configurations.Tables
{
    public class TableConfiguration : IEntityTypeConfiguration<TableEntity>
    {
        public void Configure(EntityTypeBuilder<TableEntity> builder)
        {
            builder.ToTable("DbTableName", "SchemaName");
            builder.HasKey(q => q.ID);
            //TODO : other options
            //builder.HasNoKey();
            //builder.HasKey(h => new { h.ID, h.FullName});
        }
    }
}
