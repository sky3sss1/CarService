namespace Application.CommandHandlers
{
    public class GetAllCarsCommandHandler : IRequestHandler<GetAllCarsCommand, IEnumerable<Car>>
    {
        private readonly ICarRepository _repository;

        public GetAllCarsCommandHandler(ICarRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Car>> Handle(GetAllCarsCommand query, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}