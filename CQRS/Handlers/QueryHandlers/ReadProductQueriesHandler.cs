using CQRS.Queries.Request;
using CQRS.Queries.Response;
using DataAccess;
using MediatR;
using Response;

namespace CQRS.Handlers.QueryHandlers
{

    public class ReadProductQueriesHandler : IRequestHandler<ReadProductQueriesRequest, ApiResponse<List<ReadProductQueriesResponse>>>
    {
        private readonly IProductRepository _productRepository;
        public ReadProductQueriesHandler(IProductRepository productRepository) =>
        _productRepository = productRepository;

        public async Task<ApiResponse<List<ReadProductQueriesResponse>>> Handle(ReadProductQueriesRequest request, CancellationToken cancellationToken) => 
        await _productRepository.GetAll();

    }

}