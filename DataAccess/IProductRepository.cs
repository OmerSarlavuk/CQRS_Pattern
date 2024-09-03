using CQRS.Commands.Request;
using CQRS.Commands.Response;
using CQRS.Queries.Request;
using CQRS.Queries.Response;
using Models;
using Response;

namespace DataAccess
{

    public interface IProductRepository
    {
        Task<ApiResponse<List<ReadProductQueriesResponse>>> GetAll();
        Task<ApiResponse<ReadbyIdProductQueriesResponse>> GetbyId(ReadbyIdProductQueriesRequest productReadbyIdDto);
        Task<ApiResponse<CreateProductCommandResponse>> Create(CreateProductCommandRequest productCreateDto);
        Task<ApiResponse<DeleteProductCommandResponse>> Delete(DeleteProductCommandRequest productDeleteDto);
        Task<ApiResponse<UpdateProductCommandResponse>> Update(UpdateProductCommandRequest productUpdateDto);
    }

}