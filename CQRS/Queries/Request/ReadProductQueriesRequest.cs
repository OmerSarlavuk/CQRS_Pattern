using CQRS.Queries.Response;
using MediatR;

namespace CQRS.Queries.Request
{

    public class ReadProductQueriesRequest : IRequest<List<ReadProductQueriesResponse>>
    {

    }

}