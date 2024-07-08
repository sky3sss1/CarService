namespace Application.CommandHandlers
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, bool>
    {
        private readonly IPaymentRepository _repository;
        private readonly IMediator _mediator;

        public UpdatePaymentCommandHandler(IPaymentRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(UpdatePaymentCommand command, CancellationToken cancellationToken)
        {
            var payment = await _repository.GetById(command.Id);
            if (payment == null) return false;
            payment.FromStart = command.FromStart;
            payment.Tarif_Id = command.Tarif_Id;
            await _repository.Update(payment);
            return true;
        }
    }
}