using CQRS.Queries.Request;
using CQRS.Queries.Response;
using DataAccess;
using MediatR;
using Response;

namespace CQRS.Handlers.QueryHandlers
{

    public class ReadbyIdProductQueriesHandler : IRequestHandler<ReadbyIdProductQueriesRequest, ApiResponse<ReadbyIdProductQueriesResponse>> 
    {
        private readonly IProductRepository _productRepository;
        public ReadbyIdProductQueriesHandler(IProductRepository productRepository) =>
        _productRepository = productRepository;

        public async Task<ApiResponse<ReadbyIdProductQueriesResponse>> Handle(ReadbyIdProductQueriesRequest request, CancellationToken cancellationToken) =>
        await _productRepository.GetbyId(request);

    }

}