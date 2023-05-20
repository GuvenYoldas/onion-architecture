using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GUVENYOLDAS.Data.DBName
{
    public class DBNameDbContextFactory : IDesignTimeDbContextFactory<DBNameDbContext>
    {
        public DBNameDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //TODO : if you have development/test/production settings
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT") ?? "Production"}.json", optional: true)
                .Build();

            var builder = new DbContextOptionsBuilder<DBNameDbContext>();
            var connectionString = configuration.GetConnectionString("YourDbConnection");

            builder.UseSqlServer(connectionString);
            return new DBNameDbContext(builder.Options);
        }
    }
}
