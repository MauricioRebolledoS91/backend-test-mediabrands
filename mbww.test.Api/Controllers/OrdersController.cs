using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.test.Application.Order.Commands.CreateOrder;
using SalesDatePrediction.test.Application.Order.Queries.GetNextOrderPredictionList;
using SalesDatePrediction.test.Application.Order.Queries.GetOrdersByCustomer;
using SalesDatePrediction.test.Domain.Entities;

namespace SalesDatePrediction.test.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetOrderListByCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<OrderListDto>>> GetOrderListByCustomer(int id)
        {
            var dtos = await _mediator.Send(new GetOrderByCustomerQuery() { CustomerId = id});
            return Ok(dtos);
        }

        [HttpGet("GetNextOrderPredicitonList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<NextOrderPrediction>>> GetNextOrderPredicitonList()
        {
            var dtos = await _mediator.Send(new GetNextOrderPredictionListQuery());
            return Ok(dtos);
        }

        [HttpPost("AddNewOrder")]
        public async Task<ActionResult<CreateOrderCommandResponse>> AddNewOrder([FromBody] CreateOrderCommand createOrderCommand)
        {
            var response = await _mediator.Send(createOrderCommand);
            return Ok(response);
        }
    }
}
