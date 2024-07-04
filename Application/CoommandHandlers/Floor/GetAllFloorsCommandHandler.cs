namespace Application.CommandHandlers
{
    public class GetAllFloorsCommandHandler : IRequestHandler<GetAllFloorsCommand, IEnumerable<Floor>>
    {
        private readonly IFloorRepository _repository;

        public GetAllFloorsCommandHandler(IFloorRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Floor>> Handle(GetAllFloorsCommand command, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}