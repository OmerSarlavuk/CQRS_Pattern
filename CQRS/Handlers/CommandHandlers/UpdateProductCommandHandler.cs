using CQRS.Commands.Request;
using CQRS.Commands.Response;
using MediatR;
using Models;

namespace CQRS.Handlers.CommandHandlers
{

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellation)
        {

            var product = ApplicationDbContext.ProductList.Find(x => x.Id == request.Id);
            product.Name = request.Name;
            product.Price = request.Price;
            product.Quantity = request.Quantity;

            return new UpdateProductCommandResponse() {
                Id = product.Id,
                IsSuccess = true
            };
        }

    }

}