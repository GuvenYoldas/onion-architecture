using GUVENYOLDAS.Core.DBName.Entities.Queries;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GUVENYOLDAS.Core.DBName.Configurations.Queries
{
    public class QueryConfiguration : IEntityTypeConfiguration<QueryEntity>
    {
        public void Configure(EntityTypeBuilder<QueryEntity> builder)
        {
            string sqlQuery = "SELECT A.NameAndSurname as FullName, A.Age as Age FROM dboSchema.DBName.TableName A";
            builder.ToSqlQuery(sqlQuery).HasNoKey();
        }
    }
}