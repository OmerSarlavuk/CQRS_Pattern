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
        public ProductsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAllProduct([FromQuery] ReadProductQueriesRequest request) => Ok(await _mediator.Send(request));

        [HttpGet("getById")]
        public async Task<IActionResult> GetbyIdProduct([FromQuery] ReadbyIdProductQueriesRequest request) => Ok(await _mediator.Send(request));

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromQuery] DeleteProductCommandRequest request) => Ok(await _mediator.Send(request));

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest request) => Ok(await _mediator.Send(request));

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommandRequest request) => Ok(await _mediator.Send(request));

    }

}