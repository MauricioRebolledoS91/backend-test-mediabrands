using mbww.test.Application.Contracts.Persistence;
using mbww.test.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using mbww.test.Infrastructure.Context;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace mbww.test.Infrastructure
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistence(this IServiceCollection svc, IConfiguration config)
        {
            svc.AddTransient(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            svc.AddDbContext<MbwwTestDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("testDb")));

            return svc;
        }
    }
}
