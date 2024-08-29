using CQRS.Commands.Request;
using CQRS.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase 
    {

        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct([FromQuery] ReadProductQueriesRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetbyIdProduct([FromQuery] ReadbyIdProductQueriesRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromQuery] DeleteProductCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest request) 
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }

}