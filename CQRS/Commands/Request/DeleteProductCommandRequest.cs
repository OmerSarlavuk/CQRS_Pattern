using CQRS.Commands.Response;
using MediatR;

namespace CQRS.Commands.Request
{

    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public Guid Id { get; set; }
    }

}