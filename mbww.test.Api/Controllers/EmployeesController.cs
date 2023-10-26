using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.test.Application.Employee.Queries.GetEmployeeList;

namespace SalesDatePrediction.test.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployees()
        {
            var dtos = await _mediator.Send(new GetEmployeeListQuery());
            return Ok(dtos);
        }
    }
}
