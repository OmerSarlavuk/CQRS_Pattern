using CQRS.Queries.Request;
using CQRS.Queries.Response;
using MediatR;
using Models;

namespace CQRS.Handlers.QueryHandlers
{

    public class ReadProductQueriesHandler : IRequestHandler<ReadProductQueriesRequest, List<ReadProductQueriesResponse>>
    {

        public async Task<List<ReadProductQueriesResponse>> Handle(ReadProductQueriesRequest request, CancellationToken cancellationToken)
        {
              return ApplicationDbContext.ProductList.Select(product => new ReadProductQueriesResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            }).ToList();
        }

    }

}