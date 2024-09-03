using CQRS.Commands.Response;
using MediatR;
using Response;

namespace CQRS.Commands.Request
{

    public class UpdateProductCommandRequest : IRequest<ApiResponse<UpdateProductCommandResponse>>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }

}