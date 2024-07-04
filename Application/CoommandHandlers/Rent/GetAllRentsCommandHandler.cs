namespace Application.CommandHandlers
{
    public class GetAllRentsCommandHandler : IRequestHandler<GetAllRentsCommand, IEnumerable<Rent>>
    {
        private readonly IRentRepository _repository;

        public GetAllRentsCommandHandler(IRentRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Rent>> Handle(GetAllRentsCommand command, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}