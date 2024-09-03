using CQRS.Commands.Request;
using CQRS.Commands.Response;
using DataAccess;
using MediatR;
using Response;

namespace CQRS.Handlers.CommandHandlers
{

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, ApiResponse<DeleteProductCommandResponse>>
    {

        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository) =>
        _productRepository = productRepository;

        public async Task<ApiResponse<DeleteProductCommandResponse>> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken) => 
        await _productRepository.Delete(request);

    }

}