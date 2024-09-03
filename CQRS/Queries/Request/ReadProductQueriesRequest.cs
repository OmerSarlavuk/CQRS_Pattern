using CQRS.Queries.Response;
using MediatR;
using Response;

namespace CQRS.Queries.Request
{

    public class ReadProductQueriesRequest : IRequest<ApiResponse<List<ReadProductQueriesResponse>>>
    {

    }

}