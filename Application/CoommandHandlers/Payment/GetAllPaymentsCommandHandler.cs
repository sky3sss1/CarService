namespace Application.CommandHandlers
{
    public class GetAllPaymentsCommandHandler : IRequestHandler<GetAllPaymentsCommand, IEnumerable<Payment>>
    {
        private readonly IPaymentRepository _repository;

        public GetAllPaymentsCommandHandler(IPaymentRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Payment>> Handle(GetAllPaymentsCommand command, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}