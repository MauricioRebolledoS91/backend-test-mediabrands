using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using mbww.test.Infrastructure.Context;

namespace mbww.test.Api
{
    public class PersistenceContextFactory : IDesignTimeDbContextFactory<MbwwTestDbContext>
    {
        public MbwwTestDbContext CreateDbContext(string[] args)
        {
            var Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MbwwTestDbContext>();
            optionsBuilder.UseSqlServer(Config.GetConnectionString("testDb"), sqlopts =>
            {
                sqlopts.MigrationsHistoryTable("_MigrationHistory", Config.GetValue<string>("SchemaName"));
            });

            return new MbwwTestDbContext(optionsBuilder.Options);
        }
    }
}
