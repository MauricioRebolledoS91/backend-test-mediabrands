using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.test.Infrastructure.Context;

namespace SalesDatePrediction.test.Api
{
    public class PersistenceContextFactory : IDesignTimeDbContextFactory<SalesDatePredictionTestDbContext>
    {
        public SalesDatePredictionTestDbContext CreateDbContext(string[] args)
        {
            var Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SalesDatePredictionTestDbContext>();
            optionsBuilder.UseSqlServer(Config.GetConnectionString("testDb"), sqlopts =>
            {
                sqlopts.MigrationsHistoryTable("_MigrationHistory", Config.GetValue<string>("SchemaName"));
            });

            return new SalesDatePredictionTestDbContext(optionsBuilder.Options);
        }
    }
}
