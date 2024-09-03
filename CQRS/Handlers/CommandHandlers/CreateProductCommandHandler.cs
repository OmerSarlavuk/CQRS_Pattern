using CQRS.Commands.Request;
using CQRS.Commands.Response;
using DataAccess;
using MediatR;
using Response;

namespace CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, ApiResponse<CreateProductCommandResponse>>
    {

        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository) =>
        _productRepository = productRepository;

        public async Task<ApiResponse<CreateProductCommandResponse>> Handle(CreateProductCommandRequest request, CancellationToken cancellation) =>
        await _productRepository.Create(request);
    }

}