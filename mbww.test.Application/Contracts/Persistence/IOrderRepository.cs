namespace SalesDatePrediction.test.Application.Contracts.Persistence
{
    public interface IOrderRepository
    {
        Task<List<SalesDatePrediction.test.Domain.Entities.Order>> GetOrderByCustomerId(int id);
        Task<SalesDatePrediction.test.Domain.Entities.Order> InsertOrder(SalesDatePrediction.test.Domain.Entities.Order order);
        Task<List<SalesDatePrediction.test.Domain.Entities.NextOrderPrediction>> GetNextOrderPrediction();
    }
}
