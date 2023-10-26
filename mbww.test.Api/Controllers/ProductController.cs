using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.test.Application.Product.GetProductList;

namespace SalesDatePrediction.test.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            var dtos = await _mediator.Send(new GetProductListQuery());
            return Ok(dtos);
        }
    }
}
