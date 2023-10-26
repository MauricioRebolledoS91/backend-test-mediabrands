using SalesDatePrediction.test.Application.Contracts.Persistence;
using SalesDatePrediction.test.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SalesDatePrediction.test.Infrastructure.Context;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace SalesDatePrediction.test.Infrastructure
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistence(this IServiceCollection svc, IConfiguration config)
        {
            svc.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            svc.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            svc.AddDbContext<SalesDatePredictionTestDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("testDb")));

            return svc;
        }
    }
}
