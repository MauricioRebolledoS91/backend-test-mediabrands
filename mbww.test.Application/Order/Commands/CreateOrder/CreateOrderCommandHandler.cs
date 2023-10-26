using AutoMapper;
using MediatR;
using SalesDatePrediction.test.Application.Contracts.Persistence;

namespace SalesDatePrediction.test.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, CreateOrderCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var createOrderCommandResponse = new CreateOrderCommandResponse();
            //var existUserName = await _userRepository.GetByUserNameAsync(request.UserName);
            //if (existUserName != null)
            //{
            //    createOrderCommandResponse.Success = false;
            //    createOrderCommandResponse.Message = "Este nombre de usuario ya está registrado";
            //    return createOrderCommandResponse;
            //}

            
            

            
            if (createOrderCommandResponse.Success)
            {
                var order = new Domain.Entities.Order()
                {
                    EmpId = request.EmployeId,
                    ShipAddress = request.ShipAddress,
                    ShipCity = request.ShipCity,    
                    ShipName = request.ShipName,    
                    ShippedDate = request.ShippedDate,
                    RequiredDate = request.RequiredDate,
                    ShipCountry = request.ShipCountry,
                    ShipperId = request.ShipperId,
                    Discount = request.Discount,
                    Freight = request.Freight,
                    OrderDate = request.OrderDate,
                    UnitPrice = request.UnitPrice,
                    ProductId = request.ProductId,
                    Qty = request.Qty,
                };
                order = await _orderRepository.InsertOrder(order);
                createOrderCommandResponse.User = _mapper.Map<OrderCreationDto>(order);
            }

            return createOrderCommandResponse;
        }
    }
}
