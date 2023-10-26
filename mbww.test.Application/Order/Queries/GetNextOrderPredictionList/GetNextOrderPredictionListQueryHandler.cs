using MediatR;
using SalesDatePrediction.test.Application.Contracts.Persistence;
using SalesDatePrediction.test.Domain.Entities;

namespace SalesDatePrediction.test.Application.Order.Queries.GetNextOrderPredictionList
{
    public class GetNextOrderPredictionListQueryHandler: IRequestHandler<GetNextOrderPredictionListQuery, List<NextOrderPrediction>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetNextOrderPredictionListQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<NextOrderPrediction>> Handle(GetNextOrderPredictionListQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetNextOrderPrediction();
        }
    }
}
