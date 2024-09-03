using CQRS.Commands.Request;
using CQRS.Commands.Response;
using DataAccess;
using MediatR;
using Response;

namespace CQRS.Handlers.CommandHandlers
{

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, ApiResponse<UpdateProductCommandResponse>>
    {

        private readonly IProductRepository _productRespository;
        public UpdateProductCommandHandler(IProductRepository productRespository) => 
        _productRespository = productRespository;

        public async Task<ApiResponse<UpdateProductCommandResponse>> Handle(UpdateProductCommandRequest request, CancellationToken cancellation) =>
        await _productRespository.Update(request);

    }

}