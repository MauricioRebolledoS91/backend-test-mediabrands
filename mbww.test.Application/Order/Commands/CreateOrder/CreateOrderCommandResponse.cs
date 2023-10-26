using SalesDatePrediction.test.Application.Responses;

namespace SalesDatePrediction.test.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommandResponse : BaseResponse
    {
        public CreateOrderCommandResponse() : base()
        {

        }
        public OrderCreationDto User { get; set; }
    }
}
