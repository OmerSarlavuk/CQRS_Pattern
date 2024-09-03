using CQRS.Commands.Request;
using CQRS.Commands.Response;
using CQRS.Queries.Request;
using CQRS.Queries.Response;
using Microsoft.EntityFrameworkCore;
using Models;
using Response;

namespace DataAccess
{

    public class ProductRepository : IProductRepository
    {

        private readonly CQRSPatternDataContext _context;

        public ProductRepository(CQRSPatternDataContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<CreateProductCommandResponse>> Create(CreateProductCommandRequest productCreateDto)
        {
            var product = new Product() { Name = productCreateDto.Name, Price = productCreateDto.Price, Quantity = productCreateDto.Quantity, CreateTime = DateTime.Now};
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return ApiResponse<CreateProductCommandResponse>.Success(data: new CreateProductCommandResponse() { Id = product.Id, IsSuccess = true}, statusCode: 200);
        }

        public async Task<ApiResponse<DeleteProductCommandResponse>> Delete(DeleteProductCommandRequest productDeleteDto)
        {
            var product = await _context.Product.FirstOrDefaultAsync(prd => prd.Id == productDeleteDto.Id);

            if(product == null)
            {
                return ApiResponse<DeleteProductCommandResponse>.Fail(400, "Product not found");
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return ApiResponse<DeleteProductCommandResponse>.Success(data: new DeleteProductCommandResponse() { IsSuccess = true}, statusCode: 200);
        }

        public async Task<ApiResponse<List<ReadProductQueriesResponse>>> GetAll()
        {
            
            var products = await _context.Product.ToListAsync();

            if(products.Count == 0) 
            {
                return ApiResponse<List<ReadProductQueriesResponse>>.Fail(400, "Products not list");
            }

            var productRepsonseList = new List<ReadProductQueriesResponse>();

            foreach(var product in products)
            {
                productRepsonseList.Add(new ReadProductQueriesResponse() {
                    Id = product.Id,
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    CreateTime = product.CreateTime
                });
            }

            return ApiResponse<List<ReadProductQueriesResponse>>.Success(data: productRepsonseList, statusCode: 200);
        }

        public async Task<ApiResponse<ReadbyIdProductQueriesResponse>> GetbyId(ReadbyIdProductQueriesRequest productReadbyIdDto)
        {
            var product = await _context.Product.FirstOrDefaultAsync(prd =>
            prd.Id == productReadbyIdDto.Id);

            if(product == null) 
            {
                return ApiResponse<ReadbyIdProductQueriesResponse>.Fail(400, "product not found");
            }

            return ApiResponse<ReadbyIdProductQueriesResponse>.Success(data: new ReadbyIdProductQueriesResponse() {
                Id = product.Id, Name = product.Name, Quantity = product.Quantity, Price = product.Price, CreateTime = product.CreateTime
            }, statusCode: 200);

        }

        public async Task<ApiResponse<UpdateProductCommandResponse>> Update(UpdateProductCommandRequest productUpdateDto)
        {
            var product = await _context.Product.FirstOrDefaultAsync(prd => 
            prd.Id == productUpdateDto.Id);

             if(product == null) 
            {
                return ApiResponse<UpdateProductCommandResponse>.Fail(400, "product not found");
            }

            // Update - process
            product.Id = productUpdateDto.Id;
            product.Name = productUpdateDto.Name;
            product.Price = productUpdateDto.Price;
            product.Quantity = productUpdateDto.Quantity;

             _context.Product.Update(product);
            await _context.SaveChangesAsync();

            return ApiResponse<UpdateProductCommandResponse>.Success(data: new UpdateProductCommandResponse() {
                Id = product.Id, IsSuccess = true
            }, statusCode: 200);
        }

    }

}