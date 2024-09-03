using CQRS.Queries.Response;
using MediatR;
using Response;

namespace CQRS.Queries.Request
{

    public class ReadbyIdProductQueriesRequest : IRequest<ApiResponse<ReadbyIdProductQueriesResponse>>
    {
         public int Id { get; set; }
    }

}