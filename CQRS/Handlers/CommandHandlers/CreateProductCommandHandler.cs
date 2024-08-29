using CQRS.Commands.Request;
using CQRS.Commands.Response;
using MediatR;
using Models;

namespace CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellation) 
        {
            var id = Guid.NewGuid();
            ApplicationDbContext.ProductList.Add(
                new Product() {
                    Id = id,
                    Name = request.Name,
                    Quantity = request.Quantity,
                    Price = request.Price,
                    CreateTime = DateTime.Now
                }
            );

            return new CreateProductCommandResponse() {
                Id = id,
                IsSuccess = true
            };
        }
    }

}