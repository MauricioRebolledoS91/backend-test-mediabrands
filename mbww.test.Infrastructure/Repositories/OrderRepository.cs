using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.test.Application.Contracts.Persistence;
using SalesDatePrediction.test.Domain.Entities;
using SalesDatePrediction.test.Infrastructure.Context;

namespace SalesDatePrediction.test.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        SalesDatePredictionTestDbContext _dbContext;
        public OrderRepository(SalesDatePredictionTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<NextOrderPrediction>> GetNextOrderPrediction()
        {
            int pageNumber = 1;
            int pageSize = 10;

            var results = _dbContext.NextOrderPrediction.FromSqlRaw("EXEC spCalculateNextOrderDate @p1,@p2",
                new SqlParameter("@p1", pageNumber),
                new SqlParameter("@p2", pageSize)).ToList();

            return Task.FromResult(results);
        }

        public Task<List<Order>> GetOrderByCustomerId(int id)
        {
            int pageNumber = 1; // Página actual
            int pageSize = 10;

            var orderList = _dbContext.Orders.Where(o => o.EmpId == id).Select(o => new Order()
            {
                OrderId = o.OrderId,
                ShipAddress = o.ShipAddress,
                ShipCity = o.ShipCity,
                ShipName = o.ShipName,
                ShippedDate = o.ShippedDate,
                RequiredDate = o.RequiredDate,
            })
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

            return orderList.ToListAsync();
        }

        public Task<Order> InsertOrder(Order order)
        {
            var result = _dbContext.Database.ExecuteSqlRaw(
                "execute spCreateOrder @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14",
            new SqlParameter("@p1", order.EmpId),
            new SqlParameter("@p2", order.ShipperId),
            new SqlParameter("@p3", order.ShipName),
            new SqlParameter("@p4", order.ShipAddress),
            new SqlParameter("@p5", order.ShipCity),
            new SqlParameter("@p6", order.OrderDate),
            new SqlParameter("@p7", order.RequiredDate),
            new SqlParameter("@p8", order.ShippedDate),
            new SqlParameter("@p9", order.Freight),
            new SqlParameter("@p10", order.ShipCountry),
            new SqlParameter("@p11", order.ProductId),
            new SqlParameter("@p12", order.UnitPrice),
            new SqlParameter("@p13", order.Qty),
            new SqlParameter("@p14", order.Discount)
);

            return Task.FromResult(order);
        }
    }
}
