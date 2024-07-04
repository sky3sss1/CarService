namespace Application.CommandHandlers
{
    public class GetAllParkingsCommandHandler : IRequestHandler<GetAllParkingsCommand, IEnumerable<Parking>>
    {
        private readonly IParkingRepository _repository;

        public GetAllParkingsCommandHandler(IParkingRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Parking>> Handle(GetAllParkingsCommand command, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}