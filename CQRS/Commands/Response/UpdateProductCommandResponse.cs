namespace  CQRS.Commands.Response
{

    public class UpdateProductCommandResponse
    {

        public Guid Id { get; set; }
        public bool IsSuccess { get; set; }

    }
}