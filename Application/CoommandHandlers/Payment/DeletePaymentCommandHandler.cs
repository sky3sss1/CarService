namespace Application.CommandHandlers
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, bool>
    {
        private readonly IPaymentRepository _repository;
        private readonly IMediator _mediator;

        public DeletePaymentCommandHandler(IPaymentRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(DeletePaymentCommand command, CancellationToken cancellationToken)
        {
            var payment = await _repository.GetById(command.Id);
            if (payment == null) return false;
            await _repository.Delete(payment);
            return true;
        }
    }
}