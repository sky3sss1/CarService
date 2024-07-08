namespace Application.CommandHandlers
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, bool>
    {
        private readonly IPaymentRepository _repository;
        private readonly IMediator _mediator;

        public CreatePaymentCommandHandler(IPaymentRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
        {
            var payment = new Payment(command.FromStart, command.Tarif_Id );
            await _repository.Add(payment);
            return true;
        }
    }
}