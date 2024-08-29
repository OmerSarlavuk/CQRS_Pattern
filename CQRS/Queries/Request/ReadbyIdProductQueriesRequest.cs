using CQRS.Queries.Response;
using MediatR;

namespace CQRS.Queries.Request
{

    public class ReadbyIdProductQueriesRequest : IRequest<ReadbyIdProductQueriesResponse>
    {
         public Guid Id { get; set; }
    }

}