using GUVENYOLDAS.Core.DBName.Configurations.Procedures;
using GUVENYOLDAS.Core.DBName.Configurations.Queries;
using GUVENYOLDAS.Core.DBName.Configurations.Tables;
using GUVENYOLDAS.Core.DBName.Entities.Procedures;
using GUVENYOLDAS.Core.DBName.Entities.Queries;
using GUVENYOLDAS.Core.DBName.Entities.Tables;
using Microsoft.EntityFrameworkCore;

namespace GUVENYOLDAS.Data.DBName
{
    public class DBNameDbContext : DbContext
    {
        public DBNameDbContext(DbContextOptions<DBNameDbContext> options) : base(options)
        {

        }

        #region |       DbSet Entity Classes        |

        public DbSet<ProcEntity> Proc { get; set; }
        public DbSet<QueryEntity> Query{ get; set; }
        public DbSet<TableEntity> Table { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region |       ModelBuilder Configuration      |

            modelBuilder.ApplyConfiguration(new ProcConfiguration());
            modelBuilder.ApplyConfiguration(new QueryConfiguration());
            modelBuilder.ApplyConfiguration(new TableConfiguration());

            #endregion


            var cascadeFks = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFks)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
