namespace Application.CommandHandlers
{
    public class GetAllTarifsCommandHandler : IRequestHandler<GetAllTarifsCommand, IEnumerable<Tarif>>
    {
        private readonly ITarifRepository _repository;

        public GetAllTarifsCommandHandler(ITarifRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Tarif>> Handle(GetAllTarifsCommand request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}