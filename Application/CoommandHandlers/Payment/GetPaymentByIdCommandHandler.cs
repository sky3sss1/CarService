namespace Application.CommandHandlers
{
    public class GetPaymentByIdCommandHandler : IRequestHandler<GetPaymentByIdCommand, Payment>
    {
        private readonly IPaymentRepository _repository;
        private readonly IMediator _mediator;

        public GetPaymentByIdCommandHandler(IPaymentRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Payment> Handle(GetPaymentByIdCommand command, CancellationToken cancellationToken)
        {
            return await _repository.GetById(command.Id);
        }
    }
}