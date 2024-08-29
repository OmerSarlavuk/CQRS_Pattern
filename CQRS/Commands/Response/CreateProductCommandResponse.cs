namespace CQRS.Commands.Response
{

    public class CreateProductCommandResponse
    {
        public Guid Id { get; set; }
        public bool IsSuccess { get; set; }
    }

}

