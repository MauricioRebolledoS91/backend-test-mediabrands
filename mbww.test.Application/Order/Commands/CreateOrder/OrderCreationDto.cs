using MediatR;

namespace SalesDatePrediction.test.Application.Order.Commands.CreateOrder
{
    public class OrderCreationDto : IRequest<CreateOrderCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
