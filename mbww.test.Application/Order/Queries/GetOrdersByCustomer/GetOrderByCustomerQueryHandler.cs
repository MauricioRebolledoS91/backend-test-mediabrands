using AutoMapper;
using MediatR;
using SalesDatePrediction.test.Application.Contracts.Persistence;

namespace SalesDatePrediction.test.Application.Order.Queries.GetOrdersByCustomer
{
    public class GetOrderByCustomerQueryHandler : IRequestHandler<GetOrderByCustomerQuery, List<OrderListDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByCustomerQueryHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }
        public async Task<List<OrderListDto>> Handle(GetOrderByCustomerQuery request, CancellationToken cancellationToken)
        {
            var allOrdersByCustomerId = (await _orderRepository.GetOrderByCustomerId(request.CustomerId)).OrderBy(x => x.OrderId);
            return _mapper.Map<List<OrderListDto>>(allOrdersByCustomerId);
        }
    }
}
