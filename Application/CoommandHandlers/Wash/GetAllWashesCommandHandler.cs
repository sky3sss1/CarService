namespace Application.CommandHandlers
{
    public class GetAllWashesCommandHandler : IRequestHandler<GetAllWashesCommand, IEnumerable<Wash>>
    {
        private readonly IWashRepository _repository;

        public GetAllWashesCommandHandler(IWashRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Wash>> Handle(GetAllWashesCommand request, CancellationToken cancellationToken)
        {
            var washes = await _repository.GetAll();
            return washes;
        }
    }
}
