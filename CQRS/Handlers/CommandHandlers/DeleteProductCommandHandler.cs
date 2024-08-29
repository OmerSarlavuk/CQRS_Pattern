using CQRS.Commands.Request;
using CQRS.Commands.Response;
using MediatR;
using Models;

namespace CQRS.Handlers.CommandHandlers
{

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {

            var product = ApplicationDbContext.ProductList.Find(x => x.Id == request.Id);
            ApplicationDbContext.ProductList.Remove(product);

            return new DeleteProductCommandResponse() {
                IsSuccess = true
            };
        }

    }

}