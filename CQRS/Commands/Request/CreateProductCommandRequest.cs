using CQRS.Commands.Response;
using MediatR;
using Response;

namespace CQRS.Commands.Request 
{

    public class CreateProductCommandRequest : IRequest<ApiResponse<CreateProductCommandResponse>>
    {

        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }

}