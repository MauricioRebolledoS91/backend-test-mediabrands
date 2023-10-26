using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.test.Application.Employee.Queries.GetEmployeeList;
using SalesDatePrediction.test.Application.Shippers.Queries.GetSshipperList;

namespace SalesDatePrediction.test.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippersController : Controller
    {
        private readonly IMediator _mediator;

        public ShippersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetShippers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ShipperDto>>> GetShippers()
        {
            var dtos = await _mediator.Send(new GetShipperListQuery());
            return Ok(dtos);
        }
    }
}
