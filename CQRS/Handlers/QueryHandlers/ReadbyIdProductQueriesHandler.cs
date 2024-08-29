using CQRS.Queries.Request;
using CQRS.Queries.Response;
using MediatR;
using Models;

namespace CQRS.Handlers.QueryHandlers
{

    public class ReadbyIdProductQueriesHandler : IRequestHandler<ReadbyIdProductQueriesRequest, ReadbyIdProductQueriesResponse> 
    {

        public async Task<ReadbyIdProductQueriesResponse> Handle(ReadbyIdProductQueriesRequest request, CancellationToken cancellationToken)
        {

            var product = ApplicationDbContext.ProductList.FirstOrDefault(x => x.Id == request.Id);
            return new ReadbyIdProductQueriesResponse() {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            };

        }

    }

}