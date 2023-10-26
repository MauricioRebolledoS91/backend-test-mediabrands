using MediatR;

namespace SalesDatePrediction.test.Application.Order.Queries.GetOrdersByCustomer
{
    public class GetOrderByCustomerQuery : IRequest<List<OrderListDto>>
    {
        public int CustomerId { get; set; }
    
    }
}
