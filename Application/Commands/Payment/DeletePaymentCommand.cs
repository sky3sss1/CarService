namespace Application.Commands
{
    public class DeletePaymentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeletePaymentCommand(Guid id)
        {
            Id = id;
        }
    }
}
