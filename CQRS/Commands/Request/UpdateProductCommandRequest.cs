using CQRS.Commands.Response;
using MediatR;

namespace CQRS.Commands.Request
{

    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }

}