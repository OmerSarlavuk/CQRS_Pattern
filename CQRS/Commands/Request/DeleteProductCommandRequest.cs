using CQRS.Commands.Response;
using MediatR;
using Response;

namespace CQRS.Commands.Request
{

    public class DeleteProductCommandRequest : IRequest<ApiResponse<DeleteProductCommandResponse>>
    {
        public int Id { get; set; }
    }

}