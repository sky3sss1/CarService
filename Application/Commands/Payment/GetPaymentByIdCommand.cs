namespace Application.Commands
{
    public class GetPaymentByIdCommand : IRequest<Payment>
    {
        public Guid Id { get; set; }
        public GetPaymentByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
